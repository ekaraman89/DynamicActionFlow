public interface ICommandAction<TCommand> where TCommand : BaseUpdatedCommand
{
    void Execute(TCommand command);
    bool ShouldExecute(TCommand command);
}