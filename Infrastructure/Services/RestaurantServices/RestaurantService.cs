using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Filters;
using Infrastructure.Data;
using Infrastructure.Responses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.RestaurantServices;

public class RestaurantService(DataContext context, IMapper mapper) : IRestaurantService
{
    public ApiResponse<bool> AddRestaurant(AddRestaurantDto addRestaurantDto)
    {
        var Restaurant = mapper.Map<Restaurant>(addRestaurantDto);

        context.Restaurants.Add(Restaurant);
        var res = context.SaveChanges();
        return res == 0
            ? new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Internal server error") 
            : new ApiResponse<bool>(true);
    }

    public ApiResponse<bool> DeleteRestaurant(int id)
    {
        var Restaurant = context.Restaurants.FirstOrDefault(e => e.Id == id);
        if(Restaurant == null) return new ApiResponse<bool>(HttpStatusCode.NotFound, "Restaurant Not Found");
        context.Restaurants.Remove(Restaurant);
        var res = context.SaveChanges();
        return res == 0
            ? new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Internal server error") 
            : new ApiResponse<bool>(true);
    }

    public PaginationResponse<List<GetRestaurantDto>> GetAllRestaurants(RestaurantFilter filter)
    {
        IQueryable<Restaurant> restaurants = context.Restaurants;

        if (!string.IsNullOrEmpty(filter.Name))
            restaurants = restaurants.Where(x => x.Name.ToLower().Contains(filter.Name.ToLower()));
        if (!string.IsNullOrEmpty(filter.Address))
            restaurants = restaurants.Where(x => x.Address.ToLower().Contains(filter.Address.ToLower()));
        if (filter.Rating.HasValue)
            restaurants = restaurants.Where(x => x.Rating == filter.Rating);
        if (!string.IsNullOrEmpty(filter.WorkingHours))
            restaurants = restaurants.Where(x => x.WorkingHours.ToLower().Contains(filter.WorkingHours.ToLower()));
        if (!string.IsNullOrEmpty(filter.ContactPhone))
            restaurants = restaurants.Where(x => x.ContactPhone.ToLower().Contains(filter.ContactPhone.ToLower()));
        if (filter.IsActive.HasValue)
            restaurants = restaurants.Where(x => x.IsActive == filter.IsActive);
        if (filter.MinOrderAmount.HasValue)
            restaurants = restaurants.Where(x => x.MinOrderAmount == filter.MinOrderAmount);
        if (filter.DeliveryPrice.HasValue)
            restaurants = restaurants.Where(x => x.DeliveryPrice == filter.DeliveryPrice);

        int totalRecords = restaurants.Count();
        var result = restaurants.Skip((filter.PageNumber - 1) * filter.PageSize)
                             .Take(filter.PageSize)
                             .Select(x => mapper.Map<GetRestaurantDto>(x))
                             .ToList();

        return PaginationResponse<List<GetRestaurantDto>>.Create(filter.PageNumber, filter.PageSize, totalRecords, result);
    }

    public ApiResponse<GetRestaurantDto> GetRestaurantById(int id)
    {
        var Restaurant = context.Restaurants.FirstOrDefault(e => e.Id == id);
        var getRestaurantDto =  mapper.Map<GetRestaurantDto>(Restaurant);
        return getRestaurantDto == null
            ? new ApiResponse<GetRestaurantDto>(HttpStatusCode.NotFound, "Restaurant not found") 
            : new ApiResponse<GetRestaurantDto>(getRestaurantDto);
    }

    public ApiResponse<bool> UpdateRestaurant(UpdateRestaurantDto updateRestaurantDto)
    {
        var Restaurant = context.Restaurants.FirstOrDefault(e => e.Id == updateRestaurantDto.Id);
        if(Restaurant == null) return new ApiResponse<bool>(HttpStatusCode.NotFound, "Restaurant not found");
        // Restaurant.CourierId = updateRestaurantDto.CourierId;
        // Restaurant.UserId = updateRestaurantDto.UserId;
        // Restaurant.RestaurantId = updateRestaurantDto.RestaurantId;
        // Restaurant.PaymentMethod = updateRestaurantDto.PaymentMethod;
        // Restaurant.PaymentStatus = updateRestaurantDto.PaymentStatus;
        // Restaurant.RestaurantStatus = updateRestaurantDto.RestaurantStatus;
        // Restaurant.DeliveryAddress = updateRestaurantDto.DeliveryAddress;
        // Restaurant.TotalAmount = updateRestaurantDto.TotalAmount;
        var res = context.SaveChanges();
        return res != 0
            ? new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Internal server error") 
            : new ApiResponse<bool>(true);
    }
}
