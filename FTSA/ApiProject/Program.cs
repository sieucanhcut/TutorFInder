using Entities;
using Services;
using Microsoft.EntityFrameworkCore;
using NETCore.MailKit.Core;
using Repositories.Implements;
using Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Services.Implements;
using Services.Interfaces;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program)); 

// Configure Entity Framework
builder.Services.AddDbContext<TutorWebContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TutorWebDB")));

// Register repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICustomEmailService, CustomEmailService>();
builder.Services.AddScoped<ITutorAdvertisementRepository, TutorAdvertisementRepository>();
builder.Services.AddScoped<ITutorDetailsRepository, TutorDetailsRepository>();
builder.Services.AddScoped<ITutorDetailsService, TutorDetailsService>();
builder.Services.AddScoped<ITutorAdvertisementService, TutorAdvertisementService>();
// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:8080") // Update with your React app's URL
                          .AllowAnyMethod() // Allow all methods (GET, POST, PUT, DELETE, ...)
                          .AllowAnyHeader() // Allow all headers
                          .AllowCredentials()); // Allow cookies
});

// Configure cookie authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/api/account/login";
        options.LogoutPath = "/api/account/logout";
        options.SlidingExpiration = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Use CORS
app.UseCors("AllowSpecificOrigin");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();