using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevHabits.api.Migrations.Application;

/// <inheritdoc />
public partial class AddingTagsEntity : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "tags",
            schema: "dev_habits",
            columns: table => new
            {
                id = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                created_at_utc = table.Column<DateTime>(type: "datetime2", nullable: false),
                updated_at_utc = table.Column<DateTime>(type: "datetime2", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_tags", x => x.id);
            });

        migrationBuilder.CreateIndex(
            name: "ix_tags_name",
            schema: "dev_habits",
            table: "tags",
            column: "name",
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "tags",
            schema: "dev_habits");
    }
}
