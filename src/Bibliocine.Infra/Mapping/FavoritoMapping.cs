using Bibliocine.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bibliocine.Infra.Mapping;

public class FavoritoMapping : IEntityTypeConfiguration<Favorito>
{
    public void Configure(EntityTypeBuilder<Favorito> builder)
    {
        builder.ToTable("Favoritos");

        builder.HasKey(p => p.Id);
            
        builder.Property(p => p.Id)
            .HasColumnName("id")
            .HasColumnType("varchar(36)")
            .IsRequired();

        builder.Property(p => p.TipoObra)
            .HasColumnName("tipoObra")
            .HasColumnType("int")
            .IsRequired();
        
        builder.Property(p => p.ObraId)
            .HasColumnName("obraId")
            .HasColumnType("varchar(36)")
            .IsRequired();
        
        builder.Property(p => p.UsuarioId)
            .HasColumnName("usuarioId")
            .HasColumnType("varchar(36)")
            .IsRequired();
    }
}