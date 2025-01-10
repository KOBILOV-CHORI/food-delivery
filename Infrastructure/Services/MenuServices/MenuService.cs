using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Filters;
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

    public PaginationResponse<List<GetMenuDto>> GetAllMenus(MenuFilter filter)
    {
        IQueryable<Menu> menus = context.Menus;

        if (filter.RestaurantId.HasValue)
            menus = menus.Where(x => x.RestaurantId == filter.RestaurantId);
        if (!string.IsNullOrEmpty(filter.Name))
            menus = menus.Where(x => x.Name.ToLower().Contains(filter.Name.ToLower()));
        if (filter.Price.HasValue)
            menus = menus.Where(x => x.Price == filter.Price);
        if (!string.IsNullOrEmpty(filter.Category))
            menus = menus.Where(x => x.Category.ToLower().Contains(filter.Category.ToLower()));
        if (filter.IsAvailable.HasValue)
            menus = menus.Where(x => x.IsAvailable == filter.IsAvailable);
        if (filter.PreparationTime.HasValue)
            menus = menus.Where(x => x.PreparationTime == filter.PreparationTime);
        if (filter.Weight.HasValue)
            menus = menus.Where(x => x.Weight == filter.Weight);

        int totalRecords = menus.Count();
        var result = menus.Skip((filter.PageNumber - 1) * filter.PageSize)
                         .Take(filter.PageSize)
                         .Select(x => mapper.Map<GetMenuDto>(x))
                         .ToList();

        return PaginationResponse<List<GetMenuDto>>.Create(filter.PageNumber, filter.PageSize, totalRecords, result);
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
