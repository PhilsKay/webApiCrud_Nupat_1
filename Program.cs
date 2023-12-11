using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using webApi_Nupat_1.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


string connectionKey = builder.Configuration.GetConnectionString("DataConnection") ?? "dhdhdh";

builder.Services.AddDbContext<DataContext>(options =>
options.UseMySql(connectionKey,
ServerVersion.AutoDetect(connectionKey)));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
