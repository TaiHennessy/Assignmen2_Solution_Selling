using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignmen2.Migrations
{
    /// <inheritdoc />
    public partial class eigthary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Photo",
                table: "Product",
                newName: "PhotoPath");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhotoPath",
                table: "Product",
                newName: "Photo");
        }
    }
}
