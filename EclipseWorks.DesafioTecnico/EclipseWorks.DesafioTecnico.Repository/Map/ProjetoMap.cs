using EclipseWorks.DesafioTecnico.Domain.Projetos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EclipseWorks.DesafioTecnico.Repository.Map;
public class ProjetoMap : IEntityTypeConfiguration<Projeto>
{
    public void Configure(EntityTypeBuilder<Projeto> builder)
    {
        builder.ToTable("Projetos");

        builder.HasKey(e => e.Id);
        builder.Property(p => p.Nome).IsRequired().HasMaxLength(255);
        builder.Property(p => p.DataCriacao).IsRequired();

        builder.Property(a => a.isExcluido).IsRequired();

        builder.HasOne(a => a.Usuario)
            .WithMany(usuario => usuario.Projetos)
            .HasForeignKey(a => a.IdUsuario)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(p => p.Tarefas)
            .WithOne(t => t.Projeto)
            .HasForeignKey(t => t.IdProjeto)
            .OnDelete(DeleteBehavior.Cascade);
    }
}