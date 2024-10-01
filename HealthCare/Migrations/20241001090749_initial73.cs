using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class initial73 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHstkDrugType",
                table: "SHstkDrugType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SHstkDrugStock",
                table: "SHstkDrugStock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SHstkDrugGroup",
                table: "SHstkDrugGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SHstkDrugCategory",
                table: "SHstkDrugCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shclnrolltypemaster",
                table: "Shclnrolltypemaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShclnrollAccessmaster",
                table: "ShclnrollAccessmaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SHClnRollAccess",
                table: "SHClnRollAccess");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SHclnResourseTypeMaster",
                table: "SHclnResourseTypeMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SHclnBloodGroup",
                table: "SHclnBloodGroup");

            migrationBuilder.AddColumn<string>(
                name: "FacilityID",
                table: "SHstkDrugType",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FacilityID",
                table: "SHstkDrugStock",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FacilityID",
                table: "SHstkDrugGroup",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FacilityID",
                table: "SHstkDrugCategory",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FacilityID",
                table: "Shclnrolltypemaster",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FacilityID",
                table: "ShclnrollAccessmaster",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FacilityID",
                table: "SHClnRollAccess",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FacilityID",
                table: "SHclnResourseTypeMaster",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FacilityID",
                table: "SHclnBloodGroup",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHstkDrugType",
                table: "SHstkDrugType",
                columns: new[] { "TypeID", "FacilityID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHstkDrugStock",
                table: "SHstkDrugStock",
                columns: new[] { "IDNumber", "DrugID", "FacilityID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHstkDrugGroup",
                table: "SHstkDrugGroup",
                columns: new[] { "GroupTypeName", "GroupTypeID", "FacilityID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHstkDrugCategory",
                table: "SHstkDrugCategory",
                columns: new[] { "CategoryID", "FacilityID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shclnrolltypemaster",
                table: "Shclnrolltypemaster",
                columns: new[] { "RollID", "FacilityID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShclnrollAccessmaster",
                table: "ShclnrollAccessmaster",
                columns: new[] { "StaffID", "RollID", "FacilityID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHClnRollAccess",
                table: "SHClnRollAccess",
                columns: new[] { "RollID", "ScreenID", "FacilityID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHclnResourseTypeMaster",
                table: "SHclnResourseTypeMaster",
                columns: new[] { "ResourceTypeID", "FacilityID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHclnBloodGroup",
                table: "SHclnBloodGroup",
                columns: new[] { "IntBg_Id", "FacilityID" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SHstkDrugType",
                table: "SHstkDrugType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SHstkDrugStock",
                table: "SHstkDrugStock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SHstkDrugGroup",
                table: "SHstkDrugGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SHstkDrugCategory",
                table: "SHstkDrugCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shclnrolltypemaster",
                table: "Shclnrolltypemaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShclnrollAccessmaster",
                table: "ShclnrollAccessmaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SHClnRollAccess",
                table: "SHClnRollAccess");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SHclnResourseTypeMaster",
                table: "SHclnResourseTypeMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SHclnBloodGroup",
                table: "SHclnBloodGroup");

            migrationBuilder.DropColumn(
                name: "FacilityID",
                table: "SHstkDrugType");

            migrationBuilder.DropColumn(
                name: "FacilityID",
                table: "SHstkDrugStock");

            migrationBuilder.DropColumn(
                name: "FacilityID",
                table: "SHstkDrugGroup");

            migrationBuilder.DropColumn(
                name: "FacilityID",
                table: "SHstkDrugCategory");

            migrationBuilder.DropColumn(
                name: "FacilityID",
                table: "Shclnrolltypemaster");

            migrationBuilder.DropColumn(
                name: "FacilityID",
                table: "ShclnrollAccessmaster");

            migrationBuilder.DropColumn(
                name: "FacilityID",
                table: "SHClnRollAccess");

            migrationBuilder.DropColumn(
                name: "FacilityID",
                table: "SHclnResourseTypeMaster");

            migrationBuilder.DropColumn(
                name: "FacilityID",
                table: "SHclnBloodGroup");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHstkDrugType",
                table: "SHstkDrugType",
                column: "TypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHstkDrugStock",
                table: "SHstkDrugStock",
                columns: new[] { "IDNumber", "DrugID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHstkDrugGroup",
                table: "SHstkDrugGroup",
                columns: new[] { "GroupTypeName", "GroupTypeID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHstkDrugCategory",
                table: "SHstkDrugCategory",
                column: "CategoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shclnrolltypemaster",
                table: "Shclnrolltypemaster",
                column: "RollID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShclnrollAccessmaster",
                table: "ShclnrollAccessmaster",
                columns: new[] { "StaffID", "RollID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHClnRollAccess",
                table: "SHClnRollAccess",
                columns: new[] { "RollID", "ScreenID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHclnResourseTypeMaster",
                table: "SHclnResourseTypeMaster",
                column: "ResourceTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SHclnBloodGroup",
                table: "SHclnBloodGroup",
                column: "IntBg_Id");
        }
    }
}
