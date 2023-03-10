using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleCalculator.DataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AddMathOperatorColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MathOperator",
                table: "CalculatorMemories",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MathOperator",
                table: "CalculatorMemories");
        }
    }
}
