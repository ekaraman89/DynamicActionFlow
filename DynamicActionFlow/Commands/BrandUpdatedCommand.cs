public record BrandUpdatedCommand:BaseUpdatedCommand
{
    public required string BrandId { get; init; }
}