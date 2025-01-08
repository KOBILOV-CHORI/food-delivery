using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Services.UserServices;

public class UserService(DataContext context, IMapper mapper) : IUserService
{
    public bool AddUser(AddUserDto addUserDto)
    {
        var user = mapper.Map<User>(addUserDto);

        context.Users.Add(user);
        var res = context.SaveChanges();
        return res != 0;
    }

    public bool DeleteUser(int id)
    {
        var user = context.Users.FirstOrDefault(e => e.Id == id);
        if(user == null) return false;
        context.Users.Remove(user);
        var res = context.SaveChanges();
        return res != 0;
    }

    public List<GetUserDto> GetAllUsers()
    {
        var users = context.Users.ToList();
        return mapper.Map<List<GetUserDto>>(users);
    }

    public GetUserDto GetUserById(int id)
    {
        var user = context.Users.FirstOrDefault(e => e.Id == id);
        return mapper.Map<GetUserDto>(user);
    }

    public bool UpdateUser(UpdateUserDto updateUserDto)
    {
        var user = context.Users.FirstOrDefault(e => e.Id == updateUserDto.Id);
        if(user == null) return false;
        user.Address = updateUserDto.Address;
        user.Email = updateUserDto.Email;
        user.Name = updateUserDto.Name;
        user.Phone = updateUserDto.Phone;
        user.Role = updateUserDto.Role;
        var res = context.SaveChanges();
        return res != 0; 
    }
}
