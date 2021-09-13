﻿// <auto-generated />
using System;
using DAL.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(UserDbContext))]
    [Migration("20210908122038_RenameUserColumn")]
    partial class RenameUserColumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Invoice", b =>
                {
                    b.Property<string>("invoiceId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("invoiceId");

                    b.HasIndex("userId");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Property<string>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasColumnName("FirstName");

                    b.HasKey("userId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.UserRoles", b =>
                {
                    b.Property<int>("rolesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("rolesId");

                    b.HasIndex("userId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Domain.Invoice", b =>
                {
                    b.HasOne("Domain.User", "user")
                        .WithMany("Invoices")
                        .HasForeignKey("userId");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Domain.UserRoles", b =>
                {
                    b.HasOne("Domain.User", null)
                        .WithMany("roles")
                        .HasForeignKey("userId");
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Navigation("Invoices");

                    b.Navigation("roles");
                });
#pragma warning restore 612, 618
        }
    }
}
