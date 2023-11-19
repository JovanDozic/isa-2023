using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MedEquipCentral.DA.Migrations
{
    /// <inheritdoc />
    public partial class EquipmentCompaniesRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Equipment",
                newName: "TypeId");

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

            migrationBuilder.CreateTable(
                name: "EquipmentType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_TypeId",
                table: "Equipment",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyEquipment_EquipmentId",
                table: "CompanyEquipment",
                column: "EquipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_EquipmentType_TypeId",
                table: "Equipment",
                column: "TypeId",
                principalTable: "EquipmentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_EquipmentType_TypeId",
                table: "Equipment");

            migrationBuilder.DropTable(
                name: "CompanyEquipment");

            migrationBuilder.DropTable(
                name: "EquipmentType");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_TypeId",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "CompanyIds",
                table: "Equipment");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Equipment",
                newName: "CompanyId");
        }
    }
}
