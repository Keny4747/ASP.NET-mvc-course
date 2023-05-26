using Microsoft.EntityFrameworkCore;
namespace Tarea02.Models
{
    public class ApplicationContext:DbContext
    {
        protected readonly IConfiguration configuration;
        public DbSet<LibroModel> librosCollection { get; set; }

        public ApplicationContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseMySQL(configuration.GetConnectionString("MysqlDatabase"));
        }
    }
}
