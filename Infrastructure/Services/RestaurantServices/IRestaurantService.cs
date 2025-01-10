using Domain.Dtos;
using Domain.Filters;
using Infrastructure.Responses;

namespace Infrastructure.Services.RestaurantServices;

public interface IRestaurantService
{
    ApiResponse<bool> AddRestaurant(AddRestaurantDto addRestaurantDto);
    ApiResponse<bool> UpdateRestaurant(UpdateRestaurantDto updateRestaurantDto);
    ApiResponse<bool> DeleteRestaurant(int id);
    PaginationResponse<List<GetRestaurantDto>> GetAllRestaurants(RestaurantFilter filter);
    ApiResponse<GetRestaurantDto> GetRestaurantById(int id);
}
