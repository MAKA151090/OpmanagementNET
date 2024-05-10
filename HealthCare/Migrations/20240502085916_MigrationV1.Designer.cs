﻿// <auto-generated />
using HealthCare.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HealthCare.Migrations
{
    [DbContext(typeof(HealthcareContext))]
    [Migration("20240502085916_MigrationV1")]
    partial class MigrationV1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PatientObjectiveModel", b =>
                {
                    b.Property<string>("VisitID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BldGluLvl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BloodPressure")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CheifComplaint")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClinicID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HeartRate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Height")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OxySat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PatientID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PulseRate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResptryRate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Temperature")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VisitDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Weight")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VisitID");

                    b.ToTable("objPatientObjective");
                });
#pragma warning restore 612, 618
        }
    }
}
