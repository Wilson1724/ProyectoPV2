﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ModeloDB;

namespace ModeloDB.Migrations
{
    [DbContext(typeof(PrestamoDB))]
    partial class PrestamoDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ModeloProyecto.Entidades.Banco", b =>
                {
                    b.Property<int>("BancoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Encargado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sucursal")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BancoId");

                    b.ToTable("Bancos");
                });

            modelBuilder.Entity("ModeloProyecto.Entidades.Garante", b =>
                {
                    b.Property<int>("GaranteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApellidoG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CedulaG")
                        .HasColumnType("int");

                    b.Property<string>("DireccionG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EdadG")
                        .HasColumnType("int");

                    b.Property<int>("IngresosAnualesG")
                        .HasColumnType("int");

                    b.Property<int>("MicroEmprendimientoId")
                        .HasColumnType("int");

                    b.Property<string>("NombreG")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GaranteId");

                    b.ToTable("Garantes");
                });

            modelBuilder.Entity("ModeloProyecto.Entidades.MicroEmprendimiento", b =>
                {
                    b.Property<int>("MicroEmprendimientoId")
                        .HasColumnType("int");

                    b.Property<string>("Ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreditoNecesario")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ganancias")
                        .HasColumnType("int");

                    b.Property<string>("NombreE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MicroEmprendimientoId");

                    b.ToTable("Microemprendimientos");
                });

            modelBuilder.Entity("ModeloProyecto.Entidades.Microempresario", b =>
                {
                    b.Property<int>("MicroempresarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BancoId")
                        .HasColumnType("int");

                    b.Property<int>("Cedula")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<int>("IngresosAnuales")
                        .HasColumnType("int");

                    b.Property<int>("MicroEmprendimientoId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MicroempresarioId");

                    b.HasIndex("BancoId");

                    b.ToTable("Microempresarios");
                });

            modelBuilder.Entity("ModeloProyecto.Entidades.Prestamo", b =>
                {
                    b.Property<int>("PrestamoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BancoId")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("CuotaMensual")
                        .HasColumnType("int");

                    b.Property<int>("Interes")
                        .HasColumnType("int");

                    b.Property<int>("MicroempresarioId")
                        .HasColumnType("int");

                    b.Property<int>("Plazo")
                        .HasColumnType("int");

                    b.Property<int>("TotalDeuda")
                        .HasColumnType("int");

                    b.HasKey("PrestamoId");

                    b.HasIndex("BancoId");

                    b.HasIndex("MicroempresarioId")
                        .IsUnique();

                    b.ToTable("Prestamos");
                });

            modelBuilder.Entity("ModeloProyecto.Entidades.Recurso", b =>
                {
                    b.Property<int>("MontoMaximo")
                        .HasColumnType("int");

                    b.Property<int>("MontoMinimo")
                        .HasColumnType("int");

                    b.Property<int>("PrestamoActualId")
                        .HasColumnType("int");

                    b.HasIndex("PrestamoActualId");

                    b.ToTable("Recursos");
                });

            modelBuilder.Entity("ModeloProyecto.Entidades.Solicitud", b =>
                {
                    b.Property<int>("MicroEmprendimientoId")
                        .HasColumnType("int");

                    b.Property<int>("PrestamoId")
                        .HasColumnType("int");

                    b.HasKey("MicroEmprendimientoId", "PrestamoId");

                    b.ToTable("Solicitudes");
                });

            modelBuilder.Entity("ModeloProyecto.Entidades.MicroEmprendimiento", b =>
                {
                    b.HasOne("ModeloProyecto.Entidades.Garante", "GaranteEmpr")
                        .WithOne("MicroEmprendimientoG")
                        .HasForeignKey("ModeloProyecto.Entidades.MicroEmprendimiento", "MicroEmprendimientoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModeloProyecto.Entidades.Microempresario", "MicroempresarioEmpr")
                        .WithOne("MicroemprendimientoM")
                        .HasForeignKey("ModeloProyecto.Entidades.MicroEmprendimiento", "MicroEmprendimientoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GaranteEmpr");

                    b.Navigation("MicroempresarioEmpr");
                });

            modelBuilder.Entity("ModeloProyecto.Entidades.Microempresario", b =>
                {
                    b.HasOne("ModeloProyecto.Entidades.Banco", "BancoM")
                        .WithMany("Microempresarios")
                        .HasForeignKey("BancoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BancoM");
                });

            modelBuilder.Entity("ModeloProyecto.Entidades.Prestamo", b =>
                {
                    b.HasOne("ModeloProyecto.Entidades.Banco", "BancoPres")
                        .WithMany("Prestamos")
                        .HasForeignKey("BancoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ModeloProyecto.Entidades.Microempresario", "MicroempresarioPres")
                        .WithOne("PrestamoM")
                        .HasForeignKey("ModeloProyecto.Entidades.Prestamo", "MicroempresarioId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("BancoPres");

                    b.Navigation("MicroempresarioPres");
                });

            modelBuilder.Entity("ModeloProyecto.Entidades.Recurso", b =>
                {
                    b.HasOne("ModeloProyecto.Entidades.Prestamo", "PrestamoActual")
                        .WithMany()
                        .HasForeignKey("PrestamoActualId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PrestamoActual");
                });

            modelBuilder.Entity("ModeloProyecto.Entidades.Solicitud", b =>
                {
                    b.HasOne("ModeloProyecto.Entidades.MicroEmprendimiento", "MicroEmprendimientoSoli")
                        .WithMany()
                        .HasForeignKey("MicroEmprendimientoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MicroEmprendimientoSoli");
                });

            modelBuilder.Entity("ModeloProyecto.Entidades.Banco", b =>
                {
                    b.Navigation("Microempresarios");

                    b.Navigation("Prestamos");
                });

            modelBuilder.Entity("ModeloProyecto.Entidades.Garante", b =>
                {
                    b.Navigation("MicroEmprendimientoG");
                });

            modelBuilder.Entity("ModeloProyecto.Entidades.Microempresario", b =>
                {
                    b.Navigation("MicroemprendimientoM");

                    b.Navigation("PrestamoM");
                });
#pragma warning restore 612, 618
        }
    }
}