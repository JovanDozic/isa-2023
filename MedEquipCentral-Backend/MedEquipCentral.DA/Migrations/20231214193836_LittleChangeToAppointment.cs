using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedEquipCentral.DA.Migrations
{
    /// <inheritdoc />
    public partial class LittleChangeToAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<List<int>>(
                name: "EquipmentIds",
                table: "Appointments",
                type: "integer[]",
                nullable: true,
                oldClrType: typeof(List<int>),
                oldType: "integer[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<List<int>>(
                name: "EquipmentIds",
                table: "Appointments",
                type: "integer[]",
                nullable: false,
                oldClrType: typeof(List<int>),
                oldType: "integer[]",
                oldNullable: true);
        }
    }
}
