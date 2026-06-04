using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeEstate.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddFloorInfoAndReviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentDescriptionData_Apartments_ApartmentId",
                table: "ApartmentDescriptionData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApartmentDescriptionData",
                table: "ApartmentDescriptionData");

            migrationBuilder.DropColumn(
                name: "FullDescription",
                table: "ApartmentDescriptionData");

            migrationBuilder.RenameTable(
                name: "ApartmentDescriptionData",
                newName: "ApartmentDescriptions");

            migrationBuilder.RenameColumn(
                name: "Metro",
                table: "ApartmentDescriptions",
                newName: "District");

            migrationBuilder.RenameIndex(
                name: "IX_ApartmentDescriptionData_ApartmentId",
                table: "ApartmentDescriptions",
                newName: "IX_ApartmentDescriptions_ApartmentId");

            migrationBuilder.AddColumn<int>(
                name: "Entrance",
                table: "ApartmentDescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Floor",
                table: "ApartmentDescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalFloors",
                table: "ApartmentDescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApartmentDescriptions",
                table: "ApartmentDescriptions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApartmentId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ApartmentDataId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Apartments_ApartmentDataId",
                        column: x => x.ApartmentDataId,
                        principalTable: "Apartments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reviews_Apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_UserData_UserId",
                        column: x => x.UserId,
                        principalTable: "UserData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ApartmentDataId",
                table: "Reviews",
                column: "ApartmentDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ApartmentId",
                table: "Reviews",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentDescriptions_Apartments_ApartmentId",
                table: "ApartmentDescriptions",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApartmentDescriptions_Apartments_ApartmentId",
                table: "ApartmentDescriptions");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApartmentDescriptions",
                table: "ApartmentDescriptions");

            migrationBuilder.DropColumn(
                name: "Entrance",
                table: "ApartmentDescriptions");

            migrationBuilder.DropColumn(
                name: "Floor",
                table: "ApartmentDescriptions");

            migrationBuilder.DropColumn(
                name: "TotalFloors",
                table: "ApartmentDescriptions");

            migrationBuilder.RenameTable(
                name: "ApartmentDescriptions",
                newName: "ApartmentDescriptionData");

            migrationBuilder.RenameColumn(
                name: "District",
                table: "ApartmentDescriptionData",
                newName: "Metro");

            migrationBuilder.RenameIndex(
                name: "IX_ApartmentDescriptions_ApartmentId",
                table: "ApartmentDescriptionData",
                newName: "IX_ApartmentDescriptionData_ApartmentId");

            migrationBuilder.AddColumn<string>(
                name: "FullDescription",
                table: "ApartmentDescriptionData",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApartmentDescriptionData",
                table: "ApartmentDescriptionData",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApartmentDescriptionData_Apartments_ApartmentId",
                table: "ApartmentDescriptionData",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id");
        }
    }
}
