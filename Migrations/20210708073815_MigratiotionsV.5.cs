using Microsoft.EntityFrameworkCore.Migrations;

namespace BeltExam.Migrations
{
    public partial class MigratiotionsV5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserHobby_Hobby_HobbyId",
                table: "UserHobby");

            migrationBuilder.DropForeignKey(
                name: "FK_UserHobby_Users_UserId",
                table: "UserHobby");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserHobby",
                table: "UserHobby");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hobby",
                table: "Hobby");

            migrationBuilder.RenameTable(
                name: "UserHobby",
                newName: "UserHobbies");

            migrationBuilder.RenameTable(
                name: "Hobby",
                newName: "Hobbies");

            migrationBuilder.RenameIndex(
                name: "IX_UserHobby_UserId",
                table: "UserHobbies",
                newName: "IX_UserHobbies_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserHobby_HobbyId",
                table: "UserHobbies",
                newName: "IX_UserHobbies_HobbyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserHobbies",
                table: "UserHobbies",
                column: "UserHobbyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hobbies",
                table: "Hobbies",
                column: "HobbyId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserHobbies_Hobbies_HobbyId",
                table: "UserHobbies",
                column: "HobbyId",
                principalTable: "Hobbies",
                principalColumn: "HobbyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserHobbies_Users_UserId",
                table: "UserHobbies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserHobbies_Hobbies_HobbyId",
                table: "UserHobbies");

            migrationBuilder.DropForeignKey(
                name: "FK_UserHobbies_Users_UserId",
                table: "UserHobbies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserHobbies",
                table: "UserHobbies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hobbies",
                table: "Hobbies");

            migrationBuilder.RenameTable(
                name: "UserHobbies",
                newName: "UserHobby");

            migrationBuilder.RenameTable(
                name: "Hobbies",
                newName: "Hobby");

            migrationBuilder.RenameIndex(
                name: "IX_UserHobbies_UserId",
                table: "UserHobby",
                newName: "IX_UserHobby_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserHobbies_HobbyId",
                table: "UserHobby",
                newName: "IX_UserHobby_HobbyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserHobby",
                table: "UserHobby",
                column: "UserHobbyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hobby",
                table: "Hobby",
                column: "HobbyId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserHobby_Hobby_HobbyId",
                table: "UserHobby",
                column: "HobbyId",
                principalTable: "Hobby",
                principalColumn: "HobbyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserHobby_Users_UserId",
                table: "UserHobby",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
