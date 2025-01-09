using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Responses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.MenuServices;

public class MenuService(DataContext context, IMapper mapper) : IMenuService
{
    public ApiResponse<bool> AddMenu(AddMenuDto addMenuDto)
    {
        var Menu = mapper.Map<Menu>(addMenuDto);

        context.Menus.Add(Menu);
        var res = context.SaveChanges();
        return res == 0
            ? new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Internal server error") 
            : new ApiResponse<bool>(true);
    }

    public ApiResponse<bool> DeleteMenu(int id)
    {
        var Menu = context.Menus.FirstOrDefault(e => e.Id == id);
        if(Menu == null) return new ApiResponse<bool>(HttpStatusCode.NotFound, "Menu Not Found");
        context.Menus.Remove(Menu);
        var res = context.SaveChanges();
        return res == 0
            ? new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Internal server error") 
            : new ApiResponse<bool>(true);
    }

    public ApiResponse<List<GetMenuDto>> GetAllMenus()
    {
        var Menus = context.Menus.ToList();
        var getAllMenus = mapper.Map<List<GetMenuDto>>(Menus);
        return new ApiResponse<List<GetMenuDto>>(getAllMenus);
    }

    public ApiResponse<GetMenuDto> GetMenuById(int id)
    {
        var Menu = context.Menus.FirstOrDefault(e => e.Id == id);
        var getMenuDto =  mapper.Map<GetMenuDto>(Menu);
        return getMenuDto == null
            ? new ApiResponse<GetMenuDto>(HttpStatusCode.NotFound, "Menu not found") 
            : new ApiResponse<GetMenuDto>(getMenuDto);
    }

    public ApiResponse<bool> UpdateMenu(UpdateMenuDto updateMenuDto)
    {
        var Menu = context.Menus.FirstOrDefault(e => e.Id == updateMenuDto.Id);
        if(Menu == null) return new ApiResponse<bool>(HttpStatusCode.NotFound, "Menu not found");
        // Menu.CourierId = updateMenuDto.CourierId;
        // Menu.UserId = updateMenuDto.UserId;
        // Menu.RestaurantId = updateMenuDto.RestaurantId;
        // Menu.PaymentMethod = updateMenuDto.PaymentMethod;
        // Menu.PaymentStatus = updateMenuDto.PaymentStatus;
        // Menu.MenuStatus = updateMenuDto.MenuStatus;
        // Menu.DeliveryAddress = updateMenuDto.DeliveryAddress;
        // Menu.TotalAmount = updateMenuDto.TotalAmount;
        var res = context.SaveChanges();
        return res != 0
            ? new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Internal server error") 
            : new ApiResponse<bool>(true);
    }
}
