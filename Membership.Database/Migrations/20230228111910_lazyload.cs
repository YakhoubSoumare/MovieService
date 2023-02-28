using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Membership.Database.Migrations
{
    /// <inheritdoc />
    public partial class lazyload : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Films_FilmId",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Films");

            migrationBuilder.RenameColumn(
                name: "FilmId",
                table: "Films",
                newName: "DirectorId");

            migrationBuilder.RenameIndex(
                name: "IX_Films_FilmId",
                table: "Films",
                newName: "IX_Films_DirectorId");

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Directors_DirectorId",
                table: "Films",
                column: "DirectorId",
                principalTable: "Directors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Directors_DirectorId",
                table: "Films");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.RenameColumn(
                name: "DirectorId",
                table: "Films",
                newName: "FilmId");

            migrationBuilder.RenameIndex(
                name: "IX_Films_DirectorId",
                table: "Films",
                newName: "IX_Films_FilmId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Films",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Films_FilmId",
                table: "Films",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
