﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlainClasses.Infrastructure.Databases.Sql;

namespace PlainClasses.Api.Migrations
{
    [DbContext(typeof(PlainClassesContext))]
    partial class PlainClassesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PlainClasses.Domain.EduBlocks.EduBlock", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EduBlockSubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EduBlockSubjectName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndEduBlock")
                        .HasColumnType("datetime2");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartEduBlock")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EduBlockSubjectId");

                    b.ToTable("EduBlocks");
                });

            modelBuilder.Entity("PlainClasses.Domain.EduBlocks.EduBlockSubject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EduBlockSubjects");
                });

            modelBuilder.Entity("PlainClasses.Domain.EduBlocks.PersonFunction", b =>
                {
                    b.Property<Guid>("Id")
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

            modelBuilder.Entity("PlainClasses.Domain.EduBlocks.PlatoonInEduBlock", b =>
                {
                    b.Property<Guid>("Id")
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

            modelBuilder.Entity("PlainClasses.Domain.Persons.MilitaryRank", b =>
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

            modelBuilder.Entity("PlainClasses.Domain.Persons.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FatherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(70)")
                        .HasMaxLength(70);

                    b.Property<string>("MilitaryRankAcr")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<Guid>("MilitaryRankId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<string>("PersonalPhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("PlatoonAcr")
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<Guid?>("PlatoonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkPhoneNumber")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.HasIndex("MilitaryRankId");

                    b.HasIndex("PlatoonId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("PlainClasses.Domain.Persons.PersonAuth", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AuthName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonAuths");
                });

            modelBuilder.Entity("PlainClasses.Domain.Platoons.Platoon", b =>
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

                    b.HasKey("Id");

                    b.ToTable("Platoons");
                });

            modelBuilder.Entity("PlainClasses.Domain.EduBlocks.EduBlock", b =>
                {
                    b.HasOne("PlainClasses.Domain.EduBlocks.EduBlockSubject", "EduBlockSubject")
                        .WithMany("EduBlocks")
                        .HasForeignKey("EduBlockSubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlainClasses.Domain.EduBlocks.PersonFunction", b =>
                {
                    b.HasOne("PlainClasses.Domain.EduBlocks.EduBlock", "EduBlock")
                        .WithMany("PersonFunctions")
                        .HasForeignKey("EduBlockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlainClasses.Domain.Persons.Person", "Person")
                        .WithMany("PersonFunctions")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlainClasses.Domain.EduBlocks.PlatoonInEduBlock", b =>
                {
                    b.HasOne("PlainClasses.Domain.EduBlocks.EduBlock", "EduBlock")
                        .WithMany("Platoons")
                        .HasForeignKey("EduBlockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlainClasses.Domain.Platoons.Platoon", "Platoon")
                        .WithMany("Platoons")
                        .HasForeignKey("PlatoonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlainClasses.Domain.Persons.Person", b =>
                {
                    b.HasOne("PlainClasses.Domain.Persons.MilitaryRank", "MilitaryRank")
                        .WithMany("Persons")
                        .HasForeignKey("MilitaryRankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlainClasses.Domain.Platoons.Platoon", "Platoon")
                        .WithMany("Persons")
                        .HasForeignKey("PlatoonId");
                });

            modelBuilder.Entity("PlainClasses.Domain.Persons.PersonAuth", b =>
                {
                    b.HasOne("PlainClasses.Domain.Persons.Person", "Person")
                        .WithMany("PersonAuths")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
