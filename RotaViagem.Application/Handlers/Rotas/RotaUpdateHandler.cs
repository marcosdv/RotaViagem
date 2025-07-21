using RotaViagem.Application.Commands;
using RotaViagem.Application.Commands.Results;
using RotaViagem.Application.Commands.Rotas;
using RotaViagem.Domain.Repositories;

namespace RotaViagem.Application.Handlers.Rotas;

public class RotaUpdateHandler : IHandler<RotaUpdateCommand>
{
    private readonly IRotaRepository _rotaRepository;

    public RotaUpdateHandler(IRotaRepository rotaRepository)
    {
        _rotaRepository = rotaRepository;
    }

    public async Task<ICommandResult> Execute(RotaUpdateCommand command)
    {
        command.Validar();
        if (command.ExisteErro)
        {
            return new CommandResult(false, "Dados da rota incorretos", command.Erros);
        }

        var rota = await _rotaRepository.GetByIdAsync(command.Id);

        if (rota == null)
        {
            return new CommandResult(false, "Rota não encontrada", command.Erros);
        }

        rota.Update(command.Origem, command.Destino, command.Preco);

        await _rotaRepository.UpdateAsync(rota);

        return new CommandResult(true, "Rota atualizada", rota);
    }
}