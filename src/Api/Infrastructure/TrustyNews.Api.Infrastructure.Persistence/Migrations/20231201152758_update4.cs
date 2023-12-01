using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrustyNews.Api.Infrastructure.Persistence.Migrations
{
    public partial class update4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhotoBase",
                schema: "dbo",
                table: "userphotos",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "user-photos/ifnwrbxcragwe0bdnugz",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedById",
                schema: "dbo",
                table: "userphotos",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhotoBase",
                schema: "dbo",
                table: "userphotos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "user-photos/ifnwrbxcragwe0bdnugz");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedById",
                schema: "dbo",
                table: "userphotos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }
    }
}
