using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobTracker.Migrations
{
    /// <inheritdoc />
    public partial class salaryRangeToOwnedEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalaryRange",
                table: "JobOffers");

            migrationBuilder.AddColumn<int>(
                name: "SalaryRange_Max",
                table: "JobOffers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalaryRange_Min",
                table: "JobOffers",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalaryRange_Max",
                table: "JobOffers");

            migrationBuilder.DropColumn(
                name: "SalaryRange_Min",
                table: "JobOffers");

            migrationBuilder.AddColumn<string>(
                name: "SalaryRange",
                table: "JobOffers",
                type: "TEXT",
                nullable: true);
        }
    }
}
