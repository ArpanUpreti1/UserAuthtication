using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserAuthtication.Migrations
{
    /// <inheritdoc />
    public partial class FixedTheIssue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Course",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Course",
                newName: "CourseId");
        }
    }
}
