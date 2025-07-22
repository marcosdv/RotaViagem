using RotaViagem.Application.Commands;
using RotaViagem.Application.Queries;

namespace RotaViagem.Application.Handlers;

public interface IQueryHandler<T> where T : IQueries
{
    Task<ICommandResult> Execute(T command);
}