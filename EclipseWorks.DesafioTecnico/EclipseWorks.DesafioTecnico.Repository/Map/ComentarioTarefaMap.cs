using EclipseWorks.DesafioTecnico.Domain.Tarefas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EclipseWorks.DesafioTecnico.Repository.Map;

internal class ComentarioTarefaMap : IEntityTypeConfiguration<ComentarioTarefa>
{
    public void Configure(EntityTypeBuilder<ComentarioTarefa> builder)
    {
        builder.ToTable("ComentarioTarefa");

        builder.HasKey(a => a.Id);
        builder.Property(p => p.Comentario).IsRequired().HasMaxLength(500);
        builder.Property(p => p.DataCriacao).IsRequired();

        builder.HasOne(t => t.Usuario)
            .WithMany(p => p.Comentarios)
            .HasForeignKey(t => t.IdUsuario)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(t => t.Tarefa)
            .WithMany(p => p.Comentarios)
            .HasForeignKey(t => t.IdTarefa)
            .OnDelete(DeleteBehavior.NoAction);
    }
}