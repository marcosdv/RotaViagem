using RotaViagem.Application.Validations;

namespace RotaViagem.Application.Commands.Rotas;

public class RotaUpdateCommand: Notificavel, ICommands
{
    public int Id { get; set; }
    public string Origem { get; set; } = string.Empty;
    public string Destino { get; set; } = string.Empty;
    public double Preco { get; set; }

    public void Validar()
    {
        if (Id <= 0)
        {
            AddErro("O Código da rota é obrigatória!");
        }
        if (string.IsNullOrWhiteSpace(Origem))
        {
            AddErro("A Origem da rota é obrigatória!");
        }
        if (string.IsNullOrWhiteSpace(Destino))
        {
            AddErro("O Destino da rota é obrigatório!");
        }
        if (Preco <= 0)
        {
            AddErro("O Preço da rota deve ser maior que zero!");
        }
    }
}