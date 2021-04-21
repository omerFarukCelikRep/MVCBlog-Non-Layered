using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCBlog.Migrations
{
    public partial class initialV11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Members",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 13, 10, 55, 41, 162, DateTimeKind.Local).AddTicks(3418),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 13, 3, 22, 3, 967, DateTimeKind.Local).AddTicks(3916));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 13, 10, 55, 41, 171, DateTimeKind.Local).AddTicks(2861),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 13, 3, 22, 3, 975, DateTimeKind.Local).AddTicks(7801));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Articles");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Members",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 13, 3, 22, 3, 967, DateTimeKind.Local).AddTicks(3916),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 4, 13, 10, 55, 41, 162, DateTimeKind.Local).AddTicks(3418));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 13, 3, 22, 3, 975, DateTimeKind.Local).AddTicks(7801),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 4, 13, 10, 55, 41, 171, DateTimeKind.Local).AddTicks(2861));
        }
    }
}
