﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PropertyInventorySystem.Infrastructure.Context;

#nullable disable

namespace PropertyInventorySystem.Infrastructure.Migrations
{
    [DbContext(typeof(PropertyInventoryDbContext))]
    [Migration("20241110071227_updateContactProperty")]
    partial class updateContactProperty
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PropertyInventorySystem.Entities.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifiedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("PropertyInventorySystem.Entities.ContactProperty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ContactId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ContactsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EffectiveFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EffectiveTill")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModifiedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("PriceOfAcquisition")
                        .HasColumnType("float");

                    b.Property<Guid>("PropertiesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PropertyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.HasIndex("PropertyId");

                    b.ToTable("ContactProperty");
                });

            modelBuilder.Entity("PropertyInventorySystem.Entities.Property", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfRegistration")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifiedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("PropertyInventorySystem.Entities.PropertyPriceAudit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EffectedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModifiedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("NewPrice")
                        .HasColumnType("float");

                    b.Property<double>("OldPrice")
                        .HasColumnType("float");

                    b.Property<Guid?>("PropertyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.ToTable("PropertyPriceAudits");
                });

            modelBuilder.Entity("PropertyInventorySystem.Entities.ContactProperty", b =>
                {
                    b.HasOne("PropertyInventorySystem.Entities.Contact", "Contact")
                        .WithMany("ContactProperties")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PropertyInventorySystem.Entities.Property", "Property")
                        .WithMany("ContactProperties")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contact");

                    b.Navigation("Property");
                });

            modelBuilder.Entity("PropertyInventorySystem.Entities.PropertyPriceAudit", b =>
                {
                    b.HasOne("PropertyInventorySystem.Entities.Property", null)
                        .WithMany("PropertyPriceAudit")
                        .HasForeignKey("PropertyId");
                });

            modelBuilder.Entity("PropertyInventorySystem.Entities.Contact", b =>
                {
                    b.Navigation("ContactProperties");
                });

            modelBuilder.Entity("PropertyInventorySystem.Entities.Property", b =>
                {
                    b.Navigation("ContactProperties");

                    b.Navigation("PropertyPriceAudit");
                });
#pragma warning restore 612, 618
        }
    }
}
