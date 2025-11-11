using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace finelytics.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateWithCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "Plans");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Plans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsEnable",
                table: "Plans",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Plans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Plans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_UsersGroups_GroupId",
                table: "UsersGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersGroups_UserId",
                table: "UsersGroups",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPlans_PlanId",
                table: "UserPlans",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPlans_UserId",
                table: "UserPlans",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlansCategories_CategoryId",
                table: "PlansCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PlansCategories_PlanId",
                table: "PlansCategories",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlansCategories_Categories_CategoryId",
                table: "PlansCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlansCategories_Plans_PlanId",
                table: "PlansCategories",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPlans_Plans_PlanId",
                table: "UserPlans",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPlans_Users_UserId",
                table: "UserPlans",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersGroups_Groups_GroupId",
                table: "UsersGroups",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersGroups_Users_UserId",
                table: "UsersGroups",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlansCategories_Categories_CategoryId",
                table: "PlansCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_PlansCategories_Plans_PlanId",
                table: "PlansCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPlans_Plans_PlanId",
                table: "UserPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPlans_Users_UserId",
                table: "UserPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersGroups_Groups_GroupId",
                table: "UsersGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersGroups_Users_UserId",
                table: "UsersGroups");

            migrationBuilder.DropIndex(
                name: "IX_UsersGroups_GroupId",
                table: "UsersGroups");

            migrationBuilder.DropIndex(
                name: "IX_UsersGroups_UserId",
                table: "UsersGroups");

            migrationBuilder.DropIndex(
                name: "IX_UserPlans_PlanId",
                table: "UserPlans");

            migrationBuilder.DropIndex(
                name: "IX_UserPlans_UserId",
                table: "UserPlans");

            migrationBuilder.DropIndex(
                name: "IX_PlansCategories_CategoryId",
                table: "PlansCategories");

            migrationBuilder.DropIndex(
                name: "IX_PlansCategories_PlanId",
                table: "PlansCategories");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "IsEnable",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Plans");

            migrationBuilder.AddColumn<DateTime>(
                name: "Period",
                table: "Plans",
                type: "datetime2",
                maxLength: 50,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
