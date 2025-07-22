using RotaViagem.Application.Commands.Results;
using RotaViagem.Application.Commands.Rotas;
using RotaViagem.Application.Handlers.Rotas;
using RotaViagem.Domain.Repositories;
using RotaViagem.Tests.Application.Repositories;

namespace RotaViagem.Tests.Application.Handlers.Rotas;

[TestClass]
public class RotaDeleteHandlerTests
{
    private readonly IRotaRepository _repository;
    private readonly RotaDeleteHandler _handler;

    public RotaDeleteHandlerTests()
    {
        _repository = new MockRotaRepository();
        _handler = new RotaDeleteHandler(_repository);
    }

    [TestMethod]
    public async Task DadoUmComandoValidoDeveRetornarSucessoTrue()
    {
        var command = new RotaDeleteCommand
        {
            Id = Guid.Parse("D4FE6D84-AC05-4F36-8588-1578A56BDA97"),
        };

        var result = await _handler.Execute(command);

        Assert.IsTrue(((CommandResult)result).Sucesso);
    }

    [TestMethod]
    public async Task DadoUmComandoInvalidoDeveRetornarSucessoFalse()
    {
        var command = new RotaDeleteCommand();

        var result = await _handler.Execute(command);

        Assert.IsFalse(((CommandResult)result).Sucesso);
    }
}