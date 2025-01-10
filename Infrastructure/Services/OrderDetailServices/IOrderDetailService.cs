using Domain.Dtos;
using Domain.Filters;
using Infrastructure.Responses;

namespace Infrastructure.Services.OrderDetailServices;

public interface IOrderDetailService
{
    ApiResponse<bool> AddOrderDetail(AddOrderDetailDto addOrderDetailDto);
    ApiResponse<bool> UpdateOrderDetail(UpdateOrderDetailDto updateOrderDetailDto);
    ApiResponse<bool> DeleteOrderDetail(int id);
    PaginationResponse<List<GetOrderDetailDto>> GetAllOrderDetails(OrderDetailFilter filter);
    ApiResponse<GetOrderDetailDto> GetOrderDetailById(int id);
}
