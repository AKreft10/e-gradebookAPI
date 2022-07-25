using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_gradebookAPI.Migrations
{
    public partial class OpinionsFieldAddToStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Opinions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Opinions_StudentId",
                table: "Opinions",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Opinions_Students_StudentId",
                table: "Opinions",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opinions_Students_StudentId",
                table: "Opinions");

            migrationBuilder.DropIndex(
                name: "IX_Opinions_StudentId",
                table: "Opinions");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Opinions");
        }
    }
}
