using RotaViagem.Application.Commands.Results;
using RotaViagem.Application.Commands.Rotas;
using RotaViagem.Application.Handlers.Rotas;
using RotaViagem.Domain.Repositories;
using RotaViagem.Tests.Application.Repositories;

namespace RotaViagem.Tests.Application.Handlers.Rotas;

[TestClass]
public class RotaCreateHandlerTests
{
    private readonly IRotaRepository _repository;
    private readonly RotaCreateHandler _handler;
    
    public RotaCreateHandlerTests()
    {
        _repository = new MockRotaRepository();
        _handler = new RotaCreateHandler(_repository);
    }

    [TestMethod]
    public async Task DadoUmComandoValidoDeveRetornarSucessoTrue()
    {
        var command = new RotaCreateCommand
        {
            Origem = "Origem",
            Destino = "Destino",
            Preco = 10
        };

        var result = await _handler.Execute(command);

        Assert.IsTrue(((CommandResult)result).Sucesso);
    }

    [TestMethod]
    public async Task DadoUmComandoInvalidoDeveRetornarSucessoFalse()
    {
        var command = new RotaCreateCommand();

        var result = await _handler.Execute(command);

        Assert.IsFalse(((CommandResult)result).Sucesso);
    }
}