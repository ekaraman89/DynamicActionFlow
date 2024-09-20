public abstract record BaseUpdatedCommand
{
    public string Id { get; init; }
    public required Dictionary<string, object> UpdatedFields { get; init; }
}
