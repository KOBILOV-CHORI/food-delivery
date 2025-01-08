namespace Domain.Dtos;

public record BaseOrderDetailDto
{
    public int MenuItemId { get; set; }
    public int Quantity { get; set; }
    public string SpecialInstructions { get; set; }
    public int OrderId { get; set; }
    public decimal Price { get; set; }
}

public record AddOrderDetailDto : BaseOrderDetailDto
{
}

public record UpdateOrderDetailDto : BaseOrderDetailDto
{
    public int Id { get; set; }
}

public record GetOrderDetailDto : BaseOrderDetailDto
{
    public int Id { get; set; }
}
