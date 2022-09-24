using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaxiBook.Server.Data.Migrations
{
    public partial class ChangedPorpertyToMainPhotoUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Profile_ProfilePhotoUrl",
                table: "AspNetUsers",
                newName: "Profile_MainPhotoUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Profile_MainPhotoUrl",
                table: "AspNetUsers",
                newName: "Profile_ProfilePhotoUrl");
        }
    }
}
