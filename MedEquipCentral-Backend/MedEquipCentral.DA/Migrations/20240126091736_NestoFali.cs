using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedEquipCentral.DA.Migrations
{
    /// <inheritdoc />
    public partial class NestoFali : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Equipment",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Appointments",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Appointments");
        }
    }
}
