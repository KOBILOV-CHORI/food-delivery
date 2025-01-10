using Domain.Dtos;
using Domain.Filters;
using Infrastructure.Responses;

namespace Infrastructure.Services.CourierServices;

public interface ICourierService
{
    ApiResponse<bool> AddCourier(AddCourierDto addCourierDto);
    ApiResponse<bool> UpdateCourier(UpdateCourierDto updateCourierDto);
    ApiResponse<bool> DeleteCourier(int id);
    PaginationResponse<List<GetCourierDto>> GetAllCouriers(CourierFilter filter);
    ApiResponse<GetCourierDto> GetCourierById(int id);
}
