using Domain.Dtos;
using Infrastructure.Responses;

namespace Infrastructure.Services.CourierServices;

public interface ICourierService
{
    ApiResponse<bool> AddCourier(AddCourierDto addCourierDto);
    ApiResponse<bool> UpdateCourier(UpdateCourierDto updateCourierDto);
    ApiResponse<bool> DeleteCourier(int id);
    ApiResponse<List<GetCourierDto>> GetAllCouriers();
    ApiResponse<GetCourierDto> GetCourierById(int id);
}
