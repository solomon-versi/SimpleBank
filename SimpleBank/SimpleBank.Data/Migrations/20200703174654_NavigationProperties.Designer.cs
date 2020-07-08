﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleBank.Data;

namespace SimpleBank.Data.Migrations
{
    [DbContext(typeof(SimpleBankDbContext))]
    [Migration("20200703174654_NavigationProperties")]
    partial class NavigationProperties
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SimpleBank.Data.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<short>("Currency")
                        .HasColumnType("smallint");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Iban")
                        .IsRequired()
                        .HasColumnType("nvarchar(22)")
                        .HasMaxLength(22);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("SimpleBank.Data.Models.CurrencyRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("Base")
                        .HasColumnType("smallint");

                    b.Property<short>("Quote")
                        .HasColumnType("smallint");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("CurrencyRates");
                });

            modelBuilder.Entity("SimpleBank.Data.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("IdentityNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<byte>("Type")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("SimpleBank.Data.Models.Operation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<short>("Currency")
                        .HasColumnType("smallint");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("HappenedAt")
                        .HasColumnType("datetime2");

                    b.Property<byte>("Type")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Operations");
                });

            modelBuilder.Entity("SimpleBank.Data.Models.Account", b =>
                {
                    b.HasOne("SimpleBank.Data.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SimpleBank.Data.Models.Operation", b =>
                {
                    b.HasOne("SimpleBank.Data.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SimpleBank.Data.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
