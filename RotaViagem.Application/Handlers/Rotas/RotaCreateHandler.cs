using RotaViagem.Application.Commands;
using RotaViagem.Application.Commands.Results;
using RotaViagem.Application.Commands.Rotas;
using RotaViagem.Domain.Entities;
using RotaViagem.Domain.Repositories;

namespace RotaViagem.Application.Handlers.Rotas;

public class RotaCreateHandler : IHandler<RotaCreateCommand>
{
    private readonly IRotaRepository _rotaRepository;

    public RotaCreateHandler(IRotaRepository rotaRepository)
    {
        _rotaRepository = rotaRepository;
    }

    public async Task<ICommandResult> Execute(RotaCreateCommand command)
    {
        command.Validar();
        if (command.ExisteErro)
        {
            return new CommandResult(false, "Dados da rota incorretos", command.Erros);
        }

        var rota = new Rota(Guid.NewGuid(), command.Origem, command.Destino, command.Preco);

        await _rotaRepository.AddAsync(rota);

        return new CommandResult(true, "Rota adicionada", rota);
    }
}