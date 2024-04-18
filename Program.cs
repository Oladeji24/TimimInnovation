using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;
using System.Net.Mail;
using CloudinaryDotNet;
using TimimInnovation.Data;
using TimimInnovation.Email;

var builder = WebApplication.CreateBuilder(args);

// Load configuration
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add identity services
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()  // Add support for roles
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Add the email sender service
builder.Services.AddSingleton<SmtpClient>(new SmtpClient
{
    Host = configuration["EmailSettings:Host"],
    Port = int.Parse(configuration["EmailSettings:Port"]),
    Credentials = new NetworkCredential(configuration["EmailSettings:Username"], configuration["EmailSettings:Password"]),
    EnableSsl = bool.Parse(configuration["EmailSettings:EnableSsl"])
});

builder.Services.AddTransient<IEmailSender, EmailSender>();

builder.Services.AddRazorPages();

// Add session services
builder.Services.AddSession();

// Register Cloudinary as a service
Account account = new Account(
    configuration["Cloudinary:CloudName"],
    configuration["Cloudinary:ApiKey"],
    configuration["Cloudinary:ApiSecret"]
);
Cloudinary cloudinary = new Cloudinary(account);
builder.Services.AddSingleton(cloudinary);

var app = builder.Build();

// Create roles and assign user to Admin role
using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new[] { "Admin", "Agent", "Propertyloader" };

    foreach (var role in roles)
    {
        if (!roleManager.RoleExistsAsync(role).Result)
        {
            roleManager.CreateAsync(new IdentityRole(role)).Wait();
        }
    }

    var user = userManager.FindByEmailAsync("kabie17hp@gmail.com").Result;
    if (user == null)
    {
        var newUser = new IdentityUser
        {
            UserName = "kabie17hp@gmail.com",
            Email = "kabie17hp@gmail.com",
            EmailConfirmed = true
        };

        var result = userManager.CreateAsync(newUser, "lojuAla17tim06").Result;
        if (!result.Succeeded)
        {
            throw new Exception("Error creating user: " + string.Join(", ", result.Errors.Select(e => e.Description)));
        }

        user = newUser;
    }

    if (!userManager.IsInRoleAsync(user, "Admin").Result)
    {
        userManager.AddToRoleAsync(user, "Admin").Wait();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Use the session middleware
app.UseSession();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
