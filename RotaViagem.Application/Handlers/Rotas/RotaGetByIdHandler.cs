using RotaViagem.Application.Commands;
using RotaViagem.Application.Commands.Results;
using RotaViagem.Application.Queries.Results;
using RotaViagem.Application.Queries.Rotas;
using RotaViagem.Domain.Repositories;

namespace RotaViagem.Application.Handlers.Rotas;

public class RotaGetByIdHandler : IQueryHandler<RotaGetByIdQuery>
{
    private readonly IRotaRepository _rotaRepository;

    public RotaGetByIdHandler(IRotaRepository rotaRepository)
    {
        _rotaRepository = rotaRepository;
    }

    public async Task<ICommandResult> Execute(RotaGetByIdQuery command)
    {
        command.Validar();
        if (command.ExisteErro)
        {
            return new CommandResult(false, "Dados de busca incorretos", command.Erros);
        }

        var rota = await _rotaRepository.GetByIdAsync(command.Id);
        return new QueriesResult(true, rota);
    }
}