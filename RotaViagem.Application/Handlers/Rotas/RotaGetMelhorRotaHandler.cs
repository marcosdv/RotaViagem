using RotaViagem.Application.Commands;
using RotaViagem.Application.Commands.Results;
using RotaViagem.Application.Queries.Results;
using RotaViagem.Application.Queries.Rotas;
using RotaViagem.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaViagem.Application.Handlers.Rotas;

public class RotaGetMelhorRotaHandler : IQueryHandler<RotaGetMelhorRotaQuery>
{
    private readonly IRotaRepository _rotaRepository;

    public RotaGetMelhorRotaHandler(IRotaRepository rotaRepository)
    {
        _rotaRepository = rotaRepository;
    }

    public async Task<ICommandResult> Execute(RotaGetMelhorRotaQuery command)
    {
        command.Validar();
        if (command.ExisteErro)
        {
            return new CommandResult(false, "Dados de busca incorretos", command.Erros);
        }

        var rotas = await _rotaRepository.GetAllAsync();
        return new QueriesResult(true, rotas);
    }
}