using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevHabits.api.Migrations.Application;

/// <inheritdoc />
public partial class COnfiguringTag : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            name: "name",
            schema: "dev_habits",
            table: "tags",
            type: "nvarchar(10)",
            maxLength: 10,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(50)",
            oldMaxLength: 50);

        migrationBuilder.AlterColumn<string>(
            name: "description",
            schema: "dev_habits",
            table: "tags",
            type: "nvarchar(80)",
            maxLength: 80,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(500)",
            oldMaxLength: 500,
            oldNullable: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            name: "name",
            schema: "dev_habits",
            table: "tags",
            type: "nvarchar(50)",
            maxLength: 50,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(10)",
            oldMaxLength: 10);

        migrationBuilder.AlterColumn<string>(
            name: "description",
            schema: "dev_habits",
            table: "tags",
            type: "nvarchar(500)",
            maxLength: 500,
            nullable: true,
            oldClrType: typeof(string),
            oldType: "nvarchar(80)",
            oldMaxLength: 80,
            oldNullable: true);
    }
}
