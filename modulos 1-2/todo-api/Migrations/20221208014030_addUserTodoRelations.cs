using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace todoapi.Migrations
{
    /// <inheritdoc />
    public partial class addUserTodoRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "TodoDemo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TodoDemo_UserId",
                table: "TodoDemo",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoDemo_User_UserId",
                table: "TodoDemo",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoDemo_User_UserId",
                table: "TodoDemo");

            migrationBuilder.DropIndex(
                name: "IX_TodoDemo_UserId",
                table: "TodoDemo");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TodoDemo");
        }
    }
}
