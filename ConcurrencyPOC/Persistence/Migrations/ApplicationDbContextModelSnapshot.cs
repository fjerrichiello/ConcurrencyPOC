﻿// <auto-generated />
using System;
using ConcurrencyPOC.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ConcurrencyPOC.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ConcurrencyPOC.Persistence.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AuthorId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = "Dr.Seuss"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = "Roald Dahl"
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = "Beatrix Potter"
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = "Maurice Sendak"
                        },
                        new
                        {
                            Id = 5,
                            AuthorId = "Eric Carle"
                        },
                        new
                        {
                            Id = 6,
                            AuthorId = "Shel Silverstein"
                        },
                        new
                        {
                            Id = 7,
                            AuthorId = "Judy Blume"
                        });
                });

            modelBuilder.Entity("ConcurrencyPOC.Persistence.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AuthorId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId", "Title")
                        .IsUnique();

                    b.ToTable("Books");
                });

            modelBuilder.Entity("ConcurrencyPOC.Persistence.Models.BookCount", b =>
                {
                    b.Property<Guid>("MainId")
                        .HasColumnType("uuid");

                    b.Property<string>("AuthorId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<uint?>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("xid")
                        .HasColumnName("xmin");

                    b.HasKey("MainId");

                    b.HasIndex("AuthorId")
                        .IsUnique();

                    b.ToTable("BookCounts");
                });

            modelBuilder.Entity("ConcurrencyPOC.Persistence.Models.BookRequest", b =>
                {
                    b.Property<Guid>("MainId")
                        .HasColumnType("uuid");

                    b.Property<string>("ApprovalStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AuthorId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string[]>("DeclineReasons")
                        .HasColumnType("text[]");

                    b.Property<string>("RequestType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("MainId");

                    b.HasIndex("AuthorId", "Title", "ApprovalStatus", "RequestType")
                        .IsUnique()
                        .HasFilter("\"ApprovalStatus\" = 'Pending' and \"RequestType\" = 'Add'");

                    b.ToTable("BookRequests");
                });

            modelBuilder.Entity("ConcurrencyPOC.Persistence.Models.BookRequestDeclineReason", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BookRequestMainId")
                        .HasColumnType("uuid");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BookRequestMainId");

                    b.ToTable("BookRequestDeclineReason");
                });

            modelBuilder.Entity("ConcurrencyPOC.Persistence.Models.BookRequestDeclineReasonThree", b =>
                {
                    b.Property<Guid>("BookRequestId")
                        .HasColumnType("uuid");

                    b.Property<string>("Reason")
                        .HasColumnType("text");

                    b.HasKey("BookRequestId", "Reason");

                    b.ToTable("BookRequestDeclineReasonThree");
                });

            modelBuilder.Entity("ConcurrencyPOC.Persistence.Models.BookRequestDeclineReasonTwo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<Guid?>("BookRequestMainId")
                        .HasColumnType("uuid");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BookRequestMainId");

                    b.ToTable("BookRequestDeclineReasonTwo");
                });

            modelBuilder.Entity("ConcurrencyPOC.Persistence.Models.BookRequestTwo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ApprovalStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AuthorId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<string>("RequestType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<uint?>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("xid")
                        .HasColumnName("xmin");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId", "Title", "ApprovalStatus", "RequestType", "Count")
                        .IsUnique()
                        .HasFilter("\"ApprovalStatus\" = 'Pending' and \"RequestType\" = 'Add'");

                    b.ToTable("BookRequestTwos");
                });

            modelBuilder.Entity("ConcurrencyPOC.Persistence.Models.BookRequestDeclineReason", b =>
                {
                    b.HasOne("ConcurrencyPOC.Persistence.Models.BookRequest", null)
                        .WithMany("DeclineReasons2")
                        .HasForeignKey("BookRequestMainId");
                });

            modelBuilder.Entity("ConcurrencyPOC.Persistence.Models.BookRequestDeclineReasonThree", b =>
                {
                    b.HasOne("ConcurrencyPOC.Persistence.Models.BookRequest", "BookRequest")
                        .WithMany("DeclineReasonsThree")
                        .HasForeignKey("BookRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookRequest");
                });

            modelBuilder.Entity("ConcurrencyPOC.Persistence.Models.BookRequestDeclineReasonTwo", b =>
                {
                    b.HasOne("ConcurrencyPOC.Persistence.Models.BookRequest", null)
                        .WithMany("DeclineReasonsTwo")
                        .HasForeignKey("BookRequestMainId");
                });

            modelBuilder.Entity("ConcurrencyPOC.Persistence.Models.BookRequest", b =>
                {
                    b.Navigation("DeclineReasons2");

                    b.Navigation("DeclineReasonsThree");

                    b.Navigation("DeclineReasonsTwo");
                });
#pragma warning restore 612, 618
        }
    }
}
