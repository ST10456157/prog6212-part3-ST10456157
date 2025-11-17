using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace prog6212_part3_ST10456157.Migrations
{
    /// <inheritdoc />
    public partial class AddClaimStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    ClaimId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LecturerName = table.Column<string>(type: "TEXT", nullable: false),
                    HoursWorked = table.Column<int>(type: "INTEGER", nullable: false),
                    HourlyRate = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    DateSubmitted = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateVerified = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateApproved = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DocumentName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.ClaimId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Claims");
        }
    }
}
