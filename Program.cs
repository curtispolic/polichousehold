using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using polichousehold.Areas.Identity;
using polichousehold.Data;
using polichousehold.Services;
using Microsoft.Extensions.FileProviders;
using polichousehold.Repositories;
using polichousehold.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Authentication services
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Creates the Service and Context for Shopping database integration
builder.Services.AddDbContext<ShoppingContext>(options =>
{
    options.UseSqlite("Data Source = Shopping.db");
});
builder.Services.AddScoped<ShoppingService>();

// Image upload handling
builder.Services.AddTransient<IImageUploadRepository, ImageUploadRepository>();
builder.Services.AddTransient<IFileUploadService, FileUploadService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
// Testing APIs can be integrated in the IsDevelopment area
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

// Seed the database if the .db file doesn't exist.
app.CreateDbIfNotExists();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
