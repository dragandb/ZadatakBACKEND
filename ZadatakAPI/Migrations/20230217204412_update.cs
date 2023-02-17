using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZadatakAPI.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stavke_Racuna_Zaglavlje_Racuna_Zaglavlje_RacunaId",
                table: "Stavke_Racuna");

            migrationBuilder.DropIndex(
                name: "IX_Stavke_Racuna_Zaglavlje_RacunaId",
                table: "Stavke_Racuna");

            migrationBuilder.DropColumn(
                name: "Zaglavlje_RacunaId",
                table: "Stavke_Racuna");

            migrationBuilder.CreateIndex(
                name: "IX_Stavke_Racuna_RacunId",
                table: "Stavke_Racuna",
                column: "RacunId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stavke_Racuna_Zaglavlje_Racuna_RacunId",
                table: "Stavke_Racuna",
                column: "RacunId",
                principalTable: "Zaglavlje_Racuna",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stavke_Racuna_Zaglavlje_Racuna_RacunId",
                table: "Stavke_Racuna");

            migrationBuilder.DropIndex(
                name: "IX_Stavke_Racuna_RacunId",
                table: "Stavke_Racuna");

            migrationBuilder.AddColumn<int>(
                name: "Zaglavlje_RacunaId",
                table: "Stavke_Racuna",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stavke_Racuna_Zaglavlje_RacunaId",
                table: "Stavke_Racuna",
                column: "Zaglavlje_RacunaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stavke_Racuna_Zaglavlje_Racuna_Zaglavlje_RacunaId",
                table: "Stavke_Racuna",
                column: "Zaglavlje_RacunaId",
                principalTable: "Zaglavlje_Racuna",
                principalColumn: "Id");
        }
    }
}
