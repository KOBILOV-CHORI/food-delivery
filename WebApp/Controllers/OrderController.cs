using Domain.Dtos;
using Infrastructure.Responses;
using Infrastructure.Services.OrderServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController(IOrderService orderService) : Controller
{
    [HttpGet] public ApiResponse<List<GetOrderDto>> GetAllOrders() => orderService.GetAllOrders();
    [HttpGet("{id}")] public ApiResponse<GetOrderDto> GetOrderById(int id) => orderService.GetOrderById(id);
    [HttpDelete("{id}")] public ApiResponse<bool> DeleteOrder(int id) => orderService.DeleteOrder(id);
    [HttpPost] public ApiResponse<bool> AddOrder(AddOrderDto addOrderDto) => orderService.AddOrder(addOrderDto);
    [HttpPut] public ApiResponse<bool> UpdateOrder(UpdateOrderDto updateOrderDto) => orderService.UpdateOrder(updateOrderDto);
}