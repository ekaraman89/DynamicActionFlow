public static class ActionExecutorFactory
{
    public static PropertyChangeActionExecutor<BrandUpdatedCommand> CreateBrandExecutor(ILoggerFactory loggerFactory)
    {
        var configuration = new CommandActionConfiguration<BrandUpdatedCommand>()
            .For(command => command.UpdatedFields.ContainsKey("Name"), 
                 new BrandNameChangeAction(loggerFactory.CreateLogger<BrandNameChangeAction>()))
            .For(command => command.UpdatedFields.ContainsKey("Description"), 
                 new BrandDescriptionChangeAction(loggerFactory.CreateLogger<BrandDescriptionChangeAction>()));

        return new PropertyChangeActionExecutor<BrandUpdatedCommand>(configuration);
    }

    public static PropertyChangeActionExecutor<CategoryUpdatedCommand> CreateCategoryExecutor(ILoggerFactory loggerFactory)
    {
        var configuration = new CommandActionConfiguration<CategoryUpdatedCommand>()
            .For(command => command.UpdatedFields.ContainsKey("Name"), 
                 new CategoryNameChangeAction(loggerFactory.CreateLogger<CategoryNameChangeAction>()))
            .For(command => command.UpdatedFields.ContainsKey("Description"), 
                 new CategoryDescriptionChangeAction(loggerFactory.CreateLogger<CategoryDescriptionChangeAction>()))
            .For(command => command.UpdatedFields.ContainsKey("IsActive"), 
                 new CategoryIsActiveChangeAction(loggerFactory.CreateLogger<CategoryIsActiveChangeAction>()))
            .For(command => command.UpdatedFields.ContainsKey("IsFeatured") && command.UpdatedFields["IsFeatured"] is bool && (bool)command.UpdatedFields["IsFeatured"],
                 new CategoryIsFeaturedChangeAction(loggerFactory.CreateLogger<CategoryIsFeaturedChangeAction>()));

        return new PropertyChangeActionExecutor<CategoryUpdatedCommand>(configuration);
    }

    // Diğer executor'lar için benzer metotlar ekleyebilirsiniz
}
