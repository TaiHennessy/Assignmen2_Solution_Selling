using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignmen2.Data.Migrations
{
    /// <inheritdoc />
    public partial class twelfthary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "32ff853a-2b50-46f9-ac61-d31b36929054", "AQAAAAIAAYagAAAAEHPAgWzs022O2ciRGKIebPTacZxwh+EGIFqKWPt9auGGuYYBDvdmcCmvhIfjbWLbrQ==", "1160dc4e-407f-4975-838d-68b0289e20dc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6710ffaa-4b13-4058-8545-aa80b47bdfe6", "AQAAAAIAAYagAAAAEGa6pvDLaiuI5kJVwdTXIqC9gt9XHwQZthQyCvN+heC9jExOXlyF0v/VCIIM62dpRw==", "1b3cabd7-39a8-47fd-8b65-4eb6daf9f209" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d9ae3066-4ba5-4605-8728-38b2f78b0bd2", "AQAAAAIAAYagAAAAEGjkAHICKgAq6o7BJm9vNK+tOXQZ2jX/eYuudgytp9lE8wVRZJmXzJdJmHwI2LqIqg==", "61a2ba21-766c-44c1-a78c-66815f0d98a6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
