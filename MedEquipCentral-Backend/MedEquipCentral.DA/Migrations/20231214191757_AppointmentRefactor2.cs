using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedEquipCentral.DA.Migrations
{
    /// <inheritdoc />
    public partial class AppointmentRefactor2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Appointments_EquipmentId",
                table: "Equipment");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_EquipmentId",
                table: "Equipment");

            migrationBuilder.CreateTable(
                name: "AppointmentEquipment",
                columns: table => new
                {
                    EquipmentId = table.Column<int>(type: "integer", nullable: false),
                    EquipmentId1 = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentEquipment", x => new { x.EquipmentId, x.EquipmentId1 });
                    table.ForeignKey(
                        name: "FK_AppointmentEquipment_Appointments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppointmentEquipment_Equipment_EquipmentId1",
                        column: x => x.EquipmentId1,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentEquipment_EquipmentId1",
                table: "AppointmentEquipment",
                column: "EquipmentId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentEquipment");

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
    }
}
