using Domain.Dtos;
using Infrastructure.Responses;

namespace Infrastructure.Services.UserServices;

public interface IUserService
{
    ApiResponse<bool> AddUser(AddUserDto addUserDto);
    ApiResponse<bool> UpdateUser(UpdateUserDto updateUserDto);
    ApiResponse<bool> DeleteUser(int id);
    ApiResponse<List<GetUserDto>> GetAllUsers();
    ApiResponse<GetUserDto> GetUserById(int id);
}
