using Domain.Dtos;
using Infrastructure.Responses;
using Infrastructure.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService UserService) : Controller
{
    [HttpGet] public ApiResponse<List<GetUserDto>> GetAllUsers() => UserService.GetAllUsers();
    [HttpGet("{id}")] public ApiResponse<GetUserDto> GetUserById(int id) => UserService.GetUserById(id);
    [HttpDelete("{id}")] public ApiResponse<bool> DeleteUser(int id) => UserService.DeleteUser(id);
    [HttpPost] public ApiResponse<bool> AddUser(AddUserDto addUserDto) => UserService.AddUser(addUserDto);
    [HttpPut] public ApiResponse<bool> UpdateUser(UpdateUserDto updateUserDto) => UserService.UpdateUser(updateUserDto);
}