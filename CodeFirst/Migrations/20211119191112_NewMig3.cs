using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirst.Migrations
{
    public partial class NewMig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_InculdeTable",
                table: "InculdeTable");

            migrationBuilder.RenameTable(
                name: "InculdeTable",
                newName: "Familys");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Familys",
                table: "Familys",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Familys",
                table: "Familys");

            migrationBuilder.RenameTable(
                name: "Familys",
                newName: "InculdeTable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InculdeTable",
                table: "InculdeTable",
                column: "Id");
        }
    }
}
