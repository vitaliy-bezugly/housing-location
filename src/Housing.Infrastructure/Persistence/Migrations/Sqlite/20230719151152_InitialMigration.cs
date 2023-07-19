using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Housing.Infrastructure.Persistence.Migrations.Sqlite
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HousingLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 512, nullable: false),
                    city = table.Column<string>(type: "TEXT", maxLength: 512, nullable: false),
                    state = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    photo = table.Column<string>(type: "TEXT", maxLength: 512, nullable: true),
                    available_units = table.Column<int>(type: "INTEGER", nullable: false),
                    wifi = table.Column<bool>(type: "INTEGER", nullable: false),
                    laundry = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HousingLocations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HousingLocations");
        }
    }
}
