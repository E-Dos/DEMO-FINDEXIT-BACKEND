﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TEMPLATE_ELDOS_BACKEND.Infrastructure.Data;

#nullable disable

namespace TEMPLATE_ELDOS_BACKEND.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TEMPLATE_ELDOS_BACKEND.Domain.Entities.SecurityResource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("SecurityResources");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "*"
                        },
                        new
                        {
                            Id = 2,
                            Name = "edit.data"
                        },
                        new
                        {
                            Id = 3,
                            Name = "export.data"
                        });
                });

            modelBuilder.Entity("TEMPLATE_ELDOS_BACKEND.Domain.Entities.SecurityRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasAnnotation("Relational:JsonPropertyName", "name");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("SecurityRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "SuperAdmin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Employee"
                        });
                });

            modelBuilder.Entity("TEMPLATE_ELDOS_BACKEND.Domain.Entities.SecurityRoleResource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Delete")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Edit")
                        .HasColumnType("bit");

                    b.Property<int>("ResourceId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("View")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ResourceId");

                    b.HasIndex("RoleId");

                    b.ToTable("SecurityRoleResource");
                });

            modelBuilder.Entity("TEMPLATE_ELDOS_BACKEND.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConnectionIdHub")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool?>("IsEmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsPhoneConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Phone")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "roleId");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(2023, 11, 29, 17, 59, 37, 673, DateTimeKind.Local).AddTicks(1550),
                            Created = new DateTime(2023, 1, 1, 1, 1, 1, 0, DateTimeKind.Unspecified),
                            FirstName = "",
                            LastName = "",
                            Password = "$2a$11$9zhw0/UQhHQtHSnMZxTFh.4XlypTOseY1U2E5dBxGm1x54ogN5m4y",
                            RoleId = 1,
                            SurName = "",
                            Updated = new DateTime(2023, 1, 1, 1, 1, 1, 0, DateTimeKind.Unspecified),
                            Username = "SuperAdmin"
                        });
                });

            modelBuilder.Entity("TEMPLATE_ELDOS_BACKEND.Domain.Entities.SecurityRoleResource", b =>
                {
                    b.HasOne("TEMPLATE_ELDOS_BACKEND.Domain.Entities.SecurityResource", "Resource")
                        .WithMany("SecurityRoleResources")
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TEMPLATE_ELDOS_BACKEND.Domain.Entities.SecurityRole", "Role")
                        .WithMany("SecurityRoleResources")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Resource");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("TEMPLATE_ELDOS_BACKEND.Domain.Entities.User", b =>
                {
                    b.HasOne("TEMPLATE_ELDOS_BACKEND.Domain.Entities.SecurityRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("TEMPLATE_ELDOS_BACKEND.Domain.Entities.SecurityResource", b =>
                {
                    b.Navigation("SecurityRoleResources");
                });

            modelBuilder.Entity("TEMPLATE_ELDOS_BACKEND.Domain.Entities.SecurityRole", b =>
                {
                    b.Navigation("SecurityRoleResources");
                });
#pragma warning restore 612, 618
        }
    }
}
