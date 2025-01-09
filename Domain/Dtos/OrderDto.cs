using Domain.Enums;

namespace Domain.Dtos;

public record BaseOrderDto
{
    public int UserId { get; set; }
    public int RestaurantId { get; set; }
    public string DeliveryAddress { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public int CourierId { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DeliveredAt { get; set; }
    public decimal TotalAmount { get; set; }
}

public record AddOrderDto : BaseOrderDto
{
}

public record UpdateOrderDto : BaseOrderDto
{
    public int Id { get; set; }
}

public record GetOrderDto : BaseOrderDto
{
    public int Id { get; set; }
}
