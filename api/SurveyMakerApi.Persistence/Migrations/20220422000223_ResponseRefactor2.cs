using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyMakerApi.Persistence.Migrations
{
    public partial class ResponseRefactor2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_response_questions_responses_ResponseId",
                table: "response_questions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "surveys",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 21, 21, 2, 22, 783, DateTimeKind.Local).AddTicks(7311),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 4, 21, 21, 0, 45, 82, DateTimeKind.Local).AddTicks(7697));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "responses",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 21, 21, 2, 22, 785, DateTimeKind.Local).AddTicks(2911),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 4, 21, 21, 0, 45, 84, DateTimeKind.Local).AddTicks(7456));

            migrationBuilder.AlterColumn<int>(
                name: "ResponseId",
                table: "response_questions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_response_questions_responses_ResponseId",
                table: "response_questions",
                column: "ResponseId",
                principalTable: "responses",
                principalColumn: "response_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_response_questions_responses_ResponseId",
                table: "response_questions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "surveys",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 21, 21, 0, 45, 82, DateTimeKind.Local).AddTicks(7697),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 4, 21, 21, 2, 22, 783, DateTimeKind.Local).AddTicks(7311));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "responses",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 21, 21, 0, 45, 84, DateTimeKind.Local).AddTicks(7456),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 4, 21, 21, 2, 22, 785, DateTimeKind.Local).AddTicks(2911));

            migrationBuilder.AlterColumn<int>(
                name: "ResponseId",
                table: "response_questions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_response_questions_responses_ResponseId",
                table: "response_questions",
                column: "ResponseId",
                principalTable: "responses",
                principalColumn: "response_id");
        }
    }
}
