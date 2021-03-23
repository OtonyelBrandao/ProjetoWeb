using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoWeb.Migrations
{
    public partial class modificacaoDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Especialidades_Profissionais_ProfissionaisId",
                table: "Especialidades");

            migrationBuilder.DropIndex(
                name: "IX_Especialidades_ProfissionaisId",
                table: "Especialidades");

            migrationBuilder.DropColumn(
                name: "ProfissionaisId",
                table: "Especialidades");

            migrationBuilder.CreateTable(
                name: "ProfissionaisEspecialidadesFK",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProfissionaisId = table.Column<int>(nullable: true),
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
                    table.ForeignKey(
                        name: "FK_ProfissionaisEspecialidadesFK_Profissionais_ProfissionaisId",
                        column: x => x.ProfissionaisId,
                        principalTable: "Profissionais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfissionaisEspecialidadesFK_EspecialidadesId",
                table: "ProfissionaisEspecialidadesFK",
                column: "EspecialidadesId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfissionaisEspecialidadesFK_ProfissionaisId",
                table: "ProfissionaisEspecialidadesFK",
                column: "ProfissionaisId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfissionaisEspecialidadesFK");

            migrationBuilder.AddColumn<int>(
                name: "ProfissionaisId",
                table: "Especialidades",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Especialidades_ProfissionaisId",
                table: "Especialidades",
                column: "ProfissionaisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Especialidades_Profissionais_ProfissionaisId",
                table: "Especialidades",
                column: "ProfissionaisId",
                principalTable: "Profissionais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
