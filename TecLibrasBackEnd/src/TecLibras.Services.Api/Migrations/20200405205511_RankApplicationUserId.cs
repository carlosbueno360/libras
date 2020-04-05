using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TecLibras.Services.Api.Migrations
{
    public partial class RankApplicationUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ranks_AspNetUsers_applicationUserId",
                table: "Ranks");

            migrationBuilder.DropIndex(
                name: "IX_Ranks_applicationUserId",
                table: "Ranks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Ranks");

            migrationBuilder.AlterColumn<Guid>(
                name: "applicationUserId",
                table: "Ranks",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "applicationUserId1",
                table: "Ranks",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "applicationUserId",
                table: "Ranks",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Ranks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Ranks_applicationUserId",
                table: "Ranks",
                column: "applicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ranks_AspNetUsers_applicationUserId",
                table: "Ranks",
                column: "applicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
