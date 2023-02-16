using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZadatakAPI.Migrations
{
    /// <inheritdoc />
    public partial class Updatedentities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stavke_Racuna_Proizvod_ProizvodID",
                table: "Stavke_Racuna");

            migrationBuilder.DropForeignKey(
                name: "FK_Stavke_Racuna_Zaglavlje_Racuna_RacunID",
                table: "Stavke_Racuna");

            migrationBuilder.DropForeignKey(
                name: "FK_Zaglavlje_Racuna_Kupac_KupacID",
                table: "Zaglavlje_Racuna");

            migrationBuilder.DropIndex(
                name: "IX_Stavke_Racuna_RacunID",
                table: "Stavke_Racuna");

            migrationBuilder.RenameColumn(
                name: "KupacID",
                table: "Zaglavlje_Racuna",
                newName: "KupacId");

            migrationBuilder.RenameIndex(
                name: "IX_Zaglavlje_Racuna_KupacID",
                table: "Zaglavlje_Racuna",
                newName: "IX_Zaglavlje_Racuna_KupacId");

            migrationBuilder.RenameColumn(
                name: "RacunID",
                table: "Stavke_Racuna",
                newName: "RacunId");

            migrationBuilder.RenameColumn(
                name: "ProizvodID",
                table: "Stavke_Racuna",
                newName: "ProizvodId");

            migrationBuilder.RenameIndex(
                name: "IX_Stavke_Racuna_ProizvodID",
                table: "Stavke_Racuna",
                newName: "IX_Stavke_Racuna_ProizvodId");

            migrationBuilder.AddColumn<int>(
                name: "Zaglavlje_RacunaId",
                table: "Stavke_Racuna",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Mjesto",
                table: "Kupac",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Adresa",
                table: "Kupac",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.CreateIndex(
                name: "IX_Stavke_Racuna_Zaglavlje_RacunaId",
                table: "Stavke_Racuna",
                column: "Zaglavlje_RacunaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stavke_Racuna_Proizvod_ProizvodId",
                table: "Stavke_Racuna",
                column: "ProizvodId",
                principalTable: "Proizvod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stavke_Racuna_Zaglavlje_Racuna_Zaglavlje_RacunaId",
                table: "Stavke_Racuna",
                column: "Zaglavlje_RacunaId",
                principalTable: "Zaglavlje_Racuna",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Zaglavlje_Racuna_Kupac_KupacId",
                table: "Zaglavlje_Racuna",
                column: "KupacId",
                principalTable: "Kupac",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stavke_Racuna_Proizvod_ProizvodId",
                table: "Stavke_Racuna");

            migrationBuilder.DropForeignKey(
                name: "FK_Stavke_Racuna_Zaglavlje_Racuna_Zaglavlje_RacunaId",
                table: "Stavke_Racuna");

            migrationBuilder.DropForeignKey(
                name: "FK_Zaglavlje_Racuna_Kupac_KupacId",
                table: "Zaglavlje_Racuna");

            migrationBuilder.DropIndex(
                name: "IX_Stavke_Racuna_Zaglavlje_RacunaId",
                table: "Stavke_Racuna");

            migrationBuilder.DropColumn(
                name: "Zaglavlje_RacunaId",
                table: "Stavke_Racuna");

            migrationBuilder.RenameColumn(
                name: "KupacId",
                table: "Zaglavlje_Racuna",
                newName: "KupacID");

            migrationBuilder.RenameIndex(
                name: "IX_Zaglavlje_Racuna_KupacId",
                table: "Zaglavlje_Racuna",
                newName: "IX_Zaglavlje_Racuna_KupacID");

            migrationBuilder.RenameColumn(
                name: "RacunId",
                table: "Stavke_Racuna",
                newName: "RacunID");

            migrationBuilder.RenameColumn(
                name: "ProizvodId",
                table: "Stavke_Racuna",
                newName: "ProizvodID");

            migrationBuilder.RenameIndex(
                name: "IX_Stavke_Racuna_ProizvodId",
                table: "Stavke_Racuna",
                newName: "IX_Stavke_Racuna_ProizvodID");

            migrationBuilder.AlterColumn<string>(
                name: "Mjesto",
                table: "Kupac",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Adresa",
                table: "Kupac",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateIndex(
                name: "IX_Stavke_Racuna_RacunID",
                table: "Stavke_Racuna",
                column: "RacunID");

            migrationBuilder.AddForeignKey(
                name: "FK_Stavke_Racuna_Proizvod_ProizvodID",
                table: "Stavke_Racuna",
                column: "ProizvodID",
                principalTable: "Proizvod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stavke_Racuna_Zaglavlje_Racuna_RacunID",
                table: "Stavke_Racuna",
                column: "RacunID",
                principalTable: "Zaglavlje_Racuna",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Zaglavlje_Racuna_Kupac_KupacID",
                table: "Zaglavlje_Racuna",
                column: "KupacID",
                principalTable: "Kupac",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
