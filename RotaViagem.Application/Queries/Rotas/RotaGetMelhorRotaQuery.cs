using RotaViagem.Application.Validations;

namespace RotaViagem.Application.Queries.Rotas;

public class RotaGetMelhorRotaQuery : Notificavel, IQueries
{
    public string Origem { get; set; } = string.Empty;
    public string Destino { get; set; } = string.Empty;

    public void Validar()
    {
        if (string.IsNullOrWhiteSpace(Origem))
        {
            AddErro("A Origem da rota é obrigatória!");
        }
        if (string.IsNullOrWhiteSpace(Destino))
        {
            AddErro("O Destino da rota é obrigatório!");
        }
    }
}