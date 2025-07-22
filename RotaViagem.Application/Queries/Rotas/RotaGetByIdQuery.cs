using RotaViagem.Application.Validations;

namespace RotaViagem.Application.Queries.Rotas;

public class RotaGetByIdQuery : Notificavel, IQueries {
    public Guid Id { get; set; }

    public void Validar()
    {
        if (Id == Guid.Empty)
        {
            AddErro("O Código da rota é obrigatório!");
        }
    }
}