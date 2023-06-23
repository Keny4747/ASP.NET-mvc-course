using WebApplicationAPI.Models;
using WebApplicationAPI.Repository;
using WebApplicationAPI.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// add as service DBContext
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{

});

// add as services - all repositories
builder.Services.AddScoped<ILibroRepository, LibroRepository>();

// add as services - all unity works
builder.Services.AddScoped<ILibroService, LibroService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
