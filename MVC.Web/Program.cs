using Microsoft.EntityFrameworkCore;
using MVC.Web.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProductContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Default") ?? throw new InvalidOperationException("Connection string 'ProductContext' not found.")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

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
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();
