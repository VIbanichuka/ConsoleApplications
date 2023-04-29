using Calculations;
using SimpleCalculator.Web.Services;
using SimpleCalculator.Web.Services.Interfaces;
using SimpleCalculator.Web.Models;
using SimpleCalculator.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAddition, Addition>();
builder.Services.AddScoped<IDivision, Division>();
builder.Services.AddScoped<IMultiplication, Multiplication>();
builder.Services.AddScoped<ISubtraction, Subtraction>();
builder.Services.AddScoped<IPagingService<CalculationPageModel>, PagingService>();
builder.Services.AddScoped<ICalculationService<CalculationInputModel>, CalculationService>();
builder.Services.AddScoped<ICalculationResultsApiService, CalculationResultsApiService>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<CalculatorDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CalculatorConnectionString")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();