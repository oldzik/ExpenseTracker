using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpenseTracker.Infrastructure.Migrations
{
    public partial class ChangingPlannedExpenseModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlannedExpenses_MonthOfYears_MonthOfYearId",
                table: "PlannedExpenses");

            migrationBuilder.DropIndex(
                name: "IX_PlannedExpenses_MonthOfYearId",
                table: "PlannedExpenses");

            migrationBuilder.DropColumn(
                name: "MonthOfYearId",
                table: "PlannedExpenses");

            migrationBuilder.AddColumn<DateTime>(
                name: "MonthOfYear",
                table: "PlannedExpenses",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MonthOfYear",
                table: "PlannedExpenses");

            migrationBuilder.AddColumn<int>(
                name: "MonthOfYearId",
                table: "PlannedExpenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PlannedExpenses_MonthOfYearId",
                table: "PlannedExpenses",
                column: "MonthOfYearId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlannedExpenses_MonthOfYears_MonthOfYearId",
                table: "PlannedExpenses",
                column: "MonthOfYearId",
                principalTable: "MonthOfYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
