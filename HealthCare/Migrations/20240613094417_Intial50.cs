﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class Intial50 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHipmInPatientDocVisit",
                table: "SHipmInPatientDocVisit");

            migrationBuilder.AlterColumn<string>(
                name: "VisitID",
                table: "SHipmInPatientDocVisit",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHipmInPatientDocVisit",
                table: "SHipmInPatientDocVisit",
                columns: new[] { "PatientId", "CaseId", "VisitID" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHipmInPatientDocVisit",
                table: "SHipmInPatientDocVisit");

            migrationBuilder.AlterColumn<string>(
                name: "VisitID",
                table: "SHipmInPatientDocVisit",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHipmInPatientDocVisit",
                table: "SHipmInPatientDocVisit",
                columns: new[] { "PatientId", "CaseId" });
        }
    }
}
