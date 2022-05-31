using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyMakerApi.Persistence.Migrations
{
    public partial class ResponseConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_response_answers_response_questions_response_question_id",
                table: "response_answers");

            migrationBuilder.DropForeignKey(
                name: "FK_response_questions_responses_response_id",
                table: "response_questions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "surveys",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 14, 22, 3, 27, 825, DateTimeKind.Local).AddTicks(348),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 4, 14, 19, 45, 30, 698, DateTimeKind.Local).AddTicks(9257));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "responses",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 14, 22, 3, 27, 826, DateTimeKind.Local).AddTicks(4611),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 4, 14, 19, 45, 30, 700, DateTimeKind.Local).AddTicks(5044));

            migrationBuilder.AddForeignKey(
                name: "fk_response_answers",
                table: "response_answers",
                column: "response_question_id",
                principalTable: "response_questions",
                principalColumn: "response_question_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_response_questions",
                table: "response_questions",
                column: "response_id",
                principalTable: "responses",
                principalColumn: "response_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_response_answers",
                table: "response_answers");

            migrationBuilder.DropForeignKey(
                name: "fk_response_questions",
                table: "response_questions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "surveys",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 14, 19, 45, 30, 698, DateTimeKind.Local).AddTicks(9257),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 4, 14, 22, 3, 27, 825, DateTimeKind.Local).AddTicks(348));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "responses",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 14, 19, 45, 30, 700, DateTimeKind.Local).AddTicks(5044),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 4, 14, 22, 3, 27, 826, DateTimeKind.Local).AddTicks(4611));

            migrationBuilder.AddForeignKey(
                name: "FK_response_answers_response_questions_response_question_id",
                table: "response_answers",
                column: "response_question_id",
                principalTable: "response_questions",
                principalColumn: "response_question_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_response_questions_responses_response_id",
                table: "response_questions",
                column: "response_id",
                principalTable: "responses",
                principalColumn: "response_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
