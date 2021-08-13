using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Novel.DAL.Migrations
{
    public partial class create_qrcode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QrCodeUser",
                columns: table => new
                {
                    id_qrcode = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_user = table.Column<Guid>(nullable: false),
                    display = table.Column<string>(maxLength: 200, nullable: false),
                    qrcodeUri = table.Column<string>(unicode: false, nullable: false),
                    create_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QrCodeUser", x => x.id_qrcode);
                    table.ForeignKey(
                        name: "FK_QrCodeUser_AppUsers_id_user",
                        column: x => x.id_user,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "7b64f5f8-125b-4954-bdb3-a18fd2e026da");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2609194d-d512-4655-aa81-15f1bf760fb6", "AQAAAAEAACcQAAAAEHMO0lCSY1DKWI/xUVHTynpnYEIweMHd/8LfVbxBws0l/zRvAPidIoK0iriu8wTmEA==" });

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
                value: new DateTime(2021, 8, 12, 11, 20, 13, 720, DateTimeKind.Local).AddTicks(4962));

            migrationBuilder.CreateIndex(
                name: "IX_QrCodeUser_id_user",
                table: "QrCodeUser",
                column: "id_user",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QrCodeUser");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "60fd5593-1e26-4db9-8bfc-a75cba13aa1d");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "87453b27-deb4-4242-8799-60ee93e9a923", "AQAAAAEAACcQAAAAEL4NvLB32cVrmdqPXj9Ii1FNmhSc70LpRJt2TUv1CZ1CTxf+vo1sarvgyrD/vqhtPg==" });

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
    }
}
