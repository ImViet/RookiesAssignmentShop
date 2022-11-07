using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.FileProviders;
using RAShop.CustomerSite.Interfaces;
using RAShop.CustomerSite.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//Cau hinh httpclient
builder.Services.AddHttpClient("myclient", client =>
{
    client.BaseAddress = new Uri("https://localhost:7150");
});
//Session
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "rookiesassignment";
    options.IdleTimeout = TimeSpan.FromSeconds(2000);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

//Interfaces
builder.Services.AddScoped<ICategory, CategoryService>();
builder.Services.AddScoped<IRating, RatingService>();
builder.Services.AddScoped<ISubCategory, SubCategoryService>();
builder.Services.AddScoped<IProduct, ProductService>();
builder.Services.AddScoped<ICart, CartService>();

//Razor Page
builder.Services.AddRazorPages()
    .AddRazorPagesOptions(options => {
        options.Conventions.AddPageRoute("/Home/Index", "");
    });
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

app.UseSession();
   app.UseEndpoints(endpoints =>
    {
        // Thêm endpoint chuyển đến các trang Razor Page
        // trong thư mục Pages
        endpoints.MapRazorPages();
    });
// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
