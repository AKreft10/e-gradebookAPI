using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_gradebookAPI.Migrations
{
    public partial class Grade_Year_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Grade_Year",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grade_Year",
                table: "Students");
        }
    }
}
