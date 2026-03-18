using BibliotekAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Sesija za čuvanje ulogovanog bibliotekara
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(8);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.SameSite = SameSiteMode.Lax;
});

// Singleton kontroler
builder.Services.AddSingleton<Kontroler>();

var app = builder.Build();

// Redosled middleware-a je bitan!
app.UseSession();

// Serve statičke fajlove (HTML, CSS, JS frontend)
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthorization();
app.MapControllers();

// Fallback na login stranicu
app.MapFallbackToFile("login.html");

app.Run();
