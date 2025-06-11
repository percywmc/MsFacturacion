using FluentValidation.AspNetCore;
using MsFacturacion.Api.Application.Comprobantes.Validators;
using Microsoft.EntityFrameworkCore;
using MsFacturacion.Api.Application;
using MsFacturacion.Api.Application.Comprobantes;
using MsFacturacion.Api.Domain;
using MsFacturacion.Api.Infrastructure;
using MsFacturacion.Api.Infrastructure.Data;
using MsFacturacion.Api.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateComprobanteValidator>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MsFacturacionDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton<IGreetingRepository, InMemoryGreetingRepository>();
builder.Services.AddScoped<IGreetingService, GreetingService>();

builder.Services.AddScoped<IComprobanteRepository, ComprobanteRepository>();
builder.Services.AddScoped<IComprobanteService, ComprobanteService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
