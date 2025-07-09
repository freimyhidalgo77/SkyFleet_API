using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkyFleet.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "aeronaves",
                columns: table => new
                {
                    AeronaveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    estadoId = table.Column<int>(type: "int", nullable: false),
                    ModeloAvion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescripcionCategoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Registracion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostoXHora = table.Column<double>(type: "float", nullable: true),
                    DescripcionAeronave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VelocidadMaxima = table.Column<double>(type: "float", nullable: true),
                    DescripcionMotor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapacidadCombustible = table.Column<int>(type: "int", nullable: true),
                    ConsumoXHora = table.Column<int>(type: "int", nullable: true),
                    Peso = table.Column<double>(type: "float", nullable: true),
                    Rango = table.Column<int>(type: "int", nullable: true),
                    CapacidadPasajeros = table.Column<int>(type: "int", nullable: true),
                    AltitudMaxima = table.Column<int>(type: "int", nullable: true),
                    Licencia = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aeronaves", x => x.AeronaveId);
                });

            migrationBuilder.CreateTable(
                name: "rutas",
                columns: table => new
                {
                    RutaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    origen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    destino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    distancia = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    duracion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rutas", x => x.RutaId);
                });

            migrationBuilder.CreateTable(
                name: "tipoVuelo",
                columns: table => new
                {
                    tipoVueloId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreVuelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcionTipoVuelo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoVuelo", x => x.tipoVueloId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "aeronaves");

            migrationBuilder.DropTable(
                name: "rutas");

            migrationBuilder.DropTable(
                name: "tipoVuelo");
        }
    }
}
