using Beamer_shop.Interfaces;
using Beamer_shop.Services;
using Data;
using Factory;
using Factory.Interfaces;
using Logic;
using Logic.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<ICarRepository, CarRepository>();
builder.Services.AddTransient<IAccessoryRepository, AccessoryRepository>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductFactory, ProductFactory>();
builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();

builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromHours(45);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;

});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login";
        options.AccessDeniedPath = "/Oops";
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
