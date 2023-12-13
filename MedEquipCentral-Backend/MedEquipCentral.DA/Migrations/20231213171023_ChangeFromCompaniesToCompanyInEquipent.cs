using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedEquipCentral.DA.Migrations
{
    /// <inheritdoc />
    public partial class ChangeFromCompaniesToCompanyInEquipent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyEquipment");

            migrationBuilder.DropColumn(
                name: "CompanyIds",
                table: "Equipment");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Equipment",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_CompanyId",
                table: "Equipment",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Company_CompanyId",
                table: "Equipment",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Company_CompanyId",
                table: "Equipment");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_CompanyId",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Equipment");

            migrationBuilder.AddColumn<List<int>>(
                name: "CompanyIds",
                table: "Equipment",
                type: "integer[]",
                nullable: false);

            migrationBuilder.CreateTable(
                name: "CompanyEquipment",
                columns: table => new
                {
                    CompaniesId = table.Column<int>(type: "integer", nullable: false),
                    EquipmentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyEquipment", x => new { x.CompaniesId, x.EquipmentId });
                    table.ForeignKey(
                        name: "FK_CompanyEquipment_Company_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyEquipment_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyEquipment_EquipmentId",
                table: "CompanyEquipment",
                column: "EquipmentId");
        }
    }
}
