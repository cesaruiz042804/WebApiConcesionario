using Microsoft.EntityFrameworkCore;
using WebApiConcesionario.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // Generalmente necesario para Swagger
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext < DbConcesionarioContext >(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); // Esto mapea los enpoint
    app.UseSwagger(); // Habilita el middleware de Swagger
    app.UseSwaggerUI(); // Es para poder la parte visual de swagger
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


