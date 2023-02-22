using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZadatakAPI.Migrations
{
    /// <inheritdoc />
    public partial class update4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Zaglavlje_Racuna",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Ukupno",
                table: "Zaglavlje_Racuna",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "UkupnoPopust",
                table: "Zaglavlje_Racuna",
                type: "numeric",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "Zaglavlje_Racuna");

            migrationBuilder.DropColumn(
                name: "Ukupno",
                table: "Zaglavlje_Racuna");

            migrationBuilder.DropColumn(
                name: "UkupnoPopust",
                table: "Zaglavlje_Racuna");
        }
    }
}
