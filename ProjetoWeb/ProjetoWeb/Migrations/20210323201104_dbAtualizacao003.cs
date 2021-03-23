using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoWeb.Migrations
{
    public partial class dbAtualizacao003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfissionaisEspecialidadesFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProfissionaisEspecialidadesFK",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EspecialidadesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfissionaisEspecialidadesFK", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfissionaisEspecialidadesFK_Especialidades_EspecialidadesId",
                        column: x => x.EspecialidadesId,
                        principalTable: "Especialidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfissionaisEspecialidadesFK_EspecialidadesId",
                table: "ProfissionaisEspecialidadesFK",
                column: "EspecialidadesId");
        }
    }
}
