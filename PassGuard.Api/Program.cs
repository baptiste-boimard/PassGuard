using Microsoft.EntityFrameworkCore;
using PassGuard.Api.Repositories;
using PassGuard.Core.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Ajout des Controllers
builder.Services.AddControllers();

// Ajouts des Repositories
builder.Services.AddScoped<AuthRepository>();

// Service de la base de données
builder.Services.AddDbContext<PostgresDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresDBContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Mappage des controllers
app.MapControllers();

app.UseHttpsRedirection();

app.Run();
