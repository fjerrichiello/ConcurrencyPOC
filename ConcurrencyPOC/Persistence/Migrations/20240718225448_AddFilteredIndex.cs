using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConcurrencyPOC.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddFilteredIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BookRequestTwos_AuthorId_Title_ApprovalStatus_RequestType_C~",
                table: "BookRequestTwos",
                columns: new[] { "AuthorId", "Title", "ApprovalStatus", "RequestType", "Count" },
                unique: true,
                filter: "\"ApprovalStatus\" = 'Pending' and \"RequestType\" = 'Add'");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BookRequestTwos_AuthorId_Title_ApprovalStatus_RequestType_C~",
                table: "BookRequestTwos");
        }
    }
}
