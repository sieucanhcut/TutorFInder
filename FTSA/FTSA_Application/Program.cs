using DataAccess.dbContext_Access;
using FluentEmail.Core;
using FluentEmail.Smtp;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Mail;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<TutorWebContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TutorWebDB")));

// Configure authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
        options.AccessDeniedPath = "/Account/AccessDenied";
    });

// Configure email service using FluentEmail and Gmail SMTP
builder.Services.AddFluentEmail("taiinu0126@gmail.com", "Tutor Finder")
    .AddRazorRenderer()
    .AddSmtpSender(new SmtpClient("smtp.gmail.com", 587)
    {
        Credentials = new NetworkCredential("taiinu0126@gmail.com", "sdgu ypqh ybmi cmqs"), 
        EnableSsl = true
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Enable authentication
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
