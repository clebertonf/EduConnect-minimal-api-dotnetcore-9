using EduConnect.API.Context;
using EduConnect.API.Extensions;
using EduConnect.API.Profiles;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add db context EF core
builder.Services.AddDbContext<ApplicationDbContext>(configuration =>
{
    configuration.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Swagger config
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add AutoMapper
builder.Services.AddAutoMapper(typeof(EduConnectProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Register endpoints
app.RegisterAddressEndpoints();
app.RegisterCourseEndpoints();
app.RegisterEnrollmentEndpoints();
app.RegisterStudentEndpoints();

app.Run();