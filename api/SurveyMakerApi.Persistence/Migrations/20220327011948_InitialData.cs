using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyMakerApi.Persistence.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "statuses",
                columns: table => new
                {
                    status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.status_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    tag_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.tag_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.user_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "surveys",
                columns: table => new
                {
                    survey_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Link = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndsAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DisabledAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    survey_status_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.survey_id);
                    table.ForeignKey(
                        name: "fk_survey_statuses",
                        column: x => x.survey_status_id,
                        principalTable: "statuses",
                        principalColumn: "status_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_surveys_users",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "surveys_tags",
                columns: table => new
                {
                    SurveyTagsId = table.Column<int>(type: "int", nullable: false),
                    SurveysId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_surveys_tags", x => new { x.SurveyTagsId, x.SurveysId });
                    table.ForeignKey(
                        name: "FK_surveys_tags_surveys_SurveysId",
                        column: x => x.SurveysId,
                        principalTable: "surveys",
                        principalColumn: "survey_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_surveys_tags_tags_SurveyTagsId",
                        column: x => x.SurveyTagsId,
                        principalTable: "tags",
                        principalColumn: "tag_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "statuses",
                columns: new[] { "status_id", "Name" },
                values: new object[,]
                {
                    { 1, "Active" },
                    { 2, "Draft" },
                    { 3, "Completed" }
                });

            migrationBuilder.InsertData(
                table: "tags",
                columns: new[] { "tag_id", "Name" },
                values: new object[,]
                {
                    { 1, "Sports" },
                    { 2, "Basketball" },
                    { 3, "Education" },
                    { 4, "Politics" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "user_id", "Email", "Password" },
                values: new object[] { 1, "test@test.com", "test" });

            migrationBuilder.CreateIndex(
                name: "fk_survey_survey_statuses_idx",
                table: "surveys",
                column: "survey_id");

            migrationBuilder.CreateIndex(
                name: "fk_survey_users_idx",
                table: "surveys",
                column: "survey_id");

            migrationBuilder.CreateIndex(
                name: "IX_surveys_survey_status_id",
                table: "surveys",
                column: "survey_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_surveys_user_id",
                table: "surveys",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_surveys_tags_SurveysId",
                table: "surveys_tags",
                column: "SurveysId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "surveys_tags");

            migrationBuilder.DropTable(
                name: "surveys");

            migrationBuilder.DropTable(
                name: "tags");

            migrationBuilder.DropTable(
                name: "statuses");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
