using Microsoft.EntityFrameworkCore;
using SampleMVC.Repository;
using SampleMVC.Service;

var builder = WebApplication.CreateBuilder(args);

Environment.SetEnvironmentVariable("SqliteConnString", "Data Source=C:\\Users\\abhijadh\\Personal\\Projects\\SampleMVC\\SampleMVC.Repository\\CustomerInfo.db");
Environment.SetEnvironmentVariable("CloudName", "dxbgyhoiv");
Environment.SetEnvironmentVariable("ApiKey", "815353748693478");
Environment.SetEnvironmentVariable("ApiSecret", "baPJQYj6BYoxNfKwO8aHkMHDlRA");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IDapperContext>(new DapperContext());
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();

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
    pattern: "{controller=Customer}/{action=List}/{id?}");

app.Run();
