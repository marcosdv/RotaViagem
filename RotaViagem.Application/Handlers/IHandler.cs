using RotaViagem.Application.Commands;

namespace RotaViagem.Application.Handlers;

public interface IHandler<T> where T : ICommands
{
    Task<ICommandResult> Execute(T command);
}