﻿// <auto-generated />
using eCaiet.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace eCaiet.DAL.Migrations
{
    [DbContext(typeof(EDbContext))]
    partial class EDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("eCaiet.DAL.Models.DB.Course", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<DateTime>("LastUpdateDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("Public");

                    b.Property<Guid>("UserGuid");

                    b.HasKey("Guid");

                    b.HasIndex("Name");

                    b.HasIndex("UserGuid");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("eCaiet.DAL.Models.DB.File", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<Guid?>("CourseGuid");

                    b.Property<byte[]>("Data");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<Guid?>("OwnerGuid");

                    b.HasKey("Guid");

                    b.HasIndex("CourseGuid");

                    b.HasIndex("Name");

                    b.HasIndex("OwnerGuid")
                        .IsUnique()
                        .HasFilter("[OwnerGuid] IS NOT NULL");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("eCaiet.DAL.Models.DB.User", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(254);

                    b.Property<string>("FirstName")
                        .HasMaxLength(35);

                    b.Property<string>("LastName")
                        .HasMaxLength(35);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.HasKey("Guid");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("eCaiet.DAL.Models.DB.Course", b =>
                {
                    b.HasOne("eCaiet.DAL.Models.DB.User", "User")
                        .WithMany("Courses")
                        .HasForeignKey("UserGuid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eCaiet.DAL.Models.DB.File", b =>
                {
                    b.HasOne("eCaiet.DAL.Models.DB.Course", "Course")
                        .WithMany("Files")
                        .HasForeignKey("CourseGuid");

                    b.HasOne("eCaiet.DAL.Models.DB.User", "Owner")
                        .WithOne("Avartar")
                        .HasForeignKey("eCaiet.DAL.Models.DB.File", "OwnerGuid");
                });
#pragma warning restore 612, 618
        }
    }
}
