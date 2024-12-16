using EclipseWorks.DesafioTecnico.Domain.Tarefas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EclipseWorks.DesafioTecnico.Repository.Map;
    public class HistoricoTarefaMap : IEntityTypeConfiguration<HistoricoTarefa>
    {
        public void Configure(EntityTypeBuilder<HistoricoTarefa> builder)
        {
            builder.ToTable("HistoricoAlteracaoTarefa");

            builder.HasKey(a => a.Id);

            builder.Property(p => p.DadosAlterados).IsRequired();
            builder.Property(p => p.Comentario).IsRequired().HasMaxLength(500);
            builder.Property(p => p.DataCriacao).IsRequired();

            builder.HasOne(t => t.Usuario)
                .WithMany(p => p.HistoricoAtualizacoesTarefa)
                .HasForeignKey(t => t.IdUsuario)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(t => t.Tarefa)
                .WithMany(p => p.HistoricoAtualizacoesTarefa)
                .HasForeignKey(t => t.IdTarefa)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }

