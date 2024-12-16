using EclipseWorks.DesafioTecnico.Domain.Usuarios;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EclipseWorks.DesafioTecnico.Repository.Map;

public class UsuarioMap : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuarios");

        builder.HasKey(e => e.Id);
        builder.Property(p => p.Nome).IsRequired().HasMaxLength(255);
        builder.Property(p => p.Email).IsRequired().HasMaxLength(255);
        builder.Property(p => p.DataCriacao).IsRequired();

        builder.HasMany(t => t.Comentarios)
            .WithOne(p => p.Usuario)
            .HasForeignKey(t => t.IdUsuario)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(t => t.HistoricoAtualizacoesTarefa)
            .WithOne(p => p.Usuario)
            .HasForeignKey(t => t.IdUsuario)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(t => t.Projetos)
            .WithOne(p => p.Usuario)
            .HasForeignKey(t => t.IdUsuario)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData
        (
            new Usuario("User 01", "user01@teste.com.br"),
            new Usuario("User 02", "user02@teste.com.br"),
            new Usuario("User 03", "user03@teste.com.br")
        );
    }
}