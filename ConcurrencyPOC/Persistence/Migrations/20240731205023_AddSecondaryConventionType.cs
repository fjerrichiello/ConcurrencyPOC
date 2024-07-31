using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ConcurrencyPOC.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddSecondaryConventionType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookRequestDeclineReasonTwo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Reason = table.Column<string>(type: "text", nullable: false),
                    BookRequestMainId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookRequestDeclineReasonTwo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookRequestDeclineReasonTwo_BookRequests_BookRequestMainId",
                        column: x => x.BookRequestMainId,
                        principalTable: "BookRequests",
                        principalColumn: "MainId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookRequestDeclineReasonTwo_BookRequestMainId",
                table: "BookRequestDeclineReasonTwo",
                column: "BookRequestMainId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookRequestDeclineReasonTwo");
        }
    }
}
