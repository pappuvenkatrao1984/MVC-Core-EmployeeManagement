using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpManagementMVC.Migrations
{
    public partial class InitialCreate_Three : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentType",
                table: "Departments");

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentTypeId",
                table: "Departments",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DepartmentType",
                columns: table => new
                {
                    DepartmentTypeId = table.Column<Guid>(nullable: false),
                    DepartmentName = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedDateTime = table.Column<DateTime>(nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentType", x => x.DepartmentTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DepartmentTypeId",
                table: "Departments",
                column: "DepartmentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_DepartmentType_DepartmentTypeId",
                table: "Departments",
                column: "DepartmentTypeId",
                principalTable: "DepartmentType",
                principalColumn: "DepartmentTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_DepartmentType_DepartmentTypeId",
                table: "Departments");

            migrationBuilder.DropTable(
                name: "DepartmentType");

            migrationBuilder.DropIndex(
                name: "IX_Departments_DepartmentTypeId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "DepartmentTypeId",
                table: "Departments");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentType",
                table: "Departments",
                nullable: false,
                defaultValue: 0);
        }
    }
}
