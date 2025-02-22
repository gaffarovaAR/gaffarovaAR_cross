﻿// <auto-generated />
using System;
using GaffarovaAlbina.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GaffarovaAlbina.Migrations
{
    [DbContext(typeof(DocumentContext))]
    partial class DocumentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AssignmentExecutor", b =>
                {
                    b.Property<long>("AssignmentsId")
                        .HasColumnType("bigint");

                    b.Property<long>("ExecutorsID")
                        .HasColumnType("bigint");

                    b.HasKey("AssignmentsId", "ExecutorsID");

                    b.HasIndex("ExecutorsID");

                    b.ToTable("AssignmentExecutor");
                });

            modelBuilder.Entity("GaffarovaAlbina.Models.Account", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Accounts");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Account");
                });

            modelBuilder.Entity("GaffarovaAlbina.Models.Assignment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Done")
                        .HasColumnType("bit");

                    b.Property<long?>("ProtocolId")
                        .HasColumnType("bigint");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProtocolId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("GaffarovaAlbina.Models.Attempt", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AssignmentId")
                        .HasColumnType("bigint");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateChange")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ExecutorID")
                        .HasColumnType("bigint");

                    b.Property<string>("Report")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AssignmentId");

                    b.HasIndex("ExecutorID");

                    b.ToTable("Attempts");
                });

            modelBuilder.Entity("GaffarovaAlbina.Models.Protocol", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<long?>("HeadID")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HeadID");

                    b.ToTable("Protocols");
                });

            modelBuilder.Entity("GaffarovaAlbina.Models.Executor", b =>
                {
                    b.HasBaseType("GaffarovaAlbina.Models.Account");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThirdName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThirstName")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Executor");
                });

            modelBuilder.Entity("AssignmentExecutor", b =>
                {
                    b.HasOne("GaffarovaAlbina.Models.Assignment", null)
                        .WithMany()
                        .HasForeignKey("AssignmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GaffarovaAlbina.Models.Executor", null)
                        .WithMany()
                        .HasForeignKey("ExecutorsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GaffarovaAlbina.Models.Assignment", b =>
                {
                    b.HasOne("GaffarovaAlbina.Models.Protocol", null)
                        .WithMany("Assignments")
                        .HasForeignKey("ProtocolId");
                });

            modelBuilder.Entity("GaffarovaAlbina.Models.Attempt", b =>
                {
                    b.HasOne("GaffarovaAlbina.Models.Assignment", null)
                        .WithMany("History")
                        .HasForeignKey("AssignmentId");

                    b.HasOne("GaffarovaAlbina.Models.Executor", "Executor")
                        .WithMany()
                        .HasForeignKey("ExecutorID");

                    b.Navigation("Executor");
                });

            modelBuilder.Entity("GaffarovaAlbina.Models.Protocol", b =>
                {
                    b.HasOne("GaffarovaAlbina.Models.Executor", "Head")
                        .WithMany()
                        .HasForeignKey("HeadID");

                    b.Navigation("Head");
                });

            modelBuilder.Entity("GaffarovaAlbina.Models.Assignment", b =>
                {
                    b.Navigation("History");
                });

            modelBuilder.Entity("GaffarovaAlbina.Models.Protocol", b =>
                {
                    b.Navigation("Assignments");
                });
#pragma warning restore 612, 618
        }
    }
}
