using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Responses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.UserServices;

public class UserService(DataContext context, IMapper mapper) : IUserService
{
    public ApiResponse<bool> AddUser(AddUserDto addUserDto)
    {
        var User = mapper.Map<User>(addUserDto);

        context.Users.Add(User);
        var res = context.SaveChanges();
        return res == 0
            ? new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Internal server error") 
            : new ApiResponse<bool>(true);
    }

    public ApiResponse<bool> DeleteUser(int id)
    {
        var User = context.Users.FirstOrDefault(e => e.Id == id);
        if(User == null) return new ApiResponse<bool>(HttpStatusCode.NotFound, "User Not Found");
        context.Users.Remove(User);
        var res = context.SaveChanges();
        return res == 0
            ? new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Internal server error") 
            : new ApiResponse<bool>(true);
    }

    public ApiResponse<List<GetUserDto>> GetAllUsers()
    {
        var Users = context.Users.ToList();
        var getAllUsers = mapper.Map<List<GetUserDto>>(Users);
        return new ApiResponse<List<GetUserDto>>(getAllUsers);
    }

    public ApiResponse<GetUserDto> GetUserById(int id)
    {
        var User = context.Users.FirstOrDefault(e => e.Id == id);
        var getUserDto =  mapper.Map<GetUserDto>(User);
        return getUserDto == null
            ? new ApiResponse<GetUserDto>(HttpStatusCode.NotFound, "User not found") 
            : new ApiResponse<GetUserDto>(getUserDto);
    }

    public ApiResponse<bool> UpdateUser(UpdateUserDto updateUserDto)
    {
        var User = context.Users.FirstOrDefault(e => e.Id == updateUserDto.Id);
        if(User == null) return new ApiResponse<bool>(HttpStatusCode.NotFound, "User not found");
        // User.CourierId = updateUserDto.CourierId;
        // User.UserId = updateUserDto.UserId;
        // User.RestaurantId = updateUserDto.RestaurantId;
        // User.PaymentMethod = updateUserDto.PaymentMethod;
        // User.PaymentStatus = updateUserDto.PaymentStatus;
        // User.UserStatus = updateUserDto.UserStatus;
        // User.DeliveryAddress = updateUserDto.DeliveryAddress;
        // User.TotalAmount = updateUserDto.TotalAmount;
        var res = context.SaveChanges();
        return res != 0
            ? new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Internal server error") 
            : new ApiResponse<bool>(true);
    }
}
