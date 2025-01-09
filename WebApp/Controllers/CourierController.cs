using Domain.Dtos;
using Infrastructure.Responses;
using Infrastructure.Services.CourierServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourierController(ICourierService CourierService) : Controller
{
    [HttpGet] public ApiResponse<List<GetCourierDto>> GetAllCouriers() => CourierService.GetAllCouriers();
    [HttpGet("{id}")] public ApiResponse<GetCourierDto> GetCourierById(int id) => CourierService.GetCourierById(id);
    [HttpDelete("{id}")] public ApiResponse<bool> DeleteCourier(int id) => CourierService.DeleteCourier(id);
    [HttpPost] public ApiResponse<bool> AddCourier(AddCourierDto addCourierDto) => CourierService.AddCourier(addCourierDto);
    [HttpPut] public ApiResponse<bool> UpdateCourier(UpdateCourierDto updateCourierDto) => CourierService.UpdateCourier(updateCourierDto);
}