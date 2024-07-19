using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ConcurrencyPOC.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIdForBookCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookCounts",
                table: "BookCounts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BookCounts");

            migrationBuilder.AddColumn<Guid>(
                name: "MainId",
                table: "BookCounts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookCounts",
                table: "BookCounts",
                column: "MainId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookCounts",
                table: "BookCounts");

            migrationBuilder.DropColumn(
                name: "MainId",
                table: "BookCounts");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BookCounts",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookCounts",
                table: "BookCounts",
                column: "Id");
        }
    }
}
