namespace Domain.Filters;

public record MenuFilter : BaseFilter
{
    public int? RestaurantId { get; set; }
    public string? Name { get; set; }
    public decimal? Price { get; set; }
    public string? Category { get; set; }
    public bool? IsAvailable { get; set; }
    public int? PreparationTime { get; set; }
    public int? Weight { get; set; }
}