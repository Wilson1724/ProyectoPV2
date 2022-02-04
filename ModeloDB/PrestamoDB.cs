using Microsoft.EntityFrameworkCore;
using ModeloProyecto.Entidades;
namespace ModeloDB
{
    public class PrestamoDB : DbContext
    {
        public PrestamoDB()
        {
        }



        //Constructor invoca al constructor de padre
        public PrestamoDB(DbContextOptions<PrestamoDB> options)
                : base(options)
        {
        }

        public void PreparaDB()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        //Declaración de las entidades del modelo
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Banco> Bancos { get; set; }
        public DbSet<Microempresario> Microempresarios { get; set; }
        public DbSet<MicroEmprendimiento> Microemprendimientos { get; set; }
        public DbSet<Garante> Garantes { get; set; }

        public DbSet<Configuracion> Configuraciones { get; set; }
        //Configuración de la conección
        
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=WILSON\\SQLEXPRESS; Initial Catalog=Proyecto1 ;trusted_connection=true;");

        }
        */
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
                .OnDelete(DeleteBehavior.NoAction)  // Modelar el comportamiento por defecto de delete
                .HasForeignKey<MicroEmprendimiento>(emprendimiento => emprendimiento.MicroEmprendimientoId);

            //Cardinalidad de Garante y Microemprendimiento 1-1
            model.Entity<MicroEmprendimiento>()
                .HasOne(emprendimiento => emprendimiento.GaranteEmpr)
                .WithOne(garante => garante.MicroEmprendimientoG)
                .OnDelete(DeleteBehavior.NoAction)  // Modelar el comportamiento por defecto de delete
                .HasForeignKey<MicroEmprendimiento>(emprendimiento => emprendimiento.MicroEmprendimientoId);

       
                

            //Recurso
            //- Notiene clvae primaria
            model.Entity<Configuracion>()
                .HasNoKey();
            model.Entity<Configuracion>()
                .HasOne(config => config.PrestamoActual)
                .WithMany()
                .HasForeignKey(config => config.PrestamoActualId);

        }

    }
}
