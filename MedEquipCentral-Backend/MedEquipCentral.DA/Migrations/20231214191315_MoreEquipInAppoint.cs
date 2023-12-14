using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedEquipCentral.DA.Migrations
{
    /// <inheritdoc />
    public partial class MoreEquipInAppoint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "Appointments");

            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "Equipment",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<List<int>>(
                name: "EquipmentIds",
                table: "Appointments",
                type: "integer[]",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_EquipmentId",
                table: "Equipment",
                column: "EquipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Appointments_EquipmentId",
                table: "Equipment",
                column: "EquipmentId",
                principalTable: "Appointments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Appointments_EquipmentId",
                table: "Equipment");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_EquipmentId",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "EquipmentIds",
                table: "Appointments");

            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "Appointments",
                type: "integer",
                nullable: true);
        }
    }
}
