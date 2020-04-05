using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TecLibras.Services.Api.Migrations
{
    public partial class RankApplicationUserId_V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ranks_AspNetUsers_applicationUserId1",
                table: "Ranks");

            migrationBuilder.DropIndex(
                name: "IX_Ranks_applicationUserId1",
                table: "Ranks");

            migrationBuilder.DropColumn(
                name: "applicationUserId1",
                table: "Ranks");

            migrationBuilder.RenameColumn(
                name: "applicationUserId",
                table: "Ranks",
                newName: "ApplicationUserId");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Ranks",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Ranks_ApplicationUserId",
                table: "Ranks",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ranks_AspNetUsers_ApplicationUserId",
                table: "Ranks",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ranks_AspNetUsers_ApplicationUserId",
                table: "Ranks");

            migrationBuilder.DropIndex(
                name: "IX_Ranks_ApplicationUserId",
                table: "Ranks");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Ranks",
                newName: "applicationUserId");

            migrationBuilder.AlterColumn<Guid>(
                name: "applicationUserId",
                table: "Ranks",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "applicationUserId1",
                table: "Ranks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ranks_applicationUserId1",
                table: "Ranks",
                column: "applicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Ranks_AspNetUsers_applicationUserId1",
                table: "Ranks",
                column: "applicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
