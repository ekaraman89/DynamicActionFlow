using System.Linq.Expressions;

public class CommandActionConfiguration<TCommand> where TCommand : BaseUpdatedCommand
{
    private readonly List<(Func<TCommand, bool> condition, ICommandAction<TCommand> action)> _configurations = new();

    public CommandActionConfiguration<TCommand> For(Expression<Func<TCommand, object>> propertyExpression, ICommandAction<TCommand> action)
    {
        string propertyName = GetPropertyName(propertyExpression);
        _configurations.Add((command => IsFieldUpdated(command, propertyName), action));
        return this;
    }

    public CommandActionConfiguration<TCommand> For(Expression<Func<TCommand, bool>> condition, ICommandAction<TCommand> action)
    {
        _configurations.Add((condition.Compile(), action));
        return this;
    }

    public IEnumerable<ICommandAction<TCommand>> GetActionsToExecute(TCommand command)
    {
        return _configurations
            .Where(config => config.condition(command))
            .Select(config => config.action);           
    }


    private bool IsFieldUpdated(TCommand command, string propertyName)
    {
        return command.UpdatedFields.ContainsKey(propertyName);
    }
    private string GetPropertyName(Expression<Func<TCommand, object>> propertyExpression)
    {
        if (propertyExpression.Body is MemberExpression memberExpression)
        {
            return memberExpression.Member.Name;
        }
        throw new ArgumentException("Expression is not a property", nameof(propertyExpression));
    }
    
}





/// ///////////////////////////


// public class PropertyChangeAction<TCommand> : IPropertyChangeAction<TCommand> where TCommand : BaseCommand
// {
//     private readonly List<(Func<TCommand, bool> condition, IPropertyChangeAction<TCommand> action)> _configurations;

//     public PropertyChangeAction(List<(Func<TCommand, bool> condition, IPropertyChangeAction<TCommand> action)> configurations)
//     {
//         _configurations = configurations;
//     }

//     public void Execute(TCommand command)
//     {
//         foreach (var (condition, action) in _configurations)
//         {
//             if (condition(command))
//             {
//                 action.Execute(command);
//             }
//         }
//     }

//     public bool ShouldExecute(TCommand command)
//     {
//         foreach (var (condition, action) in _configurations)
//         {
//             if (condition(command))
//             {
//                 return true;
//             }
//         }
//         return false;
//     }
// }
