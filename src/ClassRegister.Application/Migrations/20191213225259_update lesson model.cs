using Microsoft.EntityFrameworkCore.Migrations;

namespace ClassRegister.Application.Migrations
{
    public partial class updatelessonmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DayOfTheWeek",
                table: "Lessons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LessonHour",
                table: "Lessons",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayOfTheWeek",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "LessonHour",
                table: "Lessons");
        }
    }
}
