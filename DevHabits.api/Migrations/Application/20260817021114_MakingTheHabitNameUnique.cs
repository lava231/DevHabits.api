using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevHabits.api.Migrations.Application;

/// <inheritdoc />
public partial class MakingTheHabitNameUnique : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            name: "ix_habits_name",
            schema: "dev_habits",
            table: "habits");

        migrationBuilder.CreateIndex(
            name: "ix_habits_name",
            schema: "dev_habits",
            table: "habits",
            column: "name",
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            name: "ix_habits_name",
            schema: "dev_habits",
            table: "habits");

        migrationBuilder.CreateIndex(
            name: "ix_habits_name",
            schema: "dev_habits",
            table: "habits",
            column: "name");
    }
}
