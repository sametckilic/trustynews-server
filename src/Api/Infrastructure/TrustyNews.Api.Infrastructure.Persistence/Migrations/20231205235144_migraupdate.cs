using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrustyNews.Api.Infrastructure.Persistence.Migrations
{
    public partial class migraupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                schema: "dbo",
                table: "newstags",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_newstags_CreatedById",
                schema: "dbo",
                table: "newstags",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_newstags_users_CreatedById",
                schema: "dbo",
                table: "newstags",
                column: "CreatedById",
                principalSchema: "dbo",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_newstags_users_CreatedById",
                schema: "dbo",
                table: "newstags");

            migrationBuilder.DropIndex(
                name: "IX_newstags_CreatedById",
                schema: "dbo",
                table: "newstags");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                schema: "dbo",
                table: "newstags");
        }
    }
}
