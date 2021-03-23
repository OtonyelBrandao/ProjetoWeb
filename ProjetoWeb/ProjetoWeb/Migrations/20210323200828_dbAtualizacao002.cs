using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoWeb.Migrations
{
    public partial class dbAtualizacao002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfissionaisEspecialidadesFK_Profissionais_ProfissionaisId",
                table: "ProfissionaisEspecialidadesFK");

            migrationBuilder.DropIndex(
                name: "IX_ProfissionaisEspecialidadesFK_ProfissionaisId",
                table: "ProfissionaisEspecialidadesFK");

            migrationBuilder.DropColumn(
                name: "ProfissionaisId",
                table: "ProfissionaisEspecialidadesFK");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "ProfissionaisId",
                table: "ProfissionaisEspecialidadesFK",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfissionaisEspecialidadesFK_ProfissionaisId",
                table: "ProfissionaisEspecialidadesFK",
                column: "ProfissionaisId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfissionaisEspecialidadesFK_Profissionais_ProfissionaisId",
                table: "ProfissionaisEspecialidadesFK",
                column: "ProfissionaisId",
                principalTable: "Profissionais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
