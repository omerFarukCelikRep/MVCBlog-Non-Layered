using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCBlog.Migrations
{
    public partial class initialV12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Members",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 13, 11, 19, 15, 932, DateTimeKind.Local).AddTicks(8538),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 13, 10, 55, 41, 162, DateTimeKind.Local).AddTicks(3418));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 13, 11, 19, 15, 944, DateTimeKind.Local).AddTicks(4131),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 13, 10, 55, 41, 171, DateTimeKind.Local).AddTicks(2861));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Members",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 13, 10, 55, 41, 162, DateTimeKind.Local).AddTicks(3418),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 4, 13, 11, 19, 15, 932, DateTimeKind.Local).AddTicks(8538));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 13, 10, 55, 41, 171, DateTimeKind.Local).AddTicks(2861),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 4, 13, 11, 19, 15, 944, DateTimeKind.Local).AddTicks(4131));
        }
    }
}
