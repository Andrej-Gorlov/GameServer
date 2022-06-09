using AutoMapper;
using GameServer;
using GameServer.DAL;
using GameServer.DAL.Interfaces;
using GameServer.DAL.Repository;
using GameServer.Middleware.Extensions;
using GameServer.Service.Implementations;
using GameServer.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(connectionString));
// Add services to the container.

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<IServerRepository, ServerRepository>();

builder.Services.AddScoped<IServerService, ServerService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "GameServer",
        Description = "Web API GameServer.",
        TermsOfService = new Uri("https://yandex.ru"),
        Contact = new OpenApiContact
        {
            Name = "������ ������",
            Email = "avgorlov899@gmail.com",
            Url = new Uri("https://github.com/Andrej-Gorlov?tab=repositories")
        },
        License = new OpenApiLicense
        {
            Name = "��������...",
            Url = new Uri("https://yandex.ru")
        }
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseErrorHandlerMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
