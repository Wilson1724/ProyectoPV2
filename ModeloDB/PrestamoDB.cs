using Microsoft.EntityFrameworkCore;
using ModeloProyecto.Entidades;
namespace ModeloDB
{
    public class PrestamoDB : DbContext
    {
        //Declaración de las entidades del modelo
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Banco> Bancos { get; set; }
        public DbSet<Microempresario> Microempresarios { get; set; }
        public DbSet<MicroEmprendimiento> Microemprendimientos { get; set; }
        public DbSet<Garante> Garantes { get; set; }

        public DbSet<Solicitud> Solicitudes { get; set; }
        public DbSet<Recurso> Recursos { get; set; }
        //Configuración de la conección
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=WILSON\\SQLEXPRESS; Initial Catalog=Proyecto1 ;trusted_connection=true;");
        }
        //Configurar el modelo de objetos
        protected override void OnModelCreating(ModelBuilder model)
        {
            //Configuración de Banco
            //Cardinalidad de banco y prestamos 1-M
            model.Entity<Prestamo>()
                .HasOne(prestamo => prestamo.BancoPres)
                .WithMany(banco => banco.Prestamos)
                .HasForeignKey(prestamo => prestamo.BancoId);

            //Cardinalidad de banco y microempresario 1-M
            model.Entity<Microempresario>()
                .HasOne(microempresario => microempresario.BancoM)
                .WithMany(banco => banco.Microempresarios)
                .HasForeignKey(microempresario => microempresario.BancoId);

            //Cardinalidad de Microempresario y prestamo 1-1
            model.Entity<Microempresario>()
                .HasOne(microempresario => microempresario.PrestamoM)
                .WithOne(prestamo => prestamo.MicroempresarioPres)
                .OnDelete(DeleteBehavior.NoAction)  // Modelar el comportamiento por defecto de delete
                .HasForeignKey<Prestamo>(prestamo => prestamo.MicroempresarioId);

            //Cardinalidad de Microempresario y Microemprendimiento 1-1
            model.Entity<MicroEmprendimiento>()
                .HasOne(emprendimiento => emprendimiento.MicroempresarioEmpr)
                .WithOne(microempresario=> microempresario.MicroemprendimientoM)
                .HasForeignKey<MicroEmprendimiento>(emprendimiento => emprendimiento.MicroEmprendimientoId);

            //Cardinalidad de Garante y Microemprendimiento 1-1
            model.Entity<MicroEmprendimiento>()
                .HasOne(emprendimiento => emprendimiento.GaranteEmpr)
                .WithOne(garante => garante.MicroEmprendimientoG)
                .HasForeignKey<MicroEmprendimiento>(emprendimiento => emprendimiento.MicroEmprendimientoId);

            //Clave Primaria formada por dos claves foranes
            model.Entity<Solicitud>()
                .HasKey(solicitud => new
                {
                    solicitud.MicroEmprendimientoId,
                    solicitud.PrestamoId
                })
                ;
                

            //Recurso
            //- Notiene clvae primaria
            model.Entity<Recurso>()
                .HasNoKey();
            model.Entity<Recurso>()
                .HasOne(recurso => recurso.PrestamoActual)
                .WithMany()
                .HasForeignKey(recurso => recurso.PrestamoActualId);

        }

    }
}
