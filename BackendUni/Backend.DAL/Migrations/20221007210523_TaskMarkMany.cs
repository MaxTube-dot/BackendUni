using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.DAL.Migrations
{
    public partial class TaskMarkMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marks_Tasks_TaskId",
                table: "Marks");

            migrationBuilder.DropIndex(
                name: "IX_Marks_TaskId",
                table: "Marks");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Marks");

            migrationBuilder.CreateTable(
                name: "MarkTask",
                columns: table => new
                {
                    MarksId = table.Column<int>(type: "integer", nullable: false),
                    TasksId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarkTask", x => new { x.MarksId, x.TasksId });
                    table.ForeignKey(
                        name: "FK_MarkTask_Marks_MarksId",
                        column: x => x.MarksId,
                        principalTable: "Marks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarkTask_Tasks_TasksId",
                        column: x => x.TasksId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MarkTask_TasksId",
                table: "MarkTask",
                column: "TasksId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarkTask");

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "Marks",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Marks_TaskId",
                table: "Marks",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Marks_Tasks_TaskId",
                table: "Marks",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id");
        }
    }
}
