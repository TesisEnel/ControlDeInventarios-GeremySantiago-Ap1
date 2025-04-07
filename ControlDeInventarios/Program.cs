using ControlDeInventarios.Components;
using ControlDeInventarios.DAL;
using ControlDeInventarios.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Agrega autenticación con cookies
builder.Services.AddAuthentication("Cookies")
    .AddCookie("Cookies", options =>
    {
        options.LoginPath = "/Autenticacion/Login";
        options.AccessDeniedPath = "/Autenticacion/Denegado";
    });
builder.Services.AddAuthorization();


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//Obtenemos el ConStr para usarlo en el contexto
var ConStr = builder.Configuration.GetConnectionString("DefaultConnection");

//Agregamos el contexto al builder con el ConStr
builder.Services.AddDbContextFactory<Contexto>(o => o.UseSqlServer(ConStr));

builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<ProductosService>();
builder.Services.AddScoped<CategoriaService>();
builder.Services.AddScoped<EntradaService>();
builder.Services.AddScoped<SalidaService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<CustomAuthProvider>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();


var app = builder.Build();

// Habilita autenticación y autorización
app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
