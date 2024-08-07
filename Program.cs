using System.Reflection;
using dotnetmediatrdemo.Data;
using dotnetmediatrdemo.Models;
using dotnetmediatrdemo.Repositories.Interfaces;
using dotnetmediatrdemo.Repositories.Student;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddDbContext<DataContext>(ctx =>
{
    ctx.UseSqlite(builder.Configuration["ConnectionStrings:Default"]);
});
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.MapDefaultControllerRoute();


app.Run();

