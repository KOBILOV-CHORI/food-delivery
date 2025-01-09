using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Responses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.OrderServices;

public class OrderService(DataContext context, IMapper mapper) : IOrderService
{
    public ApiResponse<bool> AddOrder(AddOrderDto addOrderDto)
    {
        var Order = mapper.Map<Order>(addOrderDto);

        context.Orders.Add(Order);
        var res = context.SaveChanges();
        return res == 0
            ? new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Internal server error") 
            : new ApiResponse<bool>(true);
    }

    public ApiResponse<bool> DeleteOrder(int id)
    {
        var order = context.Orders.FirstOrDefault(e => e.Id == id);
        if(order == null) return new ApiResponse<bool>(HttpStatusCode.NotFound, "Order Not Found");
        context.Orders.Remove(order);
        var res = context.SaveChanges();
        return res == 0
            ? new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Internal server error") 
            : new ApiResponse<bool>(true);
    }

    public ApiResponse<List<GetOrderDto>> GetAllOrders()
    {
        var orders = context.Orders.ToList();
        var getAllOrders = mapper.Map<List<GetOrderDto>>(orders);
        return new ApiResponse<List<GetOrderDto>>(getAllOrders);
    }

    public ApiResponse<GetOrderDto> GetOrderById(int id)
    {
        var order = context.Orders.FirstOrDefault(e => e.Id == id);
        var getOrderDto =  mapper.Map<GetOrderDto>(order);
        return getOrderDto == null
            ? new ApiResponse<GetOrderDto>(HttpStatusCode.NotFound, "Order not found") 
            : new ApiResponse<GetOrderDto>(getOrderDto);
    }

    public ApiResponse<bool> UpdateOrder(UpdateOrderDto updateOrderDto)
    {
        var order = context.Orders.FirstOrDefault(e => e.Id == updateOrderDto.Id);
        if(order == null) return new ApiResponse<bool>(HttpStatusCode.NotFound, "Order not found");
        order.CourierId = updateOrderDto.CourierId;
        order.UserId = updateOrderDto.UserId;
        order.RestaurantId = updateOrderDto.RestaurantId;
        order.PaymentMethod = updateOrderDto.PaymentMethod;
        order.PaymentStatus = updateOrderDto.PaymentStatus;
        order.OrderStatus = updateOrderDto.OrderStatus;
        order.DeliveryAddress = updateOrderDto.DeliveryAddress;
        order.TotalAmount = updateOrderDto.TotalAmount;
        var res = context.SaveChanges();
        return res != 0
            ? new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Internal server error") 
            : new ApiResponse<bool>(true);
    }
}
