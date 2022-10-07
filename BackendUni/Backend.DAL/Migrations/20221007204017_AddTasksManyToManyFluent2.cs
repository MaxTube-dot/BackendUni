using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.DAL.Migrations
{
    public partial class AddTasksManyToManyFluent2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskUser_Users_UsersId",
                table: "TaskUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskUser",
                table: "TaskUser");

            migrationBuilder.DropIndex(
                name: "IX_TaskUser_UsersId",
                table: "TaskUser");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "TaskUser",
                newName: "TargetUsersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskUser",
                table: "TaskUser",
                columns: new[] { "TargetUsersId", "TasksId" });

            migrationBuilder.CreateIndex(
                name: "IX_TaskUser_TasksId",
                table: "TaskUser",
                column: "TasksId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskUser_Users_TargetUsersId",
                table: "TaskUser",
                column: "TargetUsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskUser_Users_TargetUsersId",
                table: "TaskUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskUser",
                table: "TaskUser");

            migrationBuilder.DropIndex(
                name: "IX_TaskUser_TasksId",
                table: "TaskUser");

            migrationBuilder.RenameColumn(
                name: "TargetUsersId",
                table: "TaskUser",
                newName: "UsersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskUser",
                table: "TaskUser",
                columns: new[] { "TasksId", "UsersId" });

            migrationBuilder.CreateIndex(
                name: "IX_TaskUser_UsersId",
                table: "TaskUser",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskUser_Users_UsersId",
                table: "TaskUser",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
