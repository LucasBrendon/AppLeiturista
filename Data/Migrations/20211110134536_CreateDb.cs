using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_leituristas",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    matricula = table.Column<long>(type: "bigint", nullable: false),
                    nome = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ativo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_leituristas", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_ocorrencias",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descricao = table.Column<string>(type: "varchar(80)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    permite_leitura = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    valor = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ocorrencias", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_usuarios",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    senha = table.Column<string>(type: "varchar(32)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    role = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_usuarios", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_leituras",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigo_Cliente = table.Column<long>(type: "bigint", nullable: false),
                    leitura_anterior = table.Column<long>(type: "bigint", nullable: false),
                    leitura_atual = table.Column<long>(type: "bigint", nullable: false),
                    fk_leiturista = table.Column<long>(type: "bigint", nullable: false),
                    fk_ocorrencia = table.Column<long>(type: "bigint", nullable: false),
                    latitude = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    longitude = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    data_leitura = table.Column<DateTime>(type: "datetime(0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_leituras", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_leituras_tbl_leituristas_fk_leiturista",
                        column: x => x.fk_leiturista,
                        principalTable: "tbl_leituristas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_leituras_tbl_ocorrencias_fk_ocorrencia",
                        column: x => x.fk_ocorrencia,
                        principalTable: "tbl_ocorrencias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_leituras_fk_leiturista",
                table: "tbl_leituras",
                column: "fk_leiturista");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_leituras_fk_ocorrencia",
                table: "tbl_leituras",
                column: "fk_ocorrencia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_leituras");

            migrationBuilder.DropTable(
                name: "tbl_usuarios");

            migrationBuilder.DropTable(
                name: "tbl_leituristas");

            migrationBuilder.DropTable(
                name: "tbl_ocorrencias");
        }
    }
}
