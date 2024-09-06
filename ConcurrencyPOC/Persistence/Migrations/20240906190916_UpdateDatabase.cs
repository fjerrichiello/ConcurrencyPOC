using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConcurrencyPOC.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookRequestDeclineReasons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: false),
                    BookRequestMainId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookRequestDeclineReasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookRequestDeclineReasons_BookRequests_BookRequestMainId",
                        column: x => x.BookRequestMainId,
                        principalTable: "BookRequests",
                        principalColumn: "MainId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookRequestDeclineReasons_BookRequestMainId_Reason",
                table: "BookRequestDeclineReasons",
                columns: new[] { "BookRequestMainId", "Reason" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookRequestDeclineReasons");
        }
    }
}
