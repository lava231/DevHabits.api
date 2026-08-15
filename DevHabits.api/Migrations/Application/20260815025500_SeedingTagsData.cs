using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DevHabits.api.Migrations.Application;

/// <inheritdoc />
public partial class SeedingTagsData : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.InsertData(
            schema: "dev_habits",
            table: "tags",
            columns: new[] { "id", "created_at_utc", "description", "name", "updated_at_utc" },
            values: new object[,]
            {
                { "tag-001", new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Habits related to health and overall wellness", "Health", null },
                { "tag-002", new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Habits related to exercise and physical activity", "Fitness", null },
                { "tag-003", new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Habits related to studying and acquiring knowledge", "Learning", null },
                { "tag-004", new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Habits related to productivity and efficiency", "Productivity", null },
                { "tag-005", new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Habits related to mindfulness and mental well-being", "Mindfulness", null },
                { "tag-006", new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Habits related to food and healthy eating", "Nutrition", null },
                { "tag-007", new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Habits related to programming and software development", "Coding", null },
                { "tag-008", new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Habits related to personal growth and development", "Personal", null },
                { "tag-009", new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Habits related to family, friends, and relationships", "Social", null },
                { "tag-010", new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Habits related to money and financial management", "Finance", null }
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            schema: "dev_habits",
            table: "tags",
            keyColumn: "id",
            keyValue: "tag-001");

        migrationBuilder.DeleteData(
            schema: "dev_habits",
            table: "tags",
            keyColumn: "id",
            keyValue: "tag-002");

        migrationBuilder.DeleteData(
            schema: "dev_habits",
            table: "tags",
            keyColumn: "id",
            keyValue: "tag-003");

        migrationBuilder.DeleteData(
            schema: "dev_habits",
            table: "tags",
            keyColumn: "id",
            keyValue: "tag-004");

        migrationBuilder.DeleteData(
            schema: "dev_habits",
            table: "tags",
            keyColumn: "id",
            keyValue: "tag-005");

        migrationBuilder.DeleteData(
            schema: "dev_habits",
            table: "tags",
            keyColumn: "id",
            keyValue: "tag-006");

        migrationBuilder.DeleteData(
            schema: "dev_habits",
            table: "tags",
            keyColumn: "id",
            keyValue: "tag-007");

        migrationBuilder.DeleteData(
            schema: "dev_habits",
            table: "tags",
            keyColumn: "id",
            keyValue: "tag-008");

        migrationBuilder.DeleteData(
            schema: "dev_habits",
            table: "tags",
            keyColumn: "id",
            keyValue: "tag-009");

        migrationBuilder.DeleteData(
            schema: "dev_habits",
            table: "tags",
            keyColumn: "id",
            keyValue: "tag-010");
    }
}
