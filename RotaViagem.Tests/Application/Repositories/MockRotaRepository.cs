using RotaViagem.Domain.Entities;
using RotaViagem.Domain.Repositories;

namespace RotaViagem.Tests.Application.Repositories;

public class MockRotaRepository : IRotaRepository
{
    private readonly IList<Rota> _rotas;

    public MockRotaRepository()
    {
        _rotas = [
            new Rota(Guid.Parse("349397A3-EC14-4720-A3A1-03769B9373C4"), "GRU", "BRC", 10),
            new Rota(Guid.Parse("60659B97-D739-4004-8C77-0DD8127F6F6A"), "BRC", "SCL", 5),
            new Rota(Guid.Parse("D4FE6D84-AC05-4F36-8588-1578A56BDA97"), "GRU", "CDG", 75),
            new Rota(Guid.Parse("4B2821E8-77A2-41F8-A2BB-19F6313C2A46"), "GRU", "SCL", 20),
            new Rota(Guid.Parse("79FB0204-ADE3-4AA5-9537-2EA9E5E9BB12"), "GRU", "ORL", 56),
            new Rota(Guid.Parse("4B8E5D48-21AF-49B5-93A6-3D80169BF4F2"), "ORL", "CDG", 5),
            new Rota(Guid.Parse("DDE82BB4-ACE9-406E-BD43-9D253A24DD58"), "SCL", "ORL", 20),
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