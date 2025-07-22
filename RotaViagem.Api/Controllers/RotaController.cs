using Microsoft.AspNetCore.Mvc;
using RotaViagem.Application.Commands;
using RotaViagem.Application.Commands.Rotas;
using RotaViagem.Application.Handlers.Rotas;
using RotaViagem.Application.Queries.Rotas;

namespace RotaViagem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RotaController : ControllerBase
{
    private readonly RotaCreateHandler _rotaCreateHandler;
    private readonly RotaUpdateHandler _rotaUpdateHandler;
    private readonly RotaDeleteHandler _rotaDeleteHandler;
    private readonly RotaGetAllHandler _rotaGetAllHandler;
    private readonly RotaGetByIdHandler _rotaGetByIdHandler;

    public RotaController(RotaCreateHandler rotaCreateHandler, RotaUpdateHandler rotaUpdateHandler, RotaDeleteHandler rotaDeleteHandler, RotaGetAllHandler rotaGetAllHandler, RotaGetByIdHandler rotaGetByIdHandler)
    {
        _rotaCreateHandler = rotaCreateHandler;
        _rotaUpdateHandler = rotaUpdateHandler;
        _rotaDeleteHandler = rotaDeleteHandler;
        _rotaGetAllHandler = rotaGetAllHandler;
        _rotaGetByIdHandler = rotaGetByIdHandler;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _rotaGetAllHandler.Execute(new RotaGetAllQuery());
        return CreateResult(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var query = new RotaGetByIdQuery { Id = id };
        var result = await _rotaGetByIdHandler.Execute(query);
        return CreateResult(result);
    }

    [HttpGet("melhor-rota/{origem}/{destino}")]
    public async Task<IActionResult> GetMelhorRotaAsync(string origem, string destino)
    {
        var query = new RotaGetByIdQuery { Id = id };
        var result = await _rotaGetByIdHandler.Execute(query);
        return CreateResult(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(RotaCreateCommand command)
    {
        var result = await _rotaCreateHandler.Execute(command);
        return CreateResult(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(RotaUpdateCommand command)
    {
        var result = await _rotaUpdateHandler.Execute(command);
        return CreateResult(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(RotaDeleteCommand command)
    {
        var result = await _rotaDeleteHandler.Execute(command);
        return CreateResult(result);
    }

    private IActionResult CreateResult(ICommandResult result)
    {
        return result.Sucesso ? Ok(result) : BadRequest(result);
    }

    /*
    [HttpPost("cargaInicial")]
    public async Task<IActionResult> CargaInicialAsync()
    {
        var rota01 = new RotaCreateCommand { Origem = "GRU", Destino = "BRC", Preco = 10 };
        var rota02 = new RotaCreateCommand { Origem = "BRC", Destino = "SCL", Preco = 5 };
        var rota03 = new RotaCreateCommand { Origem = "GRU", Destino = "CDG", Preco = 75 };
        var rota04 = new RotaCreateCommand { Origem = "GRU", Destino = "SCL", Preco = 20 };
        var rota05 = new RotaCreateCommand { Origem = "GRU", Destino = "ORL", Preco = 56 };
        var rota06 = new RotaCreateCommand { Origem = "ORL", Destino = "CDG", Preco = 5 };
        var rota07 = new RotaCreateCommand { Origem = "SCL", Destino = "ORL", Preco = 20 };

        await _rotaCreateHandler.Execute(rota01);
        await _rotaCreateHandler.Execute(rota02);
        await _rotaCreateHandler.Execute(rota03);
        await _rotaCreateHandler.Execute(rota04);
        await _rotaCreateHandler.Execute(rota05);
        await _rotaCreateHandler.Execute(rota06);
        await _rotaCreateHandler.Execute(rota07);

        return Ok();
    }
    */
}