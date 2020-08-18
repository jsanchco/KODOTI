using Microsoft.EntityFrameworkCore.Migrations;

namespace Customer.Persistence.Database.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Client");

            migrationBuilder.CreateTable(
                name: "Clients",
                schema: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Client",
                table: "Clients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Client 1" },
                    { 73, "Client 73" },
                    { 72, "Client 72" },
                    { 71, "Client 71" },
                    { 70, "Client 70" },
                    { 69, "Client 69" },
                    { 68, "Client 68" },
                    { 67, "Client 67" },
                    { 66, "Client 66" },
                    { 65, "Client 65" },
                    { 64, "Client 64" },
                    { 63, "Client 63" },
                    { 62, "Client 62" },
                    { 61, "Client 61" },
                    { 60, "Client 60" },
                    { 59, "Client 59" },
                    { 58, "Client 58" },
                    { 57, "Client 57" },
                    { 56, "Client 56" },
                    { 55, "Client 55" },
                    { 54, "Client 54" },
                    { 53, "Client 53" },
                    { 74, "Client 74" },
                    { 52, "Client 52" },
                    { 75, "Client 75" },
                    { 77, "Client 77" },
                    { 98, "Client 98" },
                    { 97, "Client 97" },
                    { 96, "Client 96" },
                    { 95, "Client 95" },
                    { 94, "Client 94" },
                    { 93, "Client 93" },
                    { 92, "Client 92" },
                    { 91, "Client 91" },
                    { 90, "Client 90" },
                    { 89, "Client 89" },
                    { 88, "Client 88" },
                    { 87, "Client 87" },
                    { 86, "Client 86" },
                    { 85, "Client 85" },
                    { 84, "Client 84" },
                    { 83, "Client 83" },
                    { 82, "Client 82" },
                    { 81, "Client 81" },
                    { 80, "Client 80" },
                    { 79, "Client 79" },
                    { 78, "Client 78" },
                    { 76, "Client 76" },
                    { 51, "Client 51" },
                    { 50, "Client 50" },
                    { 49, "Client 49" },
                    { 22, "Client 22" },
                    { 21, "Client 21" },
                    { 20, "Client 20" },
                    { 19, "Client 19" },
                    { 18, "Client 18" },
                    { 17, "Client 17" },
                    { 16, "Client 16" },
                    { 15, "Client 15" },
                    { 14, "Client 14" },
                    { 13, "Client 13" },
                    { 12, "Client 12" },
                    { 11, "Client 11" },
                    { 10, "Client 10" },
                    { 9, "Client 9" },
                    { 8, "Client 8" },
                    { 7, "Client 7" },
                    { 6, "Client 6" },
                    { 5, "Client 5" },
                    { 4, "Client 4" },
                    { 3, "Client 3" },
                    { 2, "Client 2" },
                    { 23, "Client 23" },
                    { 24, "Client 24" },
                    { 25, "Client 25" },
                    { 26, "Client 26" },
                    { 48, "Client 48" },
                    { 47, "Client 47" },
                    { 46, "Client 46" },
                    { 45, "Client 45" },
                    { 44, "Client 44" },
                    { 43, "Client 43" },
                    { 42, "Client 42" },
                    { 41, "Client 41" },
                    { 40, "Client 40" },
                    { 39, "Client 39" },
                    { 99, "Client 99" },
                    { 38, "Client 38" },
                    { 36, "Client 36" },
                    { 35, "Client 35" },
                    { 34, "Client 34" },
                    { 33, "Client 33" },
                    { 32, "Client 32" },
                    { 31, "Client 31" },
                    { 30, "Client 30" },
                    { 29, "Client 29" },
                    { 28, "Client 28" },
                    { 27, "Client 27" },
                    { 37, "Client 37" },
                    { 100, "Client 100" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Id",
                schema: "Client",
                table: "Clients",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients",
                schema: "Client");
        }
    }
}
