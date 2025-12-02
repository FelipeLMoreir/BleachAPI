using BleachAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpClient<BleachAPIService>(BleachClient =>
BleachClient.BaseAddress = new Uri("https://bleach-api-8v2r.onrender.com/"));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
