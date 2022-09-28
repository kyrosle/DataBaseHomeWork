using HomeWork.api.Context;
using HomeWork.api.Service;
using HomeWork.Api.Service;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Database Conetext
builder.Services.AddDbContext<MyDbContext>(opt =>
{
    string connStr = builder.Configuration.GetConnectionString("MyDbContext");
    var serverVersion = ServerVersion.AutoDetect(connStr);
    opt.EnableSensitiveDataLogging(true);
    opt.UseMySql(connStr, serverVersion);
});

// Dapper for sql 
builder.Services.AddScoped<IDapperService, DapperService>();

// Mapster Config
var config = new TypeAdapterConfig();
config.Scan(Assembly.GetExecutingAssembly());
builder.Services.AddSingleton(config);
builder.Services.AddScoped<IMapper, ServiceMapper>();

builder.Services.AddTransient<IStaffServiece, StaffService>();
builder.Services.AddTransient<IPostService, PostService>();
builder.Services.AddTransient<IDepartmentService, DepartmentService>();
builder.Services.AddTransient<IStaffChangeService, StaffChangeService>();
builder.Services.AddTransient<IAttendanceService, AttendanceService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

