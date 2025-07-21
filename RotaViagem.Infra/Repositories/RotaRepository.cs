using Microsoft.EntityFrameworkCore;
using RotaViagem.Domain.Entities;
using RotaViagem.Domain.Repositories;
using RotaViagem.Infra.Contexts;

namespace RotaViagem.Infra.Repositories
{
    public class RotaRepository : IRotaRepository
    {
        private readonly DataContext _context;

        public RotaRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Rota?> GetByIdAsync(Guid id)
        {
            return await _context.Rotas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Rota>> GetAllAsync()
        {
            return await _context.Rotas.ToListAsync();
        }

        public async Task AddAsync(Rota rota)
        {
            await _context.Rotas.AddAsync(rota);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Rota rota)
        {
            _context.Rotas.Update(rota);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Rota rota)
        {
            _context.Rotas.Remove(rota);
            await _context.SaveChangesAsync();
        }
    }
}