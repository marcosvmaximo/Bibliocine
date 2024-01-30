using Bibliocine.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bibliocine.Infra.Mapping;

public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuarios");

        builder.HasKey(p => p.Id);
            
        builder.Property(p => p.Id)
            .HasColumnName("id")
            .HasColumnType("varchar(36)")
            .IsRequired();

        builder.Property(p => p.Nome)
            .HasColumnName("nome")
            .HasColumnType("varchar(100)")
            .IsRequired();
        
        builder.Property(p => p.DataNascimento)
            .HasColumnName("data_nascimento")
            .HasColumnType("date")
            .IsRequired();

        builder.Property(p => p.Email)
            .HasColumnName("email")
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.HasMany(x => x.Favoritos)
            .WithOne(x => x.Usuario)
            .HasForeignKey(x => x.UsuarioId);
    }
}