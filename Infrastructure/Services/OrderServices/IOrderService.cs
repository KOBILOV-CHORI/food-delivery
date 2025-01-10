using Domain.Dtos;
using Domain.Filters;
using Infrastructure.Responses;

namespace Infrastructure.Services.OrderServices;

public interface IOrderService
{
    ApiResponse<bool> AddOrder(AddOrderDto addOrderDto);
    ApiResponse<bool> UpdateOrder(UpdateOrderDto updateOrderDto);
    ApiResponse<bool> DeleteOrder(int id);
    PaginationResponse<List<GetOrderDto>> GetAllOrders(OrderFilter filter);
    ApiResponse<GetOrderDto> GetOrderById(int id);
}
