using Domain.Dtos;
using Domain.Filters;
using Infrastructure.Responses;
using Infrastructure.Services.OrderDetailServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderDetailController(IOrderDetailService orderDetailService) : Controller
{
    [HttpGet] public PaginationResponse<List<GetOrderDetailDto>> GetAllOrderDetails([FromQuery] OrderDetailFilter filter) => orderDetailService.GetAllOrderDetails(filter);
    [HttpGet("{id}")] public ApiResponse<GetOrderDetailDto> GetOrderDetailById(int id) => orderDetailService.GetOrderDetailById(id);
    [HttpDelete("{id}")] public ApiResponse<bool> DeleteOrderDetail(int id) => orderDetailService.DeleteOrderDetail(id);
    [HttpPost] public ApiResponse<bool> AddOrderDetail([FromBody] AddOrderDetailDto addOrderDetailDto) => orderDetailService.AddOrderDetail(addOrderDetailDto);
    [HttpPut] public ApiResponse<bool> UpdateOrderDetail([FromBody] UpdateOrderDetailDto updateOrderDetailDto) => orderDetailService.UpdateOrderDetail(updateOrderDetailDto);
}