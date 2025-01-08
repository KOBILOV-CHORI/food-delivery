namespace Domain.Dtos;

public record BaseMenuDto
{
    public int RestaurantId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
    public bool IsAvailable { get; set; }
    public int PreparationTime { get; set; }
    public int Weight { get; set; }
    public string PhotoUrl { get; set; }
}

public record AddMenuDto : BaseMenuDto
{
}

public record UpdateMenuDto : BaseMenuDto
{
    public int Id { get; set; }
}

public record GetMenuDto : BaseMenuDto
{
    public int Id { get; set; }
}
