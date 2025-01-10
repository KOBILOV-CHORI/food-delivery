using Domain.Dtos;
using Domain.Filters;
using Infrastructure.Responses;
using Infrastructure.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService UserService) : Controller
{
    [HttpGet] public PaginationResponse<List<GetUserDto>> GetAllUsers([FromQuery] UserFilter filter) => UserService.GetAllUsers(filter);
    [HttpGet("{id}")] public ApiResponse<GetUserDto> GetUserById(int id) => UserService.GetUserById(id);
    [HttpDelete("{id}")] public ApiResponse<bool> DeleteUser(int id) => UserService.DeleteUser(id);
    [HttpPost] public ApiResponse<bool> AddUser([FromBody] AddUserDto addUserDto) => UserService.AddUser(addUserDto);
    [HttpPut] public ApiResponse<bool> UpdateUser([FromBody] UpdateUserDto updateUserDto) => UserService.UpdateUser(updateUserDto);
}