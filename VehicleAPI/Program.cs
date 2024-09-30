using Microsoft.Extensions.Configuration;
using VehicleAPI.Configurations;
using VehicleAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<VehicleService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();
// Bind ApiSettings from appsettings.json
builder.Services.Configure<ApiUrls>(builder.Configuration.GetSection("ApiUrls"));
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
