using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConcurrencyPOC.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddThirdOptionWithForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookRequestDeclineReasonThree",
                columns: table => new
                {
                    BookRequestId = table.Column<Guid>(type: "uuid", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookRequestDeclineReasonThree", x => new { x.BookRequestId, x.Reason });
                    table.ForeignKey(
                        name: "FK_BookRequestDeclineReasonThree_BookRequests_BookRequestId",
                        column: x => x.BookRequestId,
                        principalTable: "BookRequests",
                        principalColumn: "MainId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookRequestDeclineReasonThree");
        }
    }
}
