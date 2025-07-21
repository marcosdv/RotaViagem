namespace RotaViagem.Application.Validations;

public abstract class Notificavel
{
    private readonly List<string> _listaErros;

    protected Notificavel()
    {
        _listaErros = new List<string>();
    }

    public void AddErro(string texto)
    {
        _listaErros.Add(texto);
    }

    public IReadOnlyCollection<string> Erros => _listaErros;

    public bool ExisteErro => _listaErros.Any();

    public bool SemErro => !ExisteErro;
}
