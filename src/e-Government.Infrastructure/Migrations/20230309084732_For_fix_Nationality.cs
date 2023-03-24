using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace e_Government.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class For_fix_Nationality : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AddressIdFromCadastre = table.Column<int>(type: "integer", nullable: false),
                    IsLastAddress = table.Column<bool>(type: "boolean", nullable: false),
                    StartDateOfUse = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDateOfUse = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateOfIssue = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ValidityPeriod = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StoppedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsValidity = table.Column<bool>(type: "boolean", nullable: false),
                    IsLast = table.Column<bool>(type: "boolean", nullable: false),
                    BelongsCountryName = table.Column<int>(type: "integer", nullable: false),
                    SerialNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
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
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    MidleName = table.Column<string>(type: "text", nullable: false),
                    NationalityName = table.Column<int>(type: "integer", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    Birthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    LegalEntityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificates_Documents_Id",
                        column: x => x.Id,
                        principalTable: "Documents",
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
                        name: "FK_LegalEntityAddresses_Addresses_Id",
                        column: x => x.Id,
                        principalTable: "Addresses",
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
                name: "Foreigners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foreigners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Foreigners_Persons_Id",
                        column: x => x.Id,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Populations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    DiedDay = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Populations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Populations_Persons_Id",
                        column: x => x.Id,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    ForeignerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visas_Documents_Id",
                        column: x => x.Id,
                        principalTable: "Documents",
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
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_Populations_Id",
                        column: x => x.Id,
                        principalTable: "Populations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pasports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    PopulationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pasports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pasports_Documents_Id",
                        column: x => x.Id,
                        principalTable: "Documents",
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
                        name: "FK_PopulationAddresses_Addresses_Id",
                        column: x => x.Id,
                        principalTable: "Addresses",
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

            migrationBuilder.CreateTable(
                name: "PopulationLegalEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PopulationId = table.Column<int>(type: "integer", nullable: false),
                    LegalEntityId = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PopulationLegalEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PopulationLegalEntity_LegalEntities_LegalEntityId",
                        column: x => x.LegalEntityId,
                        principalTable: "LegalEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PopulationLegalEntity_Populations_PopulationId",
                        column: x => x.PopulationId,
                        principalTable: "Populations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_LegalEntityId",
                table: "Certificates",
                column: "LegalEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalEntityAddresses_LegalEntityId",
                table: "LegalEntityAddresses",
                column: "LegalEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pasports_PopulationId",
                table: "Pasports",
                column: "PopulationId");

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

            migrationBuilder.CreateIndex(
                name: "IX_PopulationLegalEntity_LegalEntityId",
                table: "PopulationLegalEntity",
                column: "LegalEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PopulationLegalEntity_PopulationId",
                table: "PopulationLegalEntity",
                column: "PopulationId");

            migrationBuilder.CreateIndex(
                name: "IX_Visas_ForeignerId",
                table: "Visas",
                column: "ForeignerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "LegalEntityAddresses");

            migrationBuilder.DropTable(
                name: "Pasports");

            migrationBuilder.DropTable(
                name: "PopulationAddresses");

            migrationBuilder.DropTable(
                name: "PopulationFamilies");

            migrationBuilder.DropTable(
                name: "PopulationLegalEntity");

            migrationBuilder.DropTable(
                name: "Visas");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "LegalEntities");

            migrationBuilder.DropTable(
                name: "Populations");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Foreigners");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
