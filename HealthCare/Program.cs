using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using HealthCare.Business;
using HealthCare.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSession();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
/*builder.Services.AddDbContext<HealthcareContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ClsPatientObjective")));*/

builder.Services.AddDbContext<HealthcareContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("ClsPatientObjective"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("ClsPatientObjective"))));

builder.Services.AddDbContext<HealthcareContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.LoginPath = "/LoginAuthentication/Login";
        option.ExpireTimeSpan = TimeSpan.FromHours(2);
    });



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();

//app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=LoginAuthentication}/{action=Login}/{id?}");

app.MapControllerRoute(
    name: "error",
    pattern: "/Error",
    defaults: new { controller = "Error", action = "Error" });

app.Run();
