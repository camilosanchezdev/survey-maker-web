using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyMakerApi.Persistence.Migrations
{
    public partial class Response3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Response_surveys_SurveyId",
                table: "Response");

            migrationBuilder.DropForeignKey(
                name: "FK_ResponseAnswer_ResponseQuestion_ResponseQuestionId",
                table: "ResponseAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_ResponseQuestion_Response_ResponseId",
                table: "ResponseQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResponseQuestion",
                table: "ResponseQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResponseAnswer",
                table: "ResponseAnswer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Response",
                table: "Response");

            migrationBuilder.RenameTable(
                name: "ResponseQuestion",
                newName: "response_question");

            migrationBuilder.RenameTable(
                name: "ResponseAnswer",
                newName: "response_answer");

            migrationBuilder.RenameTable(
                name: "Response",
                newName: "responses");

            migrationBuilder.RenameColumn(
                name: "ResponseId",
                table: "response_question",
                newName: "response_id");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "response_question",
                newName: "question_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "response_question",
                newName: "response_question_id");

            migrationBuilder.RenameIndex(
                name: "IX_ResponseQuestion_ResponseId",
                table: "response_question",
                newName: "IX_response_question_response_id");

            migrationBuilder.RenameColumn(
                name: "ResponseQuestionId",
                table: "response_answer",
                newName: "response_question_id");

            migrationBuilder.RenameColumn(
                name: "AnswerId",
                table: "response_answer",
                newName: "answer_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "response_answer",
                newName: "response_answer_id");

            migrationBuilder.RenameIndex(
                name: "IX_ResponseAnswer_ResponseQuestionId",
                table: "response_answer",
                newName: "IX_response_answer_response_question_id");

            migrationBuilder.RenameColumn(
                name: "SurveyId",
                table: "responses",
                newName: "survey_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "responses",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "responses",
                newName: "response_id");

            migrationBuilder.RenameIndex(
                name: "IX_Response_SurveyId",
                table: "responses",
                newName: "IX_responses_survey_id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "responses",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 13, 21, 17, 18, 0, DateTimeKind.Local).AddTicks(4939),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_response_question",
                table: "response_question",
                column: "response_question_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_response_answer",
                table: "response_answer",
                column: "response_answer_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_responses",
                table: "responses",
                column: "response_id");

            migrationBuilder.CreateIndex(
                name: "IX_response_question_question_id",
                table: "response_question",
                column: "question_id");

            migrationBuilder.CreateIndex(
                name: "IX_response_answer_answer_id",
                table: "response_answer",
                column: "answer_id");

            migrationBuilder.AddForeignKey(
                name: "FK_response_answer_answers_answer_id",
                table: "response_answer",
                column: "answer_id",
                principalTable: "answers",
                principalColumn: "answer_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_response_answer_response_question_response_question_id",
                table: "response_answer",
                column: "response_question_id",
                principalTable: "response_question",
                principalColumn: "response_question_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_response_question_questions_question_id",
                table: "response_question",
                column: "question_id",
                principalTable: "questions",
                principalColumn: "question_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_response_question_responses_response_id",
                table: "response_question",
                column: "response_id",
                principalTable: "responses",
                principalColumn: "response_id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_response_answer_answers_answer_id",
                table: "response_answer");

            migrationBuilder.DropForeignKey(
                name: "FK_response_answer_response_question_response_question_id",
                table: "response_answer");

            migrationBuilder.DropForeignKey(
                name: "FK_response_question_questions_question_id",
                table: "response_question");

            migrationBuilder.DropForeignKey(
                name: "FK_response_question_responses_response_id",
                table: "response_question");

            migrationBuilder.DropForeignKey(
                name: "FK_responses_surveys_survey_id",
                table: "responses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_responses",
                table: "responses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_response_question",
                table: "response_question");

            migrationBuilder.DropIndex(
                name: "IX_response_question_question_id",
                table: "response_question");

            migrationBuilder.DropPrimaryKey(
                name: "PK_response_answer",
                table: "response_answer");

            migrationBuilder.DropIndex(
                name: "IX_response_answer_answer_id",
                table: "response_answer");

            migrationBuilder.RenameTable(
                name: "responses",
                newName: "Response");

            migrationBuilder.RenameTable(
                name: "response_question",
                newName: "ResponseQuestion");

            migrationBuilder.RenameTable(
                name: "response_answer",
                newName: "ResponseAnswer");

            migrationBuilder.RenameColumn(
                name: "survey_id",
                table: "Response",
                newName: "SurveyId");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "Response",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "response_id",
                table: "Response",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_responses_survey_id",
                table: "Response",
                newName: "IX_Response_SurveyId");

            migrationBuilder.RenameColumn(
                name: "response_id",
                table: "ResponseQuestion",
                newName: "ResponseId");

            migrationBuilder.RenameColumn(
                name: "question_id",
                table: "ResponseQuestion",
                newName: "QuestionId");

            migrationBuilder.RenameColumn(
                name: "response_question_id",
                table: "ResponseQuestion",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_response_question_response_id",
                table: "ResponseQuestion",
                newName: "IX_ResponseQuestion_ResponseId");

            migrationBuilder.RenameColumn(
                name: "response_question_id",
                table: "ResponseAnswer",
                newName: "ResponseQuestionId");

            migrationBuilder.RenameColumn(
                name: "answer_id",
                table: "ResponseAnswer",
                newName: "AnswerId");

            migrationBuilder.RenameColumn(
                name: "response_answer_id",
                table: "ResponseAnswer",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_response_answer_response_question_id",
                table: "ResponseAnswer",
                newName: "IX_ResponseAnswer_ResponseQuestionId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Response",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 4, 13, 21, 17, 18, 0, DateTimeKind.Local).AddTicks(4939));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Response",
                table: "Response",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResponseQuestion",
                table: "ResponseQuestion",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResponseAnswer",
                table: "ResponseAnswer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Response_surveys_SurveyId",
                table: "Response",
                column: "SurveyId",
                principalTable: "surveys",
                principalColumn: "survey_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResponseAnswer_ResponseQuestion_ResponseQuestionId",
                table: "ResponseAnswer",
                column: "ResponseQuestionId",
                principalTable: "ResponseQuestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResponseQuestion_Response_ResponseId",
                table: "ResponseQuestion",
                column: "ResponseId",
                principalTable: "Response",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
