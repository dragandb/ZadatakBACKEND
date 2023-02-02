using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ZadatakAPI.Migrations
{
    /// <inheritdoc />
    public partial class Firstmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kupac",
                columns: table => new
                {
                    KupacID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Sifra = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Naziv = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Adresa = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Mjesto = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kupac", x => x.KupacID);
                });

            migrationBuilder.CreateTable(
                name: "Proizvod",
                columns: table => new
                {
                    ProizvodID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Sifra = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Naziv = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Jedinicamjere = table.Column<string>(name: "Jedinica_mjere", type: "character varying(20)", maxLength: 20, nullable: false),
                    Cijena = table.Column<decimal>(type: "numeric", nullable: false),
                    Stanje = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvod", x => x.ProizvodID);
                });

            migrationBuilder.CreateTable(
                name: "Zaglavlje_Racuna",
                columns: table => new
                {
                    RacunID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Broj = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Datum = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Napomena = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    KupacID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaglavlje_Racuna", x => x.RacunID);
                    table.ForeignKey(
                        name: "FK_Zaglavlje_Racuna_Kupac_KupacID",
                        column: x => x.KupacID,
                        principalTable: "Kupac",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stavke_Racuna",
                columns: table => new
                {
                    StavkeID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Kolicina = table.Column<int>(type: "integer", nullable: false),
                    Cijena = table.Column<decimal>(type: "numeric", nullable: false),
                    Popust = table.Column<decimal>(type: "numeric", nullable: false),
                    Iznospopusta = table.Column<decimal>(name: "Iznos_popusta", type: "numeric", nullable: false),
                    Vrijednost = table.Column<decimal>(type: "numeric", nullable: false),
                    ProizvodID = table.Column<int>(type: "integer", nullable: false),
                    RacunID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stavke_Racuna", x => x.StavkeID);
                    table.ForeignKey(
                        name: "FK_Stavke_Racuna_Proizvod_ProizvodID",
                        column: x => x.ProizvodID,
                        principalTable: "Proizvod",
                        principalColumn: "ProizvodID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stavke_Racuna_Zaglavlje_Racuna_RacunID",
                        column: x => x.RacunID,
                        principalTable: "Zaglavlje_Racuna",
                        principalColumn: "RacunID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kupac_Sifra",
                table: "Kupac",
                column: "Sifra",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proizvod_Sifra",
                table: "Proizvod",
                column: "Sifra",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stavke_Racuna_ProizvodID",
                table: "Stavke_Racuna",
                column: "ProizvodID");

            migrationBuilder.CreateIndex(
                name: "IX_Stavke_Racuna_RacunID",
                table: "Stavke_Racuna",
                column: "RacunID");

            migrationBuilder.CreateIndex(
                name: "IX_Zaglavlje_Racuna_Broj",
                table: "Zaglavlje_Racuna",
                column: "Broj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zaglavlje_Racuna_KupacID",
                table: "Zaglavlje_Racuna",
                column: "KupacID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stavke_Racuna");

            migrationBuilder.DropTable(
                name: "Proizvod");

            migrationBuilder.DropTable(
                name: "Zaglavlje_Racuna");

            migrationBuilder.DropTable(
                name: "Kupac");
        }
    }
}
