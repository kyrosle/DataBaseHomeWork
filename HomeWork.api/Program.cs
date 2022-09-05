using HomeWork.api.Context;
using HomeWork.api.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyDbContext>(opt =>
{
    string connStr = builder.Configuration.GetConnectionString("MyDbContext");
    var serverVersion = ServerVersion.AutoDetect(connStr);
    opt.EnableSensitiveDataLogging(true);
    opt.UseMySql(connStr,serverVersion);
});
builder.Services.AddScoped<IDapperService, DapperService>();

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
