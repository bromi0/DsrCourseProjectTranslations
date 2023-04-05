using DSRCourseProject.Api.Configuration;
using DsrCourseProjectTranslations.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

// Add services to the container.

services.AddControllers();
services.AddDbContext<MainDbContext>(
	   options => options.UseSqlServer(
		   builder.Configuration.GetConnectionString("MainContext")));

// Logging

builder.AddAppLogger();

services.AddHttpContextAccessor();
services.AddAppCors();
services.AddAppHealthChecks(builder.Configuration);

services.AddAppVersioning();

// Swagger

builder.Services.AddAppSwagger();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAppCors();
app.UseAppHealthChecks();


if (app.Environment.IsDevelopment())
{
	app.UseAppSwagger();
}

app.MapControllers();

app.Run();
