using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.API.Migrations
{
    public partial class CodeFirst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Population = table.Column<int>(nullable: false),
                    LandArea = table.Column<int>(nullable: false),
                    Density = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OfficialLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageName = table.Column<string>(maxLength: 100, nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficialLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfficialLanguages_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Density", "LandArea", "Name", "Population" },
                values: new object[] { 1, 60, 652860, "Afghanistan", 38928346 });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Density", "LandArea", "Name", "Population" },
                values: new object[] { 2, 105, 27400, "Albania", 2877797 });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Density", "LandArea", "Name", "Population" },
                values: new object[] { 3, 18, 2381740, "Algeria", 43851044 });

            migrationBuilder.InsertData(
                table: "OfficialLanguages",
                columns: new[] { "Id", "CountryId", "LanguageName" },
                values: new object[,]
                {
                    { 1, 1, "Pashto" },
                    { 2, 1, "Dari" },
                    { 3, 2, "Albanian" },
                    { 4, 3, "Arabic" },
                    { 5, 3, "Tamazight" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfficialLanguages_CountryId",
                table: "OfficialLanguages",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfficialLanguages");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
