using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FptLongChauApp.Migrations
{
    /// <inheritdoc />
    public partial class Init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drug",
                columns: table => new
                {
                    DrugId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drug", x => x.DrugId);
                });

            migrationBuilder.InsertData(
                table: "Drug",
                columns: new[] { "DrugId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Số 1 cao 40cm rộng 20cm dày 20cm màu xanh lá cây đậm", "Đá phong thuỷ tự nhiên", 1000000m },
                    { 2, "Trang trí trong nhà Chất liệu : • Đá muối", "Đèn đá muối hình tròn", 1500000m },
                    { 3, "Tranh sơn mài loại nhỏ 15x 15 giá 50.000", "Tranh sơn mài", 50000m },
                    { 4, "Nguyên liệu thể hiện :    Sơn dầu", "Tranh sơn dầu - Ngựa", 450000m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drug");
        }
    }
}
