﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetCore.Infrastructure.Database.Contexts;

namespace NetCore.Infrastructure.Database.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210731132845_InitialDb")]
    partial class InitialDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NetCore.Infrastructure.Database.Model.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("NetCore.Infrastructure.Database.Model.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BirthYear")
                        .HasColumnType("int");

                    b.Property<int?>("DeathYear")
                        .HasColumnType("int");

                    b.Property<string>("NameConst")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimaryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("NetCore.Infrastructure.Database.Model.Profession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Profession");
                });

            modelBuilder.Entity("NetCore.Infrastructure.Database.Model.Title", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EndYear")
                        .HasColumnType("int");

                    b.Property<bool?>("IsAdult")
                        .HasColumnType("bit");

                    b.Property<string>("OriginalTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimaryTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RuntimeMinutes")
                        .HasColumnType("int");

                    b.Property<int?>("StartYear")
                        .HasColumnType("int");

                    b.Property<string>("Tconst")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TitleTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TitleTypeId");

                    b.ToTable("Title");
                });

            modelBuilder.Entity("NetCore.Infrastructure.Database.Model.TitleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TitleType");
                });

            modelBuilder.Entity("NetCore.Infrastructure.Database.Model.Title", b =>
                {
                    b.HasOne("NetCore.Infrastructure.Database.Model.TitleType", "TitleType")
                        .WithMany()
                        .HasForeignKey("TitleTypeId");

                    b.Navigation("TitleType");
                });
#pragma warning restore 612, 618
        }
    }
}