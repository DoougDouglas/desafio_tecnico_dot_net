using EclipseWorks.DesafioTecnico.Domain.Tarefas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EclipseWorks.DesafioTecnico.Repository.Map;

    public class TarefaMap : IEntityTypeConfiguration<Tarefa>
{
    public void Configure(EntityTypeBuilder<Tarefa> builder)
    {
        builder.ToTable("Tarefas");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Titulo).IsRequired().HasMaxLength(255);
        builder.Property(t => t.Descricao).HasMaxLength(1000);

        builder.Property(t => t.DataVencimento).IsRequired();

        builder.Property(t => t.Status).IsRequired();
        builder.Property(t => t.Prioridade).IsRequired();

        builder.HasOne(t => t.Projeto)
            .WithMany(p => p.Tarefas)
            .HasForeignKey(t => t.IdProjeto)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(p => p.HistoricoAtualizacoesTarefa)
           .WithOne(t => t.Tarefa)
           .HasForeignKey(t => t.IdTarefa)
           .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(p => p.Comentarios)
           .WithOne(t => t.Tarefa)
           .HasForeignKey(t => t.IdTarefa)
           .OnDelete(DeleteBehavior.Cascade);

        builder.Property(a => a.isExcluido).IsRequired();
    }
}