using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommonUtilitesLibrary.Migrations
{
    /// <inheritdoc />
    public partial class ClientIdNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_gigs_users_client_id",
                table: "gigs");

            migrationBuilder.DropIndex(
                name: "IX_gigs_client_id",
                table: "gigs");

            migrationBuilder.DropColumn(
                name: "client_id",
                table: "gigs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "client_id",
                table: "gigs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_gigs_client_id",
                table: "gigs",
                column: "client_id");

            migrationBuilder.AddForeignKey(
                name: "FK_gigs_users_client_id",
                table: "gigs",
                column: "client_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
