public class CategoryNameChangeAction : ICommandAction<CategoryUpdatedCommand>
{
    private readonly ILogger<CategoryNameChangeAction> _logger;

    public CategoryNameChangeAction(ILogger<CategoryNameChangeAction> logger)
    {
        _logger = logger;
    }
    public void Execute(CategoryUpdatedCommand command)
    {
        _logger.LogInformation($"Name changed to {command.CategoryId}");
    }

    public bool ShouldExecute(CategoryUpdatedCommand command) => true;    
}

public class CategoryDescriptionChangeAction : ICommandAction<CategoryUpdatedCommand>
{
    private readonly ILogger<CategoryDescriptionChangeAction> _logger;

    public CategoryDescriptionChangeAction(ILogger<CategoryDescriptionChangeAction> logger)
    {
        _logger = logger;
    }
    public void Execute(CategoryUpdatedCommand command)
    {
        _logger.LogInformation($"Description changed to {command.CategoryId}");
    }

    public bool ShouldExecute(CategoryUpdatedCommand command) => true;
}

public class CategoryIsActiveChangeAction : ICommandAction<CategoryUpdatedCommand>
{
    private readonly ILogger<CategoryIsActiveChangeAction> _logger;

    public CategoryIsActiveChangeAction(ILogger<CategoryIsActiveChangeAction> logger)
    {
        _logger = logger;
    }
    public void Execute(CategoryUpdatedCommand command)
    {
        _logger.LogInformation($"IsActive changed to {command.CategoryId}");
    }

    public bool ShouldExecute(CategoryUpdatedCommand command) => true;
}

public class CategoryIsFeaturedChangeAction : ICommandAction<CategoryUpdatedCommand>
{
    private readonly ILogger<CategoryIsFeaturedChangeAction> _logger;

    public CategoryIsFeaturedChangeAction(ILogger<CategoryIsFeaturedChangeAction> logger)
    {
        _logger = logger;
    }

    public void Execute(CategoryUpdatedCommand command)
    {
       _logger.LogInformation($"IsFeatured changed to {command.CategoryId}");
    }

    public bool ShouldExecute(CategoryUpdatedCommand command) => true;
 
}
