using Catalogo_API.Context;
using Catalogo_API.DTOs.Mappings;
using Catalogo_API.Filters;
using Catalogo_API.Logging;
using Catalogo_API.Repositories;
using Catalogo_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ApiLoggingFilter>();
    options.Filters.Add<ApiExceptionFilter>();
})
.AddJsonOptions(options =>
    options.JsonSerializerOptions
        .ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

string? mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<CatalogoDbContext>(options =>
                        options.UseMySql(mySqlConnection, 
                        ServerVersion.AutoDetect(mySqlConnection)));

builder.Services.AddScoped<ApiLoggingFilter>();

builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Logging.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfiguration
{
    LogLevel = LogLevel.Information
}));

builder.Services.AddAutoMapper(typeof(CatalogoDTOMappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
        options.SwaggerEndpoint("/openapi/v1.json", "catalogo api"));

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
