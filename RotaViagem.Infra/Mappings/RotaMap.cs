using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RotaViagem.Domain.Entities;

namespace RotaViagem.Infra.Mappings;

public class RotaMap : IEntityTypeConfiguration<Rota>
{
    public void Configure(EntityTypeBuilder<Rota> builder)
    {
        builder.ToTable("TbRota");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("RotId");

        builder.Property(x => x.Origem)
            .HasColumnName("RotOrigem")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Destino)
            .HasColumnName("RotDestino")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Preco)
            .HasColumnName("RotPreco")
            .IsRequired();
    }
}