using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfitService.Migrations
{
    /// <inheritdoc />
    public partial class CreatingDbForProfitService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProfitReports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    TotalProfit = table.Column<decimal>(type: "numeric", nullable: false),
                    MonthlyProfit = table.Column<decimal>(type: "numeric", nullable: false),
                    ReportDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfitReports", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfitReports");
        }
    }
}
