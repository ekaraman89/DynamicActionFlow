public class PropertyChangeActionExecutor<TCommand> where TCommand : BaseUpdatedCommand
{
    private readonly CommandActionConfiguration<TCommand> _configuration;

    public PropertyChangeActionExecutor(CommandActionConfiguration<TCommand> configuration)
    {
        _configuration = configuration;
    }

    public void Execute(TCommand command)
    {
        var actions = _configuration.GetActionsToExecute(command);
        foreach (var action in actions)
        {
            if (action.ShouldExecute(command))
            {
                action.Execute(command);
                break;
            }
        }
    }

}