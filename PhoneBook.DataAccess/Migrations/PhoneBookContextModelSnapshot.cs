﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PhoneBook.DataAccess.Concrete.EntityFramework.Contexts;

#nullable disable

namespace PhoneBook.DataAccess.Migrations
{
    [DbContext(typeof(PhoneBookContext))]
    partial class PhoneBookContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PhoneBook.Entities.Concrete.ContactInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PersonUUID")
                        .HasColumnType("integer");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ContactInformations");
                });

            modelBuilder.Entity("PhoneBook.Entities.Concrete.Person", b =>
                {
                    b.Property<int>("UUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UUID"));

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UUID");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("PhoneBook.Entities.Concrete.Report", b =>
                {
                    b.Property<int>("UUID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UUID"));

                    b.Property<DateTime>("ReportCreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ReportPath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ReportStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UUID");

                    b.ToTable("Reports");
                });
#pragma warning restore 612, 618
        }
    }
}
