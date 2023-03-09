using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_Government.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class For_fix_Nationality1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nationality",
                table: "Persons",
                newName: "NationalityName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NationalityName",
                table: "Persons",
                newName: "Nationality");
        }
    }
}
