using System;

using Microsoft.EntityFrameworkCore.Migrations;

namespace MyProject.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "links",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created = table.Column<DateTime>(nullable: false, defaultValueSql: "now() at time zone 'utc'"),
                    last_updated = table.Column<DateTime>(nullable: true, defaultValueSql: "now() at time zone 'utc'"),
                    destination = table.Column<string>(maxLength: 64, nullable: false),
                    sub_domain = table.Column<string>(maxLength: 4, nullable: false),
                    link_type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_links", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "persons",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created = table.Column<DateTime>(nullable: false),
                    last_updated = table.Column<DateTime>(nullable: true),
                    first_name = table.Column<string>(nullable: false),
                    last_name = table.Column<string>(nullable: false),
                    midle_nblame = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_persons", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created = table.Column<DateTime>(nullable: false, defaultValueSql: "now() at time zone 'utc'"),
                    last_updated = table.Column<DateTime>(nullable: true, defaultValueSql: "now() at time zone 'utc'"),
                    user_name = table.Column<string>(maxLength: 64, nullable: false),
                    passsword = table.Column<string>(maxLength: 128, nullable: false),
                    user_type = table.Column<int>(nullable: false),
                    person_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_users_persons_person_id",
                        column: x => x.person_id,
                        principalTable: "persons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_users_person_id",
                table: "users",
                column: "person_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "links");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "persons");
        }
    }
}
