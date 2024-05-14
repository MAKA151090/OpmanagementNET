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
    [Migration("20240513113041_MigModelPK")]
    partial class MigModelPK
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClinicAdminModel", b =>
                {
                    b.Property<string>("ClinicId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClinicAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClinicEmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClinicName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClinicPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FromHour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ToHour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClinicId");

                    b.ToTable("SHclnClinicAdmin");
                });

            modelBuilder.Entity("HealthCare.Business.PatientInfoDocumentModel", b =>
                {
                    b.Property<string>("PatientID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClinicID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("VisitID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("StrlastUpdatedDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StrlastUpdatedUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientID", "ClinicID", "VisitID");

                    b.ToTable("SHExmInfoDocument");
                });

            modelBuilder.Entity("HealthCare.Models.PatientVisitIntoDocumentModel", b =>
                {
                    b.Property<string>("PatientID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClinicID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("VisitID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("lastUpdatedDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientID", "ClinicID", "VisitID");

                    b.ToTable("PatientVisitIntoDocumentModel");
                });

            modelBuilder.Entity("PatExmSymptomsSeverity", b =>
                {
                    b.Property<string>("PatientID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClinicID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("VisitID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ExaminationID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Severity")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PatientExaminationModelClinicID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PatientExaminationModelExaminationID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PatientExaminationModelPatientID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PatientExaminationModelVisitID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Symptoms")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientID", "ClinicID", "VisitID", "ExaminationID", "Severity");

                    b.HasIndex("PatientExaminationModelPatientID", "PatientExaminationModelClinicID", "PatientExaminationModelVisitID", "PatientExaminationModelExaminationID");

                    b.ToTable("SHExmSeverity");
                });

            modelBuilder.Entity("PatientExaminationModel", b =>
                {
                    b.Property<string>("PatientID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClinicID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("VisitID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ExaminationID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Complaint")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Diagnosis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FollowUp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientID", "ClinicID", "VisitID", "ExaminationID");

                    b.ToTable("SHExmPatientExamination");
                });

            modelBuilder.Entity("PatientFHPHModel", b =>
                {
                    b.Property<string>("PatientID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Question")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientID", "Question", "Type");

                    b.ToTable("SHExmPatientFHPH");
                });

            modelBuilder.Entity("PatientFHPHModel1", b =>
                {
                    b.Property<string>("PatientID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Question")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientID", "Question", "Type");

                    b.ToTable("SHExmPatientFHPH1");
                });

            modelBuilder.Entity("PatientObjectiveModel", b =>
                {
                    b.Property<string>("PatientID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClinicID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("VisitID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BldGluLvl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BloodPressure")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CheifComplaint")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HeartRate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Height")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OxySat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PulseRate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResptryRate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Temperature")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VisitDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Weight")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("lastUpdatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientID", "ClinicID", "VisitID");

                    b.ToTable("SHExmPatientObjective");
                });

            modelBuilder.Entity("PatientRegistrationModel", b =>
                {
                    b.Property<string>("PatientID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Age")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BloodGroup")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClinicID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CnctPrsnName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dob")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmgcyCntNum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IDPrfName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IDPrfNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Initial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaritalStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MidName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prefix")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rlnpatient")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientID");

                    b.ToTable("SHPatientRegistration");
                });

            modelBuilder.Entity("PatExmSymptomsSeverity", b =>
                {
                    b.HasOne("PatientExaminationModel", null)
                        .WithMany("Severity")
                        .HasForeignKey("PatientExaminationModelPatientID", "PatientExaminationModelClinicID", "PatientExaminationModelVisitID", "PatientExaminationModelExaminationID");
                });

            modelBuilder.Entity("PatientExaminationModel", b =>
                {
                    b.Navigation("Severity");
                });
#pragma warning restore 612, 618
        }
    }
}
