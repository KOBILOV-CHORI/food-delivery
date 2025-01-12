using Domain.Enums;

namespace Domain.Entities;

public class Courier
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public CourierStatus Status { get; set; }
    public string CurrentLocation { get; set; }
    public decimal Rating { get; set; }
    public TransportType TransportType { get; set; }
    public List<Order> Orders { get; set; }
}
