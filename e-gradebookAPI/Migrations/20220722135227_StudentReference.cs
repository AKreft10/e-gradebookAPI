using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_gradebookAPI.Migrations
{
    public partial class StudentReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opinions_Students_StudentId",
                table: "Opinions");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Opinions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Opinions_Students_StudentId",
                table: "Opinions",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opinions_Students_StudentId",
                table: "Opinions");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Opinions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Opinions_Students_StudentId",
                table: "Opinions",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }
    }
}
