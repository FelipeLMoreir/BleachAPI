using BleachAPI.DataBase;
using BleachAPI.Repository;
using BleachAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpClient<BleachAPIService>(Bclient => Bclient.BaseAddress = 
new Uri("https://bleach-api-8v2r.onrender.com/"));
builder.Services.AddSingleton<SqlConnectionFactory>();
builder.Services.AddSingleton<BleachAPIService>();
builder.Services.AddSingleton<BleachAPIRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
