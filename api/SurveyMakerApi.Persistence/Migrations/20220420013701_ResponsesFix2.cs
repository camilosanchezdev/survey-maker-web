using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyMakerApi.Persistence.Migrations
{
    public partial class ResponsesFix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_response_answers",
                table: "response_answers");

            migrationBuilder.DropForeignKey(
                name: "fk_response_questions",
                table: "response_questions");

            migrationBuilder.RenameColumn(
                name: "response_id",
                table: "response_questions",
                newName: "ResponseId");

            migrationBuilder.RenameIndex(
                name: "IX_response_questions_response_id",
                table: "response_questions",
                newName: "IX_response_questions_ResponseId");

            migrationBuilder.RenameColumn(
                name: "response_question_id",
                table: "response_answers",
                newName: "ResponseQuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_response_answers_response_question_id",
                table: "response_answers",
                newName: "IX_response_answers_ResponseQuestionId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "surveys",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 22, 37, 0, 785, DateTimeKind.Local).AddTicks(2046),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 4, 19, 22, 21, 58, 924, DateTimeKind.Local).AddTicks(1203));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "responses",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 22, 37, 0, 786, DateTimeKind.Local).AddTicks(8147),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 4, 19, 22, 21, 58, 925, DateTimeKind.Local).AddTicks(8516));

            migrationBuilder.AlterColumn<int>(
                name: "ResponseId",
                table: "response_questions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_responses_survey_id",
                table: "responses",
                column: "survey_id");

            migrationBuilder.AddForeignKey(
                name: "FK_response_answers_response_questions_ResponseQuestionId",
                table: "response_answers",
                column: "ResponseQuestionId",
                principalTable: "response_questions",
                principalColumn: "response_question_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_response_questions_responses_ResponseId",
                table: "response_questions",
                column: "ResponseId",
                principalTable: "responses",
                principalColumn: "response_id");

            migrationBuilder.AddForeignKey(
                name: "FK_responses_surveys_survey_id",
                table: "responses",
                column: "survey_id",
                principalTable: "surveys",
                principalColumn: "survey_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_response_answers_response_questions_ResponseQuestionId",
                table: "response_answers");

            migrationBuilder.DropForeignKey(
                name: "FK_response_questions_responses_ResponseId",
                table: "response_questions");

            migrationBuilder.DropForeignKey(
                name: "FK_responses_surveys_survey_id",
                table: "responses");

            migrationBuilder.DropIndex(
                name: "IX_responses_survey_id",
                table: "responses");

            migrationBuilder.RenameColumn(
                name: "ResponseId",
                table: "response_questions",
                newName: "response_id");

            migrationBuilder.RenameIndex(
                name: "IX_response_questions_ResponseId",
                table: "response_questions",
                newName: "IX_response_questions_response_id");

            migrationBuilder.RenameColumn(
                name: "ResponseQuestionId",
                table: "response_answers",
                newName: "response_question_id");

            migrationBuilder.RenameIndex(
                name: "IX_response_answers_ResponseQuestionId",
                table: "response_answers",
                newName: "IX_response_answers_response_question_id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "surveys",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 22, 21, 58, 924, DateTimeKind.Local).AddTicks(1203),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 4, 19, 22, 37, 0, 785, DateTimeKind.Local).AddTicks(2046));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "responses",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 19, 22, 21, 58, 925, DateTimeKind.Local).AddTicks(8516),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 4, 19, 22, 37, 0, 786, DateTimeKind.Local).AddTicks(8147));

            migrationBuilder.AlterColumn<int>(
                name: "response_id",
                table: "response_questions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
