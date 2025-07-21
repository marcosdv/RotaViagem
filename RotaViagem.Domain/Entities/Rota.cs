namespace RotaViagem.Domain.Entities;

public class Rota
{
    public int Id { get; set; }
    public string Origem { get; set; } = string.Empty;
    public string Destino { get; set; } = string.Empty;
    public double Preco { get; set; }

    // Construtor privado para EF Core
    private Rota() { }

    public Rota(int id, string origem, string destino, double preco)
    {
        if (id <= 0)
        {
            throw new ArgumentException("Campo Id deve ser maior que zero.");
        }
        ValidarObrigatorios();

        Id = id;
        Origem = origem;
        Destino = destino;
        Preco = preco;
    }

    public void Update(string origem, string destino, double preco)
    {
        ValidarObrigatorios();

        Origem = origem;
        Destino = destino;
        Preco = preco;
    }

    private void ValidarObrigatorios()
    {
        if (string.IsNullOrWhiteSpace(Origem))
        {
            throw new ArgumentException("Campo Origem é obrigatório.");
        }
        if (string.IsNullOrWhiteSpace(Destino))
        {
            throw new ArgumentException("Campo Destino é obrigatório.");
        }
        if (Preco <= 0)
        {
            throw new ArgumentException("Campo Preço deve ser maior que zero.");
        }
    }
}