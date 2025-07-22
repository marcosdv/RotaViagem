namespace RotaViagem.Application.Queries.Response;

public class MelhorRotaResponse
{
    public string Resposta { get; set; } = string.Empty;
    public string Rota { get; set; } = string.Empty;
    public double PrecoTotal { get; set; }
}