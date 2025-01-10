using Domain.Enums;

namespace Domain.Filters;

public record UserFilter : BaseFilter
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public UserRole? Role { get; set; }
    public bool? IsActive { get; set; }
    public DateTime? RegisterDate { get; set; }
}
