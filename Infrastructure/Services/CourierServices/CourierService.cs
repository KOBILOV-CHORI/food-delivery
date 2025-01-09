using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Responses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.CourierServices;

public class CourierService(DataContext context, IMapper mapper) : ICourierService
{
    public ApiResponse<bool> AddCourier(AddCourierDto addCourierDto)
    {
        var Courier = mapper.Map<Courier>(addCourierDto);

        context.Couriers.Add(Courier);
        var res = context.SaveChanges();
        return res == 0
            ? new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Internal server error") 
            : new ApiResponse<bool>(true);
    }

    public ApiResponse<bool> DeleteCourier(int id)
    {
        var Courier = context.Couriers.FirstOrDefault(e => e.Id == id);
        if(Courier == null) return new ApiResponse<bool>(HttpStatusCode.NotFound, "Courier Not Found");
        context.Couriers.Remove(Courier);
        var res = context.SaveChanges();
        return res == 0
            ? new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Internal server error") 
            : new ApiResponse<bool>(true);
    }

    public ApiResponse<List<GetCourierDto>> GetAllCouriers()
    {
        var Couriers = context.Couriers.ToList();
        var getAllCouriers = mapper.Map<List<GetCourierDto>>(Couriers);
        return new ApiResponse<List<GetCourierDto>>(getAllCouriers);
    }

    public ApiResponse<GetCourierDto> GetCourierById(int id)
    {
        var Courier = context.Couriers.FirstOrDefault(e => e.Id == id);
        var getCourierDto =  mapper.Map<GetCourierDto>(Courier);
        return getCourierDto == null
            ? new ApiResponse<GetCourierDto>(HttpStatusCode.NotFound, "Courier not found") 
            : new ApiResponse<GetCourierDto>(getCourierDto);
    }

    public ApiResponse<bool> UpdateCourier(UpdateCourierDto updateCourierDto)
    {
        var Courier = context.Couriers.FirstOrDefault(e => e.Id == updateCourierDto.Id);
        if(Courier == null) return new ApiResponse<bool>(HttpStatusCode.NotFound, "Courier not found");
        // Courier.CourierId = updateCourierDto.CourierId;
        // Courier.UserId = updateCourierDto.UserId;
        // Courier.RestaurantId = updateCourierDto.RestaurantId;
        // Courier.PaymentMethod = updateCourierDto.PaymentMethod;
        // Courier.PaymentStatus = updateCourierDto.PaymentStatus;
        // Courier.CourierStatus = updateCourierDto.CourierStatus;
        // Courier.DeliveryAddress = updateCourierDto.DeliveryAddress;
        // Courier.TotalAmount = updateCourierDto.TotalAmount;
        var res = context.SaveChanges();
        return res != 0
            ? new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Internal server error") 
            : new ApiResponse<bool>(true);
    }
}
