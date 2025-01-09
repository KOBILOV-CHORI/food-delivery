using Infrastructure.Data;
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
builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICourierService, CourierService>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddAutoMapper(typeof(InfrastructureProfile));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "Food Delivery"));
}

app.MapControllers();
app.Run();