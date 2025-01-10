using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Filters;
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

    public PaginationResponse<List<GetOrderDto>> GetAllOrders(OrderFilter filter)
    {
        IQueryable<Order> orders = context.Orders;

        if (filter.UserId.HasValue)
            orders = orders.Where(x => x.UserId == filter.UserId);
        if (filter.RestaurantId.HasValue)
            orders = orders.Where(x => x.RestaurantId == filter.RestaurantId);
        if (filter.CourierId.HasValue)
            orders = orders.Where(x => x.CourierId == filter.CourierId);
        if (filter.OrderStatus.HasValue)
            orders = orders.Where(x => x.OrderStatus == filter.OrderStatus);
        if (filter.DeliveredAt.HasValue)
            orders = orders.Where(x => x.DeliveredAt == filter.DeliveredAt);
        if (filter.TotalAmount.HasValue)
            orders = orders.Where(x => x.TotalAmount == filter.TotalAmount);
        if (!string.IsNullOrEmpty(filter.DeliveryAddress))
            orders = orders.Where(x => x.DeliveryAddress.ToLower().Contains(filter.DeliveryAddress.ToLower()));
        if (filter.PaymentMethod.HasValue)
            orders = orders.Where(x => x.PaymentMethod == filter.PaymentMethod);
        if (filter.PaymentStatus.HasValue)
            orders = orders.Where(x => x.PaymentStatus == filter.PaymentStatus);

        int totalRecords = orders.Count();
        var result = orders.Skip((filter.PageNumber - 1) * filter.PageSize)
                         .Take(filter.PageSize)
                         .Select(x => mapper.Map<GetOrderDto>(x))
                         .ToList();

        return PaginationResponse<List<GetOrderDto>>.Create(filter.PageNumber, filter.PageSize, totalRecords, result);
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
