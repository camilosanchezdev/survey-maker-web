using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyMakerApi.Persistence.Migrations
{
    public partial class ResponsesFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_responses_surveys_survey_id",
                table: "responses");

            migrationBuilder.DropIndex(
                name: "IX_responses_survey_id",
                table: "responses");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "surveys",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 22, 21, 58, 924, DateTimeKind.Local).AddTicks(1203),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 4, 14, 22, 3, 27, 825, DateTimeKind.Local).AddTicks(348));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "responses",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 22, 21, 58, 925, DateTimeKind.Local).AddTicks(8516),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 4, 14, 22, 3, 27, 826, DateTimeKind.Local).AddTicks(4611));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "surveys",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 14, 22, 3, 27, 825, DateTimeKind.Local).AddTicks(348),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 4, 19, 22, 21, 58, 924, DateTimeKind.Local).AddTicks(1203));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "responses",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 14, 22, 3, 27, 826, DateTimeKind.Local).AddTicks(4611),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 4, 19, 22, 21, 58, 925, DateTimeKind.Local).AddTicks(8516));

            migrationBuilder.CreateIndex(
                name: "IX_responses_survey_id",
                table: "responses",
                column: "survey_id");

            migrationBuilder.AddForeignKey(
                name: "FK_responses_surveys_survey_id",
                table: "responses",
                column: "survey_id",
                principalTable: "surveys",
                principalColumn: "survey_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
