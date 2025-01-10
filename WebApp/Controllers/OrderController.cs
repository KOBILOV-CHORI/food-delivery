using Domain.Dtos;
using Domain.Filters;
using Infrastructure.Responses;
using Infrastructure.Services.OrderServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController(IOrderService orderService) : Controller
{
    [HttpGet] public PaginationResponse<List<GetOrderDto>> GetAllOrders([FromQuery] OrderFilter filter) => orderService.GetAllOrders(filter);
    [HttpGet("{id}")] public ApiResponse<GetOrderDto> GetOrderById(int id) => orderService.GetOrderById(id);
    [HttpDelete("{id}")] public ApiResponse<bool> DeleteOrder(int id) => orderService.DeleteOrder(id);
    [HttpPost] public ApiResponse<bool> AddOrder([FromBody] AddOrderDto addOrderDto) => orderService.AddOrder(addOrderDto);
    [HttpPut] public ApiResponse<bool> UpdateOrder([FromBody] UpdateOrderDto updateOrderDto) => orderService.UpdateOrder(updateOrderDto);
}