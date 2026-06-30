using Patterns.Results;

namespace Cqs.Queries
{
    public interface IQueryHandler<TQuery, TResult>
        where TQuery : IQueryDefinition<TResult>
    {
        Result<TResult> Execute(TQuery query);
    }
}
