using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace e_Government.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Changed_Entities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_CustomOffices_CustomsOfficeId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_IssuedByBranchs_IssuedByBranchId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_LegalEntities_LegalEntityId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Populations_PopulationId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_IssuedByBranchs_IssuedByBranchId",
                table: "Certificates");

            migrationBuilder.DropForeignKey(
                name: "FK_Pasports_IssuedByBranchs_IssuedByBranchId",
                table: "Pasports");

            migrationBuilder.DropForeignKey(
                name: "FK_Visas_CustomOffices_CustomsId",
                table: "Visas");

            migrationBuilder.DropTable(
                name: "CustomOffices");

            migrationBuilder.DropTable(
                name: "IssuedByBranchs");

            migrationBuilder.DropTable(
                name: "PopulationPopulations");

            migrationBuilder.DropIndex(
                name: "IX_Visas_CustomsId",
                table: "Visas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pasports",
                table: "Pasports");

            migrationBuilder.DropIndex(
                name: "IX_Pasports_IssuedByBranchId",
                table: "Pasports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Certificates",
                table: "Certificates");

            migrationBuilder.DropIndex(
                name: "IX_Certificates_IssuedByBranchId",
                table: "Certificates");

            migrationBuilder.DropIndex(
                name: "IX_Certificates_SerialNumber",
                table: "Certificates");

            migrationBuilder.DropIndex(
                name: "IX_Address_CustomsOfficeId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_IssuedByBranchId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_LegalEntityId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_PopulationId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "CustomsId",
                table: "Visas");

            migrationBuilder.DropColumn(
                name: "DateOfIssue",
                table: "Visas");

            migrationBuilder.DropColumn(
                name: "LastVisa",
                table: "Visas");

            migrationBuilder.DropColumn(
                name: "Validity",
                table: "Visas");

            migrationBuilder.DropColumn(
                name: "ValidityPerriod",
                table: "Visas");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Populations");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Populations");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Populations");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Populations");

            migrationBuilder.DropColumn(
                name: "MidleName",
                table: "Populations");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Populations");

            migrationBuilder.DropColumn(
                name: "Citizenship",
                table: "Pasports");

            migrationBuilder.DropColumn(
                name: "DateOfIssue",
                table: "Pasports");

            migrationBuilder.DropColumn(
                name: "IssuedByBranchId",
                table: "Pasports");

            migrationBuilder.DropColumn(
                name: "PINFLNumber",
                table: "Pasports");

            migrationBuilder.DropColumn(
                name: "Validity",
                table: "Pasports");

            migrationBuilder.DropColumn(
                name: "ValidityPeriod",
                table: "Pasports");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Foreigners");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Foreigners");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Foreigners");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Foreigners");

            migrationBuilder.DropColumn(
                name: "Midlname",
                table: "Foreigners");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Foreigners");

            migrationBuilder.DropColumn(
                name: "DateOfIssue",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "Validity",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "ValidityPeriod",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "CustomsOfficeId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "HomeName",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "IssuedByBranchId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "LegalEntityId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "PopulationId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Visas",
                newName: "SerialNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Visas_Number",
                table: "Visas",
                newName: "IX_Visas_SerialNumber");

            migrationBuilder.RenameColumn(
                name: "countryNameCitizenship",
                table: "Pasports",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IssuedByBranchId",
                table: "Certificates",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "Address",
                newName: "AddressIdFromCadastre");

            migrationBuilder.RenameColumn(
                name: "LastAddress",
                table: "Address",
                newName: "IsLastAddress");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Visas",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Populations",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Foreigners",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pasports",
                table: "Pasports",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Certificates",
                table: "Certificates",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateOfIssue = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ValidityPeriod = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsValidity = table.Column<bool>(type: "boolean", nullable: false),
                    IsLast = table.Column<bool>(type: "boolean", nullable: false),
                    IssuedByBranchLegalEntityId = table.Column<int>(type: "integer", nullable: false),
                    BelongsCountryName = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_LegalEntities_IssuedByBranchLegalEntityId",
                        column: x => x.IssuedByBranchLegalEntityId,
                        principalTable: "LegalEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LegalEntityAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    LegalEntityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalEntityAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LegalEntityAddresses_Address_Id",
                        column: x => x.Id,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LegalEntityAddresses_LegalEntities_LegalEntityId",
                        column: x => x.LegalEntityId,
                        principalTable: "LegalEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    MidleName = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    Birthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Nationality = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PopulationAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    PopulationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PopulationAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PopulationAddresses_Address_Id",
                        column: x => x.Id,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PopulationAddresses_Populations_PopulationId",
                        column: x => x.PopulationId,
                        principalTable: "Populations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PopulationFamilies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Population1Id = table.Column<int>(type: "integer", nullable: false),
                    RelativeName = table.Column<int>(type: "integer", nullable: false),
                    Population2Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PopulationFamilies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PopulationFamilies_Populations_Population1Id",
                        column: x => x.Population1Id,
                        principalTable: "Populations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PopulationFamilies_Populations_Population2Id",
                        column: x => x.Population2Id,
                        principalTable: "Populations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_SerialNumber",
                table: "Certificates",
                column: "SerialNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_IssuedByBranchLegalEntityId",
                table: "Documents",
                column: "IssuedByBranchLegalEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalEntityAddresses_LegalEntityId",
                table: "LegalEntityAddresses",
                column: "LegalEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PopulationAddresses_PopulationId",
                table: "PopulationAddresses",
                column: "PopulationId");

            migrationBuilder.CreateIndex(
                name: "IX_PopulationFamilies_Population1Id",
                table: "PopulationFamilies",
                column: "Population1Id");

            migrationBuilder.CreateIndex(
                name: "IX_PopulationFamilies_Population2Id",
                table: "PopulationFamilies",
                column: "Population2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_Documents_Id",
                table: "Certificates",
                column: "Id",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Foreigners_Persons_Id",
                table: "Foreigners",
                column: "Id",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pasports_Documents_Id",
                table: "Pasports",
                column: "Id",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Populations_Persons_Id",
                table: "Populations",
                column: "Id",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visas_Documents_Id",
                table: "Visas",
                column: "Id",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_Documents_Id",
                table: "Certificates");

            migrationBuilder.DropForeignKey(
                name: "FK_Foreigners_Persons_Id",
                table: "Foreigners");

            migrationBuilder.DropForeignKey(
                name: "FK_Pasports_Documents_Id",
                table: "Pasports");

            migrationBuilder.DropForeignKey(
                name: "FK_Populations_Persons_Id",
                table: "Populations");

            migrationBuilder.DropForeignKey(
                name: "FK_Visas_Documents_Id",
                table: "Visas");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "LegalEntityAddresses");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "PopulationAddresses");

            migrationBuilder.DropTable(
                name: "PopulationFamilies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pasports",
                table: "Pasports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Certificates",
                table: "Certificates");

            migrationBuilder.DropIndex(
                name: "IX_Certificates_SerialNumber",
                table: "Certificates");

            migrationBuilder.RenameColumn(
                name: "SerialNumber",
                table: "Visas",
                newName: "Number");

            migrationBuilder.RenameIndex(
                name: "IX_Visas_SerialNumber",
                table: "Visas",
                newName: "IX_Visas_Number");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Pasports",
                newName: "countryNameCitizenship");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Certificates",
                newName: "IssuedByBranchId");

            migrationBuilder.RenameColumn(
                name: "IsLastAddress",
                table: "Address",
                newName: "LastAddress");

            migrationBuilder.RenameColumn(
                name: "AddressIdFromCadastre",
                table: "Address",
                newName: "PostalCode");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Visas",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "CustomsId",
                table: "Visas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfIssue",
                table: "Visas",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "LastVisa",
                table: "Visas",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Validity",
                table: "Visas",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidityPerriod",
                table: "Visas",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Populations",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "Populations",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Populations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Populations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Populations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MidleName",
                table: "Populations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Nationality",
                table: "Populations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Citizenship",
                table: "Pasports",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfIssue",
                table: "Pasports",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IssuedByBranchId",
                table: "Pasports",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PINFLNumber",
                table: "Pasports",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Validity",
                table: "Pasports",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidityPeriod",
                table: "Pasports",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Foreigners",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "Foreigners",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Foreigners",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Foreigners",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Foreigners",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Midlname",
                table: "Foreigners",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Nationality",
                table: "Foreigners",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfIssue",
                table: "Certificates",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Validity",
                table: "Certificates",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidityPeriod",
                table: "Certificates",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Address",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CustomsOfficeId",
                table: "Address",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "HomeName",
                table: "Address",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IssuedByBranchId",
                table: "Address",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LegalEntityId",
                table: "Address",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PopulationId",
                table: "Address",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Address",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pasports",
                table: "Pasports",
                column: "SerialNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Certificates",
                table: "Certificates",
                column: "SerialNumber");

            migrationBuilder.CreateTable(
                name: "CustomOffices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomOffices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IssuedByBranchs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssuedByBranchs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PopulationPopulations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Population1Id = table.Column<int>(type: "integer", nullable: false),
                    Population2Id = table.Column<int>(type: "integer", nullable: false),
                    Relative = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PopulationPopulations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PopulationPopulations_Populations_Population1Id",
                        column: x => x.Population1Id,
                        principalTable: "Populations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visas_CustomsId",
                table: "Visas",
                column: "CustomsId");

            migrationBuilder.CreateIndex(
                name: "IX_Pasports_IssuedByBranchId",
                table: "Pasports",
                column: "IssuedByBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_IssuedByBranchId",
                table: "Certificates",
                column: "IssuedByBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_SerialNumber",
                table: "Certificates",
                column: "SerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CustomsOfficeId",
                table: "Address",
                column: "CustomsOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_IssuedByBranchId",
                table: "Address",
                column: "IssuedByBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_LegalEntityId",
                table: "Address",
                column: "LegalEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_PopulationId",
                table: "Address",
                column: "PopulationId");

            migrationBuilder.CreateIndex(
                name: "IX_PopulationPopulations_Population1Id",
                table: "PopulationPopulations",
                column: "Population1Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_CustomOffices_CustomsOfficeId",
                table: "Address",
                column: "CustomsOfficeId",
                principalTable: "CustomOffices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_IssuedByBranchs_IssuedByBranchId",
                table: "Address",
                column: "IssuedByBranchId",
                principalTable: "IssuedByBranchs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_LegalEntities_LegalEntityId",
                table: "Address",
                column: "LegalEntityId",
                principalTable: "LegalEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Populations_PopulationId",
                table: "Address",
                column: "PopulationId",
                principalTable: "Populations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_IssuedByBranchs_IssuedByBranchId",
                table: "Certificates",
                column: "IssuedByBranchId",
                principalTable: "IssuedByBranchs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pasports_IssuedByBranchs_IssuedByBranchId",
                table: "Pasports",
                column: "IssuedByBranchId",
                principalTable: "IssuedByBranchs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visas_CustomOffices_CustomsId",
                table: "Visas",
                column: "CustomsId",
                principalTable: "CustomOffices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
