using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace eCaiet.DAL.Migrations
{
    public partial class fakeFriends : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatRecords",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    ReceiverGuid = table.Column<Guid>(nullable: false),
                    SendTime = table.Column<DateTime>(nullable: false),
                    SenderGuid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatRecords", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_ChatRecords_Users_ReceiverGuid",
                        column: x => x.ReceiverGuid,
                        principalTable: "Users",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatRecords_Users_SenderGuid",
                        column: x => x.SenderGuid,
                        principalTable: "Users",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Friend",
                columns: table => new
                {
                    Friend2Guid = table.Column<Guid>(nullable: false),
                    Friend1Guid = table.Column<Guid>(nullable: false),
                    Friend1Guid1 = table.Column<Guid>(nullable: true),
                    Friend2Guid1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friend", x => x.Friend2Guid);
                    table.UniqueConstraint("AK_Friend_Friend1Guid", x => x.Friend1Guid);
                    table.ForeignKey(
                        name: "FK_Friend_Users_Friend1Guid1",
                        column: x => x.Friend1Guid1,
                        principalTable: "Users",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Friend_Users_Friend2Guid1",
                        column: x => x.Friend2Guid1,
                        principalTable: "Users",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatRecords_ReceiverGuid",
                table: "ChatRecords",
                column: "ReceiverGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ChatRecords_SenderGuid",
                table: "ChatRecords",
                column: "SenderGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Friend_Friend1Guid1",
                table: "Friend",
                column: "Friend1Guid1");

            migrationBuilder.CreateIndex(
                name: "IX_Friend_Friend2Guid1",
                table: "Friend",
                column: "Friend2Guid1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatRecords");

            migrationBuilder.DropTable(
                name: "Friend");
        }
    }
}
