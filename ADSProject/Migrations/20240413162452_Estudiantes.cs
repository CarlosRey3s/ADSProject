using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADSProject.Migrations
{
    /// <inheritdoc />
    public partial class Estudiantes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    IdEstudiante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEstudiante = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApellidoEstudiante = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Codigoestudiante = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Correoestudiante = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.IdEstudiante);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estudiantes");
        }
    }
}
