using Persistence.Persistence; 
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Registrar el DbContext con SQL Server
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<InvestmentAppContext>(opt => opt.UseSqlServer(connectionString) );

builder.Services.AddScoped<ICountryService, CountryService>();
builder.Services.AddScoped<IMacroIndicatorService, MacroIndicatorService>();
builder.Services.AddScoped<ICountryIndicatorService, CountryIndicatorService>();
builder.Services.AddScoped<IReturnRateConfigService, ReturnRateConfigService>();
builder.Services.AddScoped<IRankingService, RankingService>();


builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); 

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Ranking}/{action=Index}/{id?}");

app.Run();

