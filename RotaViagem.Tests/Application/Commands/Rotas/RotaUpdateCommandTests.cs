using RotaViagem.Application.Commands.Rotas;

namespace RotaViagem.Tests.Application.Commands.Rotas;

[TestClass]
public class RotaUpdateCommandTests
{
    [TestMethod]
    public void DadoUmComandoValidoDeveRetornarSemErro()
    {
        var command = new RotaUpdateCommand
        {
            Id = Guid.NewGuid(),
            Origem = "Origem",
            Destino = "Destino",
            Preco = 10
        };

        command.Validar();

        Assert.IsTrue(command.SemErro);
    }

    [TestMethod]
    public void DadoUmComandoSemIdDeveRetornarExisteErro()
    {
        var command = new RotaUpdateCommand
        {
            Origem = "Origem",
            Destino = "Destino",
            Preco = 10
        };

        command.Validar();

        Assert.IsTrue(command.ExisteErro);
        Assert.IsTrue(command.Erros.Any());
    }

    [TestMethod]
    public void DadoUmComandoSemOrigemDeveRetornarExisteErro()
    {
        var command = new RotaUpdateCommand
        {
            Id = Guid.NewGuid(),
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
        var command = new RotaUpdateCommand
        {
            Id = Guid.NewGuid(),
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
        var command = new RotaUpdateCommand
        {
            Id = Guid.NewGuid(),
            Origem = "Origem",
            Destino = "Destino"
        };

        command.Validar();

        Assert.IsTrue(command.ExisteErro);
        Assert.IsTrue(command.Erros.Any());
    }
}