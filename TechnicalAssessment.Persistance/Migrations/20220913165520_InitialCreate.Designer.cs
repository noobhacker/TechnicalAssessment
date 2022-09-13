﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechnicalAssessment.Persistance;

#nullable disable

namespace TechnicalAssessment.Persistance.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220913165520_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TechnicalAssessment.Persistance.Feature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<int>("FeatureNameId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FeatureNameId");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("TechnicalAssessment.Persistance.FeatureName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("FeatureNames");
                });

            modelBuilder.Entity("TechnicalAssessment.Persistance.Feature", b =>
                {
                    b.HasOne("TechnicalAssessment.Persistance.FeatureName", "FeatureName")
                        .WithMany()
                        .HasForeignKey("FeatureNameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FeatureName");
                });
#pragma warning restore 612, 618
        }
    }
}
