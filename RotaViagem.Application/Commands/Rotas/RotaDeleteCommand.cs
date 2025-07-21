using RotaViagem.Application.Validations;

namespace RotaViagem.Application.Commands.Rotas;

public class RotaDeleteCommand: Notificavel, ICommands
{
    public Guid Id { get; set; }

    public void Validar()
    {
        if (Id == Guid.Empty)
        {
            AddErro("O Código da rota é obrigatório!");
        }
    }
}