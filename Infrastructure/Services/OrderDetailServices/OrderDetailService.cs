using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Responses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.OrderDetailServices;

public class OrderDetailService(DataContext context, IMapper mapper) : IOrderDetailService
{
    public ApiResponse<bool> AddOrderDetail(AddOrderDetailDto addOrderDetailDto)
    {
        var OrderDetail = mapper.Map<OrderDetail>(addOrderDetailDto);

        context.OrderDetails.Add(OrderDetail);
        var res = context.SaveChanges();
        return res == 0
            ? new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Internal server error") 
            : new ApiResponse<bool>(true);
    }

    public ApiResponse<bool> DeleteOrderDetail(int id)
    {
        var OrderDetail = context.OrderDetails.FirstOrDefault(e => e.Id == id);
        if(OrderDetail == null) return new ApiResponse<bool>(HttpStatusCode.NotFound, "OrderDetail Not Found");
        context.OrderDetails.Remove(OrderDetail);
        var res = context.SaveChanges();
        return res == 0
            ? new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Internal server error") 
            : new ApiResponse<bool>(true);
    }

    public ApiResponse<List<GetOrderDetailDto>> GetAllOrderDetails()
    {
        var OrderDetails = context.OrderDetails.ToList();
        var getAllOrderDetails = mapper.Map<List<GetOrderDetailDto>>(OrderDetails);
        return new ApiResponse<List<GetOrderDetailDto>>(getAllOrderDetails);
    }

    public ApiResponse<GetOrderDetailDto> GetOrderDetailById(int id)
    {
        var OrderDetail = context.OrderDetails.FirstOrDefault(e => e.Id == id);
        var getOrderDetailDto =  mapper.Map<GetOrderDetailDto>(OrderDetail);
        return getOrderDetailDto == null
            ? new ApiResponse<GetOrderDetailDto>(HttpStatusCode.NotFound, "OrderDetail not found") 
            : new ApiResponse<GetOrderDetailDto>(getOrderDetailDto);
    }

    public ApiResponse<bool> UpdateOrderDetail(UpdateOrderDetailDto updateOrderDetailDto)
    {
        var OrderDetail = context.OrderDetails.FirstOrDefault(e => e.Id == updateOrderDetailDto.Id);
        if(OrderDetail == null) return new ApiResponse<bool>(HttpStatusCode.NotFound, "OrderDetail not found");
        // OrderDetail.CourierId = updateOrderDetailDto.CourierId;
        // OrderDetail.UserId = updateOrderDetailDto.UserId;
        // OrderDetail.RestaurantId = updateOrderDetailDto.RestaurantId;
        // OrderDetail.PaymentMethod = updateOrderDetailDto.PaymentMethod;
        // OrderDetail.PaymentStatus = updateOrderDetailDto.PaymentStatus;
        // OrderDetail.OrderDetailStatus = updateOrderDetailDto.OrderDetailStatus;
        // OrderDetail.DeliveryAddress = updateOrderDetailDto.DeliveryAddress;
        // OrderDetail.TotalAmount = updateOrderDetailDto.TotalAmount;
        var res = context.SaveChanges();
        return res != 0
            ? new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Internal server error") 
            : new ApiResponse<bool>(true);
    }
}
