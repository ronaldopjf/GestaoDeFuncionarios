using Microsoft.EntityFrameworkCore.Migrations;

namespace Ronaldo.GestaoDeFuncionarios.Infrastructure.Migrations
{
    public partial class EmployeeMapChangedtwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "FL_ATIVO",
                table: "TB_FUNCIONARIO",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "FL_ACESSO",
                table: "TB_FUNCIONARIO",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "FL_ATIVO",
                table: "TB_FUNCIONARIO",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "FL_ACESSO",
                table: "TB_FUNCIONARIO",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);
        }
    }
}
