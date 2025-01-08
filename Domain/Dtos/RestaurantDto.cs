namespace Domain.Dtos;

public record BaseRestaurantDto
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string WorkingHours { get; set; }
    public string Description { get; set; }
    public string ContactPhone { get; set; }
    public bool IsActive { get; set; }
    public decimal MinOrderAmount { get; set; }
    public decimal DeliveryPrice { get; set; }
    public decimal Rating { get; set; }
}

public record AddRestaurantDto : BaseRestaurantDto
{
}

public record UpdateRestaurantDto : BaseRestaurantDto
{
    public int Id { get; set; }
}

public record GetRestaurantDto : BaseRestaurantDto
{
    public int Id { get; set; }
}
