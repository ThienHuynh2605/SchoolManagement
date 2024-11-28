using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Domain.Interfaces.IServices;
using SchoolManagement.Infrastructure.Data;
using SchoolManagement.Infrastructure.Repositories;
using SchoolManagement.Application.Services;
using SchoolManagement.API.Middlewares;
using System.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using SchoolManagement.Application.Supports.Mappers;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.Supports.Validations;
using SchoolManagement.Application.DTOs.StudentDtos;
using SchoolManagement.Domain.IRepositories;
using SchoolManagement.Application.IServices;
//using Hellang.Middleware.ProblemDetails;

var builder = WebApplication.CreateBuilder(args);

// Add connection to DB
builder.Services.AddDbContext<SchoolDbContext>(Options =>
{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolContext"));
});

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(StudentMapping));
builder.Services.AddAutoMapper(typeof(GradeMapping));
builder.Services.AddAutoMapper(typeof(TeacherMapping));
builder.Services.AddAutoMapper(typeof(SubjectMapping));
builder.Services.AddAutoMapper(typeof(PrincipalMapping));

// Add Dependency Injection for Repositories
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IGradeRepository, GradeRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<IPrincipalRepository, PrincipalRepository>();

// Add Dependency Injection for Services
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IGradeService, GradeService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<IPrincipalService, PrincipalService>();

// Add Fluent Validation 
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<PeopleBaseDto>, PeopleBaseValidator<PeopleBaseDto>>();
builder.Services.AddScoped<IValidator<CreateStudentDto>, CreateStudentValidator>();
builder.Services.AddScoped<IValidator<UpdateStudentDto>, UpdateStudentValidator>();
builder.Services.AddScoped<IValidator<UpdateStudentPartialDto>, UpdateStudentPartialValidator>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Exception services
builder.Services.AddExceptionHandler<GlobalCustomExceptionHandlerMiddleware2>();
builder.Services.AddProblemDetails(options =>
{
    options.CustomizeProblemDetails = context =>
    {
        context.ProblemDetails.Instance =
            $"{context.HttpContext.Request.Method} {context.HttpContext.Request.Path}";

        Activity? activity = context.HttpContext.Features.Get<IHttpActivityFeature>()?.Activity;
        context.ProblemDetails.Extensions.TryAdd("traceId", activity?.Id);
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();
app.UseStatusCodePages();
app.UseHsts();

//app.UseMiddleware(typeof(GlobalExceptionHandlerMiddleware));
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
