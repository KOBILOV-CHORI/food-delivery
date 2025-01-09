using Domain.Dtos;
using Infrastructure.Responses;
using Infrastructure.Services.OrderDetailServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderDetailController(IOrderDetailService orderDetailService) : Controller
{
    [HttpGet] public ApiResponse<List<GetOrderDetailDto>> GetAllOrderDetails() => orderDetailService.GetAllOrderDetails();
    [HttpGet("{id}")] public ApiResponse<GetOrderDetailDto> GetOrderDetailById(int id) => orderDetailService.GetOrderDetailById(id);
    [HttpDelete("{id}")] public ApiResponse<bool> DeleteOrderDetail(int id) => orderDetailService.DeleteOrderDetail(id);
    [HttpPost] public ApiResponse<bool> AddOrderDetail(AddOrderDetailDto addOrderDetailDto) => orderDetailService.AddOrderDetail(addOrderDetailDto);
    [HttpPut] public ApiResponse<bool> UpdateOrderDetail(UpdateOrderDetailDto updateOrderDetailDto) => orderDetailService.UpdateOrderDetail(updateOrderDetailDto);
}