using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCBlog.Migrations
{
    public partial class initialV13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Members",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 13, 11, 35, 36, 148, DateTimeKind.Local).AddTicks(3174),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 13, 11, 19, 15, 932, DateTimeKind.Local).AddTicks(8538));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 13, 11, 35, 36, 160, DateTimeKind.Local).AddTicks(3346),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 13, 11, 35, 36, 160, DateTimeKind.Local).AddTicks(2709),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 4, 13, 11, 19, 15, 944, DateTimeKind.Local).AddTicks(4131));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Members",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 13, 11, 19, 15, 932, DateTimeKind.Local).AddTicks(8538),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 4, 13, 11, 35, 36, 148, DateTimeKind.Local).AddTicks(3174));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 4, 13, 11, 35, 36, 160, DateTimeKind.Local).AddTicks(3346));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 4, 13, 11, 19, 15, 944, DateTimeKind.Local).AddTicks(4131),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2021, 4, 13, 11, 35, 36, 160, DateTimeKind.Local).AddTicks(2709));
        }
    }
}
