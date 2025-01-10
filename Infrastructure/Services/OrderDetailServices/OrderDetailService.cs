using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Filters;
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

    public PaginationResponse<List<GetOrderDetailDto>> GetAllOrderDetails(OrderDetailFilter filter)
    {
        IQueryable<OrderDetail> orderDetails = context.OrderDetails;

        if (filter.OrderId.HasValue)
            orderDetails = orderDetails.Where(x => x.OrderId == filter.OrderId);
        if (filter.MenuItemId.HasValue)
            orderDetails = orderDetails.Where(x => x.MenuItemId == filter.MenuItemId);
        if (filter.Quantity.HasValue)
            orderDetails = orderDetails.Where(x => x.Quantity == filter.Quantity);
        if (filter.Price.HasValue)
            orderDetails = orderDetails.Where(x => x.Price == filter.Price);
        if (!string.IsNullOrEmpty(filter.SpecialInstructions))
            orderDetails = orderDetails.Where(x => x.SpecialInstructions.ToLower().Contains(filter.SpecialInstructions.ToLower()));

        int totalRecords = orderDetails.Count();
        var result = orderDetails.Skip((filter.PageNumber - 1) * filter.PageSize)
                               .Take(filter.PageSize)
                               .Select(x => mapper.Map<GetOrderDetailDto>(x))
                               .ToList();

        return PaginationResponse<List<GetOrderDetailDto>>.Create(filter.PageNumber, filter.PageSize, totalRecords, result);
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
