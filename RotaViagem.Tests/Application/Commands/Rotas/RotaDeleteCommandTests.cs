using RotaViagem.Application.Commands.Rotas;

namespace RotaViagem.Tests.Application.Commands.Rotas;

[TestClass]
public class RotaDeleteCommandTests
{
    [TestMethod]
    public void DadoUmComandoValidoDeveRetornarSemErro()
    {
        var command = new RotaDeleteCommand
        {
            Id = Guid.NewGuid()
        };

        command.Validar();

        Assert.IsTrue(command.SemErro);
    }

    [TestMethod]
    public void DadoUmComandoSemIdDeveRetornarExisteErro()
    {
        var command = new RotaDeleteCommand();

        command.Validar();

        Assert.IsTrue(command.ExisteErro);
        Assert.IsTrue(command.Erros.Any());
    }
}