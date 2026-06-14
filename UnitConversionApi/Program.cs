using FluentValidation;
using FluentValidation.AspNetCore;
using UnitConversionApi.Middleware;
using UnitConversionApi.Repositories;
using UnitConversionApi.Services;
using UnitConversionApi.Strategies;
using UnitConversionApi.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddValidatorsFromAssemblyContaining<
    ConversionRequestValidator>();

builder.Services.AddSingleton<IUnitRepository, InMemoryUnitRepository>();

builder.Services.AddScoped<IConversionService,
                           ConversionService>();

builder.Services.AddScoped<IConversionStrategy,
                           LengthConversionStrategy>();

builder.Services.AddScoped<IConversionStrategy,
                           WeightConversionStrategy>();

builder.Services.AddScoped<IConversionStrategy,
                           TemperatureConversionStrategy>();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();

public partial class Program
{
}
