using RotaViagem.Application.Commands.Results;
using RotaViagem.Application.Handlers.Rotas;
using RotaViagem.Application.Queries.Results;
using RotaViagem.Application.Queries.Rotas;
using RotaViagem.Domain.Repositories;
using RotaViagem.Tests.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotaViagem.Tests.Application.Handlers.Rotas;

[TestClass]
public class RotaGetMelhorRotaHandlerTests
{
    private readonly IRotaRepository _repository;
    private readonly RotaGetMelhorRotaHandler _handler;

    public RotaGetMelhorRotaHandlerTests()
    {
        _repository = new MockRotaRepository();
        _handler = new RotaGetMelhorRotaHandler(_repository);
    }

    [TestMethod]
    public async Task DadoUmComandoValidoDeveRetornarSucessoTrue()
    {
        var command = new RotaGetMelhorRotaQuery
        {
            Origem = "GRU",
            Destino = "CDG"
        };

        var result = await _handler.Execute(command);

        Assert.IsTrue(((QueriesResult)result).Sucesso);
    }

    [TestMethod]
    public async Task DadoUmComandoValidoSemRotaExistenteDeveRetornarSucessoTrue()
    {
        var command = new RotaGetMelhorRotaQuery
        {
            Origem = "CDG",
            Destino = "GRU"
        };

        var result = await _handler.Execute(command);

        Assert.IsTrue(((QueriesResult)result).Sucesso);
    }

    [TestMethod]
    public async Task DadoUmComandoValidoOrigemInexistenteDeveRetornarSucessoTrue()
    {
        var command = new RotaGetMelhorRotaQuery
        {
            Origem = "Teste",
            Destino = "CDG"
        };

        var result = await _handler.Execute(command);

        Assert.IsTrue(((QueriesResult)result).Sucesso);
    }

    [TestMethod]
    public async Task DadoUmComandoValidoDestinoInexistenteDeveRetornarSucessoTrue()
    {
        var command = new RotaGetMelhorRotaQuery
        {
            Origem = "GRU",
            Destino = "Teste"
        };

        var result = await _handler.Execute(command);

        Assert.IsTrue(((QueriesResult)result).Sucesso);
    }

    [TestMethod]
    public async Task DadoUmComandoInvalidoSemOrigemDeveRetornarSucessoFalse()
    {
        var command = new RotaGetMelhorRotaQuery
        {
            Destino = "Destino"
        };

        var result = await _handler.Execute(command);

        Assert.IsFalse(((CommandResult)result).Sucesso);
    }

    [TestMethod]
    public async Task DadoUmComandoInvalidoSemDestinoDeveRetornarSucessoFalse()
    {
        var command = new RotaGetMelhorRotaQuery
        {
            Origem = "Origem"
        };

        var result = await _handler.Execute(command);

        Assert.IsFalse(((CommandResult)result).Sucesso);
    }
}