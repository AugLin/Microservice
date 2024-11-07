using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductMicroservice.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_ProductCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ProductCategory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CategoryVariation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    VariationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCategoryid = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryVariation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryVariation_ProductCategory_ProductCategoryid",
                        column: x => x.ProductCategoryid,
                        principalTable: "ProductCategory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryVariation_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VariationValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VariationId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryVariationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VariationValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VariationValue_CategoryVariation_CategoryVariationId",
                        column: x => x.CategoryVariationId,
                        principalTable: "CategoryVariation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductVariationValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    VariationValueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariationValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductVariationValue_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductVariationValue_VariationValue_VariationValueId",
                        column: x => x.VariationValueId,
                        principalTable: "VariationValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryVariation_ProductCategoryid",
                table: "CategoryVariation",
                column: "ProductCategoryid");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryVariation_ProductId",
                table: "CategoryVariation",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductId",
                table: "Product",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariationValue_ProductId",
                table: "ProductVariationValue",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariationValue_VariationValueId",
                table: "ProductVariationValue",
                column: "VariationValueId");

            migrationBuilder.CreateIndex(
                name: "IX_VariationValue_CategoryVariationId",
                table: "VariationValue",
                column: "CategoryVariationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductVariationValue");

            migrationBuilder.DropTable(
                name: "VariationValue");

            migrationBuilder.DropTable(
                name: "CategoryVariation");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ProductCategory");
        }
    }
}
