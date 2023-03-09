﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using e_Government.Infrastructure.Persistence;

#nullable disable

namespace e_Government.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230309081734_For_fix_Nationality1")]
    partial class For_fix_Nationality1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("e_Government.Domain.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressIdFromCadastre")
                        .HasColumnType("integer");

                    b.Property<DateTime>("EndDateOfUse")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsLastAddress")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("StartDateOfUse")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Addresses");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("e_Government.Domain.Entities.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BelongsCountryName")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateOfIssue")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsLast")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsValidity")
                        .HasColumnType("boolean");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("StoppedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("ValidityPeriod")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Documents");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("e_Government.Domain.Entities.LegalEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Direction")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("LegalEntities");
                });

            modelBuilder.Entity("e_Government.Domain.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MidleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NationalityName")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("e_Government.Domain.Entities.PopulationFamily", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Population1Id")
                        .HasColumnType("integer");

                    b.Property<int>("Population2Id")
                        .HasColumnType("integer");

                    b.Property<int>("RelativeName")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Population1Id");

                    b.HasIndex("Population2Id");

                    b.ToTable("PopulationFamilies");
                });

            modelBuilder.Entity("e_Government.Domain.Entities.PopulationLegalEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("LegalEntityId")
                        .HasColumnType("integer");

                    b.Property<int>("PopulationId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("LegalEntityId");

                    b.HasIndex("PopulationId");

                    b.ToTable("PopulationLegalEntity");
                });

            modelBuilder.Entity("e_Government.Domain.Entities.LegalEntityAddress", b =>
                {
                    b.HasBaseType("e_Government.Domain.Entities.Address");

                    b.Property<int>("LegalEntityId")
                        .HasColumnType("integer");

                    b.HasIndex("LegalEntityId");

                    b.ToTable("LegalEntityAddresses", (string)null);
                });

            modelBuilder.Entity("e_Government.Domain.Entities.PopulationAddress", b =>
                {
                    b.HasBaseType("e_Government.Domain.Entities.Address");

                    b.Property<int>("PopulationId")
                        .HasColumnType("integer");

                    b.HasIndex("PopulationId");

                    b.ToTable("PopulationAddresses", (string)null);
                });

            modelBuilder.Entity("e_Government.Domain.Entities.Certificate", b =>
                {
                    b.HasBaseType("e_Government.Domain.Entities.Document");

                    b.Property<int>("LegalEntityId")
                        .HasColumnType("integer");

                    b.HasIndex("LegalEntityId");

                    b.ToTable("Certificates", (string)null);
                });

            modelBuilder.Entity("e_Government.Domain.Entities.Passport", b =>
                {
                    b.HasBaseType("e_Government.Domain.Entities.Document");

                    b.Property<int>("PopulationId")
                        .HasColumnType("integer");

                    b.HasIndex("PopulationId");

                    b.ToTable("Pasports", (string)null);
                });

            modelBuilder.Entity("e_Government.Domain.Entities.Visa", b =>
                {
                    b.HasBaseType("e_Government.Domain.Entities.Document");

                    b.Property<int>("ForeignerId")
                        .HasColumnType("integer");

                    b.HasIndex("ForeignerId");

                    b.ToTable("Visas", (string)null);
                });

            modelBuilder.Entity("e_Government.Domain.Entities.Foreigner", b =>
                {
                    b.HasBaseType("e_Government.Domain.Entities.Person");

                    b.ToTable("Foreigners", (string)null);
                });

            modelBuilder.Entity("e_Government.Domain.Entities.Population", b =>
                {
                    b.HasBaseType("e_Government.Domain.Entities.Person");

                    b.Property<DateTime>("DiedDay")
                        .HasColumnType("timestamp with time zone");

                    b.ToTable("Populations", (string)null);
                });

            modelBuilder.Entity("e_Government.Domain.Entities.Admin", b =>
                {
                    b.HasBaseType("e_Government.Domain.Entities.Population");

                    b.ToTable("Admins", (string)null);
                });

            modelBuilder.Entity("e_Government.Domain.Entities.PopulationFamily", b =>
                {
                    b.HasOne("e_Government.Domain.Entities.Population", "Population1")
                        .WithMany("PopulationFamilies")
                        .HasForeignKey("Population1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("e_Government.Domain.Entities.Population", "Population2")
                        .WithMany("FamilyPopulation")
                        .HasForeignKey("Population2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Population1");

                    b.Navigation("Population2");
                });

            modelBuilder.Entity("e_Government.Domain.Entities.PopulationLegalEntity", b =>
                {
                    b.HasOne("e_Government.Domain.Entities.LegalEntity", "LegalEntity")
                        .WithMany("LegalEntityPopulation")
                        .HasForeignKey("LegalEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("e_Government.Domain.Entities.Population", "Population")
                        .WithMany("PopulationLegalEntities")
                        .HasForeignKey("PopulationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LegalEntity");

                    b.Navigation("Population");
                });

            modelBuilder.Entity("e_Government.Domain.Entities.LegalEntityAddress", b =>
                {
                    b.HasOne("e_Government.Domain.Entities.Address", null)
                        .WithOne()
                        .HasForeignKey("e_Government.Domain.Entities.LegalEntityAddress", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("e_Government.Domain.Entities.LegalEntity", "LegalEntity")
                        .WithMany("LegalEntityAddresses")
                        .HasForeignKey("LegalEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LegalEntity");
                });

            modelBuilder.Entity("e_Government.Domain.Entities.PopulationAddress", b =>
                {
                    b.HasOne("e_Government.Domain.Entities.Address", null)
                        .WithOne()
                        .HasForeignKey("e_Government.Domain.Entities.PopulationAddress", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("e_Government.Domain.Entities.Population", "Population")
                        .WithMany("PopulationAddresses")
                        .HasForeignKey("PopulationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Population");
                });

            modelBuilder.Entity("e_Government.Domain.Entities.Certificate", b =>
                {
                    b.HasOne("e_Government.Domain.Entities.Document", null)
                        .WithOne()
                        .HasForeignKey("e_Government.Domain.Entities.Certificate", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("e_Government.Domain.Entities.LegalEntity", "LegalEntity")
                        .WithMany("Certificates")
                        .HasForeignKey("LegalEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LegalEntity");
                });

            modelBuilder.Entity("e_Government.Domain.Entities.Passport", b =>
                {
                    b.HasOne("e_Government.Domain.Entities.Document", null)
                        .WithOne()
                        .HasForeignKey("e_Government.Domain.Entities.Passport", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("e_Government.Domain.Entities.Population", "Population")
                        .WithMany("Pasports")
                        .HasForeignKey("PopulationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Population");
                });

            modelBuilder.Entity("e_Government.Domain.Entities.Visa", b =>
                {
                    b.HasOne("e_Government.Domain.Entities.Foreigner", "Foreigner")
                        .WithMany("Visas")
                        .HasForeignKey("ForeignerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("e_Government.Domain.Entities.Document", null)
                        .WithOne()
                        .HasForeignKey("e_Government.Domain.Entities.Visa", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Foreigner");
                });

            modelBuilder.Entity("e_Government.Domain.Entities.Foreigner", b =>
                {
                    b.HasOne("e_Government.Domain.Entities.Person", null)
                        .WithOne()
                        .HasForeignKey("e_Government.Domain.Entities.Foreigner", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("e_Government.Domain.Entities.Population", b =>
                {
                    b.HasOne("e_Government.Domain.Entities.Person", null)
                        .WithOne()
                        .HasForeignKey("e_Government.Domain.Entities.Population", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("e_Government.Domain.Entities.Admin", b =>
                {
                    b.HasOne("e_Government.Domain.Entities.Population", null)
                        .WithOne()
                        .HasForeignKey("e_Government.Domain.Entities.Admin", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("e_Government.Domain.Entities.LegalEntity", b =>
                {
                    b.Navigation("Certificates");

                    b.Navigation("LegalEntityAddresses");

                    b.Navigation("LegalEntityPopulation");
                });

            modelBuilder.Entity("e_Government.Domain.Entities.Foreigner", b =>
                {
                    b.Navigation("Visas");
                });

            modelBuilder.Entity("e_Government.Domain.Entities.Population", b =>
                {
                    b.Navigation("FamilyPopulation");

                    b.Navigation("Pasports");

                    b.Navigation("PopulationAddresses");

                    b.Navigation("PopulationFamilies");

                    b.Navigation("PopulationLegalEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
