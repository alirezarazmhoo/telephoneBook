using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Telephonebook.Data;

using Telephonebook.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TelephonebookContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TelephonebookContext") ?? throw new InvalidOperationException("Connection string 'TelephonebookContext' not found.")));

// Add services to the container.
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
};

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.MapPersonEndpoints();

app.Run();
