using Microsoft.AspNetCore.Mvc;
using RotaViagem.Api.Controllers;
using RotaViagem.Application.Commands.Rotas;
using RotaViagem.Application.Handlers.Rotas;
using RotaViagem.Domain.Repositories;
using RotaViagem.Tests.Application.Repositories;

namespace RotaViagem.Tests.Api.Controllers;

[TestClass]
public class RotaControllerTests
{
    private readonly IRotaRepository _repository;
    private readonly RotaCreateHandler _rotaCreateHandler;
    private readonly RotaUpdateHandler _rotaUpdateHandler;
    private readonly RotaDeleteHandler _rotaDeleteHandler;
    private readonly RotaGetAllHandler _rotaGetAllHandler;
    private readonly RotaGetByIdHandler _rotaGetByIdHandler;
    private readonly RotaGetMelhorRotaHandler _rotaGetMelhorRotaHandler;
    private readonly RotaController _controller;

    public RotaControllerTests()
    {
        _repository = new MockRotaRepository();
        _rotaCreateHandler = new RotaCreateHandler(_repository);
        _rotaUpdateHandler = new RotaUpdateHandler(_repository);
        _rotaDeleteHandler = new RotaDeleteHandler(_repository);
        _rotaGetAllHandler = new RotaGetAllHandler(_repository);
        _rotaGetByIdHandler = new RotaGetByIdHandler(_repository);
        _rotaGetMelhorRotaHandler = new RotaGetMelhorRotaHandler(_repository);

        _controller = new RotaController(
            _rotaCreateHandler, _rotaUpdateHandler,
            _rotaDeleteHandler, _rotaGetAllHandler,
            _rotaGetByIdHandler, _rotaGetMelhorRotaHandler
        );
    }

    [TestMethod]
    public async Task AoChamarGetAllAsyncDeveRetornarOkResult()
    {
        var result = await _controller.GetAllAsync();

        Assert.IsInstanceOfType(result, typeof(OkObjectResult));
    }

    [TestMethod]
    public async Task AoChamarGetByIdAsyncDeveRetornarOkObjectResult()
    {
        var result = await _controller.GetByIdAsync(Guid.NewGuid());

        Assert.IsInstanceOfType(result, typeof(OkObjectResult));
    }

    [TestMethod]
    public async Task AoChamarGetMelhorRotaAsyncValidoDeveRetornarOkObjectResult()
    {
        var result = await _controller.GetMelhorRotaAsync("origem", "destino");

        Assert.IsInstanceOfType(result, typeof(OkObjectResult));
    }

    [TestMethod]
    public async Task AoChamarGetMelhorRotaAsyncInvalidoDeveRetornarBadRequestObjectResult()
    {
        var result = await _controller.GetMelhorRotaAsync("", "");

        Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
    }

    [TestMethod]
    public async Task AoChamarCreateAsyncValidoDeveRetornarOkObjectResult()
    {
        var command = new RotaCreateCommand
        {
            Origem = "Origem",
            Destino = "Destino",
            Preco = 10
        };

        var result = await _controller.CreateAsync(command);

        Assert.IsInstanceOfType(result, typeof(OkObjectResult));
    }

    [TestMethod]
    public async Task AoChamarCreateAsyncInvalidoDeveRetornarBadRequestObjectResult()
    {
        var command = new RotaCreateCommand();

        var result = await _controller.CreateAsync(command);

        Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
    }

    [TestMethod]
    public async Task AoChamarUpdateAsyncValidoDeveRetornarOkObjectResult()
    {
        var command = new RotaUpdateCommand
        {
            Id = Guid.Parse("349397A3-EC14-4720-A3A1-03769B9373C4"),
            Origem = "Origem",
            Destino = "Destino",
            Preco = 10
        };

        var result = await _controller.UpdateAsync(command);

        Assert.IsInstanceOfType(result, typeof(OkObjectResult));
    }

    [TestMethod]
    public async Task AoChamarUpdateAsyncInvalidoDeveRetornarBadRequestObjectResult()
    {
        var command = new RotaUpdateCommand();

        var result = await _controller.UpdateAsync(command);

        Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
    }

    [TestMethod]
    public async Task AoChamarDeleteAsyncValidoDeveRetornarOkObjectResult()
    {
        var command = new RotaDeleteCommand
        {
            Id = Guid.Parse("349397A3-EC14-4720-A3A1-03769B9373C4")
        };

        var result = await _controller.DeleteAsync(command);

        Assert.IsInstanceOfType(result, typeof(OkObjectResult));
    }

    [TestMethod]
    public async Task AoChamarDeleteAsyncInvalidoDeveRetornarBadRequestObjectResult()
    {
        var command = new RotaDeleteCommand();

        var result = await _controller.DeleteAsync(command);

        Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
    }
}