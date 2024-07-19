using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConcurrencyPOC.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId_Title",
                table: "Books",
                columns: new[] { "AuthorId", "Title" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookRequests_AuthorId_Title_ApprovalStatus_RequestType",
                table: "BookRequests",
                columns: new[] { "AuthorId", "Title", "ApprovalStatus", "RequestType" },
                unique: true,
                filter: "\"ApprovalStatus\" = 'Pending' and \"RequestType\" = 'Add'");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Books_AuthorId_Title",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_BookRequests_AuthorId_Title_ApprovalStatus_RequestType",
                table: "BookRequests");
        }
    }
}
