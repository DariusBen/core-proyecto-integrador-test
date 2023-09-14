using Microsoft.Extensions.Configuration;
using TPIIntegrador.API.Configuracion;

var builder = WebApplication.CreateBuilder(args);


builder.Services.ConfigurarControllers();

builder.Services.AgregarContextoBaseDeDatos(builder.Configuration);

builder.Services.ConfigurarIdentity();

builder.Services.AgregarValidadores();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.InyectarDependencias();

builder.Services.AgregarCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Politicas");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
