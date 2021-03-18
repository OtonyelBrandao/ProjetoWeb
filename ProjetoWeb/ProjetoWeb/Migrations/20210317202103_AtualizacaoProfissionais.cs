using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoWeb.Migrations
{
    public partial class AtualizacaoProfissionais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EspecialidadeIDId",
                table: "Profissionais",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProfissionaisId",
                table: "especialidades",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profissionais_EspecialidadeIDId",
                table: "Profissionais",
                column: "EspecialidadeIDId");

            migrationBuilder.CreateIndex(
                name: "IX_especialidades_ProfissionaisId",
                table: "especialidades",
                column: "ProfissionaisId");

            migrationBuilder.AddForeignKey(
                name: "FK_especialidades_Profissionais_ProfissionaisId",
                table: "especialidades",
                column: "ProfissionaisId",
                principalTable: "Profissionais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profissionais_especialidades_EspecialidadeIDId",
                table: "Profissionais",
                column: "EspecialidadeIDId",
                principalTable: "especialidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_especialidades_Profissionais_ProfissionaisId",
                table: "especialidades");

            migrationBuilder.DropForeignKey(
                name: "FK_Profissionais_especialidades_EspecialidadeIDId",
                table: "Profissionais");

            migrationBuilder.DropIndex(
                name: "IX_Profissionais_EspecialidadeIDId",
                table: "Profissionais");

            migrationBuilder.DropIndex(
                name: "IX_especialidades_ProfissionaisId",
                table: "especialidades");

            migrationBuilder.DropColumn(
                name: "EspecialidadeIDId",
                table: "Profissionais");

            migrationBuilder.DropColumn(
                name: "ProfissionaisId",
                table: "especialidades");
        }
    }
}
