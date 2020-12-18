using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Ronaldo.GestaoDeFuncionarios.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_DEPARTAMENTO",
                columns: table => new
                {
                    ID_DEPARTAMENTO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM_DEPARTAMENTO = table.Column<string>(maxLength: 50, nullable: false),
                    FL_ATIVO = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_DEPARTAMENTO", x => x.ID_DEPARTAMENTO);
                });

            migrationBuilder.CreateTable(
                name: "TB_FUNCIONARIO",
                columns: table => new
                {
                    ID_FUNCIONARIO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM_FUNCIONARIO = table.Column<string>(maxLength: 100, nullable: false),
                    DS_EMAIL = table.Column<string>(maxLength: 50, nullable: false),
                    ID_DEPARTAMENTO = table.Column<int>(nullable: false),
                    DT_NASCIMENTO = table.Column<DateTime>(maxLength: 50, nullable: false),
                    DS_TELEFONEPRIMARIO = table.Column<string>(maxLength: 50, nullable: false),
                    DS_TELEFONESECUNDARIO = table.Column<string>(maxLength: 50, nullable: false),
                    DS_LOGIN = table.Column<string>(maxLength: 50, nullable: false),
                    DS_SENHA = table.Column<string>(maxLength: 50, nullable: false),
                    FL_ACESSO = table.Column<bool>(nullable: false, defaultValue: true),
                    FL_ATIVO = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_FUNCIONARIO", x => x.ID_FUNCIONARIO);
                    table.ForeignKey(
                        name: "FK_TB_FUNCIONARIO_TB_DEPARTAMENTO_ID_DEPARTAMENTO",
                        column: x => x.ID_DEPARTAMENTO,
                        principalTable: "TB_DEPARTAMENTO",
                        principalColumn: "ID_DEPARTAMENTO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_FUNCIONARIO_ID_DEPARTAMENTO",
                table: "TB_FUNCIONARIO",
                column: "ID_DEPARTAMENTO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_FUNCIONARIO");

            migrationBuilder.DropTable(
                name: "TB_DEPARTAMENTO");
        }
    }
}
