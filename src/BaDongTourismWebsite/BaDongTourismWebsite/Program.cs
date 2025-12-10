using Microsoft.EntityFrameworkCore;
using BaDongTourismWebsite.DAL.Data;
using BaDongTourismWebsite.DAL.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Add Session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // HTTPS only
});

// Configure HTTPS
builder.Services.AddHttpsRedirection(options =>
{
    options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
    options.HttpsPort = 7069;
});

// Add HSTS
builder.Services.AddHsts(options =>
{
    options.Preload = true;
    options.IncludeSubDomains = true;
    options.MaxAge = TimeSpan.FromDays(365);
});

// Add DbContext with PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("BaDongTourismWebsite")));

// Add Unit of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Add Services
builder.Services.AddScoped<BaDongTourismWebsite.BLL.Services.IAuthService, BaDongTourismWebsite.BLL.Services.AuthService>();
builder.Services.AddScoped<BaDongTourismWebsite.BLL.Services.IDestinationService, BaDongTourismWebsite.BLL.Services.DestinationService>();
builder.Services.AddScoped<BaDongTourismWebsite.BLL.Services.ITourService, BaDongTourismWebsite.BLL.Services.TourService>();
builder.Services.AddScoped<BaDongTourismWebsite.BLL.Services.IBookingService, BaDongTourismWebsite.BLL.Services.BookingService>();

// Add DbSeeder
builder.Services.AddScoped<DbSeeder>();

var app = builder.Build();

// Seed database
using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<DbSeeder>();
    await seeder.SeedAsync();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

// Always redirect HTTP to HTTPS
app.UseHttpsRedirection();

app.UseRouting();

app.UseSession();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
    .WithStaticAssets();

app.Run();