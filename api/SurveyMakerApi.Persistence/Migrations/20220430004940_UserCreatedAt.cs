using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyMakerApi.Persistence.Migrations
{
    public partial class UserCreatedAt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 29, 21, 49, 39, 995, DateTimeKind.Local).AddTicks(5928));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "surveys",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 29, 21, 49, 39, 992, DateTimeKind.Local).AddTicks(7938),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 4, 23, 17, 10, 38, 833, DateTimeKind.Local).AddTicks(5018));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "responses",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 29, 21, 49, 39, 996, DateTimeKind.Local).AddTicks(1720),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 4, 23, 17, 10, 38, 836, DateTimeKind.Local).AddTicks(1025));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_at",
                table: "users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "surveys",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 23, 17, 10, 38, 833, DateTimeKind.Local).AddTicks(5018),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 4, 29, 21, 49, 39, 992, DateTimeKind.Local).AddTicks(7938));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "responses",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 23, 17, 10, 38, 836, DateTimeKind.Local).AddTicks(1025),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 4, 29, 21, 49, 39, 996, DateTimeKind.Local).AddTicks(1720));
        }
    }
}
