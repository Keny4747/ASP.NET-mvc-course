using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models
{
    public class ApplicationDBContext: DbContext
    {
        private readonly IConfiguration configuration;
        public DbSet<VentaModel> ventasCollection { get; set; }
        public DbSet<DetalleVentaModel> detalleVentasCollection { get; set; }
        public DbSet<ProductoModel> productosCollection { get; set; }
        public DbSet<UsuarioModel> usuariosCollection { get; set; }
        public DbSet<RolModel> rolesCollection { get; set; }
        public DbSet<UsuarioRolModel> usuarioRolsCollection { get; set; }

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

            modelBuilder.Entity<VentaModel>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.nombre).IsRequired();
            });

            modelBuilder.Entity<ProductoModel>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.nombre).IsRequired();
            });

            modelBuilder.Entity<DetalleVentaModel>(entity =>
            {
                entity.HasKey(e => e.id);
            });
            modelBuilder.Entity<UsuarioModel>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Ignore(e => e.roles);
                entity.HasMany(e => e.usuarioRoles).WithOne(a => a.usuario).HasForeignKey(q => q.usuario_id);
            });
            modelBuilder.Entity<RolModel>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.HasMany(e => e.usuarioRoles).WithOne(a => a.rol).HasForeignKey(q => q.rol_id);
            });
            modelBuilder.Entity<UsuarioRolModel>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.HasOne(e => e.usuario).WithMany(p => p.usuarioRoles).HasForeignKey(q => q.usuario_id);
                entity.HasOne(e => e.rol).WithMany(p => p.usuarioRoles).HasForeignKey(q => q.rol_id);
            });
        }
    }
}
