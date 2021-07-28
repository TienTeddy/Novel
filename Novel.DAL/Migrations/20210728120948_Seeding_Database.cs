using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Novel.DAL.Migrations
{
    public partial class Seeding_Database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppConfigs",
                columns: new[] { "Key", "Value" },
                values: new object[,]
                {
                    { "HomeTitle", "This is home page of Novel" },
                    { "HomeKeyword", "This is keyword of Novel" },
                    { "HomeDesciption", "This is description of Novel" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "id_category", "IsShowOnHome", "id_parent", "sort_order", "status" },
                values: new object[,]
                {
                    { 1, true, null, 1, 1 },
                    { 2, true, null, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "id_language", "IsDefault", "name" },
                values: new object[,]
                {
                    { "vi-VN", true, "Tiếng Việt" },
                    { "en-US", false, "English" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id_product", "IsFeatured", "date_created", "original_price", "price" },
                values: new object[] { 1, null, new DateTime(2021, 7, 28, 19, 9, 47, 43, DateTimeKind.Local).AddTicks(7519), 100000m, 200000m });

            migrationBuilder.InsertData(
                table: "CategoryTranslations",
                columns: new[] { "id_categoryTranslation", "id_category", "id_language", "name", "seo_alias", "seo_description", "seo_title" },
                values: new object[,]
                {
                    { 1, 1, "vi-VN", "Áo Nam", "ao-nam", "Sản phẩm thời trang nam", "Sản phẩm thời trang nam" },
                    { 2, 1, "en-US", "Men Shirt", "men-shirt", "The shirt product for men", "The shirt product for men" }
                });

            migrationBuilder.InsertData(
                table: "ProductInCategories",
                columns: new[] { "id_category", "id_product" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "ProductTranslations",
                columns: new[] { "id_productTranslation", "description", "details", "id_language", "id_product", "name", "seo_alias", "seo_description", "seo_title" },
                values: new object[,]
                {
                    { 1, "", "Mô tả sản phẩm", "vi-VN", 1, "Áo sơ mi nam trắng Việt Tiến", "ao-so-mi-nam-trang-viet-tien", "Sản phẩm thời trang nam", "Sản phẩm thời trang nam" },
                    { 2, "", "Description of product", "en-US", 1, "Viet Tien Men T-Shirt", "viet-tien-men-t-shirt", "The shirt product for men", "The shirt product for men" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppConfigs",
                keyColumn: "Key",
                keyValue: "HomeDesciption");

            migrationBuilder.DeleteData(
                table: "AppConfigs",
                keyColumn: "Key",
                keyValue: "HomeKeyword");

            migrationBuilder.DeleteData(
                table: "AppConfigs",
                keyColumn: "Key",
                keyValue: "HomeTitle");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "id_category",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "id_categoryTranslation",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CategoryTranslations",
                keyColumn: "id_categoryTranslation",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductInCategories",
                keyColumns: new[] { "id_category", "id_product" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProductTranslations",
                keyColumn: "id_productTranslation",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductTranslations",
                keyColumn: "id_productTranslation",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "id_category",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "id_language",
                keyValue: "en-US");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "id_language",
                keyValue: "vi-VN");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id_product",
                keyValue: 1);
        }
    }
}
