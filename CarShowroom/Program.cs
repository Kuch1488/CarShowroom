using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Showroom.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>(o => o.UseMySQL(builder.Configuration.GetConnectionString("BloggingDatabase")));

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

app.UseHttpsRedirection();
app.UseCors("MyPolicy");
app.UseAuthorization();
app.MapControllers();

app.Run();
