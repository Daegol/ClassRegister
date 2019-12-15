using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassRegister.Application.Migrations
{
    public partial class updategrades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Grades",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Grades");
        }
    }
}
