using RotaViagem.Application.Handlers.Rotas;
using RotaViagem.Application.Queries.Results;
using RotaViagem.Application.Queries.Rotas;
using RotaViagem.Domain.Repositories;
using RotaViagem.Tests.Application.Repositories;

namespace RotaViagem.Tests.Application.Handlers.Rotas;

[TestClass]
public class RotaGetAllHandlerTests
{
    private readonly IRotaRepository _repository;
    private readonly RotaGetAllHandler _handler;

    public RotaGetAllHandlerTests()
    {
        _repository = new MockRotaRepository();
        _handler = new RotaGetAllHandler(_repository);
    }

    [TestMethod]
    public async Task DadoUmComandoValidoDeveRetornarSucessoTrue()
    {
        var command = new RotaGetAllQuery();

        var result = await _handler.Execute(command);

        Assert.IsTrue(((QueriesResult)result).Sucesso);
    }
}