using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class Intial32 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_SHclnResourceSchedule",
            //    table: "SHclnResourceSchedule");

            ////migrationBuilder.RenameColumn(
            ////    name: "SlotsID",
            ////    table: "SHclnViewResourceSchedule",
            ////    newName: "Viewslot");

            //migrationBuilder.AddColumn<string>(
            //    name: "Viewslot",
            //    table: "SHclnResourceSchedule",
            //    type: "nvarchar(450)",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_SHclnResourceSchedule",
            //    table: "SHclnResourceSchedule",
            //    columns: new[] { "StaffID", "FacilityID", "SlotsID", "Viewslot" });

            //migrationBuilder.CreateIndex(
            //    name: "IX_SHclnResourceSchedule_StaffID_FacilityID_Viewslot",
            //    table: "SHclnResourceSchedule",
            //    columns: new[] { "StaffID", "FacilityID", "Viewslot" });

            //migrationBuilder.AddForeignKey(
            //    name: "FK_SHclnResourceSchedule_SHclnViewResourceSchedule_StaffID_FacilityID_Viewslot",
            //    table: "SHclnResourceSchedule",
            //    columns: new[] { "StaffID", "FacilityID", "Viewslot" },
            //    principalTable: "SHclnViewResourceSchedule",
            //    principalColumns: new[] { "StaffID", "FacilityID", "Viewslot" },
            //    onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SHclnResourceSchedule_SHclnViewResourceSchedule_StaffID_FacilityID_Viewslot",
                table: "SHclnResourceSchedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SHclnResourceSchedule",
                table: "SHclnResourceSchedule");

            migrationBuilder.DropIndex(
                name: "IX_SHclnResourceSchedule_StaffID_FacilityID_Viewslot",
                table: "SHclnResourceSchedule");

            migrationBuilder.DropColumn(
                name: "Viewslot",
                table: "SHclnResourceSchedule");

            migrationBuilder.RenameColumn(
                name: "Viewslot",
                table: "SHclnViewResourceSchedule",
                newName: "SlotsID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHclnResourceSchedule",
                table: "SHclnResourceSchedule",
                columns: new[] { "StaffID", "FacilityID", "SlotsID" });
        }
    }
}
