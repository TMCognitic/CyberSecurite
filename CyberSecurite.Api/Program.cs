using Tools.Cqs.Commands;
using Tools.Cqs.Queries;
using CyberSecurite.Domain.Commands;
using CyberSecurite.Domain.Entities;
using CyberSecurite.Domain.Queries;
using Microsoft.Data.SqlClient;
using Scalar.AspNetCore;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<DbConnection>(sp => new SqlConnection(config.GetConnectionString("Default")));
builder.Services.AddScoped<IQueryHandler<LoginQuery, Utilisateur>, LoginQueryHandler>();
builder.Services.AddScoped<ICommandHandler<RegisterCommand>, RegisterCommandHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
#region Hidden
//if(app.Environment.IsDevelopment())
//{

//}
#endregion

app.MapOpenApi();
app.MapScalarApiReference();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
