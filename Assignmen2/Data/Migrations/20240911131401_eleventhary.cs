using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignmen2.Data.Migrations
{
    /// <inheritdoc />
    public partial class eleventhary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d8c8539-acb6-49fe-9ce4-3ddfb1364749", "AQAAAAIAAYagAAAAEJom/hl6sWiz2zg8GimfzbdxVmUkPfut72mcY1aPcOHvJt9CNygw50yidwkKvadwYA==", "41403eba-d4de-4101-b14f-db72ff910bbe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "222879fa-f447-4e26-8ec5-d6f37128ff91", "AQAAAAIAAYagAAAAEAwsWL6l/17eVNcFdLiMjw/au1Ra36fHqunb4fBaeLia9bSiD/siBRlyaRBypF6JbA==", "5c01c54b-54c5-4797-b671-1fcf1a77c1ec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dffe2cf4-51a3-48b4-aaf9-b677f3fe2b8e", "AQAAAAIAAYagAAAAENL0khYMDUWJQITUQI6p/2xBOhDpEh5biw8duf9lz0Xu17F6C2rSPNpgPRdNa6YsWw==", "946077b5-622c-4d30-b880-8747daa1cb2b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "TotalAmount",
                table: "Transactions",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

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
                values: new object[] { "efab26f4-4c4a-4f82-8a8c-89f04d2bde06", "AQAAAAIAAYagAAAAELbECqjDD32yzs1Qy1V3j3leKLBN6zIgl7X+0pN1L18gSpGpo0F5GzwSLWHfYmDMfg==", "f4062174-f3b5-4c8f-8c66-e3bf6b87c46c" });
        }
    }
}
