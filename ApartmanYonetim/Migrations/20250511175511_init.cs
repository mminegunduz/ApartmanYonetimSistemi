using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApartmanYonetim.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calisans",
                columns: table => new
                {
                    CalisanId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CalisanAdi = table.Column<string>(type: "TEXT", nullable: true),
                    Sifre = table.Column<string>(type: "TEXT", nullable: true),
                    Gorev = table.Column<string>(type: "TEXT", nullable: true),
                    Telefon = table.Column<string>(type: "TEXT", nullable: true),
                    Mail = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calisans", x => x.CalisanId);
                });

            migrationBuilder.CreateTable(
                name: "Duyurus",
                columns: table => new
                {
                    DuyuruId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Baslik = table.Column<string>(type: "TEXT", nullable: true),
                    Icerik = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duyurus", x => x.DuyuruId);
                });

            migrationBuilder.CreateTable(
                name: "Gorevs",
                columns: table => new
                {
                    GorevId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GorevAd = table.Column<string>(type: "TEXT", nullable: true),
                    Durum = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gorevs", x => x.GorevId);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicis",
                columns: table => new
                {
                    KullaniciId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KullaniciAd = table.Column<string>(type: "TEXT", nullable: true),
                    Sifre = table.Column<string>(type: "TEXT", nullable: true),
                    Telefon = table.Column<string>(type: "TEXT", nullable: true),
                    Mail = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicis", x => x.KullaniciId);
                });

            migrationBuilder.CreateTable(
                name: "Odemes",
                columns: table => new
                {
                    OdemeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KullaniciId = table.Column<int>(type: "INTEGER", nullable: false),
                    KullaniciAd = table.Column<string>(type: "TEXT", nullable: true),
                    OdenecekTutar = table.Column<int>(type: "INTEGER", nullable: false),
                    OdemeBilgisi = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odemes", x => x.OdemeId);
                });

            migrationBuilder.InsertData(
                table: "Calisans",
                columns: new[] { "CalisanId", "CalisanAdi", "Gorev", "Mail", "Sifre", "Telefon" },
                values: new object[] { 11, "Ahmet Yılmaz", "Çöpleri Topla", "ahmet@gmail.com", "1234", "0575 486 33 12" });

            migrationBuilder.InsertData(
                table: "Gorevs",
                columns: new[] { "GorevId", "Durum", "GorevAd" },
                values: new object[] { 1, true, "Çöpleri Topla" });

            migrationBuilder.InsertData(
                table: "Kullanicis",
                columns: new[] { "KullaniciId", "KullaniciAd", "Mail", "Sifre", "Telefon" },
                values: new object[] { 1, "Fatma Açıkgöz", "fatma@gmail.com", "1234", "0555 444 33 22" });

            migrationBuilder.InsertData(
                table: "Kullanicis",
                columns: new[] { "KullaniciId", "KullaniciAd", "Mail", "Sifre", "Telefon" },
                values: new object[] { 2, "Sinem Kaya", "sinem@gmail.com", "1234", "0523 414 33 22" });

            migrationBuilder.InsertData(
                table: "Kullanicis",
                columns: new[] { "KullaniciId", "KullaniciAd", "Mail", "Sifre", "Telefon" },
                values: new object[] { 3, "Ali Tulup", "ali@gmail.com", "1234", "0509 314 45 45" });

            migrationBuilder.InsertData(
                table: "Kullanicis",
                columns: new[] { "KullaniciId", "KullaniciAd", "Mail", "Sifre", "Telefon" },
                values: new object[] { 4, "Erkut Demirci", "erkut@gmail.com", "1234", "0595 416 57 19" });

            migrationBuilder.InsertData(
                table: "Kullanicis",
                columns: new[] { "KullaniciId", "KullaniciAd", "Mail", "Sifre", "Telefon" },
                values: new object[] { 5, "Umut Kaya", "umut@gmail.com", "1234", "0556 364 11 00" });

            migrationBuilder.InsertData(
                table: "Kullanicis",
                columns: new[] { "KullaniciId", "KullaniciAd", "Mail", "Sifre", "Telefon" },
                values: new object[] { 6, "Mehmet Dinçer", "mehmet@gmail.com", "1234", "0567 444 33 22" });

            migrationBuilder.InsertData(
                table: "Kullanicis",
                columns: new[] { "KullaniciId", "KullaniciAd", "Mail", "Sifre", "Telefon" },
                values: new object[] { 7, "Sueda İnce", "sueda@gmail.com", "1234", "0544 567 17 17" });

            migrationBuilder.InsertData(
                table: "Kullanicis",
                columns: new[] { "KullaniciId", "KullaniciAd", "Mail", "Sifre", "Telefon" },
                values: new object[] { 8, "Sudenaz Gündüz", "sudenaz@gmail.com", "1234", "0543 419 45 57" });

            migrationBuilder.InsertData(
                table: "Kullanicis",
                columns: new[] { "KullaniciId", "KullaniciAd", "Mail", "Sifre", "Telefon" },
                values: new object[] { 9, "Selin Poyraz", "selin@gmail.com", "1234", "0557 654 75 45" });

            migrationBuilder.InsertData(
                table: "Kullanicis",
                columns: new[] { "KullaniciId", "KullaniciAd", "Mail", "Sifre", "Telefon" },
                values: new object[] { 10, "Esra Kasap", "esra@gmail.com", "1234", "0585 325 93 22" });

            migrationBuilder.InsertData(
                table: "Kullanicis",
                columns: new[] { "KullaniciId", "KullaniciAd", "Mail", "Sifre", "Telefon" },
                values: new object[] { 11, "Ahmet Yılmaz", "ahmet@gmail.com", "1234", "0575 486 33 12" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calisans");

            migrationBuilder.DropTable(
                name: "Duyurus");

            migrationBuilder.DropTable(
                name: "Gorevs");

            migrationBuilder.DropTable(
                name: "Kullanicis");

            migrationBuilder.DropTable(
                name: "Odemes");
        }
    }
}
