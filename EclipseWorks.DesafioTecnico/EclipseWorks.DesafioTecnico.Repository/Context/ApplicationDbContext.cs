using EclipseWorks.DesafioTecnico.Domain.Projetos;
using EclipseWorks.DesafioTecnico.Domain.Tarefas;
using EclipseWorks.DesafioTecnico.Domain.Usuarios;
using EclipseWorks.DesafioTecnico.Repository.Map;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EclipseWorks.DesafioTecnico.Repository.Context
{
    public  class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<HistoricoTarefa> HistoricoTarefas { get; set; }
        public DbSet<ComentarioTarefa> Comentarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProjetoMap());
            modelBuilder.ApplyConfiguration(new ComentarioTarefaMap());
            modelBuilder.ApplyConfiguration(new HistoricoTarefaMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }
    }
}
