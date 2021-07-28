using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Novel.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppConfigs",
                columns: table => new
                {
                    Key = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppConfigs", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "AppRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    first_name = table.Column<string>(maxLength: 200, nullable: false),
                    last_name = table.Column<string>(maxLength: 200, nullable: false),
                    Dob = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    id_category = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sort_order = table.Column<int>(nullable: false),
                    IsShowOnHome = table.Column<bool>(nullable: false),
                    id_parent = table.Column<int>(nullable: true),
                    status = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.id_category);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    id_contact = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 200, nullable: false),
                    email = table.Column<string>(maxLength: 200, nullable: false),
                    phone_number = table.Column<string>(maxLength: 200, nullable: false),
                    message = table.Column<string>(nullable: false),
                    status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.id_contact);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    id_language = table.Column<string>(unicode: false, maxLength: 5, nullable: false),
                    name = table.Column<string>(maxLength: 20, nullable: false),
                    IsDefault = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.id_language);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id_product = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    price = table.Column<decimal>(nullable: false),
                    original_price = table.Column<decimal>(nullable: false),
                    stock = table.Column<int>(nullable: false, defaultValue: 0),
                    view_count = table.Column<int>(nullable: false, defaultValue: 0),
                    date_created = table.Column<DateTime>(nullable: false),
                    IsFeatured = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.id_product);
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    id_promotion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    from_date = table.Column<DateTime>(nullable: false),
                    to_date = table.Column<DateTime>(nullable: false),
                    ApplyForAll = table.Column<bool>(nullable: false),
                    discount_percent = table.Column<int>(nullable: true),
                    discount_amount = table.Column<decimal>(nullable: true),
                    id_product = table.Column<string>(nullable: true),
                    id_productCategory = table.Column<string>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.id_promotion);
                });

            migrationBuilder.CreateTable(
                name: "Slides",
                columns: table => new
                {
                    id_slide = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 200, nullable: false),
                    description = table.Column<string>(maxLength: 200, nullable: false),
                    url = table.Column<string>(maxLength: 200, nullable: false),
                    image = table.Column<string>(maxLength: 200, nullable: false),
                    sort_order = table.Column<int>(nullable: false),
                    status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slides", x => x.id_slide);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id_order = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_date = table.Column<DateTime>(nullable: false),
                    id_user = table.Column<Guid>(nullable: false),
                    ship_name = table.Column<string>(maxLength: 200, nullable: false),
                    ship_address = table.Column<string>(maxLength: 200, nullable: false),
                    ship_email = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    ship_phoneNumber = table.Column<string>(maxLength: 200, nullable: false),
                    status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id_order);
                    table.ForeignKey(
                        name: "FK_Orders_AppUsers_id_user",
                        column: x => x.id_user,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    id_transaction = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    transaction_date = table.Column<DateTime>(nullable: false),
                    ExternalTransactionId = table.Column<string>(nullable: true),
                    amount = table.Column<decimal>(nullable: false),
                    fee = table.Column<decimal>(nullable: false),
                    result = table.Column<string>(nullable: true),
                    message = table.Column<string>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    provider = table.Column<string>(nullable: true),
                    id_user = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.id_transaction);
                    table.ForeignKey(
                        name: "FK_Transactions_AppUsers_id_user",
                        column: x => x.id_user,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryTranslations",
                columns: table => new
                {
                    id_categoryTranslation = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_category = table.Column<int>(nullable: false),
                    name = table.Column<string>(maxLength: 200, nullable: false),
                    seo_description = table.Column<string>(maxLength: 500, nullable: true),
                    seo_title = table.Column<string>(maxLength: 200, nullable: true),
                    id_language = table.Column<string>(unicode: false, maxLength: 5, nullable: false),
                    seo_alias = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTranslations", x => x.id_categoryTranslation);
                    table.ForeignKey(
                        name: "FK_CategoryTranslations_Categories_id_category",
                        column: x => x.id_category,
                        principalTable: "Categories",
                        principalColumn: "id_category",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryTranslations_Languages_id_language",
                        column: x => x.id_language,
                        principalTable: "Languages",
                        principalColumn: "id_language",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    id_cart = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_product = table.Column<int>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    price = table.Column<decimal>(nullable: false),
                    id_user = table.Column<Guid>(nullable: false),
                    date_create = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.id_cart);
                    table.ForeignKey(
                        name: "FK_Carts_Products_id_product",
                        column: x => x.id_product,
                        principalTable: "Products",
                        principalColumn: "id_product",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carts_AppUsers_id_user",
                        column: x => x.id_user,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    id_productImage = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_product = table.Column<int>(nullable: false),
                    image_path = table.Column<string>(maxLength: 200, nullable: false),
                    caption = table.Column<string>(maxLength: 200, nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    date_created = table.Column<DateTime>(nullable: false),
                    sort_order = table.Column<int>(nullable: false),
                    file_size = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.id_productImage);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_id_product",
                        column: x => x.id_product,
                        principalTable: "Products",
                        principalColumn: "id_product",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductInCategories",
                columns: table => new
                {
                    id_product = table.Column<int>(nullable: false),
                    id_category = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInCategories", x => new { x.id_category, x.id_product });
                    table.ForeignKey(
                        name: "FK_ProductInCategories_Categories_id_category",
                        column: x => x.id_category,
                        principalTable: "Categories",
                        principalColumn: "id_category",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductInCategories_Products_id_product",
                        column: x => x.id_product,
                        principalTable: "Products",
                        principalColumn: "id_product",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTranslations",
                columns: table => new
                {
                    id_productTranslation = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_product = table.Column<int>(nullable: false),
                    name = table.Column<string>(maxLength: 200, nullable: false),
                    description = table.Column<string>(nullable: true),
                    details = table.Column<string>(maxLength: 500, nullable: true),
                    seo_description = table.Column<string>(nullable: true),
                    seo_title = table.Column<string>(nullable: true),
                    seo_alias = table.Column<string>(maxLength: 200, nullable: false),
                    id_language = table.Column<string>(unicode: false, maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTranslations", x => x.id_productTranslation);
                    table.ForeignKey(
                        name: "FK_ProductTranslations_Languages_id_language",
                        column: x => x.id_language,
                        principalTable: "Languages",
                        principalColumn: "id_language",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTranslations_Products_id_product",
                        column: x => x.id_product,
                        principalTable: "Products",
                        principalColumn: "id_product",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    id_order = table.Column<int>(nullable: false),
                    id_product = table.Column<int>(nullable: false),
                    quantity = table.Column<int>(nullable: false),
                    price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.id_order, x.id_product });
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_id_order",
                        column: x => x.id_order,
                        principalTable: "Orders",
                        principalColumn: "id_order",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_id_product",
                        column: x => x.id_product,
                        principalTable: "Products",
                        principalColumn: "id_product",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_id_product",
                table: "Carts",
                column: "id_product");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_id_user",
                table: "Carts",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTranslations_id_category",
                table: "CategoryTranslations",
                column: "id_category");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTranslations_id_language",
                table: "CategoryTranslations",
                column: "id_language");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_id_product",
                table: "OrderDetails",
                column: "id_product");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_id_user",
                table: "Orders",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_id_product",
                table: "ProductImages",
                column: "id_product");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInCategories_id_product",
                table: "ProductInCategories",
                column: "id_product");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTranslations_id_language",
                table: "ProductTranslations",
                column: "id_language");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTranslations_id_product",
                table: "ProductTranslations",
                column: "id_product");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_id_user",
                table: "Transactions",
                column: "id_user");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppConfigs");

            migrationBuilder.DropTable(
                name: "AppRoles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "CategoryTranslations");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProductInCategories");

            migrationBuilder.DropTable(
                name: "ProductTranslations");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "Slides");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AppUsers");
        }
    }
}
