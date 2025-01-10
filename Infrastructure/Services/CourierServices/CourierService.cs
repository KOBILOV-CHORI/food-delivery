using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Filters;
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

    public PaginationResponse<List<GetCourierDto>> GetAllCouriers(CourierFilter filter)
    {
        IQueryable<Courier> couriers = context.Couriers;

        if (filter.UserId.HasValue)
            couriers = couriers.Where(x => x.UserId == filter.UserId);
        if (filter.Status.HasValue)
            couriers = couriers.Where(x => x.Status == filter.Status);
        if (!string.IsNullOrEmpty(filter.CurrentLocation))
            couriers = couriers.Where(x => x.CurrentLocation.ToLower().Contains(filter.CurrentLocation.ToLower()));
        if (filter.Rating.HasValue)
            couriers = couriers.Where(x => x.Rating == filter.Rating);

        int totalRecords = couriers.Count();
        var result = couriers.Skip((filter.PageNumber - 1) * filter.PageSize)
                            .Take(filter.PageSize)
                            .Select(x => mapper.Map<GetCourierDto>(x))
                            .ToList();

        return PaginationResponse<List<GetCourierDto>>.Create(filter.PageNumber, filter.PageSize, totalRecords, result);
    }

    public ApiResponse<GetCourierDto> GetCourierById(int id)
    {
        var courier = context.Couriers.FirstOrDefault(e => e.Id == id);
        var getCourierDto = mapper.Map<GetCourierDto>(courier);
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
