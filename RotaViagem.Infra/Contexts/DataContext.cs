using Microsoft.EntityFrameworkCore;
using RotaViagem.Domain.Entities;
using RotaViagem.Infra.Mappings;

namespace RotaViagem.Infra.Contexts;

public class DataContext : DbContext
{
    public DataContext() { }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options) { }

    public DbSet<Rota> Rotas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new RotaMap());
    }
}