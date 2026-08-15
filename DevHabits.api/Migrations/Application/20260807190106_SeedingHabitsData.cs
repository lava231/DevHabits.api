using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DevHabits.api.Migrations.Application;

/// <inheritdoc />
public partial class SeedingHabitsData : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.InsertData(
            schema: "dev_habits",
            table: "habits",
            columns: new[] { "id", "frequency_time_per_period", "frequency_type", "created_at_utc", "description", "end_date", "is_archived", "last_completed_at_utc", "name", "status", "type", "updated_at_utc", "milestone_current", "milestone_target", "target_unit", "target_value" },
            values: new object[,]
            {
                { "habit-001", 1, 1, new DateTime(2026, 8, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Drink at least 2 liters of water per day", null, false, null, "Drink Water", 1, 2, null, 8, 30, "liters", 2 },
                { "habit-002", 1, 1, new DateTime(2026, 8, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Read 20 pages every day", null, false, null, "Read Books", 1, 2, null, 260, 1000, "pages", 20 },
                { "habit-003", 4, 2, new DateTime(2026, 8, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Complete four workouts per week", null, false, null, "Exercise", 1, 1, null, 12, 50, "workout", 1 },
                { "habit-004", 1, 1, new DateTime(2026, 8, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Meditate for 10 minutes every day", null, false, null, "Meditate", 1, 2, null, 5, 30, "minutes", 10 },
                { "habit-005", 1, 1, new DateTime(2026, 8, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Avoid eating fast food", null, false, null, "No Fast Food", 1, 1, null, 14, 30, "day", 1 },
                { "habit-006", 1, 1, new DateTime(2026, 8, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Practice backend development for one hour", null, false, null, "Practice Coding", 1, 2, null, 37, 100, "minutes", 60 },
                { "habit-007", 3, 2, new DateTime(2026, 8, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Run five kilometers three times per week", null, false, null, "Running", 1, 2, null, 25, 100, "km", 5 }
            });

        migrationBuilder.InsertData(
            schema: "dev_habits",
            table: "habits",
            columns: new[] { "id", "frequency_time_per_period", "frequency_type", "created_at_utc", "description", "end_date", "is_archived", "last_completed_at_utc", "name", "status", "type", "updated_at_utc", "target_unit", "target_value" },
            values: new object[] { "habit-008", 2, 2, new DateTime(2026, 8, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Call family twice per week", null, false, null, "Call Family", 1, 1, null, "call", 1 });

        migrationBuilder.InsertData(
            schema: "dev_habits",
            table: "habits",
            columns: new[] { "id", "frequency_time_per_period", "frequency_type", "created_at_utc", "description", "end_date", "is_archived", "last_completed_at_utc", "name", "status", "type", "updated_at_utc", "milestone_current", "milestone_target", "target_unit", "target_value" },
            values: new object[,]
            {
                { "habit-009", 5, 2, new DateTime(2026, 6, 28, 0, 0, 0, 0, DateTimeKind.Utc), "Complete a backend development course", null, false, new DateTime(2026, 8, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Complete Course", 2, 1, new DateTime(2026, 8, 7, 0, 0, 0, 0, DateTimeKind.Utc), 40, 40, "lesson", 1 },
                { "habit-010", 1, 1, new DateTime(2026, 8, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Study two hours every day", null, false, null, "Study", 1, 2, null, 18, 30, "hours", 2 }
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            schema: "dev_habits",
            table: "habits",
            keyColumn: "id",
            keyValue: "habit-001");

        migrationBuilder.DeleteData(
            schema: "dev_habits",
            table: "habits",
            keyColumn: "id",
            keyValue: "habit-002");

        migrationBuilder.DeleteData(
            schema: "dev_habits",
            table: "habits",
            keyColumn: "id",
            keyValue: "habit-003");

        migrationBuilder.DeleteData(
            schema: "dev_habits",
            table: "habits",
            keyColumn: "id",
            keyValue: "habit-004");

        migrationBuilder.DeleteData(
            schema: "dev_habits",
            table: "habits",
            keyColumn: "id",
            keyValue: "habit-005");

        migrationBuilder.DeleteData(
            schema: "dev_habits",
            table: "habits",
            keyColumn: "id",
            keyValue: "habit-006");

        migrationBuilder.DeleteData(
            schema: "dev_habits",
            table: "habits",
            keyColumn: "id",
            keyValue: "habit-007");

        migrationBuilder.DeleteData(
            schema: "dev_habits",
            table: "habits",
            keyColumn: "id",
            keyValue: "habit-008");

        migrationBuilder.DeleteData(
            schema: "dev_habits",
            table: "habits",
            keyColumn: "id",
            keyValue: "habit-009");

        migrationBuilder.DeleteData(
            schema: "dev_habits",
            table: "habits",
            keyColumn: "id",
            keyValue: "habit-010");
    }
}
