using Microsoft.EntityFrameworkCore;
using BaDongTourismWebsite.Entity.Entities;

namespace BaDongTourismWebsite.DAL.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    // DbSets
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Destination> Destinations { get; set; }
    public DbSet<DestinationImage> DestinationImages { get; set; }
    public DbSet<Tour> Tours { get; set; }
    public DbSet<TourDestination> TourDestinations { get; set; }
    public DbSet<TourSchedule> TourSchedules { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Accommodation> Accommodations { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Configure table names
        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<Role>().ToTable("Roles");
        modelBuilder.Entity<UserRole>().ToTable("UserRoles");
        modelBuilder.Entity<Category>().ToTable("Categories");
        modelBuilder.Entity<Destination>().ToTable("Destinations");
        modelBuilder.Entity<DestinationImage>().ToTable("DestinationImages");
        modelBuilder.Entity<Tour>().ToTable("Tours");
        modelBuilder.Entity<TourDestination>().ToTable("TourDestinations");
        modelBuilder.Entity<TourSchedule>().ToTable("TourSchedules");
        modelBuilder.Entity<Booking>().ToTable("Bookings");
        modelBuilder.Entity<Payment>().ToTable("Payments");
        modelBuilder.Entity<Review>().ToTable("Reviews");
        modelBuilder.Entity<Accommodation>().ToTable("Accommodations");
        modelBuilder.Entity<Restaurant>().ToTable("Restaurants");
        
        // Configure indexes for performance
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
        
        modelBuilder.Entity<Destination>()
            .HasIndex(d => d.Name);
        
        modelBuilder.Entity<Destination>()
            .HasIndex(d => d.Province);
        
        modelBuilder.Entity<Tour>()
            .HasIndex(t => t.StartDate);
        
        modelBuilder.Entity<Booking>()
            .HasIndex(b => b.BookingCode)
            .IsUnique();
        
        modelBuilder.Entity<Payment>()
            .HasIndex(p => p.TransactionId)
            .IsUnique();
        
        // Configure relationships
        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.RoleId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Destination>()
            .HasOne(d => d.Category)
            .WithMany(c => c.Destinations)
            .HasForeignKey(d => d.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<DestinationImage>()
            .HasOne(di => di.Destination)
            .WithMany(d => d.Images)
            .HasForeignKey(di => di.DestinationId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<TourDestination>()
            .HasOne(td => td.Tour)
            .WithMany(t => t.TourDestinations)
            .HasForeignKey(td => td.TourId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<TourDestination>()
            .HasOne(td => td.Destination)
            .WithMany(d => d.TourDestinations)
            .HasForeignKey(td => td.DestinationId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<TourSchedule>()
            .HasOne(ts => ts.Tour)
            .WithMany(t => t.TourSchedules)
            .HasForeignKey(ts => ts.TourId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Booking>()
            .HasOne(b => b.User)
            .WithMany(u => u.Bookings)
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Booking>()
            .HasOne(b => b.Tour)
            .WithMany(t => t.Bookings)
            .HasForeignKey(b => b.TourId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Payment>()
            .HasOne(p => p.Booking)
            .WithOne(b => b.Payment)
            .HasForeignKey<Payment>(p => p.BookingId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Review>()
            .HasOne(r => r.User)
            .WithMany(u => u.Reviews)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Review>()
            .HasOne(r => r.Tour)
            .WithMany(t => t.Reviews)
            .HasForeignKey(r => r.TourId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Review>()
            .HasOne(r => r.Destination)
            .WithMany(d => d.Reviews)
            .HasForeignKey(r => r.DestinationId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // Configure query filters for soft delete
        modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);
        modelBuilder.Entity<Destination>().HasQueryFilter(d => !d.IsDeleted);
        modelBuilder.Entity<Tour>().HasQueryFilter(t => !t.IsDeleted);
        modelBuilder.Entity<Booking>().HasQueryFilter(b => !b.IsDeleted);
    }
    
    public override int SaveChanges()
    {
        UpdateTimestamps();
        return base.SaveChanges();
    }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateTimestamps();
        return base.SaveChangesAsync(cancellationToken);
    }
    
    private void UpdateTimestamps()
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));
        
        foreach (var entry in entries)
        {
            var entity = (BaseEntity)entry.Entity;
            
            if (entry.State == EntityState.Added)
            {
                entity.CreatedDate = DateTime.UtcNow;
            }
            
            if (entry.State == EntityState.Modified)
            {
                entity.UpdatedDate = DateTime.UtcNow;
            }
        }
    }
}
