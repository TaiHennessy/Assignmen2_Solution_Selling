using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignmen2.Migrations
{
    /// <inheritdoc />
    public partial class seventhary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Seller",
                table: "Product",
                newName: "SellerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SellerId",
                table: "Product",
                newName: "Seller");
        }
    }
}
