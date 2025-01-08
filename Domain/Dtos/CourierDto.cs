using Domain.Enums;

namespace Domain.Dtos;

public record BaseCourierDto
{
    public int UserId { get; set; }
    public CourierStatus Status { get; set; }
    public string CurrentLocation { get; set; }
    public decimal Rating { get; set; }
    public TransportType TransportType { get; set; }
}
public record AddCourierDto : BaseCourierDto
{

}
public record UpdateCourierDto : BaseCourierDto
{
    public int Id { get; set; }
}

public record GetCourierDto : BaseCourierDto
{
    public int Id { get; set; }
}