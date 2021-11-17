using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class NovoAjustetblUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cargo",
                table: "tbl_usuarios",
                newName: "cargo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cargo",
                table: "tbl_usuarios",
                newName: "Cargo");
        }
    }
}
