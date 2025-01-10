using Infrastructure.Data;
using Infrastructure.Profiles;
using Infrastructure.Services.CourierServices;
using Infrastructure.Services.MenuServices;
using Infrastructure.Services.OrderDetailServices;
using Infrastructure.Services.OrderServices;
using Infrastructure.Services.RestaurantServices;
using Infrastructure.Services.UserServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class RegisterExtension
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IMenuService, MenuService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<ICourierService, CourierService>();
        services.AddScoped<IRestaurantService, RestaurantService>();
        services.AddScoped<IOrderDetailService, OrderDetailService>();

        services.AddAutoMapper(typeof(InfrastructureProfile));

        services.AddDbContext<DataContext>(options => 
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
    }
}
