using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_Government.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Changed_Entities3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Visas_SerialNumber",
                table: "Visas");

            migrationBuilder.DropIndex(
                name: "IX_Pasports_SerialNumber",
                table: "Pasports");

            migrationBuilder.DropIndex(
                name: "IX_Certificates_SerialNumber",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "Visas");

            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "Pasports");

            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "Certificates");

            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                table: "Documents",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "StoppedDate",
                table: "Documents",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "StoppedDate",
                table: "Documents");

            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                table: "Visas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                table: "Pasports",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                table: "Certificates",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Visas_SerialNumber",
                table: "Visas",
                column: "SerialNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pasports_SerialNumber",
                table: "Pasports",
                column: "SerialNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_SerialNumber",
                table: "Certificates",
                column: "SerialNumber",
                unique: true);
        }
    }
}
