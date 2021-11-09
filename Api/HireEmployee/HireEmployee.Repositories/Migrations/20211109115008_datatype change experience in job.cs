using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HireEmployee.Repositories.Migrations
{
    public partial class datatypechangeexperienceinjob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Experience",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"),
                column: "Experience",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                column: "Experience",
                value: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Experience",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"),
                column: "Experience",
                value: "1");

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                column: "Experience",
                value: "3");
        }
    }
}
