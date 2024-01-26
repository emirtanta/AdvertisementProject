using AdvertisementProject.Business.DependencyResolvers.Microsoft;
using AdvertisementProject.Business.Helpers;
using AdvertisementProject.WebUI.Mappings.AutoMapper;
using AdvertisementProject.WebUI.Models;
using AdvertisementProject.WebUI.ValidationRules;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

DependencyExtension.AddDependencies(builder.Services, builder.Configuration);

builder.Services.AddTransient<IValidator<UserCreateModel>, UserCreateModelValidator>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opt =>
    {
        opt.Cookie.Name = "SiteCookie";
        opt.Cookie.HttpOnly = true;
        opt.Cookie.SameSite = SameSiteMode.Strict;
        opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
        opt.ExpireTimeSpan = TimeSpan.FromSeconds(5); //5 gün için cookie de durur
    });

var profiles=ProfileHelper.GetProfiles();
profiles.Add(new UserCreateModelProfile());
var configuration = new MapperConfiguration(opt =>
{
    opt.AddProfiles(profiles);
});

var mapper = configuration.CreateMapper();

builder.Services.AddSingleton(mapper);

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
