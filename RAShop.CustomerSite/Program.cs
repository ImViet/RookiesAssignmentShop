using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.FileProviders;
using RAShop.CustomerSite.Interfaces;
using RAShop.CustomerSite.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
     .AddRazorOptions(options =>
     {
         options.ViewLocationFormats.Add("/Views/Shared/Components/");
     }); ;

//Cau hinh httpclient
builder.Services.AddHttpClient("myclient", client =>
{
    client.BaseAddress = new Uri("https://localhost:7150");
});
builder.Services.AddScoped<ICategory, CategoryService>();
builder.Services.AddScoped<IProduct, ProductService>();
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
