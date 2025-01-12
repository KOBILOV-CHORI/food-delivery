namespace Domain.Filters;

public record RestaurantFilter : BaseFilter
{
    public string? Name { get; set; }
    public string? Address { get; set; }
    public decimal? Rating { get; set; }
    public string? WorkingHours { get; set; }
    public string? ContactPhone { get; set; }
    public bool? IsActive { get; set; }
    public decimal? MinOrderAmount { get; set; }
    public decimal? DeliveryPrice { get; set; }
}
