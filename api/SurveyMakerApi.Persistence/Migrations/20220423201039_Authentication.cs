using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyMakerApi.Persistence.Migrations
{
    public partial class Authentication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "users",
                newName: "email");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "users",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "surveys",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 23, 17, 10, 38, 833, DateTimeKind.Local).AddTicks(5018),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 4, 21, 21, 2, 22, 783, DateTimeKind.Local).AddTicks(7311));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "responses",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 23, 17, 10, 38, 836, DateTimeKind.Local).AddTicks(1025),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 4, 21, 21, 2, 22, 785, DateTimeKind.Local).AddTicks(2911));

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 1,
                column: "name",
                value: "test");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "users",
                newName: "Email");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "surveys",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 21, 21, 2, 22, 783, DateTimeKind.Local).AddTicks(7311),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 4, 23, 17, 10, 38, 833, DateTimeKind.Local).AddTicks(5018));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "responses",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 21, 21, 2, 22, 785, DateTimeKind.Local).AddTicks(2911),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 4, 23, 17, 10, 38, 836, DateTimeKind.Local).AddTicks(1025));
        }
    }
}
