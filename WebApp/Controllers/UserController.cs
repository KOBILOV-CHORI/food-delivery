using Domain.Dtos;
using Infrastructure.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService) : Controller
{
    [HttpGet] public List<GetUserDto> GetAllUsers() => userService.GetAllUsers();
    [HttpGet("{id}")] public GetUserDto GetUserById(int id) => userService.GetUserById(id);
    [HttpDelete("{id}")] public bool DeleteUser(int id) => userService.DeleteUser(id);
    [HttpPost] public bool AddUser(AddUserDto addUserDto) => userService.AddUser(addUserDto);
    [HttpPut] public bool UpdateUser(UpdateUserDto updateUserDto) => userService.UpdateUser(updateUserDto);
}
