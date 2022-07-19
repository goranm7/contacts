﻿// <auto-generated />
using System;
using Contacts_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Contacts_API.Migrations
{
    [DbContext(typeof(ContactDetailContext))]
    partial class ContactDetailContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Contacts_API.Models.ContactDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Address");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nickname");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Surname");

                    b.Property<int?>("TagDetailId")
                        .HasColumnType("int")
                        .HasColumnName("Tag");

                    b.HasKey("Id");

                    b.HasIndex("TagDetailId");

                    b.ToTable("ContactDetails");
                });

            modelBuilder.Entity("Contacts_API.Models.EmailDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ContactDetailId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContactDetailId");

                    b.ToTable("EmailDetails");
                });

            modelBuilder.Entity("Contacts_API.Models.TagDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TagDetails");
                });

            modelBuilder.Entity("Contacts_API.Models.TelephoneDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ContactDetailId")
                        .HasColumnType("int");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContactDetailId");

                    b.ToTable("TelephoneDetails");
                });

            modelBuilder.Entity("Contacts_API.Models.ContactDetail", b =>
                {
                    b.HasOne("Contacts_API.Models.TagDetail", "TagDetail")
                        .WithMany()
                        .HasForeignKey("TagDetailId");

                    b.Navigation("TagDetail");
                });

            modelBuilder.Entity("Contacts_API.Models.EmailDetail", b =>
                {
                    b.HasOne("Contacts_API.Models.ContactDetail", null)
                        .WithMany("Emails")
                        .HasForeignKey("ContactDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Contacts_API.Models.TelephoneDetail", b =>
                {
                    b.HasOne("Contacts_API.Models.ContactDetail", null)
                        .WithMany("Numbers")
                        .HasForeignKey("ContactDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Contacts_API.Models.ContactDetail", b =>
                {
                    b.Navigation("Emails");

                    b.Navigation("Numbers");
                });
#pragma warning restore 612, 618
        }
    }
}
