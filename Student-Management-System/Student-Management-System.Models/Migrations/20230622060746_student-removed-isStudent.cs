using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Management_System.Models.Migrations
{
    /// <inheritdoc />
    public partial class studentremovedisStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsStudent",
                table: "Students");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsStudent",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
