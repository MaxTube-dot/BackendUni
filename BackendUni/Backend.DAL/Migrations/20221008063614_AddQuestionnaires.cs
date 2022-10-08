using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Backend.DAL.Migrations
{
    public partial class AddQuestionnaires : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questionnaires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questionnaires", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnswerVariants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "text", nullable: true),
                    QuestionnaireId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerVariants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerVariants_Questionnaires_QuestionnaireId",
                        column: x => x.QuestionnaireId,
                        principalTable: "Questionnaires",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuestionnaireUser",
                columns: table => new
                {
                    QuestionnairesId = table.Column<int>(type: "integer", nullable: false),
                    TargetUsersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionnaireUser", x => new { x.QuestionnairesId, x.TargetUsersId });
                    table.ForeignKey(
                        name: "FK_QuestionnaireUser_Questionnaires_QuestionnairesId",
                        column: x => x.QuestionnairesId,
                        principalTable: "Questionnaires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionnaireUser_Users_TargetUsersId",
                        column: x => x.TargetUsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersQuestionnaireAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    QuestionnaireId = table.Column<int>(type: "integer", nullable: true),
                    AnswerVariantId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersQuestionnaireAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersQuestionnaireAnswers_AnswerVariants_AnswerVariantId",
                        column: x => x.AnswerVariantId,
                        principalTable: "AnswerVariants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsersQuestionnaireAnswers_Questionnaires_QuestionnaireId",
                        column: x => x.QuestionnaireId,
                        principalTable: "Questionnaires",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsersQuestionnaireAnswers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerVariants_QuestionnaireId",
                table: "AnswerVariants",
                column: "QuestionnaireId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionnaireUser_TargetUsersId",
                table: "QuestionnaireUser",
                column: "TargetUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersQuestionnaireAnswers_AnswerVariantId",
                table: "UsersQuestionnaireAnswers",
                column: "AnswerVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersQuestionnaireAnswers_QuestionnaireId",
                table: "UsersQuestionnaireAnswers",
                column: "QuestionnaireId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersQuestionnaireAnswers_UserId",
                table: "UsersQuestionnaireAnswers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionnaireUser");

            migrationBuilder.DropTable(
                name: "UsersQuestionnaireAnswers");

            migrationBuilder.DropTable(
                name: "AnswerVariants");

            migrationBuilder.DropTable(
                name: "Questionnaires");
        }
    }
}
