using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ConcurrencyPOC.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIdToGuid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookRequests",
                table: "BookRequests");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BookRequests");

            migrationBuilder.AddColumn<Guid>(
                name: "MainId",
                table: "BookRequests",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookRequests",
                table: "BookRequests",
                column: "MainId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookRequests",
                table: "BookRequests");

            migrationBuilder.DropColumn(
                name: "MainId",
                table: "BookRequests");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BookRequests",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookRequests",
                table: "BookRequests",
                column: "Id");
        }
    }
}
