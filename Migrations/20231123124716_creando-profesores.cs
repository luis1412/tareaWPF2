using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ejercicio8DI.Migrations
{
    public partial class creandoprofesores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProfesoresFuncionarios",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AnyoIngresoCuerpo = table.Column<int>(type: "int", nullable: false),
                    DestinoDefinitivo = table.Column<bool>(type: "bit", nullable: false),
                    tipoMedico = table.Column<long>(type: "bigint", nullable: false),
                    tipoFuncionario = table.Column<long>(type: "bigint", nullable: false),
                    nombreImagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rutaFoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    edad = table.Column<int>(type: "int", nullable: false),
                    Materia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoProfesor = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfesoresFuncionarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfesoresExtendidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    profesorFuncionarioId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ECivil = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Peso = table.Column<int>(type: "int", nullable: false),
                    Estatura = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfesoresExtendidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfesoresExtendidos_ProfesoresFuncionarios_profesorFuncionarioId",
                        column: x => x.profesorFuncionarioId,
                        principalTable: "ProfesoresFuncionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfesoresExtendidos_profesorFuncionarioId",
                table: "ProfesoresExtendidos",
                column: "profesorFuncionarioId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfesoresExtendidos");

            migrationBuilder.DropTable(
                name: "ProfesoresFuncionarios");
        }
    }
}
