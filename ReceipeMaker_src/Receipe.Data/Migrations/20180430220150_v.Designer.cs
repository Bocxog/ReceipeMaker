﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Receipe.Data;
using System;

namespace Receipe.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20180430220150_v")]
    partial class v
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("Receipe.Data.Receipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("Delicious");

                    b.Property<bool?>("Healthy");

                    b.Property<string>("Name");

                    b.Property<TimeSpan>("PrepareTime");

                    b.HasKey("Id");

                    b.ToTable("Receipes");
                });

            modelBuilder.Entity("Receipe.Data.Requirement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("Optional");

                    b.Property<int>("Quantity");

                    b.Property<int>("ReceipeId");

                    b.Property<int>("ResourceId");

                    b.Property<int>("VolumeType");

                    b.HasKey("Id");

                    b.HasIndex("ReceipeId");

                    b.HasIndex("ResourceId");

                    b.ToTable("Requirements");
                });

            modelBuilder.Entity("Receipe.Data.Resource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("Receipe.Data.Requirement", b =>
                {
                    b.HasOne("Receipe.Data.Receipe", "Receipe")
                        .WithMany("Requirements")
                        .HasForeignKey("ReceipeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Receipe.Data.Resource", "Resource")
                        .WithMany("Requirements")
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
