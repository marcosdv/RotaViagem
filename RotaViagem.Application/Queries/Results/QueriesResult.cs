using RotaViagem.Application.Commands;

namespace RotaViagem.Application.Queries.Results;

public class QueriesResult : ICommandResult
{
    public QueriesResult(bool sucesso, object? dados)
    {
        Sucesso = sucesso;
        Dados = dados;
    }

    public bool Sucesso { get; set; }
    public object? Dados { get; set; }
}