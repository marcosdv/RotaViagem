using RotaViagem.Application.Validations;

namespace RotaViagem.Application.Commands.Rotas;

public class RotaDeleteCommand: Notificavel, ICommands
{
    public int Id { get; set; }

    public void Validar()
    {
        if (Id <= 0)
        {
            AddErro("O Código da rota é obrigatória!");
        }
    }
}