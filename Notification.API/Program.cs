using Microsoft.AspNetCore.Authentication.JwtBearer;
using Notification.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddControllers();
builder.Services.AddHostedService<ServerTimeNotifier>();
builder.Services.AddCors();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowAnyMethod().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.MapHub<NotificationHub>("notifications");

app.Run();
