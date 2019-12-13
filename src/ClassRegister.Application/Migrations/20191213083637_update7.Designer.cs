﻿// <auto-generated />
using System;
using ClassRegister.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClassRegister.Application.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20191213083637_update7")]
    partial class update7
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClassRegister.Core.Model.Admin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("HouseNumber");

                    b.Property<string>("LastName");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Pesel");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("PostCode");

                    b.Property<string>("Role");

                    b.Property<string>("Street");

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("ClassRegister.Core.Model.Class", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<Guid>("TeacherId");

                    b.HasKey("Id");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("ClassRegister.Core.Model.Grade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("StudentId");

                    b.Property<Guid?>("SubjectId");

                    b.Property<int>("Value");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("ClassRegister.Core.Model.Lesson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ClassId");

                    b.Property<Guid?>("ScheduleId");

                    b.Property<Guid?>("SubjectId");

                    b.Property<Guid?>("TeacherId");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("ScheduleId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("ClassRegister.Core.Model.Parent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("HouseNumber");

                    b.Property<string>("LastName");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Pesel");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("PostCode");

                    b.Property<string>("Role");

                    b.Property<string>("Street");

                    b.Property<Guid?>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("StudentId")
                        .IsUnique()
                        .HasFilter("[StudentId] IS NOT NULL");

                    b.ToTable("Parents");
                });

            modelBuilder.Entity("ClassRegister.Core.Model.Schedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DayOfTheWeek");

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("ClassRegister.Core.Model.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<Guid?>("ClassId");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("HouseNumber");

                    b.Property<string>("LastName");

                    b.Property<Guid?>("ParentId");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Pesel");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("PostCode");

                    b.Property<string>("Role");

                    b.Property<string>("Street");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ClassRegister.Core.Model.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("ClassRegister.Core.Model.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("HouseNumber");

                    b.Property<string>("LastName");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Pesel");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("PostCode");

                    b.Property<string>("Role");

                    b.Property<string>("Street");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("ClassRegister.Core.Model.Grade", b =>
                {
                    b.HasOne("ClassRegister.Core.Model.Student", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ClassRegister.Core.Model.Lesson", b =>
                {
                    b.HasOne("ClassRegister.Core.Model.Class", "Class")
                        .WithMany("Lessons")
                        .HasForeignKey("ClassId");

                    b.HasOne("ClassRegister.Core.Model.Schedule", "Schedule")
                        .WithMany("Lessons")
                        .HasForeignKey("ScheduleId");

                    b.HasOne("ClassRegister.Core.Model.Subject", "Subject")
                        .WithMany("Lessons")
                        .HasForeignKey("SubjectId");

                    b.HasOne("ClassRegister.Core.Model.Teacher", "Teacher")
                        .WithMany("Lessons")
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("ClassRegister.Core.Model.Parent", b =>
                {
                    b.HasOne("ClassRegister.Core.Model.Student", "Student")
                        .WithOne("Parent")
                        .HasForeignKey("ClassRegister.Core.Model.Parent", "StudentId");
                });

            modelBuilder.Entity("ClassRegister.Core.Model.Student", b =>
                {
                    b.HasOne("ClassRegister.Core.Model.Class", "Class")
                        .WithMany("Students")
                        .HasForeignKey("ClassId");
                });
#pragma warning restore 612, 618
        }
    }
}
