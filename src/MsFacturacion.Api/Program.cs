using MsFacturacion.Api.Application;
using MsFacturacion.Api.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Registro de dependencias siguiendo la arquitectura limpia
builder.Services.AddSingleton<IComprobanteRepository, InMemoryComprobanteRepository>();
builder.Services.AddScoped<ComprobanteService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

