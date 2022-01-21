using Microsoft.EntityFrameworkCore.Migrations;

namespace ModeloDB.Migrations
{
    public partial class CargaInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bancos",
                columns: table => new
                {
                    BancoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sucursal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Encargado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bancos", x => x.BancoId);
                });

            migrationBuilder.CreateTable(
                name: "Garantes",
                columns: table => new
                {
                    GaranteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApellidoG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CedulaG = table.Column<int>(type: "int", nullable: false),
                    EdadG = table.Column<int>(type: "int", nullable: false),
                    DireccionG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IngresosAnualesG = table.Column<int>(type: "int", nullable: false),
                    MicroEmprendimientoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garantes", x => x.GaranteId);
                });

            migrationBuilder.CreateTable(
                name: "Microempresarios",
                columns: table => new
                {
                    MicroempresarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cedula = table.Column<int>(type: "int", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IngresosAnuales = table.Column<int>(type: "int", nullable: false),
                    BancoId = table.Column<int>(type: "int", nullable: false),
                    MicroEmprendimientoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Microempresarios", x => x.MicroempresarioId);
                    table.ForeignKey(
                        name: "FK_Microempresarios_Bancos_BancoId",
                        column: x => x.BancoId,
                        principalTable: "Bancos",
                        principalColumn: "BancoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Microemprendimientos",
                columns: table => new
                {
                    MicroEmprendimientoId = table.Column<int>(type: "int", nullable: false),
                    NombreE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditoNecesario = table.Column<int>(type: "int", nullable: false),
                    Ganancias = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Microemprendimientos", x => x.MicroEmprendimientoId);
                    table.ForeignKey(
                        name: "FK_Microemprendimientos_Garantes_MicroEmprendimientoId",
                        column: x => x.MicroEmprendimientoId,
                        principalTable: "Garantes",
                        principalColumn: "GaranteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Microemprendimientos_Microempresarios_MicroEmprendimientoId",
                        column: x => x.MicroEmprendimientoId,
                        principalTable: "Microempresarios",
                        principalColumn: "MicroempresarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    PrestamoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Plazo = table.Column<int>(type: "int", nullable: false),
                    Interes = table.Column<int>(type: "int", nullable: false),
                    CuotaMensual = table.Column<int>(type: "int", nullable: false),
                    TotalDeuda = table.Column<int>(type: "int", nullable: false),
                    BancoId = table.Column<int>(type: "int", nullable: false),
                    MicroempresarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.PrestamoId);
                    table.ForeignKey(
                        name: "FK_Prestamos_Bancos_BancoId",
                        column: x => x.BancoId,
                        principalTable: "Bancos",
                        principalColumn: "BancoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prestamos_Microempresarios_MicroempresarioId",
                        column: x => x.MicroempresarioId,
                        principalTable: "Microempresarios",
                        principalColumn: "MicroempresarioId");
                });

            migrationBuilder.CreateTable(
                name: "Solicitudes",
                columns: table => new
                {
                    MicroEmprendimientoId = table.Column<int>(type: "int", nullable: false),
                    PrestamoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitudes", x => new { x.MicroEmprendimientoId, x.PrestamoId });
                    table.ForeignKey(
                        name: "FK_Solicitudes_Microemprendimientos_MicroEmprendimientoId",
                        column: x => x.MicroEmprendimientoId,
                        principalTable: "Microemprendimientos",
                        principalColumn: "MicroEmprendimientoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recursos",
                columns: table => new
                {
                    MontoMinimo = table.Column<int>(type: "int", nullable: false),
                    MontoMaximo = table.Column<int>(type: "int", nullable: false),
                    PrestamoActualId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Recursos_Prestamos_PrestamoActualId",
                        column: x => x.PrestamoActualId,
                        principalTable: "Prestamos",
                        principalColumn: "PrestamoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Microempresarios_BancoId",
                table: "Microempresarios",
                column: "BancoId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_BancoId",
                table: "Prestamos",
                column: "BancoId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_MicroempresarioId",
                table: "Prestamos",
                column: "MicroempresarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recursos_PrestamoActualId",
                table: "Recursos",
                column: "PrestamoActualId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recursos");

            migrationBuilder.DropTable(
                name: "Solicitudes");

            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "Microemprendimientos");

            migrationBuilder.DropTable(
                name: "Garantes");

            migrationBuilder.DropTable(
                name: "Microempresarios");

            migrationBuilder.DropTable(
                name: "Bancos");
        }
    }
}
