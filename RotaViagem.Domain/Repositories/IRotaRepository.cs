using RotaViagem.Domain.Entities;

namespace RotaViagem.Domain.Repositories;

public interface IRotaRepository
{
    Task<Rota> GetByIdAsync(Guid id);
    Task<IEnumerable<Rota>> GetAllAsync();

    Task AddAsync(Rota route);
    Task UpdateAsync(Rota route);
    Task DeleteAsync(Rota route);
}