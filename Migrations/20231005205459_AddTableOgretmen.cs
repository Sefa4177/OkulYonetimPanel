using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OkulYonetimPaneli.Migrations
{
    /// <inheritdoc />
    public partial class AddTableOgretmen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OgretmenId",
                table: "Dersler",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ogretmenler",
                columns: table => new
                {
                    OgretmenId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(type: "TEXT", nullable: true),
                    Soyad = table.Column<string>(type: "TEXT", nullable: true),
                    Eposta = table.Column<string>(type: "TEXT", nullable: true),
                    Telefon = table.Column<string>(type: "TEXT", nullable: true),
                    BaslamaTarihi = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogretmenler", x => x.OgretmenId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dersler_OgretmenId",
                table: "Dersler",
                column: "OgretmenId");

            migrationBuilder.CreateIndex(
                name: "IX_DersKayitlari_DersId",
                table: "DersKayitlari",
                column: "DersId");

            migrationBuilder.CreateIndex(
                name: "IX_DersKayitlari_OgrenciId",
                table: "DersKayitlari",
                column: "OgrenciId");

            migrationBuilder.AddForeignKey(
                name: "FK_DersKayitlari_Dersler_DersId",
                table: "DersKayitlari",
                column: "DersId",
                principalTable: "Dersler",
                principalColumn: "DersId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DersKayitlari_Ogrenciler_OgrenciId",
                table: "DersKayitlari",
                column: "OgrenciId",
                principalTable: "Ogrenciler",
                principalColumn: "OgrenciId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dersler_Ogretmenler_OgretmenId",
                table: "Dersler",
                column: "OgretmenId",
                principalTable: "Ogretmenler",
                principalColumn: "OgretmenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DersKayitlari_Dersler_DersId",
                table: "DersKayitlari");

            migrationBuilder.DropForeignKey(
                name: "FK_DersKayitlari_Ogrenciler_OgrenciId",
                table: "DersKayitlari");

            migrationBuilder.DropForeignKey(
                name: "FK_Dersler_Ogretmenler_OgretmenId",
                table: "Dersler");

            migrationBuilder.DropTable(
                name: "Ogretmenler");

            migrationBuilder.DropIndex(
                name: "IX_Dersler_OgretmenId",
                table: "Dersler");

            migrationBuilder.DropIndex(
                name: "IX_DersKayitlari_DersId",
                table: "DersKayitlari");

            migrationBuilder.DropIndex(
                name: "IX_DersKayitlari_OgrenciId",
                table: "DersKayitlari");

            migrationBuilder.DropColumn(
                name: "OgretmenId",
                table: "Dersler");
        }
    }
}
