public class BrandNameChangeAction : ICommandAction<BrandUpdatedCommand>
{
    private readonly ILogger<BrandNameChangeAction> _logger;

    public BrandNameChangeAction(ILogger<BrandNameChangeAction> logger)
    {
        _logger = logger;
    }
    public void Execute(BrandUpdatedCommand command)
    {
        _logger.LogInformation($"Name changed to {command.BrandId}");
    }

    public bool ShouldExecute(BrandUpdatedCommand command) => true;
}

public class BrandDescriptionChangeAction : ICommandAction<BrandUpdatedCommand>
{
    private readonly ILogger<BrandDescriptionChangeAction> _logger;

    public BrandDescriptionChangeAction(ILogger<BrandDescriptionChangeAction> logger)
    {
        _logger = logger;
    }
    public void Execute(BrandUpdatedCommand command)
    {
        _logger.LogInformation($"Description changed to {command.BrandId}");
    }

    public bool ShouldExecute(BrandUpdatedCommand command) => true;
}


