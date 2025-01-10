using Domain.Enums;

namespace Domain.Filters;

public record CourierFilter : BaseFilter
{
    public int? UserId { get; set; }
    public CourierStatus? Status { get; set; }
    public string? CurrentLocation { get; set; }
    public string? TransportType { get; set; }
    public decimal? Rating { get; set; }
}
