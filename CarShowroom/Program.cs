using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Showroom.Domain;
using Showroom.Domain.Entities.Interface;
using Showroom.Domain.Entitis.CarEntities.Interface;
using Showroom.Infrastructure.Helpers;
using Showroom.Infrastructure.Middleware;
using Showroom.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICarRepository, CarRepository>();


builder.Services.AddDbContext<Context>(o => o.UseMySql(builder.Configuration.GetConnectionString("BloggingDatabase"), 
    new MySqlServerVersion(new System.Version(8, 0, 22))));
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddControllers();
builder.Services.AddMvc();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Showroom",
        Description = "ASP.NET Core Web API"
    });
});

builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<JwtMiddleware>();
app.UseMiddleware<CustomExceptionHandlerMiddleware>();

app.UseHttpsRedirection();
app.UseCors("MyPolicy");
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();
