using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkyFleet.Data.Migrations
{
    /// <inheritdoc />
    public partial class SkyFleetApp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "tipoVuelo");
        }
    }
}
