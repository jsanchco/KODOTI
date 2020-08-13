using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalog.Persistence.Database.Migrations
{
    public partial class Intialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Catalog");

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    Stock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stocks_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Catalog",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Description for product 1", "Product 1", 267m },
                    { 73, "Description for product 73", "Product 73", 843m },
                    { 72, "Description for product 72", "Product 72", 621m },
                    { 71, "Description for product 71", "Product 71", 856m },
                    { 70, "Description for product 70", "Product 70", 451m },
                    { 69, "Description for product 69", "Product 69", 409m },
                    { 68, "Description for product 68", "Product 68", 822m },
                    { 67, "Description for product 67", "Product 67", 792m },
                    { 66, "Description for product 66", "Product 66", 910m },
                    { 65, "Description for product 65", "Product 65", 257m },
                    { 64, "Description for product 64", "Product 64", 538m },
                    { 63, "Description for product 63", "Product 63", 745m },
                    { 62, "Description for product 62", "Product 62", 762m },
                    { 61, "Description for product 61", "Product 61", 764m },
                    { 60, "Description for product 60", "Product 60", 330m },
                    { 59, "Description for product 59", "Product 59", 528m },
                    { 58, "Description for product 58", "Product 58", 268m },
                    { 57, "Description for product 57", "Product 57", 843m },
                    { 56, "Description for product 56", "Product 56", 406m },
                    { 55, "Description for product 55", "Product 55", 657m },
                    { 54, "Description for product 54", "Product 54", 726m },
                    { 53, "Description for product 53", "Product 53", 799m },
                    { 74, "Description for product 74", "Product 74", 267m },
                    { 52, "Description for product 52", "Product 52", 709m },
                    { 75, "Description for product 75", "Product 75", 872m },
                    { 77, "Description for product 77", "Product 77", 717m },
                    { 98, "Description for product 98", "Product 98", 705m },
                    { 97, "Description for product 97", "Product 97", 405m },
                    { 96, "Description for product 96", "Product 96", 274m },
                    { 95, "Description for product 95", "Product 95", 243m },
                    { 94, "Description for product 94", "Product 94", 598m },
                    { 93, "Description for product 93", "Product 93", 165m },
                    { 92, "Description for product 92", "Product 92", 700m },
                    { 91, "Description for product 91", "Product 91", 597m },
                    { 90, "Description for product 90", "Product 90", 159m },
                    { 89, "Description for product 89", "Product 89", 299m },
                    { 88, "Description for product 88", "Product 88", 353m },
                    { 87, "Description for product 87", "Product 87", 294m },
                    { 86, "Description for product 86", "Product 86", 558m },
                    { 85, "Description for product 85", "Product 85", 838m },
                    { 84, "Description for product 84", "Product 84", 209m },
                    { 83, "Description for product 83", "Product 83", 219m },
                    { 82, "Description for product 82", "Product 82", 883m },
                    { 81, "Description for product 81", "Product 81", 189m },
                    { 80, "Description for product 80", "Product 80", 655m },
                    { 79, "Description for product 79", "Product 79", 933m },
                    { 78, "Description for product 78", "Product 78", 137m },
                    { 76, "Description for product 76", "Product 76", 607m },
                    { 51, "Description for product 51", "Product 51", 557m },
                    { 50, "Description for product 50", "Product 50", 361m },
                    { 49, "Description for product 49", "Product 49", 210m },
                    { 22, "Description for product 22", "Product 22", 860m },
                    { 21, "Description for product 21", "Product 21", 658m },
                    { 20, "Description for product 20", "Product 20", 809m },
                    { 19, "Description for product 19", "Product 19", 174m },
                    { 18, "Description for product 18", "Product 18", 672m },
                    { 17, "Description for product 17", "Product 17", 216m },
                    { 16, "Description for product 16", "Product 16", 724m },
                    { 15, "Description for product 15", "Product 15", 792m },
                    { 14, "Description for product 14", "Product 14", 776m },
                    { 13, "Description for product 13", "Product 13", 679m },
                    { 12, "Description for product 12", "Product 12", 772m },
                    { 11, "Description for product 11", "Product 11", 904m },
                    { 10, "Description for product 10", "Product 10", 425m },
                    { 9, "Description for product 9", "Product 9", 834m },
                    { 8, "Description for product 8", "Product 8", 216m },
                    { 7, "Description for product 7", "Product 7", 992m },
                    { 6, "Description for product 6", "Product 6", 311m },
                    { 5, "Description for product 5", "Product 5", 252m },
                    { 4, "Description for product 4", "Product 4", 473m },
                    { 3, "Description for product 3", "Product 3", 301m },
                    { 2, "Description for product 2", "Product 2", 471m },
                    { 23, "Description for product 23", "Product 23", 628m },
                    { 24, "Description for product 24", "Product 24", 133m },
                    { 25, "Description for product 25", "Product 25", 944m },
                    { 26, "Description for product 26", "Product 26", 922m },
                    { 48, "Description for product 48", "Product 48", 663m },
                    { 47, "Description for product 47", "Product 47", 832m },
                    { 46, "Description for product 46", "Product 46", 388m },
                    { 45, "Description for product 45", "Product 45", 199m },
                    { 44, "Description for product 44", "Product 44", 590m },
                    { 43, "Description for product 43", "Product 43", 243m },
                    { 42, "Description for product 42", "Product 42", 151m },
                    { 41, "Description for product 41", "Product 41", 937m },
                    { 40, "Description for product 40", "Product 40", 907m },
                    { 39, "Description for product 39", "Product 39", 828m },
                    { 99, "Description for product 99", "Product 99", 432m },
                    { 38, "Description for product 38", "Product 38", 594m },
                    { 36, "Description for product 36", "Product 36", 441m },
                    { 35, "Description for product 35", "Product 35", 466m },
                    { 34, "Description for product 34", "Product 34", 856m },
                    { 33, "Description for product 33", "Product 33", 980m },
                    { 32, "Description for product 32", "Product 32", 994m },
                    { 31, "Description for product 31", "Product 31", 267m },
                    { 30, "Description for product 30", "Product 30", 396m },
                    { 29, "Description for product 29", "Product 29", 470m },
                    { 28, "Description for product 28", "Product 28", 329m },
                    { 27, "Description for product 27", "Product 27", 547m },
                    { 37, "Description for product 37", "Product 37", 868m },
                    { 100, "Description for product 100", "Product 100", 289m }
                });

            migrationBuilder.InsertData(
                schema: "Catalog",
                table: "Stocks",
                columns: new[] { "Id", "ProductId", "Stock" },
                values: new object[,]
                {
                    { 1, 1, 78 },
                    { 73, 73, 41 },
                    { 72, 72, 94 },
                    { 71, 71, 90 },
                    { 70, 70, 68 },
                    { 69, 69, 20 },
                    { 68, 68, 18 },
                    { 67, 67, 99 },
                    { 66, 66, 95 },
                    { 65, 65, 47 },
                    { 64, 64, 59 },
                    { 63, 63, 1 },
                    { 62, 62, 97 },
                    { 61, 61, 54 },
                    { 60, 60, 96 },
                    { 59, 59, 75 },
                    { 58, 58, 80 },
                    { 57, 57, 17 },
                    { 56, 56, 62 },
                    { 55, 55, 42 },
                    { 54, 54, 68 },
                    { 53, 53, 96 },
                    { 74, 74, 74 },
                    { 52, 52, 59 },
                    { 75, 75, 89 },
                    { 77, 77, 61 },
                    { 98, 98, 94 },
                    { 97, 97, 9 },
                    { 96, 96, 41 },
                    { 95, 95, 48 },
                    { 94, 94, 86 },
                    { 93, 93, 38 },
                    { 92, 92, 88 },
                    { 91, 91, 15 },
                    { 90, 90, 25 },
                    { 89, 89, 66 },
                    { 88, 88, 65 },
                    { 87, 87, 33 },
                    { 86, 86, 48 },
                    { 85, 85, 80 },
                    { 84, 84, 37 },
                    { 83, 83, 86 },
                    { 82, 82, 72 },
                    { 81, 81, 94 },
                    { 80, 80, 12 },
                    { 79, 79, 34 },
                    { 78, 78, 50 },
                    { 76, 76, 97 },
                    { 51, 51, 39 },
                    { 50, 50, 44 },
                    { 49, 49, 12 },
                    { 22, 22, 15 },
                    { 21, 21, 8 },
                    { 20, 20, 27 },
                    { 19, 19, 77 },
                    { 18, 18, 24 },
                    { 17, 17, 8 },
                    { 16, 16, 59 },
                    { 15, 15, 1 },
                    { 14, 14, 8 },
                    { 13, 13, 27 },
                    { 12, 12, 34 },
                    { 11, 11, 25 },
                    { 10, 10, 55 },
                    { 9, 9, 80 },
                    { 8, 8, 82 },
                    { 7, 7, 96 },
                    { 6, 6, 23 },
                    { 5, 5, 71 },
                    { 4, 4, 4 },
                    { 3, 3, 74 },
                    { 2, 2, 50 },
                    { 23, 23, 33 },
                    { 24, 24, 94 },
                    { 25, 25, 29 },
                    { 26, 26, 74 },
                    { 48, 48, 96 },
                    { 47, 47, 79 },
                    { 46, 46, 16 },
                    { 45, 45, 60 },
                    { 44, 44, 82 },
                    { 43, 43, 54 },
                    { 42, 42, 10 },
                    { 41, 41, 38 },
                    { 40, 40, 2 },
                    { 39, 39, 83 },
                    { 99, 99, 34 },
                    { 38, 38, 14 },
                    { 36, 36, 32 },
                    { 35, 35, 88 },
                    { 34, 34, 8 },
                    { 33, 33, 34 },
                    { 32, 32, 29 },
                    { 31, 31, 8 },
                    { 30, 30, 20 },
                    { 29, 29, 81 },
                    { 28, 28, 99 },
                    { 27, 27, 68 },
                    { 37, 37, 69 },
                    { 100, 100, 64 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Id",
                schema: "Catalog",
                table: "Products",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_Id",
                schema: "Catalog",
                table: "Stocks",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId",
                schema: "Catalog",
                table: "Stocks",
                column: "ProductId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Catalog");
        }
    }
}
