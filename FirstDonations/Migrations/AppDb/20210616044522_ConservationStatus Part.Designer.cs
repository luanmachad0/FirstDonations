﻿// <auto-generated />
using FirstDonations.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FirstDonations.Migrations.AppDb
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210616044522_ConservationStatus Part")]
    partial class ConservationStatusPart
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FirstDonations.Models.Donation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DonatorTeamId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DonatorTeamName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePart")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InterestedTeamId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InterestedTeamName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NamePart")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PartId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PartId");

                    b.ToTable("Donations");
                });

            modelBuilder.Entity("FirstDonations.Models.Part", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConservationStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerTeam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Parts");
                });

            modelBuilder.Entity("FirstDonations.Models.Donation", b =>
                {
                    b.HasOne("FirstDonations.Models.Part", "Part")
                        .WithMany()
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
