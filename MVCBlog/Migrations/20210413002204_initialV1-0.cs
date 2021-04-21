using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCBlog.Migrations
{
    public partial class initialV10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Biography = table.Column<string>(maxLength: 180, nullable: true),
                    Image = table.Column<byte[]>(nullable: true),
                    Username = table.Column<string>(type: "varchar(32)", nullable: false),
                    Url = table.Column<string>(type: "varchar(100)", nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 4, 13, 3, 22, 3, 967, DateTimeKind.Local).AddTicks(3916)),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Image = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 4, 13, 3, 22, 3, 975, DateTimeKind.Local).AddTicks(7801)),
                    ReadingCount = table.Column<int>(nullable: false),
                    ReadTime = table.Column<int>(nullable: false),
                    Image = table.Column<byte[]>(nullable: true),
                    IsPublished = table.Column<bool>(nullable: false),
                    MemberID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Articles_Members_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Members",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemberFollowedTopics",
                columns: table => new
                {
                    MemberID = table.Column<int>(nullable: false),
                    TopicID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberFollowedTopics", x => new { x.MemberID, x.TopicID });
                    table.ForeignKey(
                        name: "FK_MemberFollowedTopics_Members_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Members",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberFollowedTopics_Topics_TopicID",
                        column: x => x.TopicID,
                        principalTable: "Topics",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleTopics",
                columns: table => new
                {
                    TopicID = table.Column<int>(nullable: false),
                    ArticleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleTopics", x => new { x.TopicID, x.ArticleID });
                    table.ForeignKey(
                        name: "FK_ArticleTopics_Articles_ArticleID",
                        column: x => x.ArticleID,
                        principalTable: "Articles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleTopics_Topics_TopicID",
                        column: x => x.TopicID,
                        principalTable: "Topics",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_MemberID",
                table: "Articles",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTopics_ArticleID",
                table: "ArticleTopics",
                column: "ArticleID");

            migrationBuilder.CreateIndex(
                name: "IX_MemberFollowedTopics_TopicID",
                table: "MemberFollowedTopics",
                column: "TopicID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleTopics");

            migrationBuilder.DropTable(
                name: "MemberFollowedTopics");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
