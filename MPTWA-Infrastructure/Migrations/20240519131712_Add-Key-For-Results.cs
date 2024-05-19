using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MPTWA_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddKeyForResults : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "request_log_entity_id",
                table: "results_logs",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "ix_results_logs_request_log_entity_id",
                table: "results_logs",
                column: "request_log_entity_id");

            migrationBuilder.AddForeignKey(
                name: "fk_results_logs_request_logs_request_log_entity_id",
                table: "results_logs",
                column: "request_log_entity_id",
                principalTable: "request_logs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_results_logs_request_logs_request_log_entity_id",
                table: "results_logs");

            migrationBuilder.DropIndex(
                name: "ix_results_logs_request_log_entity_id",
                table: "results_logs");

            migrationBuilder.DropColumn(
                name: "request_log_entity_id",
                table: "results_logs");
        }
    }
}
