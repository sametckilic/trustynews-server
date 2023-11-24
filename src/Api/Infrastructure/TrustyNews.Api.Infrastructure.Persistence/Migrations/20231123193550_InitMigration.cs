using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrustyNews.Api.Infrastructure.Persistence.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "users",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    IsPhoneConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    IsConfirmedUser = table.Column<bool>(type: "bit", nullable: false),
                    IsTrustedUser = table.Column<bool>(type: "bit", nullable: false),
                    UserPhotoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "news",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsTrusty = table.Column<bool>(type: "bit", nullable: false),
                    NewsCoverPhotoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_news", x => x.Id);
                    table.ForeignKey(
                        name: "FK_news_users_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "dbo",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "userphotos",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhotoBase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userphotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userphotos_users_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "dbo",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "newsbookmarks",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NewsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_newsbookmarks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_newsbookmarks_news_NewsId",
                        column: x => x.NewsId,
                        principalSchema: "dbo",
                        principalTable: "news",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_newsbookmarks_users_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "dbo",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "newscomments",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NewsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_newscomments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_newscomments_news_NewsId",
                        column: x => x.NewsId,
                        principalSchema: "dbo",
                        principalTable: "news",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_newscomments_users_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "dbo",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "newscoverphotos",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhotoBase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_newscoverphotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_newscoverphotos_news_NewsId",
                        column: x => x.NewsId,
                        principalSchema: "dbo",
                        principalTable: "news",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_newscoverphotos_users_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "dbo",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "newstags",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NewsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_newstags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_newstags_news_NewsId",
                        column: x => x.NewsId,
                        principalSchema: "dbo",
                        principalTable: "news",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "newsvotes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NewsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VoteType = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_newsvotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_newsvotes_news_NewsId",
                        column: x => x.NewsId,
                        principalSchema: "dbo",
                        principalTable: "news",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_newsvotes_users_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "dbo",
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_news_CreatedById",
                schema: "dbo",
                table: "news",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_newsbookmarks_CreatedById",
                schema: "dbo",
                table: "newsbookmarks",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_newsbookmarks_NewsId",
                schema: "dbo",
                table: "newsbookmarks",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_newscomments_CreatedById",
                schema: "dbo",
                table: "newscomments",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_newscomments_NewsId",
                schema: "dbo",
                table: "newscomments",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_newscoverphotos_CreatedById",
                schema: "dbo",
                table: "newscoverphotos",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_newscoverphotos_NewsId",
                schema: "dbo",
                table: "newscoverphotos",
                column: "NewsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_newstags_NewsId",
                schema: "dbo",
                table: "newstags",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_newsvotes_CreatedById",
                schema: "dbo",
                table: "newsvotes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_newsvotes_NewsId",
                schema: "dbo",
                table: "newsvotes",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_userphotos_CreatedById",
                schema: "dbo",
                table: "userphotos",
                column: "CreatedById",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "newsbookmarks",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "newscomments",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "newscoverphotos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "newstags",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "newsvotes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "userphotos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "news",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "users",
                schema: "dbo");
        }
    }
}
