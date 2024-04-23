﻿// <auto-generated />
using System;
using ADIA.Uow.SqlServer.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ADIA.Uow.SqlServer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240413151457_Db_222")]
    partial class Db_222
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ADIA.Model.Domain.Entities.Analysis", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("AnalysisDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileBase64")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("FileType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Analysis");
                });

            modelBuilder.Entity("ADIA.Model.Domain.Entities.AnalysisResponse", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<int>("DocumentType")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndAnalysis")
                        .HasColumnType("datetime2");

                    b.Property<int>("Ia")
                        .HasColumnType("int");

                    b.Property<long>("IdAnalysis")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsSuccess")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ResponseTime")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("StartAnalysis")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdAnalysis")
                        .IsUnique();

                    b.ToTable("AnalysisResponse");
                });

            modelBuilder.Entity("ADIA.Model.Domain.Entities.GeneralText", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("IdAnalysisResponse")
                        .HasColumnType("bigint");

                    b.Property<string>("Sentiment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdAnalysisResponse")
                        .IsUnique();

                    b.ToTable("GeneralText");
                });

            modelBuilder.Entity("ADIA.Model.Domain.Entities.Invoice", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("CustomerAddress")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<long>("IdAnalysisResponse")
                        .HasColumnType("bigint");

                    b.Property<string>("InvoiceDate")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("InvoiceNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SupplierAddress")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<decimal>("TotalAmmount")
                        .HasPrecision(12, 3)
                        .HasColumnType("decimal(12,3)");

                    b.HasKey("Id");

                    b.HasIndex("IdAnalysisResponse")
                        .IsUnique();

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("ADIA.Model.Domain.Entities.ItemInvoice", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("IdInvoice")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Quantity")
                        .HasPrecision(12, 3)
                        .HasColumnType("decimal(12,3)");

                    b.Property<decimal>("TotalAmount")
                        .HasPrecision(12, 3)
                        .HasColumnType("decimal(12,3)");

                    b.Property<decimal>("UnitPrice")
                        .HasPrecision(12, 3)
                        .HasColumnType("decimal(12,3)");

                    b.HasKey("Id");

                    b.HasIndex("IdInvoice");

                    b.ToTable("ItemInvoice");
                });

            modelBuilder.Entity("ADIA.Model.Domain.Entities.AnalysisResponse", b =>
                {
                    b.HasOne("ADIA.Model.Domain.Entities.Analysis", "Analysis")
                        .WithOne("AnalysisResponse")
                        .HasForeignKey("ADIA.Model.Domain.Entities.AnalysisResponse", "IdAnalysis")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Analysis");
                });

            modelBuilder.Entity("ADIA.Model.Domain.Entities.GeneralText", b =>
                {
                    b.HasOne("ADIA.Model.Domain.Entities.AnalysisResponse", null)
                        .WithOne("GeneralText")
                        .HasForeignKey("ADIA.Model.Domain.Entities.GeneralText", "IdAnalysisResponse")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ADIA.Model.Domain.Entities.Invoice", b =>
                {
                    b.HasOne("ADIA.Model.Domain.Entities.AnalysisResponse", null)
                        .WithOne("Invoice")
                        .HasForeignKey("ADIA.Model.Domain.Entities.Invoice", "IdAnalysisResponse")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ADIA.Model.Domain.Entities.ItemInvoice", b =>
                {
                    b.HasOne("ADIA.Model.Domain.Entities.Invoice", null)
                        .WithMany("Items")
                        .HasForeignKey("IdInvoice")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ADIA.Model.Domain.Entities.Analysis", b =>
                {
                    b.Navigation("AnalysisResponse")
                        .IsRequired();
                });

            modelBuilder.Entity("ADIA.Model.Domain.Entities.AnalysisResponse", b =>
                {
                    b.Navigation("GeneralText")
                        .IsRequired();

                    b.Navigation("Invoice")
                        .IsRequired();
                });

            modelBuilder.Entity("ADIA.Model.Domain.Entities.Invoice", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
