using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ApiQueriesControlAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "QueryHistoryId",
                table: "Vehicles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ApiQueryHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QueryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MinEffectiness = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaxEffectiness = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiQueryHistories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_QueryHistoryId",
                table: "Vehicles",
                column: "QueryHistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_ApiQueryHistories_QueryHistoryId",
                table: "Vehicles",
                column: "QueryHistoryId",
                principalTable: "ApiQueryHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_ApiQueryHistories_QueryHistoryId",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "ApiQueryHistories");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_QueryHistoryId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "QueryHistoryId",
                table: "Vehicles");
        }
    }
}
