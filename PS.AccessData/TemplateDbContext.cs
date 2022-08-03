using Microsoft.EntityFrameworkCore;
using PS.Domain.Entities;
using PS.Domain.EntitiesConfiguration;

namespace PS.AccessData
{
    public class TemplateDbContext : DbContext
    {

        public TemplateDbContext(DbContextOptions<TemplateDbContext> options) : base(options)
        { }

        public DbSet<Funciones> Funciones { get; set; }
        public DbSet<Peliculas> Peliculas { get; set; }
        public DbSet<Salas> Salas { get; set; }
        public DbSet<Tickets> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Funciones>(new FuncionesConfiguration());
            modelBuilder.ApplyConfiguration<Peliculas>(new PeliculasConfiguration());
            modelBuilder.ApplyConfiguration<Salas>(new SalasConfiguration());
            modelBuilder.ApplyConfiguration<Tickets>(new TicketsConfiguration());
        }


    }
}
