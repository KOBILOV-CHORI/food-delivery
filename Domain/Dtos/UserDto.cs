using Domain.Enums;

namespace Domain.Dtos;

public record BaseUserDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public UserRole Role { get; set; }
}

public record AddUserDto : BaseUserDto
{
    public string Password { get; set; }
}

public record UpdateUserDto : BaseUserDto
{
    public int Id { get; set; }
}

public record GetUserDto : BaseUserDto
{
    public int Id { get; set; }
    public string Password { get; set; }
}
