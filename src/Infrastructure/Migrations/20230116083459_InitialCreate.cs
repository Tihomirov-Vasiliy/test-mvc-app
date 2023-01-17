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
                name: "business_areas",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_business_areas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "organizations",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    full_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    short_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    business_area_id = table.Column<int>(type: "integer", nullable: false),
                    fio_ceo = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    authorized_capital = table.Column<long>(type: "bigint", nullable: false),
                    inn = table.Column<long>(type: "bigint", fixedLength: true, maxLength: 10, nullable: false),
                    kpp = table.Column<long>(type: "bigint", fixedLength: true, maxLength: 9, nullable: false),
                    ogrn = table.Column<long>(type: "bigint", fixedLength: true, maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_organizations", x => x.id);
                    table.ForeignKey(
                        name: "fk_organizations_business_areas_business_area_id",
                        column: x => x.business_area_id,
                        principalTable: "business_areas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "ix_organizations_business_area_id",
                table: "organizations",
                column: "business_area_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "organizations");

            migrationBuilder.DropTable(
                name: "business_areas");
        }
    }
}
