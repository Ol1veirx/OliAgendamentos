using Microsoft.EntityFrameworkCore;
using OliAgendamentos.Models;

namespace OliAgendamentos.Data
{
    public class OAContext : DbContext
    {
        public OAContext(DbContextOptions<OAContext> options) : base(options) { }

        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set;}
    }
}
