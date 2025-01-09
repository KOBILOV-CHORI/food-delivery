using Domain.Dtos;
using Infrastructure.Responses;
using Infrastructure.Services.RestaurantServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestaurantController(IRestaurantService RestaurantService) : Controller
{
    [HttpGet] public ApiResponse<List<GetRestaurantDto>> GetAllRestaurants() => RestaurantService.GetAllRestaurants();
    [HttpGet("{id}")] public ApiResponse<GetRestaurantDto> GetRestaurantById(int id) => RestaurantService.GetRestaurantById(id);
    [HttpDelete("{id}")] public ApiResponse<bool> DeleteRestaurant(int id) => RestaurantService.DeleteRestaurant(id);
    [HttpPost] public ApiResponse<bool> AddRestaurant(AddRestaurantDto addRestaurantDto) => RestaurantService.AddRestaurant(addRestaurantDto);
    [HttpPut] public ApiResponse<bool> UpdateRestaurant(UpdateRestaurantDto updateRestaurantDto) => RestaurantService.UpdateRestaurant(updateRestaurantDto);
}