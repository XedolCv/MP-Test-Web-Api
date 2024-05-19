﻿// <auto-generated />
using System;
using MPTWA_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MPTWA_Infrastructure.Migrations
{
    [DbContext(typeof(LogContext))]
    [Migration("20240519094939_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.3.24172.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MPTWA_Domain.Entities.RequestLogEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("create_time");

                    b.Property<string>("KeyWord")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("key_word");

                    b.Property<string>("Section")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("section");

                    b.HasKey("Id")
                        .HasName("pk_request_logs");

                    b.ToTable("request_logs", (string)null);
                });

            modelBuilder.Entity("MPTWA_Domain.Entities.ResultsLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("create_time");

                    b.Property<string>("SearchText")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("search_text");

                    b.Property<int>("VowelsCount")
                        .HasColumnType("integer")
                        .HasColumnName("vowels_count");

                    b.HasKey("Id")
                        .HasName("pk_results_logs");

                    b.ToTable("results_logs", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
