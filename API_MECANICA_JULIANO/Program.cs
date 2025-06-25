using API_MECANICA_JULIANO.BaseDados;
using API_MECANICA_JULIANO.Mapping;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using API_MECANICA_JULIANO.BaseDados.Models;
using API_MECANICA_JULIANO.Services;
using API_MECANICA_JULIANO.Services.Validators;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddXmlSerializerFormatters();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddDbContext<TrabalhoMecanicaContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<VeiculoService>();
builder.Services.AddScoped<ClienteService>();
builder.Services.AddValidatorsFromAssemblyContaining<CriarClienteDTOValidator>();
builder.Services.AddScoped<ServicoService>();
builder.Services.AddScoped<ServicoRealizadoService>();
builder.Services.AddScoped<FuncionarioService>();
builder.Services.AddScoped<OrdemServicoService>();
builder.Services.AddAutoMapper(typeof(Program));





var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
