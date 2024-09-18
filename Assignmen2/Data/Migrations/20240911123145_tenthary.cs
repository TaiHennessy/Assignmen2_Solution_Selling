using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignmen2.Data.Migrations
{
    public partial class tenthary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            // Remove Product table creation as it already exists in the database.
            // If the Product table already exists, we shouldn't recreate it.
            // Remove the following block if not needed:
            // migrationBuilder.CreateTable(
            //     name: "Product",
            //     columns: table => new
            //     {
            //         Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //         Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //         Price = table.Column<double>(type: "float", nullable: false),
            //         Quantity = table.Column<int>(type: "int", nullable: false),
            //         Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //         SellerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //         PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //         ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Product", x => x.Id);
            //         table.ForeignKey(
            //             name: "FK_Product_AspNetUsers_ApplicationUserId",
            //             column: x => x.ApplicationUserId,
            //             principalTable: "AspNetUsers",
            //             principalColumn: "Id");
            //     });

            // Create the Transactions table with correct decimal type for TotalAmount
            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SellerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),  // Correct decimal type with precision
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_AspNetUsers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_AspNetUsers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89969362-fd14-4d53-897c-f09813368ff6", "AQAAAAIAAYagAAAAEDoqzSLi+24kgqj8R+o5UL3jxeBo3j0h43HncADkwA7NYIQ1gEpwkTubDeFL1fSvqg==", "117718e2-979d-4f32-9992-2b4027093bef" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f5c2edaf-5bfe-46d6-bab1-eba19ee90a76", "AQAAAAIAAYagAAAAECPxYDw85iZI6h32CdkYYh+Br0IVIL3ngCiDz2ie3eEUjE9lHYkGi4WavvHMZNjPjg==", "1ca847c7-6e01-4772-a183-83afe9e4adeb" });

           migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dffe2cf4-51a3-48b4-aaf9-b677f3fe2b8e", "AQAAAAIAAYagAAAAENL0khYMDUWJQITUQI6p/2xBOhDpEh5biw8duf9lz0Xu17F6C2rSPNpgPRdNa6YsWw==", "946077b5-622c-4d30-b880-8747daa1cb2b" });
            
            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BuyerId",
                table: "Transactions",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_SellerId",
                table: "Transactions",
                column: "SellerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");


            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2783551d-a188-4088-8cf2-e9e25a6cba93", "AQAAAAIAAYagAAAAEKmXEd8wjOspAiZTzehB3omLPjCXeL4WAeTR0R86ljjlFafq5ppJu0rlZzxqg2Ccow==", "32fac884-f0e9-4058-9631-a590dba68d2b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b55d2ff0-2647-474c-b482-ead8415b1f2b", "AQAAAAIAAYagAAAAEGa5Yei157Xymaq6WwGN1E4SN784kdRMHTvFtGYBFSOUeGwZAGnsGH5TQ82qwyJuFw==", "c253b079-2c41-472f-a10d-c0f58c739b80" });
        }
    }
}
