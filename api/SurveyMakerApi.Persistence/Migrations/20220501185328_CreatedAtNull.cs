using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyMakerApi.Persistence.Migrations
{
    public partial class CreatedAtNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "users",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 1, 15, 53, 28, 44, DateTimeKind.Local).AddTicks(2249),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 5, 1, 13, 30, 34, 33, DateTimeKind.Local).AddTicks(7215));

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "tags",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "surveys",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "surveys",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 1, 15, 53, 28, 42, DateTimeKind.Local).AddTicks(9761),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 5, 1, 13, 30, 34, 31, DateTimeKind.Local).AddTicks(6419));

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "survey_statuses",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "survey_questions",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "survey_answers",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "responses",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "responses",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 1, 15, 53, 28, 44, DateTimeKind.Local).AddTicks(7525),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 5, 1, 13, 30, 34, 34, DateTimeKind.Local).AddTicks(2875));

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "response_questions",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "response_answers",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.UpdateData(
                table: "survey_statuses",
                keyColumn: "status_id",
                keyValue: 1,
                column: "deleted_at",
                value: null);

            migrationBuilder.UpdateData(
                table: "survey_statuses",
                keyColumn: "status_id",
                keyValue: 2,
                column: "deleted_at",
                value: null);

            migrationBuilder.UpdateData(
                table: "survey_statuses",
                keyColumn: "status_id",
                keyValue: 3,
                column: "deleted_at",
                value: null);

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "tag_id",
                keyValue: 1,
                column: "deleted_at",
                value: null);

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "tag_id",
                keyValue: 2,
                column: "deleted_at",
                value: null);

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "tag_id",
                keyValue: 3,
                column: "deleted_at",
                value: null);

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "tag_id",
                keyValue: 4,
                column: "deleted_at",
                value: null);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 1,
                column: "deleted_at",
                value: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 1, 13, 30, 34, 33, DateTimeKind.Local).AddTicks(7215),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 5, 1, 15, 53, 28, 44, DateTimeKind.Local).AddTicks(2249));

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "tags",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "surveys",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "surveys",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 1, 13, 30, 34, 31, DateTimeKind.Local).AddTicks(6419),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 5, 1, 15, 53, 28, 42, DateTimeKind.Local).AddTicks(9761));

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "survey_statuses",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "survey_questions",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "survey_answers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "responses",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "responses",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 1, 13, 30, 34, 34, DateTimeKind.Local).AddTicks(2875),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 5, 1, 15, 53, 28, 44, DateTimeKind.Local).AddTicks(7525));

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "response_questions",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "response_answers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "survey_statuses",
                keyColumn: "status_id",
                keyValue: 1,
                column: "deleted_at",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "survey_statuses",
                keyColumn: "status_id",
                keyValue: 2,
                column: "deleted_at",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "survey_statuses",
                keyColumn: "status_id",
                keyValue: 3,
                column: "deleted_at",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "tag_id",
                keyValue: 1,
                column: "deleted_at",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "tag_id",
                keyValue: 2,
                column: "deleted_at",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "tag_id",
                keyValue: 3,
                column: "deleted_at",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "tag_id",
                keyValue: 4,
                column: "deleted_at",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 1,
                column: "deleted_at",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
