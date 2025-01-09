using Domain.Dtos;
using Infrastructure.Responses;

namespace Infrastructure.Services.OrderServices;

public interface IOrderService
{
    ApiResponse<bool> AddOrder(AddOrderDto addOrderDto);
    ApiResponse<bool> UpdateOrder(UpdateOrderDto updateOrderDto);
    ApiResponse<bool> DeleteOrder(int id);
    ApiResponse<List<GetOrderDto>> GetAllOrders();
    ApiResponse<GetOrderDto> GetOrderById(int id);
}
