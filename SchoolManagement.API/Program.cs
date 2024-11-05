using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.Mappers;
using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Domain.Interfaces.IServices;
using SchoolManagement.Infrastructure.Data;
using SchoolManagement.Infrastructure.Repositories;
using SchoolManagement.Application.Services;
using SchoolManagement.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<SchoolDbContext>(Options =>
{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolContext"));
});

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(StudentMapping));

// Add Dependency Injection
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware(typeof(GlobalExceptionHandlerMiddleware));
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
