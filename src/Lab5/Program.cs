using Itmo.ObjectOrientedProgramming.Lab5.Application;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Persistence;
using Lab5.Presentation.Http;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(new SystemPassword("YaAdmin228"));

builder.Services
    .AddApplication()
    .AddInfrastructurePersistence()
    .AddPresentationHttp();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();