using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_business_areas",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_business_areas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_citizens",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    last_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    first_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    middle_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    birth_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    gender = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    registration_address = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    inn = table.Column<long>(type: "bigint", nullable: false),
                    snils = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_citizens", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_organizations",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    full_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    short_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    business_area_id = table.Column<int>(type: "integer", nullable: false),
                    ceo_id = table.Column<int>(type: "integer", nullable: false),
                    authorized_capital = table.Column<long>(type: "bigint", nullable: false),
                    inn = table.Column<long>(type: "bigint", fixedLength: true, maxLength: 10, nullable: false),
                    kpp = table.Column<long>(type: "bigint", fixedLength: true, maxLength: 9, nullable: false),
                    ogrn = table.Column<long>(type: "bigint", fixedLength: true, maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_organizations", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_organizations_t_business_areas_business_area_id",
                        column: x => x.business_area_id,
                        principalTable: "t_business_areas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_organizations_t_citizens_ceo_id",
                        column: x => x.ceo_id,
                        principalTable: "t_citizens",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_organizations_business_area_id",
                table: "t_organizations",
                column: "business_area_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_organizations_ceo_id",
                table: "t_organizations",
                column: "ceo_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_organizations");

            migrationBuilder.DropTable(
                name: "t_business_areas");

            migrationBuilder.DropTable(
                name: "t_citizens");
        }
    }
}
