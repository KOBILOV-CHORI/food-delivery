using Domain.Dtos;
using Domain.Filters;
using Infrastructure.Responses;
using Infrastructure.Services.RestaurantServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestaurantController(IRestaurantService RestaurantService) : Controller
{
    [HttpGet] public PaginationResponse<List<GetRestaurantDto>> GetAllRestaurants([FromQuery] RestaurantFilter filter) => RestaurantService.GetAllRestaurants(filter);
    [HttpGet("{id}")] public ApiResponse<GetRestaurantDto> GetRestaurantById(int id) => RestaurantService.GetRestaurantById(id);
    [HttpDelete("{id}")] public ApiResponse<bool> DeleteRestaurant(int id) => RestaurantService.DeleteRestaurant(id);
    [HttpPost] public ApiResponse<bool> AddRestaurant([FromBody] AddRestaurantDto addRestaurantDto) => RestaurantService.AddRestaurant(addRestaurantDto);
    [HttpPut] public ApiResponse<bool> UpdateRestaurant([FromBody] UpdateRestaurantDto updateRestaurantDto) => RestaurantService.UpdateRestaurant(updateRestaurantDto);
}