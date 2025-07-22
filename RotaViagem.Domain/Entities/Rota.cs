namespace RotaViagem.Domain.Entities;

public class Rota
{
    public Guid Id { get; set; }
    public string Origem { get; set; } = string.Empty;
    public string Destino { get; set; } = string.Empty;
    public double Preco { get; set; }

    // Construtor privado para EF Core
    private Rota() { }

    public Rota(Guid id, string origem, string destino, double preco)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Campo Id deve ser maior que zero.");
        }
        ValidarObrigatorios(origem, destino, preco);

        Id = id;
        Origem = origem;
        Destino = destino;
        Preco = preco;
    }

    public void Update(string origem, string destino, double preco)
    {
        ValidarObrigatorios(origem, destino, preco);

        Origem = origem;
        Destino = destino;
        Preco = preco;
    }

    private void ValidarObrigatorios(string origem, string destino, double preco)
    {
        if (string.IsNullOrWhiteSpace(origem))
        {
            throw new ArgumentException("Campo Origem é obrigatório.");
        }
        if (string.IsNullOrWhiteSpace(destino))
        {
            throw new ArgumentException("Campo Destino é obrigatório.");
        }
        if (preco <= 0)
        {
            throw new ArgumentException("Campo Preço deve ser maior que zero.");
        }
    }
}