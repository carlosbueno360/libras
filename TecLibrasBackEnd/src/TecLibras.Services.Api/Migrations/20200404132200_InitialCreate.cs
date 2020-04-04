using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TecLibras.Services.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PointEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Points = table.Column<int>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointEvents", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PointEvents");
        }
    }
}
