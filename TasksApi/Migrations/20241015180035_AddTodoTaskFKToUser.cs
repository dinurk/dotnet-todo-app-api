using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TasksApi.Migrations
{
    /// <inheritdoc />
    public partial class AddTodoTaskFKToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "TodoTasks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TodoTasks_CreatorId",
                table: "TodoTasks",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "My_CreatorId_Constraint",
                table: "TodoTasks",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "My_CreatorId_Constraint",
                table: "TodoTasks");

            migrationBuilder.DropIndex(
                name: "IX_TodoTasks_CreatorId",
                table: "TodoTasks");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "TodoTasks");
        }
    }
}
