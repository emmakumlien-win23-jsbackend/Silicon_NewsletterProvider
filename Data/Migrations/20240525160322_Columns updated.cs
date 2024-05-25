using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Columnsupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AdvertisingUpdate",
                table: "subscriber",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DailyNewsLetter",
                table: "subscriber",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EventUpdates",
                table: "subscriber",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Podcast",
                table: "subscriber",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StartupWeekly",
                table: "subscriber",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "WeekinReview",
                table: "subscriber",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdvertisingUpdate",
                table: "subscriber");

            migrationBuilder.DropColumn(
                name: "DailyNewsLetter",
                table: "subscriber");

            migrationBuilder.DropColumn(
                name: "EventUpdates",
                table: "subscriber");

            migrationBuilder.DropColumn(
                name: "Podcast",
                table: "subscriber");

            migrationBuilder.DropColumn(
                name: "StartupWeekly",
                table: "subscriber");

            migrationBuilder.DropColumn(
                name: "WeekinReview",
                table: "subscriber");
        }
    }
}
