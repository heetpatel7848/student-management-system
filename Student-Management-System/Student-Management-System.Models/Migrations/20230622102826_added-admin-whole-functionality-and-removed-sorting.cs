using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Management_System.Models.Migrations
{
    /// <inheritdoc />
    public partial class addedadminwholefunctionalityandremovedsorting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Admins",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Admins");
        }
    }
}
