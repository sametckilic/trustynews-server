using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrustyNews.Api.Infrastructure.Persistence.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhotoBase",
                schema: "dbo",
                table: "newscoverphotos",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "user-photos/ifnwrbxcragwe0bdnugz",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "NewsCoverPhotoId",
                schema: "dbo",
                table: "news",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<bool>(
                name: "IsTrusty",
                schema: "dbo",
                table: "news",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhotoBase",
                schema: "dbo",
                table: "newscoverphotos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "user-photos/ifnwrbxcragwe0bdnugz");

            migrationBuilder.AlterColumn<Guid>(
                name: "NewsCoverPhotoId",
                schema: "dbo",
                table: "news",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<bool>(
                name: "IsTrusty",
                schema: "dbo",
                table: "news",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);
        }
    }
}
