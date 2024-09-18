using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignmen2.Data.Migrations
{
    /// <inheritdoc />
    public partial class sixthary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "City", "ConcurrencyStamp", "Country", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "Calgary", "2783551d-a188-4088-8cf2-e9e25a6cba93", "Canada", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAIAAYagAAAAEKmXEd8wjOspAiZTzehB3omLPjCXeL4WAeTR0R86ljjlFafq5ppJu0rlZzxqg2Ccow==", "32fac884-f0e9-4058-9631-a590dba68d2b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "City", "ConcurrencyStamp", "Country", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "London", "b55d2ff0-2647-474c-b482-ead8415b1f2b", "England", new DateTime(1991, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAIAAYagAAAAEGa5Yei157Xymaq6WwGN1E4SN784kdRMHTvFtGYBFSOUeGwZAGnsGH5TQ82qwyJuFw==", "c253b079-2c41-472f-a10d-c0f58c739b80" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "157dcd4d-9a7d-4677-9c2e-ee4107a7bfc7", "AQAAAAIAAYagAAAAEFSk9IXXC0dl5En14XJXStCKwJXlFGvP1DB7Tt1i6zYHW3vLGokhNUP+gVv48b1AgA==", "4b61b748-629e-41b2-96f0-e9481c3a3fd3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "013f6bab-4776-451f-8b0f-ce912d98300c", "AQAAAAIAAYagAAAAEEn4qR7sM1XSBH1/pXSSeNpTJfZ5JLES1oQb1c/B//wY+H8VXMR3MozbRKKRz0FKug==", "32595a2c-d9a0-4d82-957e-2f9bdbf51cd6" });
        }
    }
}
