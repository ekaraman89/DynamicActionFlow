public record CategoryUpdatedCommand:BaseUpdatedCommand
{
    public required string CategoryId { get; init; }    
}