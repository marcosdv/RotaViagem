using RotaViagem.Application.Commands.Rotas;

namespace RotaViagem.Tests.Application.Commands.Rotas;

[TestClass]
public class RotaCreateCommandTests
{
    [TestMethod]
    public void DadoUmComandoValidoDeveRetornarSemErro()
    {
        var command = new RotaCreateCommand
        {
            Origem = "Origem",
            Destino = "Destino",
            Preco = 10
        };

        command.Validar();

        Assert.IsTrue(command.SemErro);
    }

    [TestMethod]
    public void DadoUmComandoSemOrigemDeveRetornarExisteErro()
    {
        var command = new RotaCreateCommand
        {
            Destino = "Destino",
            Preco = 10
        };

        command.Validar();

        Assert.IsTrue(command.ExisteErro);
        Assert.IsTrue(command.Erros.Any());
    }

    [TestMethod]
    public void DadoUmComandoSemDestinoDeveRetornarExisteErro()
    {
        var command = new RotaCreateCommand
        {
            Origem = "Origem",
            Preco = 10
        };

        command.Validar();

        Assert.IsTrue(command.ExisteErro);
        Assert.IsTrue(command.Erros.Any());
    }

    [TestMethod]
    public void DadoUmComandoSemPrecoDeveRetornarExisteErro()
    {
        var command = new RotaCreateCommand
        {
            Origem = "Origem",
            Destino = "Destino"
        };

        command.Validar();

        Assert.IsTrue(command.ExisteErro);
        Assert.IsTrue(command.Erros.Any());
    }
}