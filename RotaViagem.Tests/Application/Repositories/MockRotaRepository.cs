using RotaViagem.Domain.Entities;
using RotaViagem.Domain.Repositories;

namespace RotaViagem.Tests.Application.Repositories;

public class MockRotaRepository : IRotaRepository
{
    private readonly IList<Rota> _rotas;

    public MockRotaRepository()
    {
        _rotas = [
            new Rota(Guid.NewGuid(), "GRU", "BRC", 10),
            new Rota(Guid.NewGuid(), "BRC", "SCL", 5),
            new Rota(Guid.NewGuid(), "GRU", "CDG", 75),
            new Rota(Guid.NewGuid(), "GRU", "SCL", 20),
            new Rota(Guid.NewGuid(), "GRU", "ORL", 56),
            new Rota(Guid.NewGuid(), "ORL", "CDG", 5),
            new Rota(Guid.NewGuid(), "SCL", "ORL", 20),
        ];
    }

    public Task<Rota?> GetByIdAsync(Guid id)
    {
        return Task.FromResult(_rotas.FirstOrDefault(r => r.Id == id));
    }

    public Task<IEnumerable<Rota>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<Rota>>(_rotas);
    }

    public Task AddAsync(Rota rota)
    {
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Rota rota)
    {
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Rota rota) 
    {
        return Task.CompletedTask;
    }
}