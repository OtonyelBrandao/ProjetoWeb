using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoWeb.Migrations
{
    public partial class AtualizacaoNaTabelaProfissionais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profissionais_especialidades_EspecialidadeIDId",
                table: "Profissionais");

            migrationBuilder.AlterColumn<string>(
                name: "UF",
                table: "Profissionais",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Profissionais",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Rua",
                table: "Profissionais",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "EspecialidadeIDId",
                table: "Profissionais",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "Profissionais",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "CEP",
                table: "Profissionais",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<string>(
                name: "Bairro",
                table: "Profissionais",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Profissionais_especialidades_EspecialidadeIDId",
                table: "Profissionais",
                column: "EspecialidadeIDId",
                principalTable: "especialidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profissionais_especialidades_EspecialidadeIDId",
                table: "Profissionais");

            migrationBuilder.AlterColumn<string>(
                name: "UF",
                table: "Profissionais",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Profissionais",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Rua",
                table: "Profissionais",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EspecialidadeIDId",
                table: "Profissionais",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "Profissionais",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CEP",
                table: "Profissionais",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Bairro",
                table: "Profissionais",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Profissionais_especialidades_EspecialidadeIDId",
                table: "Profissionais",
                column: "EspecialidadeIDId",
                principalTable: "especialidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
