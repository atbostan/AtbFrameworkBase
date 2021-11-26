using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtbFramework.Persistance.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Example",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    City = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Number = table.Column<int>(type: "int", maxLength: 25, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<int>(type: "int", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifierUserId = table.Column<int>(type: "int", nullable: false),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletorUserId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Example", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Example",
                columns: new[] { "Id", "City", "CreationTime", "CreatorUserId", "DeletionTime", "DeletorUserId", "IsDeleted", "ModificationTime", "ModifierUserId", "Name", "Number", "Surname" },
                values: new object[] { 1, "Ankara", new DateTime(2021, 11, 26, 0, 7, 32, 805, DateTimeKind.Local).AddTicks(8426), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Ahmet Tarık", 88754, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Example");
        }
    }
}
