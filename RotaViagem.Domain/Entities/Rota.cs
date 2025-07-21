namespace RotaViagem.Domain.Entities;

public class Rota
{
    public int Id { get; set; }
    public string Origem { get; set; } = string.Empty;
    public string Destino { get; set; } = string.Empty;
    public double Preco { get; set; }
}
