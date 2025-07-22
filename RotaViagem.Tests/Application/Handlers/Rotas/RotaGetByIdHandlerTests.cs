using RotaViagem.Application.Commands.Results;
using RotaViagem.Application.Handlers.Rotas;
using RotaViagem.Application.Queries.Results;
using RotaViagem.Application.Queries.Rotas;
using RotaViagem.Domain.Repositories;
using RotaViagem.Tests.Application.Repositories;

namespace RotaViagem.Tests.Application.Handlers.Rotas;

[TestClass]
public class RotaGetByIdHandlerTests
{
    private readonly IRotaRepository _repository;
    private readonly RotaGetByIdHandler _handler;

    public RotaGetByIdHandlerTests()
    {
        _repository = new MockRotaRepository();
        _handler = new RotaGetByIdHandler(_repository);
    }

    [TestMethod]
    public async Task DadoUmComandoValidoDeveRetornarSucessoTrue()
    {
        var command = new RotaGetByIdQuery
        {
            Id = Guid.Parse("D4FE6D84-AC05-4F36-8588-1578A56BDA97"),
        };

        var result = await _handler.Execute(command);

        Assert.IsTrue(((QueriesResult)result).Sucesso);
    }

    [TestMethod]
    public async Task DadoUmComandoInvalidoDeveRetornarSucessoFalse()
    {
        var command = new RotaGetByIdQuery();

        var result = await _handler.Execute(command);

        Assert.IsFalse(((CommandResult)result).Sucesso);
    }
}