using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZadatakAPI.Migrations
{
    /// <inheritdoc />
    public partial class druga : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RacunID",
                table: "Zaglavlje_Racuna",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "StavkeID",
                table: "Stavke_Racuna",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProizvodID",
                table: "Proizvod",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "KupacID",
                table: "Kupac",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Zaglavlje_Racuna",
                newName: "RacunID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Stavke_Racuna",
                newName: "StavkeID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Proizvod",
                newName: "ProizvodID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Kupac",
                newName: "KupacID");
        }
    }
}
