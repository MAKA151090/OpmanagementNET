﻿// <auto-generated />
using System;
using HealthCare.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HealthCare.Migrations
{
    [DbContext(typeof(HealthcareContext))]
    partial class HealthcareContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BloodGroupModel", b =>
                {
                    b.Property<string>("IntBg_Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BloodGroup")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("lastUpdatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IntBg_Id", "BloodGroup");

                    b.ToTable("SHclnBloodGroup");
                });

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

            modelBuilder.Entity("DoctorAdminModel", b =>
                {
                    b.Property<string>("DoctorID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateofBirth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MedialLicenseNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DoctorID");

                    b.ToTable("SHclnDoctorAdmin");
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

            modelBuilder.Entity("HealthCare.Models.DrugCategoryModel", b =>
                {
                    b.Property<string>("CategoryID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedmachine")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("SHstkDrugCategory");
                });

            modelBuilder.Entity("HealthCare.Models.DrugGroupModel", b =>
                {
                    b.Property<string>("GroupTypeName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GroupTypeID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LastUpdatedmachine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GroupTypeName", "GroupTypeID");

                    b.ToTable("SHstkDrugGroup");
                });

            modelBuilder.Entity("HealthCare.Models.DrugInventoryModel", b =>
                {
                    b.Property<string>("DrugId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BarCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dosage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastUpdatedMachine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastupdatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastupdatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MedicalDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModelName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RockId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SideEffects")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Therapy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DrugId");

                    b.ToTable("SHstkDrugInventory");
                });

            modelBuilder.Entity("HealthCare.Models.DrugRackModel", b =>
                {
                    b.Property<string>("RackID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RackName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UniqueIdentifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedmachine")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RackID", "RackName");

                    b.ToTable("SHstkDrugRack");
                });

            modelBuilder.Entity("HealthCare.Models.DrugStockModel", b =>
                {
                    b.Property<string>("IDNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DrugID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ExpiryDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManufacturingDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumberOfStock")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedMachine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDNumber", "DrugID");

                    b.ToTable("SHstkDrugStock");
                });

            modelBuilder.Entity("HealthCare.Models.DrugTypeModel", b =>
                {
                    b.Property<string>("TypeID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TypeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedmachine")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TypeID");

                    b.ToTable("SHstkDrugType");
                });

            modelBuilder.Entity("HealthCare.Models.LogsModel", b =>
                {
                    b.Property<int>("LogID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LogID"));

                    b.Property<int?>("Att1")
                        .HasColumnType("int");

                    b.Property<string>("LogDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogScreens")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MachineName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LogID");

                    b.ToTable("SHLogs");
                });

            modelBuilder.Entity("HealthCare.Models.PatientEPrescriptionModel", b =>
                {
                    b.Property<string>("PatientID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CaseVisitID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OrderID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DrugID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoctorID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Duration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EndDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("EpressID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("EpressID"));

                    b.Property<string>("FillDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Frequency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FrequencyUnit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instructions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrescriptionDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Quantity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Result")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RouteAdmin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedMachine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastupdatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientID", "CaseVisitID", "OrderID", "DrugID");

                    b.ToTable("SHprsPrescription");
                });

            modelBuilder.Entity("HealthCare.Models.PatientEPrescriptionPrintModel", b =>
                {
                    b.Property<string>("PatientID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CaseVisitID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OrderID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DoctorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Duration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EndDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Frequency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FrequencyUnit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instructions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MedicactionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PatientName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Quantity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedMachine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastupdatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientID", "CaseVisitID", "OrderID");

                    b.ToTable("SHprsPrescriptionPrint");
                });

            modelBuilder.Entity("HealthCare.Models.PatientFHPHMasterModel", b =>
                {
                    b.Property<string>("QuestionID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LastUpdatedDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastUpdatedUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuestionID");

                    b.ToTable("PatExmFHPH");
                });

            modelBuilder.Entity("HealthCare.Models.PatientRadiolodyModel", b =>
                {
                    b.Property<string>("RadioID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClinicID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PatientID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ScreeningDate")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ReferralDoctorID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReferralDoctorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Result")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ScreeningCompleted")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ScreeningCompletedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedMachine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RadioID", "ClinicID", "PatientID", "ScreeningDate");

                    b.ToTable("SHPatientRadiology");
                });

            modelBuilder.Entity("HealthCare.Models.PatientTestModel", b =>
                {
                    b.Property<string>("PatientID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClinicID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TestID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TestDateTime")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ExptRsltDateTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReferDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReferDocID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResultDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResultPublish")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TestResult")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TsampleClt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TsampleCltDateTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedMachine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientID", "ClinicID", "TestID", "TestDateTime");

                    b.ToTable("SHPatientTest");
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

            modelBuilder.Entity("HealthCare.Models.RadiologyMasterModel", b =>
                {
                    b.Property<string>("RadioID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Cost")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RadioName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedMachine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RadioID");

                    b.ToTable("SHRadioMaster");
                });

            modelBuilder.Entity("HealthCare.Models.SeverityModel", b =>
                {
                    b.Property<string>("SeverityID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Active")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastUpdatedMachine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastupdatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastupdatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SeverityName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SeverityID");

                    b.ToTable("SHSeverityModel");
                });

            modelBuilder.Entity("HealthCare.Models.TestMasterModel", b =>
                {
                    b.Property<string>("TestID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Cost")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Range")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TestName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedMachine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TestID");

                    b.ToTable("SHTestMaster");
                });

            modelBuilder.Entity("HealthCare.Models.UpdateRadiologyResultsModel", b =>
                {
                    b.Property<string>("PatientID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClinicID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RadioID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ImageData")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientID", "ClinicID", "RadioID");

                    b.ToTable("SHUpdateRadiologyResult");
                });

            modelBuilder.Entity("HealthCare.Models.WebErrorsModel", b =>
                {
                    b.Property<string>("ErrodDesc")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ErrDateTime")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ScreenName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ErrodDesc", "ErrDateTime", "ScreenName");

                    b.ToTable("SHWebErrors");
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

                    b.Property<string>("QuestionID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Answer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClinicID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientID", "QuestionID", "Type");

                    b.ToTable("SHExmPatientFHPH");
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

            modelBuilder.Entity("PatientScheduleModel", b =>
                {
                    b.Property<string>("PatientID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClinicID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoctorID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastUpdatedUser")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientID");

                    b.ToTable("SHPatientSchedule");
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
