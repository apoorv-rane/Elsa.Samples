﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HireEmployee.Repositories.Migrations
{
    public partial class Dataadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "Designation", "Experience", "Salary", "Skills" },
                values: new object[] { new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "Software Engineer", 3, "30,000 - 40,0000", "Dot Net, NodeJS, SQL" });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "Designation", "Experience", "Salary", "Skills" },
                values: new object[] { new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), "Automation Tester", 1, "25,000 - 28,0000", "Dot Net, Django, NodeJS, SQL" });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "Age", "Email", "ExpectedSalary", "Experience", "JobId", "Name", "Resume", "Skill" },
                values: new object[] { new Guid("5b1c5587-eddd-4fc0-a6ca-3f83983b14e5"), 21, "shivam@gmail.com", 380000, 3, new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "Shivam Gupta", "ShivamResume.docx", "Dot Net, Python, Django, ReactJs" });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "Age", "Email", "ExpectedSalary", "Experience", "JobId", "Name", "Resume", "Skill" },
                values: new object[] { new Guid("5606e734-8d48-49af-a981-4ad9d862cc8d"), 20, "alista@gmail.com", 300000, 1, new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "Alista Menezes", "AlistaResume.docx", "Python, Angular, NodeJS " });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "Age", "Email", "ExpectedSalary", "Experience", "JobId", "Name", "Resume", "Skill" },
                values: new object[] { new Guid("fc5c071a-89a4-4622-a7ea-7afcb08ed22e"), 35, "rakesh@gmail.com", 410000, 7, new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), "Rakesh Verma", "RakeshResume.docx", "Java, Dot Net, MongoDb" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: new Guid("5606e734-8d48-49af-a981-4ad9d862cc8d"));

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: new Guid("5b1c5587-eddd-4fc0-a6ca-3f83983b14e5"));

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: new Guid("fc5c071a-89a4-4622-a7ea-7afcb08ed22e"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"));
        }
    }
}
