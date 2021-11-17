using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AjusteTblUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "role",
                table: "tbl_usuarios",
                newName: "Cargo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cargo",
                table: "tbl_usuarios",
                newName: "role");
        }
    }
}
