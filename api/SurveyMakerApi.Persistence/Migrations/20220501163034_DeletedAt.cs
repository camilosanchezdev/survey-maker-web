using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyMakerApi.Persistence.Migrations
{
    public partial class DeletedAt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 1, 13, 30, 34, 33, DateTimeKind.Local).AddTicks(7215),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 4, 29, 21, 49, 39, 995, DateTimeKind.Local).AddTicks(5928));

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "tags",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "surveys",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 1, 13, 30, 34, 31, DateTimeKind.Local).AddTicks(6419),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 4, 29, 21, 49, 39, 992, DateTimeKind.Local).AddTicks(7938));

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "surveys",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "survey_statuses",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "survey_questions",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "survey_answers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "responses",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 1, 13, 30, 34, 34, DateTimeKind.Local).AddTicks(2875),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 4, 29, 21, 49, 39, 996, DateTimeKind.Local).AddTicks(1720));

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "responses",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "response_questions",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "response_answers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "users");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "tags");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "surveys");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "survey_statuses");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "survey_questions");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "survey_answers");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "responses");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "response_questions");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "response_answers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 29, 21, 49, 39, 995, DateTimeKind.Local).AddTicks(5928),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 5, 1, 13, 30, 34, 33, DateTimeKind.Local).AddTicks(7215));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "surveys",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 29, 21, 49, 39, 992, DateTimeKind.Local).AddTicks(7938),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 5, 1, 13, 30, 34, 31, DateTimeKind.Local).AddTicks(6419));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "responses",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 29, 21, 49, 39, 996, DateTimeKind.Local).AddTicks(1720),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 5, 1, 13, 30, 34, 34, DateTimeKind.Local).AddTicks(2875));
        }
    }
}
