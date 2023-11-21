using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CharityPost.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTargetMoneyFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentMoney",
                table: "Publications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TargetMoney",
                table: "Publications",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentMoney",
                table: "Publications");

            migrationBuilder.DropColumn(
                name: "TargetMoney",
                table: "Publications");
        }
    }
}
