using Microsoft.EntityFrameworkCore;

namespace Proy_I.Models
{
    public class UniversidadContext : DbContext
    {
        protected readonly IConfiguration configuration;

        public DbSet<DocenteModel> docenteModel { get; set; }
        public DbSet<EstudianteModel> estudianteModel { get; set; }

        public UniversidadContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(configuration.GetConnectionString("MysqlConnectionContext"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DocenteModel>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.nombre).IsRequired();
            });

            modelBuilder.Entity<EstudianteModel>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.nombre).IsRequired();
            });
        }
    }
}
