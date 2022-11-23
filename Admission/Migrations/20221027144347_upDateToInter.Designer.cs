﻿// <auto-generated />
using System;
using Admission.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Admission.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221027144347_upDateToInter")]
    partial class upDateToInter
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Admission.DB.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Admission.DB.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Admission.Model.DomainModel.Admin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AdminName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Admission.Model.DomainModel.Document", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdminId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DocumentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("filePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("Admission.Model.DomainModel.Gender", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdminId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GenderType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("Admission.Model.DomainModel.Grade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdminId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("Admission.Model.DomainModel.Interview", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdminId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InterviewName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("InterviewerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("InterviewerId");

                    b.HasIndex("StudentId");

                    b.ToTable("Interviews");
                });

            modelBuilder.Entity("Admission.Model.DomainModel.Interviewer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdminId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InterviewerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("Interviewers");
                });

            modelBuilder.Entity("Admission.Model.DomainModel.Round", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdminId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndAdmission")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("RoundName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartAdmission")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("Rounds");
                });

            modelBuilder.Entity("Admission.Model.DomainModel.Status", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdminId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("StatusName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("Admission.Model.DomainModel.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AdminId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("GenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("GradeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("GraduationYear")
                        .HasColumnType("int");

                    b.Property<Guid?>("InterviewId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("InterviewerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("RoundId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("StatusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StudentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TrackId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UniversityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("GenderId");

                    b.HasIndex("GradeId");

                    b.HasIndex("InterviewerId");

                    b.HasIndex("RoundId");

                    b.HasIndex("StatusId");

                    b.HasIndex("TrackId");

                    b.HasIndex("UniversityId");

                    b.HasIndex("UserId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Admission.Model.DomainModel.Track", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdminId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("RoundId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TrackName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("RoundId");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("Admission.Model.DomainModel.University", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdminId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("UniversityName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("Universities");
                });

            modelBuilder.Entity("DocumentStudent", b =>
                {
                    b.Property<Guid>("DocumentsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StudentsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DocumentsId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("DocumentStudent");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Admission.Model.DomainModel.Document", b =>
                {
                    b.HasOne("Admission.Model.DomainModel.Admin", "Admin")
                        .WithMany("Documents")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("Admission.Model.DomainModel.Gender", b =>
                {
                    b.HasOne("Admission.Model.DomainModel.Admin", "Admin")
                        .WithMany("Genders")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("Admission.Model.DomainModel.Grade", b =>
                {
                    b.HasOne("Admission.Model.DomainModel.Admin", "Admin")
                        .WithMany("Grades")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("Admission.Model.DomainModel.Interview", b =>
                {
                    b.HasOne("Admission.Model.DomainModel.Admin", "Admin")
                        .WithMany("Interviews")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Admission.Model.DomainModel.Interviewer", "Interviewer")
                        .WithMany("InterviewId")
                        .HasForeignKey("InterviewerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Admission.Model.DomainModel.Student", "Student")
                        .WithMany("Interview")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("Interviewer");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Admission.Model.DomainModel.Interviewer", b =>
                {
                    b.HasOne("Admission.Model.DomainModel.Admin", "Admin")
                        .WithMany("Interviewer")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("Admission.Model.DomainModel.Round", b =>
                {
                    b.HasOne("Admission.Model.DomainModel.Admin", "Admin")
                        .WithMany("Round")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("Admission.Model.DomainModel.Status", b =>
                {
                    b.HasOne("Admission.Model.DomainModel.Admin", "Admin")
                        .WithMany("Statuses")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("Admission.Model.DomainModel.Student", b =>
                {
                    b.HasOne("Admission.Model.DomainModel.Admin", "Admin")
                        .WithMany("Student")
                        .HasForeignKey("AdminId");

                    b.HasOne("Admission.Model.DomainModel.Gender", "Gender")
                        .WithMany("Students")
                        .HasForeignKey("GenderId");

                    b.HasOne("Admission.Model.DomainModel.Grade", "Grade")
                        .WithMany("Students")
                        .HasForeignKey("GradeId");

                    b.HasOne("Admission.Model.DomainModel.Interviewer", "Interviewer")
                        .WithMany("Student")
                        .HasForeignKey("InterviewerId");

                    b.HasOne("Admission.Model.DomainModel.Round", "Round")
                        .WithMany("Student")
                        .HasForeignKey("RoundId");

                    b.HasOne("Admission.Model.DomainModel.Status", "Status")
                        .WithMany("Students")
                        .HasForeignKey("StatusId");

                    b.HasOne("Admission.Model.DomainModel.Track", "Track")
                        .WithMany("Student")
                        .HasForeignKey("TrackId");

                    b.HasOne("Admission.Model.DomainModel.University", "University")
                        .WithMany("Students")
                        .HasForeignKey("UniversityId");

                    b.HasOne("Admission.DB.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Admin");

                    b.Navigation("Gender");

                    b.Navigation("Grade");

                    b.Navigation("Interviewer");

                    b.Navigation("Round");

                    b.Navigation("Status");

                    b.Navigation("Track");

                    b.Navigation("University");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Admission.Model.DomainModel.Track", b =>
                {
                    b.HasOne("Admission.Model.DomainModel.Admin", "Admin")
                        .WithMany("Track")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Admission.Model.DomainModel.Round", "Round")
                        .WithMany("Track")
                        .HasForeignKey("RoundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("Round");
                });

            modelBuilder.Entity("Admission.Model.DomainModel.University", b =>
                {
                    b.HasOne("Admission.Model.DomainModel.Admin", "Admin")
                        .WithMany("Universities")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("DocumentStudent", b =>
                {
                    b.HasOne("Admission.Model.DomainModel.Document", null)
                        .WithMany()
                        .HasForeignKey("DocumentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Admission.Model.DomainModel.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Admission.DB.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Admission.DB.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Admission.DB.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Admission.DB.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Admission.DB.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Admission.DB.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Admission.Model.DomainModel.Admin", b =>
                {
                    b.Navigation("Documents");

                    b.Navigation("Genders");

                    b.Navigation("Grades");

                    b.Navigation("Interviewer");

                    b.Navigation("Interviews");

                    b.Navigation("Round");

                    b.Navigation("Statuses");

                    b.Navigation("Student");

                    b.Navigation("Track");

                    b.Navigation("Universities");
                });

            modelBuilder.Entity("Admission.Model.DomainModel.Gender", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("Admission.Model.DomainModel.Grade", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("Admission.Model.DomainModel.Interviewer", b =>
                {
                    b.Navigation("InterviewId");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Admission.Model.DomainModel.Round", b =>
                {
                    b.Navigation("Student");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("Admission.Model.DomainModel.Status", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("Admission.Model.DomainModel.Student", b =>
                {
                    b.Navigation("Interview");
                });

            modelBuilder.Entity("Admission.Model.DomainModel.Track", b =>
                {
                    b.Navigation("Student");
                });

            modelBuilder.Entity("Admission.Model.DomainModel.University", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
