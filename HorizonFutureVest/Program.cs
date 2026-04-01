using Persistence.Persistence;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<InvestmentAppContext>(opt => opt.UseSqlServer(connectionString));

// Configurar Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
})
.AddEntityFrameworkStores<InvestmentAppContext>()
.AddDefaultTokenProviders();

// Configurar redirecciones de login
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/Login";
});

builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IMacroIndicatorService, MacroIndicatorService>();
builder.Services.AddScoped<ICountryIndicatorService, CountryIndicatorService>();
builder.Services.AddScoped<IReturnRateConfigService, ReturnRateConfigService>();
builder.Services.AddScoped<IRankingService, RankingService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

// Crear usuario administrador inicial
using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

    string email = "admin@horizonfuturevest.com";
    string password = "Admin123!";

    var existingUser = await userManager.FindByEmailAsync(email);
    if (existingUser == null)
    {
        var user = new IdentityUser
        {
            UserName = email,
            Email = email,
            EmailConfirmed = true
        };
        await userManager.CreateAsync(user, password);
    }
}

app.Run();

