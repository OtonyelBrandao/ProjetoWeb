using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoWeb.Migrations
{
    public partial class MudancaNasTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logradouro");

            migrationBuilder.DropColumn(
                name: "LogradouroId",
                table: "Profissionais");

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Profissionais",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CEP",
                table: "Profissionais",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Profissionais",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Complemento",
                table: "Profissionais",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Rua",
                table: "Profissionais",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UF",
                table: "Profissionais",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Profissionais");

            migrationBuilder.DropColumn(
                name: "CEP",
                table: "Profissionais");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Profissionais");

            migrationBuilder.DropColumn(
                name: "Complemento",
                table: "Profissionais");

            migrationBuilder.DropColumn(
                name: "Rua",
                table: "Profissionais");

            migrationBuilder.DropColumn(
                name: "UF",
                table: "Profissionais");

            migrationBuilder.AddColumn<int>(
                name: "LogradouroId",
                table: "Profissionais",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Logradouro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bairro = table.Column<string>(nullable: false),
                    CEP = table.Column<string>(maxLength: 8, nullable: false),
                    Cidade = table.Column<string>(nullable: false),
                    Complemento = table.Column<string>(nullable: false),
                    Rua = table.Column<string>(nullable: false),
                    UF = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logradouro", x => x.Id);
                });
        }
    }
}
