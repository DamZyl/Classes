﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlainClasses.Infrastructure.Databases.Sql;

namespace PlainClasses.Api.Migrations
{
    [DbContext(typeof(PlainClassesContext))]
    [Migration("20201223150835_Refactor_Db")]
    partial class Refactor_Db
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PlainClasses.Domain.Models.Auth", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Auths");
                });

            modelBuilder.Entity("PlainClasses.Domain.Models.EduBlock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EduBlockSubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EduBlockSubjectName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EduBlockSubjectId");

                    b.ToTable("EduBlocks");
                });

            modelBuilder.Entity("PlainClasses.Domain.Models.EduBlockSubject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EduBlockSubjects");
                });

            modelBuilder.Entity("PlainClasses.Domain.Models.MilitaryRank", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Acronym")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MilitaryRanks");
                });

            modelBuilder.Entity("PlainClasses.Domain.Models.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FatherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MilitaryRankAcr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("MilitaryRankId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PersonalPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PlatoonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MilitaryRankId");

                    b.HasIndex("PlatoonId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("PlainClasses.Domain.Models.PersonAuth", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AuthId");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonAuths");
                });

            modelBuilder.Entity("PlainClasses.Domain.Models.PersonFunction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EduBlockId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Function")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EduBlockId");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonFunctions");
                });

            modelBuilder.Entity("PlainClasses.Domain.Models.Platoon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Acronym")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Commander")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Platoons");
                });

            modelBuilder.Entity("PlainClasses.Domain.Models.PlatoonInEduBlock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EduBlockId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlatoonId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EduBlockId");

                    b.HasIndex("PlatoonId");

                    b.ToTable("PlatoonInEduBlocks");
                });

            modelBuilder.Entity("PlainClasses.Domain.Models.Topic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EduBlockSubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EduBlockSubjectId");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("PlainClasses.Domain.Models.EduBlock", b =>
                {
                    b.HasOne("PlainClasses.Domain.Models.EduBlockSubject", "EduBlockSubject")
                        .WithMany("EduBlocks")
                        .HasForeignKey("EduBlockSubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlainClasses.Domain.Models.Person", b =>
                {
                    b.HasOne("PlainClasses.Domain.Models.MilitaryRank", "MilitaryRank")
                        .WithMany("Persons")
                        .HasForeignKey("MilitaryRankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlainClasses.Domain.Models.Platoon", "Platoon")
                        .WithMany("Persons")
                        .HasForeignKey("PlatoonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlainClasses.Domain.Models.PersonAuth", b =>
                {
                    b.HasOne("PlainClasses.Domain.Models.Auth", "Auth")
                        .WithMany("PersonAuths")
                        .HasForeignKey("AuthId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlainClasses.Domain.Models.Person", "Person")
                        .WithMany("PersonAuths")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlainClasses.Domain.Models.PersonFunction", b =>
                {
                    b.HasOne("PlainClasses.Domain.Models.EduBlock", "EduBlock")
                        .WithMany("PersonFunctions")
                        .HasForeignKey("EduBlockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlainClasses.Domain.Models.Person", "Person")
                        .WithMany("PersonFunctions")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlainClasses.Domain.Models.PlatoonInEduBlock", b =>
                {
                    b.HasOne("PlainClasses.Domain.Models.EduBlock", "EduBlock")
                        .WithMany("Platoons")
                        .HasForeignKey("EduBlockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlainClasses.Domain.Models.Platoon", "Platoon")
                        .WithMany("Platoons")
                        .HasForeignKey("PlatoonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlainClasses.Domain.Models.Topic", b =>
                {
                    b.HasOne("PlainClasses.Domain.Models.EduBlockSubject", "EduBlockSubject")
                        .WithMany("Topics")
                        .HasForeignKey("EduBlockSubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
