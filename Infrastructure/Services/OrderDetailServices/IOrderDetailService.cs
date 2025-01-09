using Domain.Dtos;
using Infrastructure.Responses;

namespace Infrastructure.Services.OrderDetailServices;

public interface IOrderDetailService
{
    ApiResponse<bool> AddOrderDetail(AddOrderDetailDto addOrderDetailDto);
    ApiResponse<bool> UpdateOrderDetail(UpdateOrderDetailDto updateOrderDetailDto);
    ApiResponse<bool> DeleteOrderDetail(int id);
    ApiResponse<List<GetOrderDetailDto>> GetAllOrderDetails();
    ApiResponse<GetOrderDetailDto> GetOrderDetailById(int id);
}
