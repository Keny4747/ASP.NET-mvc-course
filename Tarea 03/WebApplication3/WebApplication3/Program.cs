using Microsoft.AspNetCore.Authentication.Cookies;
using WebApplication3.Models;
using WebApplication3.Repository;
using WebApplication3.Security;
using WebApplication3.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// add as service DBContext
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{

});

// add as services - all repositories
builder.Services.AddScoped<IVentaRepository, VentaRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRespository>();
builder.Services.AddScoped<IDetalleVentaRepository, DetalleVentaRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IRolRepository, RolRepository>();
builder.Services.AddScoped<IUsuarioRolRepository, UsuarioRolRepository>();

// add as service - authentication service
builder.Services.AddScoped<ICustomAuthenticationService, CustomAuthenticationService>();

// add as services - all unity works
builder.Services.AddScoped<IVentaService, VentaService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

// add authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    options.SlidingExpiration = true;
    options.AccessDeniedPath = "/Home/Forbidden";
    options.LoginPath = "/Login";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

// add use mode authentication
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
