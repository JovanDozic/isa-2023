using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedEquipCentral.DA.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkingHoursToCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeOnly>(
                name: "EndTime",
                table: "Company",
                type: "time without time zone",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "StartTime",
                table: "Company",
                type: "time without time zone",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Company");
        }
    }
}
