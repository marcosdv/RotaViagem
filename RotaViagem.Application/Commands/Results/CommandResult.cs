namespace RotaViagem.Application.Commands.Results;

public class CommandResult : ICommandResult
{
    public CommandResult(bool sucesso, string mensagem, object dados)
    {
        Sucesso = sucesso;
        Mensagem = mensagem;
        Dados = dados;
    }

    public bool Sucesso { get; set; }
    public string Mensagem { get; set; }
    public object Dados { get; set; }
}