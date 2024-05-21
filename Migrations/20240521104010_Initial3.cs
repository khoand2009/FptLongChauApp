using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FptLongChauApp.Migrations
{
    /// <inheritdoc />
    public partial class Initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Drug",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Drug",
                keyColumn: "DrugId",
                keyValue: 1,
                columns: new[] { "Description", "ImagePath", "Name", "Price" },
                values: new object[] { "Non-prescription pain relievers and fever reducers.", "paracetamol.jpg", "Paracetamol 500mg", 25000m });

            migrationBuilder.UpdateData(
                table: "Drug",
                keyColumn: "DrugId",
                keyValue: 2,
                columns: new[] { "Description", "ImagePath", "Name", "Price" },
                values: new object[] { "Antiplatelet drugs, stroke prevention.", "aspirin.jpg", "Aspirin 81mg", 38000m });

            migrationBuilder.UpdateData(
                table: "Drug",
                keyColumn: "DrugId",
                keyValue: 3,
                columns: new[] { "Description", "ImagePath", "Name", "Price" },
                values: new object[] { "Non-steroidal anti-inflammatory and pain relievers.", "ibuprofen.jpg", "Ibuprofen 400mg", 42000m });

            migrationBuilder.UpdateData(
                table: "Drug",
                keyColumn: "DrugId",
                keyValue: 4,
                columns: new[] { "Description", "ImagePath", "Name", "Price" },
                values: new object[] { "Antihistamines, allergy treatment.", "loratadine.jpg", "Loratadine 10mg", 55000m });

            migrationBuilder.InsertData(
                table: "Drug",
                columns: new[] { "DrugId", "Description", "ImagePath", "Name", "Price" },
                values: new object[,]
                {
                    { 5, "Proton pump inhibitors, treatment of stomach ulcers.", "omeprazole.jpg", "Omeprazole 20mg", 80000m },
                    { 6, "Statin drugs, lowering blood cholesterol.", "simvastatin.jpg", "Simvastatin 20mg", 120000m },
                    { 7, "Drugs to treat type 2 diabetes.", "metformin.jpg", "Metformin 500mg", 95000m },
                    { 8, "Antibiotics, treatment of infections.", "amoxicillin.jpg", "Amoxicillin 500mg", 68000m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Drug",
                keyColumn: "DrugId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Drug",
                keyColumn: "DrugId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Drug",
                keyColumn: "DrugId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Drug",
                keyColumn: "DrugId",
                keyValue: 8);

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Drug");

            migrationBuilder.UpdateData(
                table: "Drug",
                keyColumn: "DrugId",
                keyValue: 1,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Số 1 cao 40cm rộng 20cm dày 20cm màu xanh lá cây đậm", "Đá phong thuỷ tự nhiên", 1000000m });

            migrationBuilder.UpdateData(
                table: "Drug",
                keyColumn: "DrugId",
                keyValue: 2,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Trang trí trong nhà Chất liệu : • Đá muối", "Đèn đá muối hình tròn", 1500000m });

            migrationBuilder.UpdateData(
                table: "Drug",
                keyColumn: "DrugId",
                keyValue: 3,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Tranh sơn mài loại nhỏ 15x 15 giá 50.000", "Tranh sơn mài", 50000m });

            migrationBuilder.UpdateData(
                table: "Drug",
                keyColumn: "DrugId",
                keyValue: 4,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Nguyên liệu thể hiện :    Sơn dầu", "Tranh sơn dầu - Ngựa", 450000m });
        }
    }
}
