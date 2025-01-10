using Domain.Dtos;
using Domain.Filters;
using Infrastructure.Responses;

namespace Infrastructure.Services.UserServices;

public interface IUserService
{
    ApiResponse<bool> AddUser(AddUserDto addUserDto);
    ApiResponse<bool> UpdateUser(UpdateUserDto updateUserDto);
    ApiResponse<bool> DeleteUser(int id);
    PaginationResponse<List<GetUserDto>> GetAllUsers(UserFilter filter);
    ApiResponse<GetUserDto> GetUserById(int id);
}
