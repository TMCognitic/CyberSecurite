using Patterns.Results;

namespace Cqs.Commands
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommandDefinition
    {
        Result Execute(TCommand command);
    }
}
