using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Eventodo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "ModuleSequence");

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Url = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModulesAgenda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"ModuleSequence\"')"),
                    Title = table.Column<string>(type: "text", nullable: false),
                    EventId = table.Column<int>(type: "integer", nullable: false),
                    Day = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModulesAgenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModulesAgenda_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModulesGalery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('\"ModuleSequence\"')"),
                    Title = table.Column<string>(type: "text", nullable: false),
                    EventId = table.Column<int>(type: "integer", nullable: false),
                    Elements = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModulesGalery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModulesGalery_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Title", "Url" },
                values: new object[,]
                {
                    { 1, "Woodstock", "woodstock" },
                    { 2, "Open'er", "open-er" }
                });

            migrationBuilder.InsertData(
                table: "ModulesAgenda",
                columns: new[] { "Id", "Day", "EventId", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, "Agenda1" },
                    { 2, 2, 2, "Agenda2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_Url",
                table: "Events",
                column: "Url",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ModulesAgenda_EventId",
                table: "ModulesAgenda",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_ModulesGalery_EventId",
                table: "ModulesGalery",
                column: "EventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModulesAgenda");

            migrationBuilder.DropTable(
                name: "ModulesGalery");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropSequence(
                name: "ModuleSequence");
        }
    }
}
