using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
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

    public ApiResponse<List<GetRestaurantDto>> GetAllRestaurants()
    {
        var Restaurants = context.Restaurants.ToList();
        var getAllRestaurants = mapper.Map<List<GetRestaurantDto>>(Restaurants);
        return new ApiResponse<List<GetRestaurantDto>>(getAllRestaurants);
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
