using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OkulYonetimPaneli.Migrations
{
    /// <inheritdoc />
    public partial class CloumnOgretmenIdRequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dersler_Ogretmenler_OgretmenId",
                table: "Dersler");

            migrationBuilder.AlterColumn<int>(
                name: "OgretmenId",
                table: "Dersler",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dersler_Ogretmenler_OgretmenId",
                table: "Dersler",
                column: "OgretmenId",
                principalTable: "Ogretmenler",
                principalColumn: "OgretmenId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dersler_Ogretmenler_OgretmenId",
                table: "Dersler");

            migrationBuilder.AlterColumn<int>(
                name: "OgretmenId",
                table: "Dersler",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Dersler_Ogretmenler_OgretmenId",
                table: "Dersler",
                column: "OgretmenId",
                principalTable: "Ogretmenler",
                principalColumn: "OgretmenId");
        }
    }
}
