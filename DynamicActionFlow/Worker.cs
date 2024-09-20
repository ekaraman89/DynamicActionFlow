namespace DynamicActionFlow;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly ILoggerFactory _loggerFactory;
    public Worker(ILogger<Worker> logger, ILoggerFactory loggerFactory)
    {
        _loggerFactory = loggerFactory;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var brandExecutor = ActionExecutorFactory.CreateBrandExecutor(_loggerFactory);
        var categoryExecutor = ActionExecutorFactory.CreateCategoryExecutor(_loggerFactory);

        while (!stoppingToken.IsCancellationRequested)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            }

            var command1 = new BrandUpdatedCommand
            {
                BrandId = "123",
                UpdatedFields = new Dictionary<string, object>
                {
                    { "Name", "New Brand Name" },
                    { "Description", "New Description" }
                }
            };
            brandExecutor.Execute(command1);

            var command2 = new CategoryUpdatedCommand
            {
                CategoryId = "456",
                UpdatedFields = new Dictionary<string, object>
                {
                    { "Name", "New Category Name" },
                    { "Description", "New Category Description" },
                }
            };
            categoryExecutor.Execute(command2);

            var command3 = new CategoryUpdatedCommand
            {
                CategoryId = "456",
                UpdatedFields = new Dictionary<string, object>
                {
                    { "Name", "New Category Name" },
                    { "Description", "New Category Description" },
                }
            };
            categoryExecutor.Execute(command3);

            var command4 = new CategoryUpdatedCommand
            {
                CategoryId = "44356",
                UpdatedFields = new Dictionary<string, object>
                {
                    { "IsFeatured", true }
                }
            };
            categoryExecutor.Execute(command4);

            var command5 = new CategoryUpdatedCommand
            {
                CategoryId = "44356",
                UpdatedFields = new Dictionary<string, object>
                {
                    { "IsFeatured", false }
                }
            };
            categoryExecutor.Execute(command5);

            await Task.Delay(1000, stoppingToken);
        }
    }
}