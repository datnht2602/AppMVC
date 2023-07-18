using System.Text.RegularExpressions;
using System.Net;
using System;
using AppMVC.Services;
using Microsoft.AspNetCore.Mvc.Razor;
using AppMVC.ExtendMethods;
using Microsoft.AspNetCore.Routing.Constraints;
using AppMVC.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.Configure<RazorViewEngineOptions>(options =>
{ options.ViewLocationFormats.Add("MyViews/{1}/{0}" + RazorViewEngine.ViewExtension);
});
builder.Services.AddSingleton<ProductService>();
builder.Services.AddSingleton(typeof(PlanetService));
builder.Services.AddDbContext<ApplicationDBContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDBContext")));
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
app.AddStatusCodePage();
app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/sayhi", async(context) =>{
        await context.Response.WriteAsync($"Hello Asp.Net MVC {DateTime.Now}");
    });
});
app.MapControllerRoute(
    name: "first",
    pattern: "{url:regex(^((xemsanpham)|(viewproduct))$)}/{id:range(1,3)}",
    defaults: new{
        controller = "First",
        action = "ViewProduct"
    }
    // constraints: new {
    //     // url = new StringRouteConstraint("xemsanpham"),
    //     // url = new RegexRouteConstraint(@"^((xemsanpham)|(viewproduct))$"),
    //     // id = new RangeRouteConstraint(1,3)
    // }
);
app.MapControllerRoute(
    name: "defaults",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);
app.MapAreaControllerRoute(
    name: "product",
    pattern :"{controller}/{action=Index}/{id?}",
    areaName: "ProductManage"
);
app.MapRazorPages();
app.Run();
