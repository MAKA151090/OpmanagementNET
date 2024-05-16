﻿using Microsoft.EntityFrameworkCore;
using HealthCare.Models;
using HealthCare.Business;

namespace HealthCare.Context

{
    public class HealthcareContext : DbContext
    {
        public HealthcareContext() { }
        public HealthcareContext(DbContextOptions options) : base(options)
        {
        }
        //PatientObjective
        public DbSet<PatientObjectiveModel> SHExmPatientObjective { get; set; }

        //ClinicAdmin 
        public DbSet<ClinicAdminModel> SHclnClinicAdmin { get; set; }

        public DbSet<BloodGroupModel> SHclnBloodGroup { get; set; }

        public DbSet<DoctorAdminModel> SHclnDoctorAdmin {  get; set; }


        public DbSet<PatientRegistrationModel> SHPatientRegistration { get; set; }

        public DbSet<PatientScheduleModel> SHPatientSchedule { get; set; }


        public DbSet<PatientExaminationModel> SHExmPatientExamination { get; set; }

        public DbSet<PatExmSymptomsSeverity> SHExmSeverity { get; set; }

        //public DbSet<PatientVisitIntoDocumentModel>SHExmPatientDocument { get; set; }

        public DbSet<PatientFHPHModel>SHExmPatientFHPH { get; set; }

        public DbSet<PatientFHPHMasterModel> PatExmFHPH {  get; set; }

     

        public DbSet<PatientInfoDocumentModel> SHExmInfoDocument { get; set; }

        public DbSet<WebErrorsModel> SHWebErrors { get; set; }

        public DbSet<LogsModel> SHLogs { get; set; }

        public DbSet<PatientTestModel> SHPatientTest { get; set; }

        public DbSet<TestMasterModel> SHTestMaster { get; set; }

        public DbSet<MedicationCategoryModel>SHstkMedCategory { get; set; }

        public DbSet<MedicationTypeModel>SHstkMedType { get; set; }

        public DbSet<MedicationRackModel> SHstkMedRack {  get; set; }

        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-L8EIGER\\SQLEXPRESS;Initial Catalog=StellarHealthcare;Integrated Security=True;Trust Server Certificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<MedicationRackModel>().HasKey(i => new { i.RackID, i.RackName });

            modelBuilder.Entity<MedicationTypeModel>().HasKey(i => new { i.TypeID });

            modelBuilder.Entity<MedicationCategoryModel>().HasKey(i => new { i.CategoryID });

            modelBuilder.Entity<PatientFHPHMasterModel>().HasKey(i => new { i.QuestionID });

            modelBuilder.Entity<TestMasterModel>().HasKey(i => new { i.TestID });

            modelBuilder.Entity<PatientTestModel>().HasKey(i => new { i.PatientID,i.ClinicID,i.TestID ,i.TestDateTime});
                

            // Configure primary key for Login
            modelBuilder.Entity<PatientObjectiveModel>()
        .HasKey(i => new { i.PatientID, i.ClinicID, i.VisitID });


            modelBuilder.Entity<ClinicAdminModel>()
       .HasKey(i => new { i.ClinicId });

            modelBuilder.Entity<BloodGroupModel>()
                .HasKey(i => new { i.IntBg_Id, i.BloodGroup});

            modelBuilder.Entity<DoctorAdminModel>()
                .HasKey(i => new { i.DoctorID });

            modelBuilder.Entity<PatientRegistrationModel>()
                .HasKey(i => new { i.PatientID });

            modelBuilder.Entity<PatientScheduleModel>()
                .HasKey(i => new { i.PatientID });

            modelBuilder.Entity<PatientExaminationModel>()
        .HasKey(i => new { i.PatientID, i.ClinicID, i.VisitID, i.ExaminationID });

            modelBuilder.Entity<PatExmSymptomsSeverity>()
        .HasKey(i => new { i.PatientID, i.ClinicID, i.VisitID, i.ExaminationID, i.Severity });

            modelBuilder.Entity<PatientVisitIntoDocumentModel>()
        .HasKey(i => new { i.PatientID, i.ClinicID, i.VisitID });

            modelBuilder.Entity<PatientFHPHModel>()
        .HasKey(i => new { i.PatientID, i.QuestionID, i.Type });



            modelBuilder.Entity<PatientInfoDocumentModel>()
       .HasKey(i => new { i.PatientID, i.ClinicID, i.VisitID });

            modelBuilder.Entity<WebErrorsModel>()
        .HasKey(i => new { i.ErrodDesc, i.ErrDateTime, i.ScreenName });

            modelBuilder.Entity<LogsModel>()
        .HasKey(i => new { i.LogID });


            modelBuilder.Entity<PatientObjectiveModel>()
       .Property(i => i.lastUpdatedDate)
       .ValueGeneratedOnUpdate()
       .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }


    }
    
}
