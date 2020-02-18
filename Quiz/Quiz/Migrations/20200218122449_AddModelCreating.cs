using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiz.Migrations
{
    public partial class AddModelCreating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Counters",
                columns: new[] { "IdNote", "Id", "Value" },
                values: new object[,]
                {
                    { 273314807, 1, 1 },
                    { -578715950, 1, 2 },
                    { 1203322088, 1, 3 },
                    { 599104171, 2, 1 },
                    { -665040943, 2, 1 },
                    { 1747910321, 2, 3 },
                    { -1267453471, 2, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Counters",
                keyColumn: "IdNote",
                keyValue: -1267453471);

            migrationBuilder.DeleteData(
                table: "Counters",
                keyColumn: "IdNote",
                keyValue: -665040943);

            migrationBuilder.DeleteData(
                table: "Counters",
                keyColumn: "IdNote",
                keyValue: -578715950);

            migrationBuilder.DeleteData(
                table: "Counters",
                keyColumn: "IdNote",
                keyValue: 273314807);

            migrationBuilder.DeleteData(
                table: "Counters",
                keyColumn: "IdNote",
                keyValue: 599104171);

            migrationBuilder.DeleteData(
                table: "Counters",
                keyColumn: "IdNote",
                keyValue: 1203322088);

            migrationBuilder.DeleteData(
                table: "Counters",
                keyColumn: "IdNote",
                keyValue: 1747910321);
        }
    }
}
