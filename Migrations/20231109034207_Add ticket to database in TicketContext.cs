using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketToDo.Migrations
{
    /// <inheritdoc />
    public partial class AddtickettodatabaseinTicketContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Statuses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "Description", "DueDate", "Name", "PointValue", "SprintNumber", "StatusId" },
                values: new object[] { 5, "do this task", new DateTime(2023, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "task", 2, 4, "qa" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Statuses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
