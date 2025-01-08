using AutoMapper;
using Domain.Dtos;
using Domain.Entities;

namespace Infrastructure.Profiles;

public class InfrastructureProfile : Profile
{
    public InfrastructureProfile()
    {
        CreateMap<AddUserDto, User>();
        CreateMap<User, GetUserDto>();

        CreateMap<AddMenuDto, Menu>();
        CreateMap<Menu, GetMenuDto>();

        CreateMap<AddOrderDto, Order>();
        CreateMap<Order, GetOrderDto>();

        CreateMap<AddCourierDto, Courier>();
        CreateMap<Courier, GetCourierDto>();

        CreateMap<AddRestaurantDto, Restaurant>();
        CreateMap<Restaurant, GetRestaurantDto>();

        CreateMap<AddOrderDetailDto, OrderDetail>();
        CreateMap<OrderDetail, GetOrderDetailDto>();
    }
}
