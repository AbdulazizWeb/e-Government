using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace e_Government.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Citizens");

            migrationBuilder.DropTable(
                name: "NotCitizens");

            migrationBuilder.DropTable(
                name: "Users");

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
                name: "Foreigners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Midlname = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    Birthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Nationality = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foreigners", x => x.Id);
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
                name: "LegalEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Direction = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Populations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    MidleName = table.Column<string>(type: "text", nullable: false),
                    Birthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Nationality = table.Column<int>(type: "integer", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    DiedDay = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Populations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Visas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ForeignerId = table.Column<int>(type: "integer", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: false),
                    DateOfIssue = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CustomsId = table.Column<int>(type: "integer", nullable: false),
                    LastVisa = table.Column<bool>(type: "boolean", nullable: false),
                    ValidityPerriod = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Validity = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visas_CustomOffices_CustomsId",
                        column: x => x.CustomsId,
                        principalTable: "CustomOffices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visas_Foreigners_ForeignerId",
                        column: x => x.ForeignerId,
                        principalTable: "Foreigners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(type: "text", nullable: false),
                    LegalEntityId = table.Column<int>(type: "integer", nullable: false),
                    DateOfIssue = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ValidityPeriod = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Validity = table.Column<bool>(type: "boolean", nullable: false),
                    IssuedByBranchId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.SerialNumber);
                    table.ForeignKey(
                        name: "FK_Certificates_IssuedByBranchs_IssuedByBranchId",
                        column: x => x.IssuedByBranchId,
                        principalTable: "IssuedByBranchs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Certificates_LegalEntities_LegalEntityId",
                        column: x => x.LegalEntityId,
                        principalTable: "LegalEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HomeName = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    PostalCode = table.Column<int>(type: "integer", nullable: false),
                    AddressId = table.Column<int>(type: "integer", nullable: false),
                    LastAddress = table.Column<bool>(type: "boolean", nullable: false),
                    StartDateOfUse = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDateOfUse = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IssuedByBranchId = table.Column<int>(type: "integer", nullable: false),
                    CustomsOfficeId = table.Column<int>(type: "integer", nullable: false),
                    PopulationId = table.Column<int>(type: "integer", nullable: false),
                    LegalEntityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_CustomOffices_CustomsOfficeId",
                        column: x => x.CustomsOfficeId,
                        principalTable: "CustomOffices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Address_IssuedByBranchs_IssuedByBranchId",
                        column: x => x.IssuedByBranchId,
                        principalTable: "IssuedByBranchs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Address_LegalEntities_LegalEntityId",
                        column: x => x.LegalEntityId,
                        principalTable: "LegalEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Address_Populations_PopulationId",
                        column: x => x.PopulationId,
                        principalTable: "Populations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pasports",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(type: "text", nullable: false),
                    PopulationId = table.Column<int>(type: "integer", nullable: false),
                    PINFLNumber = table.Column<string>(type: "text", nullable: false),
                    DateOfIssue = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ValidityPeriod = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Validity = table.Column<bool>(type: "boolean", nullable: false),
                    IssuedByBranchId = table.Column<int>(type: "integer", nullable: false),
                    Citizenship = table.Column<bool>(type: "boolean", nullable: false),
                    countryNameCitizenship = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pasports", x => x.SerialNumber);
                    table.ForeignKey(
                        name: "FK_Pasports_IssuedByBranchs_IssuedByBranchId",
                        column: x => x.IssuedByBranchId,
                        principalTable: "IssuedByBranchs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pasports_Populations_PopulationId",
                        column: x => x.PopulationId,
                        principalTable: "Populations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PopulationPopulations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Population1Id = table.Column<int>(type: "integer", nullable: false),
                    Relative = table.Column<int>(type: "integer", nullable: false),
                    Population2Id = table.Column<int>(type: "integer", nullable: false)
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
                name: "IX_Certificates_IssuedByBranchId",
                table: "Certificates",
                column: "IssuedByBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_LegalEntityId",
                table: "Certificates",
                column: "LegalEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_SerialNumber",
                table: "Certificates",
                column: "SerialNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Pasports_IssuedByBranchId",
                table: "Pasports",
                column: "IssuedByBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Pasports_PopulationId",
                table: "Pasports",
                column: "PopulationId");

            migrationBuilder.CreateIndex(
                name: "IX_Pasports_SerialNumber",
                table: "Pasports",
                column: "SerialNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PopulationPopulations_Population1Id",
                table: "PopulationPopulations",
                column: "Population1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Visas_CustomsId",
                table: "Visas",
                column: "CustomsId");

            migrationBuilder.CreateIndex(
                name: "IX_Visas_ForeignerId",
                table: "Visas",
                column: "ForeignerId");

            migrationBuilder.CreateIndex(
                name: "IX_Visas_Number",
                table: "Visas",
                column: "Number",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "Pasports");

            migrationBuilder.DropTable(
                name: "PopulationPopulations");

            migrationBuilder.DropTable(
                name: "Visas");

            migrationBuilder.DropTable(
                name: "LegalEntities");

            migrationBuilder.DropTable(
                name: "IssuedByBranchs");

            migrationBuilder.DropTable(
                name: "Populations");

            migrationBuilder.DropTable(
                name: "CustomOffices");

            migrationBuilder.DropTable(
                name: "Foreigners");

            migrationBuilder.CreateTable(
                name: "Citizens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Birthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateOfIssue = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DiedDay = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    IssuedBy = table.Column<int>(type: "integer", nullable: false),
                    Lastname = table.Column<string>(type: "text", nullable: true),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    Nationality = table.Column<string>(type: "text", nullable: true),
                    PINFL = table.Column<string>(type: "text", nullable: true),
                    PassportSerialNumber = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citizens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotCitizens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Birthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    Lastname = table.Column<string>(type: "text", nullable: true),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    Nationality = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotCitizens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Login = table.Column<string>(type: "text", nullable: true),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citizens_PassportSerialNumber",
                table: "Citizens",
                column: "PassportSerialNumber",
                unique: true);
        }
    }
}
