using BibliotekAPI;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Dodaj servise
builder.Services.AddControllers();

// Sesija za čuvanje ulogovanog bibliotekara
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(8);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// CORS - dozvoli zahteve sa frontend stranica
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

// Singleton kontroler — isto kao u desktop verziji
builder.Services.AddSingleton<Kontroler>();

var app = builder.Build();

app.UseSession();
app.UseCors("AllowAll");

// Serve statičke fajlove (HTML, CSS, JS frontend)
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthorization();
app.MapControllers();

// Fallback: sve nepoznate rute idu na index.html (SPA ponašanje)
app.MapFallbackToFile("index.html");

app.Run();
