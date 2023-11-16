using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using MySqlConnector;
using TesteTecnicoBHS.Domain.Interfaces;
using TesteTecnicoBHS.Infrastructure.Data.Context;
using TesteTecnicoBHS.Services.Repositories;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "APItesteBHs", Description = "Desafio BHs", Version = "v1" });
});

string mySqlConnection =
              builder.Configuration.GetConnectionString("SQLConnection");

services.AddDbContext<TesteBHSContext>(options =>
    options.UseMySql(mySqlConnection,
                      ServerVersion.AutoDetect(mySqlConnection)));

//injeção de dependencias

services.AddScoped<IProdutoRepositoy, ProdutoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "APItesteBHs v1");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
