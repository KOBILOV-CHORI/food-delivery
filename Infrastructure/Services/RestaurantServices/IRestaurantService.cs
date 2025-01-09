using Domain.Dtos;
using Infrastructure.Responses;

namespace Infrastructure.Services.RestaurantServices;

public interface IRestaurantService
{
    ApiResponse<bool> AddRestaurant(AddRestaurantDto addRestaurantDto);
    ApiResponse<bool> UpdateRestaurant(UpdateRestaurantDto updateRestaurantDto);
    ApiResponse<bool> DeleteRestaurant(int id);
    ApiResponse<List<GetRestaurantDto>> GetAllRestaurants();
    ApiResponse<GetRestaurantDto> GetRestaurantById(int id);
}
