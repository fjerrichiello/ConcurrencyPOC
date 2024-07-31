using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConcurrencyPOC.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddSecondaryPrimitiveCollection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookRequestDeclineReason",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: false),
                    BookRequestMainId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookRequestDeclineReason", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookRequestDeclineReason_BookRequests_BookRequestMainId",
                        column: x => x.BookRequestMainId,
                        principalTable: "BookRequests",
                        principalColumn: "MainId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookRequestDeclineReason_BookRequestMainId",
                table: "BookRequestDeclineReason",
                column: "BookRequestMainId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookRequestDeclineReason");
        }
    }
}
