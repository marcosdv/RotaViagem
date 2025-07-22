using RotaViagem.Application.Commands;
using RotaViagem.Application.Queries.Results;
using RotaViagem.Application.Queries.Rotas;
using RotaViagem.Domain.Repositories;

namespace RotaViagem.Application.Handlers.Rotas;

public class RotaGetAllHandler : IQueryHandler<RotaGetAllQuery>
{
    private readonly IRotaRepository _rotaRepository;

    public RotaGetAllHandler(IRotaRepository rotaRepository)
    {
        _rotaRepository = rotaRepository;
    }

    public async Task<ICommandResult> Execute(RotaGetAllQuery command)
    {
        var rotas = await _rotaRepository.GetAllAsync();
        return new QueriesResult(true, rotas);
    }
}