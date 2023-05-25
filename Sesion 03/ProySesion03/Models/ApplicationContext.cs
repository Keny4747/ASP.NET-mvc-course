using Microsoft.EntityFrameworkCore;

namespace ProySesion03.Models
{ 
    public class ApplicationContext:DbContext
    {
        protected readonly IConfiguration configuration;
        public DbSet<VentaModel> ventasCollection { get; set; }

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
