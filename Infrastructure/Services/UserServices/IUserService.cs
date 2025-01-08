using Domain.Dtos;

namespace Infrastructure.Services.UserServices;

public interface IUserService
{
    bool AddUser(AddUserDto addUserDto);
    bool UpdateUser(UpdateUserDto updateUserDto);
    bool DeleteUser(int id);
    List<GetUserDto> GetAllUsers();
    GetUserDto GetUserById(int id);
}
