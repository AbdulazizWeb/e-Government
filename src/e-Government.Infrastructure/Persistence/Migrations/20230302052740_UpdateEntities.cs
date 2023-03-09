using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_Government.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_LegalEntities_IssuedByBranchLegalEntityId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_LegalEntityAddresses_Address_Id",
                table: "LegalEntityAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_PopulationAddresses_Address_Id",
                table: "PopulationAddresses");

            migrationBuilder.DropIndex(
                name: "IX_Documents_IssuedByBranchLegalEntityId",
                table: "Documents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "IssuedByBranchLegalEntityId",
                table: "Documents");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalEntityAddresses_Addresses_Id",
                table: "LegalEntityAddresses",
                column: "Id",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PopulationAddresses_Addresses_Id",
                table: "PopulationAddresses",
                column: "Id",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LegalEntityAddresses_Addresses_Id",
                table: "LegalEntityAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_PopulationAddresses_Addresses_Id",
                table: "PopulationAddresses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address");

            migrationBuilder.AddColumn<int>(
                name: "IssuedByBranchLegalEntityId",
                table: "Documents",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_IssuedByBranchLegalEntityId",
                table: "Documents",
                column: "IssuedByBranchLegalEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_LegalEntities_IssuedByBranchLegalEntityId",
                table: "Documents",
                column: "IssuedByBranchLegalEntityId",
                principalTable: "LegalEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LegalEntityAddresses_Address_Id",
                table: "LegalEntityAddresses",
                column: "Id",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PopulationAddresses_Address_Id",
                table: "PopulationAddresses",
                column: "Id",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
