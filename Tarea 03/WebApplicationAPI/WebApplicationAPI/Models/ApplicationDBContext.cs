using Microsoft.EntityFrameworkCore;

namespace WebApplicationAPI.Models
{
    public class ApplicationDBContext: DbContext
    {
        private readonly IConfiguration configuration;


        public DbSet<LibroModel> libroCollection { get; set; }

        public ApplicationDBContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseMySQL(configuration.GetConnectionString("MysqlDatabase"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

     
            modelBuilder.Entity<LibroModel>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.titulo).IsRequired();
            });

        }
    }
}
