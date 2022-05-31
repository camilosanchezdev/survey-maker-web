using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyMakerApi.Persistence.Migrations
{
    public partial class MultipleAnswers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "surveys",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 14, 19, 45, 30, 698, DateTimeKind.Local).AddTicks(9257),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 4, 13, 22, 20, 24, 331, DateTimeKind.Local).AddTicks(913));

            migrationBuilder.AddColumn<bool>(
                name: "multiple",
                table: "survey_questions",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "responses",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 14, 19, 45, 30, 700, DateTimeKind.Local).AddTicks(5044),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 4, 13, 22, 20, 24, 333, DateTimeKind.Local).AddTicks(2998));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "multiple",
                table: "survey_questions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "surveys",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 13, 22, 20, 24, 331, DateTimeKind.Local).AddTicks(913),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 4, 14, 19, 45, 30, 698, DateTimeKind.Local).AddTicks(9257));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "responses",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 13, 22, 20, 24, 333, DateTimeKind.Local).AddTicks(2998),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 4, 14, 19, 45, 30, 700, DateTimeKind.Local).AddTicks(5044));
        }
    }
}
