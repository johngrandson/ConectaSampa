using dotnet.DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace dotnet.DataAccess
{
    public class BusHelperContext : DbContext
    {
        public BusHelperContext(DbContextOptions<BusHelperContext> options) : base(options)
        {
        }

        public DbSet<Veiculo> veiculos { get; set; }
        public DbSet<Sensor> sensores { get; set; }
        public DbSet<HistoricoSensor> historicoSensores { get; set; }
        public DbSet<Feedback> feedbacks { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<PontoDeOnibus> pontosDeOnibus { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Veiculo>().ToTable("veiculos");
            modelBuilder.Entity<Sensor>().ToTable("sensores");
            modelBuilder.Entity<HistoricoSensor>().ToTable("historicoSensores");
            modelBuilder.Entity<Feedback>().ToTable("feedbacks");
            modelBuilder.Entity<Usuario>().ToTable("usuarios");
            modelBuilder.Entity<PontoDeOnibus>().ToTable("pontosDeOnibus");


        }
    }
}