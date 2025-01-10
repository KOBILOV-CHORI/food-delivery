using Domain.Dtos;
using Domain.Filters;
using Infrastructure.Responses;
using Infrastructure.Services.CourierServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourierController(ICourierService CourierService) : Controller
{
    [HttpGet] public PaginationResponse<List<GetCourierDto>> GetAllCouriers([FromQuery] CourierFilter filter) => CourierService.GetAllCouriers(filter);
    [HttpGet("{id}")] public ApiResponse<GetCourierDto> GetCourierById(int id) => CourierService.GetCourierById(id);
    [HttpDelete("{id}")] public ApiResponse<bool> DeleteCourier(int id) => CourierService.DeleteCourier(id);
    [HttpPost] public ApiResponse<bool> AddCourier([FromBody] AddCourierDto addCourierDto) => CourierService.AddCourier(addCourierDto);
    [HttpPut] public ApiResponse<bool> UpdateCourier([FromBody] UpdateCourierDto updateCourierDto) => CourierService.UpdateCourier(updateCourierDto);
}