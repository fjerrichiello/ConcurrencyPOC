using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConcurrencyPOC.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddLatestChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
               migrationBuilder.AddColumn<string>(
                                        name: "NewTitle",
                                        table: "BookRequests",
                                        type: "text",
                                        nullable: false,
                                        defaultValue: "");
               
            migrationBuilder.CreateIndex(
                name: "IX_BookRequests_AuthorId_NewTitle_ApprovalStatus",
                table: "BookRequests",
                columns: new[] { "AuthorId", "NewTitle", "ApprovalStatus" },
                unique: true,
                filter: "\"ApprovalStatus\" = 'Pending'");

            migrationBuilder.CreateIndex(
                name: "IX_BookRequests_AuthorId_Title_ApprovalStatus",
                table: "BookRequests",
                columns: new[] { "AuthorId", "Title", "ApprovalStatus" },
                unique: true,
                filter: "\"ApprovalStatus\" = 'Pending'");
            
          
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BookRequests_AuthorId_NewTitle_ApprovalStatus",
                table: "BookRequests");

            migrationBuilder.DropIndex(
                name: "IX_BookRequests_AuthorId_Title_ApprovalStatus",
                table: "BookRequests");
            
             migrationBuilder.DropColumn(
                            name: "Title",
                            table: "BookRequests");
        }
    }
}
