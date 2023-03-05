using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleCalculator.DataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class DbCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculatorMemories");

            migrationBuilder.CreateTable(
                name: "CalculationResultEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MathOperator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstNumber = table.Column<double>(type: "float", nullable: false),
                    SecondNumber = table.Column<double>(type: "float", nullable: false),
                    Result = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculationResultEntities", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculationResultEntities");

            migrationBuilder.CreateTable(
                name: "CalculatorMemories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstNumber = table.Column<double>(type: "float", nullable: false),
                    MathOperator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Result = table.Column<double>(type: "float", nullable: false),
                    SecondNumber = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculatorMemories", x => x.Id);
                });
        }
    }
}
