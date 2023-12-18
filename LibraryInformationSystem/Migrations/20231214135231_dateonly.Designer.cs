﻿// <auto-generated />
using System;
using LibraryInformationSystem.LibraryInformationSystem.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryInformationSystem.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20231214135231_dateonly")]
    partial class dateonly
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LibraryInformationSystem.LibraryInformationSystem.DAL.Entities.Book", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<long>("GenreId")
                        .HasColumnType("bigint");

                    b.Property<int>("PublishedYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("LibraryInformationSystem.LibraryInformationSystem.DAL.Entities.Borrow", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("BookId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("BorrowDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("StatusId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("StatusId");

                    b.HasIndex("UserId");

                    b.ToTable("Borrows");
                });

            modelBuilder.Entity("LibraryInformationSystem.LibraryInformationSystem.DAL.Entities.Genre", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Action and adventure"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Detective"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Sci-fi"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "Historical fiction"
                        },
                        new
                        {
                            Id = 5L,
                            Name = "Dystopia"
                        },
                        new
                        {
                            Id = 6L,
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = 7L,
                            Name = "Romance novel"
                        },
                        new
                        {
                            Id = 8L,
                            Name = "Horror"
                        },
                        new
                        {
                            Id = 9L,
                            Name = "Fairy tale"
                        },
                        new
                        {
                            Id = 10L,
                            Name = "Graphic novel"
                        },
                        new
                        {
                            Id = 11L,
                            Name = "Classic"
                        },
                        new
                        {
                            Id = 12L,
                            Name = "Non-fiction"
                        });
                });

            modelBuilder.Entity("LibraryInformationSystem.LibraryInformationSystem.DAL.Entities.Status", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Status");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Returned"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Not returned yet"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Lost"
                        });
                });

            modelBuilder.Entity("LibraryInformationSystem.LibraryInformationSystem.DAL.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LibraryInformationSystem.LibraryInformationSystem.DAL.Entities.Book", b =>
                {
                    b.HasOne("LibraryInformationSystem.LibraryInformationSystem.DAL.Entities.Genre", "Genre")
                        .WithMany("Books")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("LibraryInformationSystem.LibraryInformationSystem.DAL.Entities.Borrow", b =>
                {
                    b.HasOne("LibraryInformationSystem.LibraryInformationSystem.DAL.Entities.Book", "Book")
                        .WithMany("Borrows")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryInformationSystem.LibraryInformationSystem.DAL.Entities.Status", "Status")
                        .WithMany("Borrows")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryInformationSystem.LibraryInformationSystem.DAL.Entities.User", "User")
                        .WithMany("Borrows")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Status");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LibraryInformationSystem.LibraryInformationSystem.DAL.Entities.Book", b =>
                {
                    b.Navigation("Borrows");
                });

            modelBuilder.Entity("LibraryInformationSystem.LibraryInformationSystem.DAL.Entities.Genre", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("LibraryInformationSystem.LibraryInformationSystem.DAL.Entities.Status", b =>
                {
                    b.Navigation("Borrows");
                });

            modelBuilder.Entity("LibraryInformationSystem.LibraryInformationSystem.DAL.Entities.User", b =>
                {
                    b.Navigation("Borrows");
                });
#pragma warning restore 612, 618
        }
    }
}
