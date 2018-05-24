using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace eCaiet.DAL.Migrations
{
    public partial class FileTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    ContentType = table.Column<string>(maxLength: 50, nullable: false),
                    CourseGuid = table.Column<Guid>(nullable: true),
                    Data = table.Column<byte[]>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    OwnerGuid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Files_Courses_CourseGuid",
                        column: x => x.CourseGuid,
                        principalTable: "Courses",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Files_Users_OwnerGuid",
                        column: x => x.OwnerGuid,
                        principalTable: "Users",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Files_CourseGuid",
                table: "Files",
                column: "CourseGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Files_Name",
                table: "Files",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Files_OwnerGuid",
                table: "Files",
                column: "OwnerGuid",
                unique: true,
                filter: "[OwnerGuid] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");
        }
    }
}
