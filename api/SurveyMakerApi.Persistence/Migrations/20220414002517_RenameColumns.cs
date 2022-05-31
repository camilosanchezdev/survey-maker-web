using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyMakerApi.Persistence.Migrations
{
    public partial class RenameColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_answers_questions_QuestionId",
                table: "answers");

            migrationBuilder.DropForeignKey(
                name: "FK_questions_surveys_SurveyId",
                table: "questions");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_response_question",
                table: "response_question");

            migrationBuilder.DropPrimaryKey(
                name: "PK_response_answer",
                table: "response_answer");

            migrationBuilder.RenameTable(
                name: "statuses",
                newName: "survey_statuses");

            migrationBuilder.RenameTable(
                name: "response_question",
                newName: "response_questions");

            migrationBuilder.RenameTable(
                name: "response_answer",
                newName: "response_answers");

            migrationBuilder.RenameTable(
                name: "questions",
                newName: "survey_questions");

            migrationBuilder.RenameTable(
                name: "answers",
                newName: "survey_answers");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "tags",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "surveys",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Link",
                table: "surveys",
                newName: "link");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "surveys",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "EndsAt",
                table: "surveys",
                newName: "ends_at");

            migrationBuilder.RenameColumn(
                name: "DisabledAt",
                table: "surveys",
                newName: "disabled_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "surveys",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "survey_statuses",
                newName: "name");

            migrationBuilder.RenameIndex(
                name: "IX_response_question_response_id",
                table: "response_questions",
                newName: "IX_response_questions_response_id");

            migrationBuilder.RenameIndex(
                name: "IX_response_question_question_id",
                table: "response_questions",
                newName: "IX_response_questions_question_id");

            migrationBuilder.RenameIndex(
                name: "IX_response_answer_response_question_id",
                table: "response_answers",
                newName: "IX_response_answers_response_question_id");

            migrationBuilder.RenameIndex(
                name: "IX_response_answer_answer_id",
                table: "response_answers",
                newName: "IX_response_answers_answer_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "survey_questions",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "SurveyId",
                table: "survey_questions",
                newName: "survey_id");

            migrationBuilder.RenameIndex(
                name: "IX_questions_SurveyId",
                table: "survey_questions",
                newName: "IX_survey_questions_survey_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "survey_answers",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "survey_answers",
                newName: "question_id");

            migrationBuilder.RenameIndex(
                name: "IX_answers_QuestionId",
                table: "survey_answers",
                newName: "IX_survey_answers_question_id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "surveys",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 13, 21, 25, 16, 990, DateTimeKind.Local).AddTicks(5454),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "responses",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 13, 21, 25, 16, 992, DateTimeKind.Local).AddTicks(3479),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 4, 13, 21, 17, 18, 0, DateTimeKind.Local).AddTicks(4939));

            migrationBuilder.AddPrimaryKey(
                name: "PK_response_questions",
                table: "response_questions",
                column: "response_question_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_response_answers",
                table: "response_answers",
                column: "response_answer_id");

            migrationBuilder.AddForeignKey(
                name: "FK_response_answers_response_questions_response_question_id",
                table: "response_answers",
                column: "response_question_id",
                principalTable: "response_questions",
                principalColumn: "response_question_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_response_answers_survey_answers_answer_id",
                table: "response_answers",
                column: "answer_id",
                principalTable: "survey_answers",
                principalColumn: "answer_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_response_questions_responses_response_id",
                table: "response_questions",
                column: "response_id",
                principalTable: "responses",
                principalColumn: "response_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_response_questions_survey_questions_question_id",
                table: "response_questions",
                column: "question_id",
                principalTable: "survey_questions",
                principalColumn: "question_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_survey_answers_survey_questions_question_id",
                table: "survey_answers",
                column: "question_id",
                principalTable: "survey_questions",
                principalColumn: "question_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_survey_questions_surveys_survey_id",
                table: "survey_questions",
                column: "survey_id",
                principalTable: "surveys",
                principalColumn: "survey_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_response_answers_response_questions_response_question_id",
                table: "response_answers");

            migrationBuilder.DropForeignKey(
                name: "FK_response_answers_survey_answers_answer_id",
                table: "response_answers");

            migrationBuilder.DropForeignKey(
                name: "FK_response_questions_responses_response_id",
                table: "response_questions");

            migrationBuilder.DropForeignKey(
                name: "FK_response_questions_survey_questions_question_id",
                table: "response_questions");

            migrationBuilder.DropForeignKey(
                name: "FK_survey_answers_survey_questions_question_id",
                table: "survey_answers");

            migrationBuilder.DropForeignKey(
                name: "FK_survey_questions_surveys_survey_id",
                table: "survey_questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_response_questions",
                table: "response_questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_response_answers",
                table: "response_answers");

            migrationBuilder.RenameTable(
                name: "survey_statuses",
                newName: "statuses");

            migrationBuilder.RenameTable(
                name: "survey_questions",
                newName: "questions");

            migrationBuilder.RenameTable(
                name: "survey_answers",
                newName: "answers");

            migrationBuilder.RenameTable(
                name: "response_questions",
                newName: "response_question");

            migrationBuilder.RenameTable(
                name: "response_answers",
                newName: "response_answer");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "tags",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "surveys",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "link",
                table: "surveys",
                newName: "Link");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "surveys",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "ends_at",
                table: "surveys",
                newName: "EndsAt");

            migrationBuilder.RenameColumn(
                name: "disabled_at",
                table: "surveys",
                newName: "DisabledAt");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "surveys",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "statuses",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "questions",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "survey_id",
                table: "questions",
                newName: "SurveyId");

            migrationBuilder.RenameIndex(
                name: "IX_survey_questions_survey_id",
                table: "questions",
                newName: "IX_questions_SurveyId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "answers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "question_id",
                table: "answers",
                newName: "QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_survey_answers_question_id",
                table: "answers",
                newName: "IX_answers_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_response_questions_response_id",
                table: "response_question",
                newName: "IX_response_question_response_id");

            migrationBuilder.RenameIndex(
                name: "IX_response_questions_question_id",
                table: "response_question",
                newName: "IX_response_question_question_id");

            migrationBuilder.RenameIndex(
                name: "IX_response_answers_response_question_id",
                table: "response_answer",
                newName: "IX_response_answer_response_question_id");

            migrationBuilder.RenameIndex(
                name: "IX_response_answers_answer_id",
                table: "response_answer",
                newName: "IX_response_answer_answer_id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "surveys",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 4, 13, 21, 25, 16, 990, DateTimeKind.Local).AddTicks(5454));

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "responses",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 13, 21, 17, 18, 0, DateTimeKind.Local).AddTicks(4939),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 4, 13, 21, 25, 16, 992, DateTimeKind.Local).AddTicks(3479));

            migrationBuilder.AddPrimaryKey(
                name: "PK_response_question",
                table: "response_question",
                column: "response_question_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_response_answer",
                table: "response_answer",
                column: "response_answer_id");

            migrationBuilder.AddForeignKey(
                name: "FK_answers_questions_QuestionId",
                table: "answers",
                column: "QuestionId",
                principalTable: "questions",
                principalColumn: "question_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_questions_surveys_SurveyId",
                table: "questions",
                column: "SurveyId",
                principalTable: "surveys",
                principalColumn: "survey_id",
                onDelete: ReferentialAction.Cascade);

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
        }
    }
}
