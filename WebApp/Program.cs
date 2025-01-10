using Infrastructure.Data;
using Infrastructure.Extensions;
using Infrastructure.Profiles;
using Infrastructure.Services.CourierServices;
using Infrastructure.Services.MenuServices;
using Infrastructure.Services.OrderDetailServices;
using Infrastructure.Services.OrderServices;
using Infrastructure.Services.RestaurantServices;
using Infrastructure.Services.UserServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.RegisterServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "Food Delivery"));
}

app.MapControllers();
app.Run();