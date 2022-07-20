﻿// <auto-generated />
using BoardGameAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BoardGameAPI.Migrations
{
    [DbContext(typeof(BoardGameContext))]
    [Migration("20220720154809_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BoardGameAPI.Models.BoardGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Genre")
                        .HasColumnType("int");

                    b.Property<bool>("IsCoop")
                        .HasColumnType("bit");

                    b.Property<int>("MaxPlayers")
                        .HasColumnType("int");

                    b.Property<int>("MinPlayers")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BoardGames");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Genre = 6,
                            IsCoop = true,
                            MaxPlayers = 4,
                            MinPlayers = 1,
                            Name = "Omega Virus"
                        },
                        new
                        {
                            Id = 2,
                            Genre = 2,
                            IsCoop = false,
                            MaxPlayers = 4,
                            MinPlayers = 2,
                            Name = "Mr Bacon's Big Adventure"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
