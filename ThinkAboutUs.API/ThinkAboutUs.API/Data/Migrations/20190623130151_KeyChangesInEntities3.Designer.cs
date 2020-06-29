﻿// <auto-generated />

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ThinkAboutUs.API.Data.Context;

namespace ThinkAboutUs.API.Data.Migrations
{
    [DbContext(typeof(ThinkAboutUsContext))]
    [Migration("20190623130151_KeyChangesInEntities3")]
    partial class KeyChangesInEntities3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ThinkAboutUs.API.Data.Entities.DogEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Breed");

                    b.Property<string>("Code");

                    b.Property<string>("Description");

                    b.Property<int>("Gender");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Location");

                    b.Property<string>("Size");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Dogs");
                });

            modelBuilder.Entity("ThinkAboutUs.API.Data.Entities.ReportEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactEmail");

                    b.Property<string>("ContactNumber");

                    b.Property<DateTime>("DateReported");

                    b.Property<int>("DogId");

                    b.HasKey("Id");

                    b.HasIndex("DogId")
                        .IsUnique();

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("ThinkAboutUs.API.Data.Entities.ReportEntity", b =>
                {
                    b.HasOne("ThinkAboutUs.API.Data.Entities.DogEntity", "Dog")
                        .WithOne("Report")
                        .HasForeignKey("ThinkAboutUs.API.Data.Entities.ReportEntity", "DogId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
