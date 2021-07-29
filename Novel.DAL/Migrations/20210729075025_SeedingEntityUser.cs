using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Novel.DAL.Migrations
{
    public partial class SeedingEntityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), "60fd5593-1e26-4db9-8bfc-a75cba13aa1d", "Administrator role", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), new Guid("8d04dce2-969a-435d-bba4-df3f325983dc") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "first_name", "last_name" },
                values: new object[] { new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), 0, "87453b27-deb4-4242-8799-60ee93e9a923", new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "tienle10998@gmail.com", true, false, null, "tienle10998@gmail.com", "admin", "AQAAAAEAACcQAAAAEL4NvLB32cVrmdqPXj9Ii1FNmhSc70LpRJt2TUv1CZ1CTxf+vo1sarvgyrD/vqhtPg==", null, false, "", false, "admin", "Tien", "Lee" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id_category",
                keyValue: 1,
                column: "status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id_category",
                keyValue: 2,
                column: "status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id_product",
                keyValue: 1,
                column: "date_created",
                value: new DateTime(2021, 7, 29, 14, 50, 24, 213, DateTimeKind.Local).AddTicks(8076));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), new Guid("8d04dce2-969a-435d-bba4-df3f325983dc") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id_category",
                keyValue: 1,
                column: "status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id_category",
                keyValue: 2,
                column: "status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "id_product",
                keyValue: 1,
                column: "date_created",
                value: new DateTime(2021, 7, 29, 14, 6, 7, 154, DateTimeKind.Local).AddTicks(2573));
        }
    }
}
