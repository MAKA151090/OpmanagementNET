using Microsoft.EntityFrameworkCore;
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

        public DbSet<PatientRegistrationModel> SHPatientRegistration { get; set; }



        public DbSet<PatientExaminationModel> SHExmPatientExamination { get; set; }

        public DbSet<PatExmSymptomsSeverity> SHExmSeverity { get; set; }

        //public DbSet<PatientVisitIntoDocumentModel>SHExmPatientDocument { get; set; }

        public DbSet<PatientFHPHModel>SHExmPatientFHPH { get; set; }

        public DbSet<PatientFHPHModel1> SHExmPatientFHPH1 { get; set; }

        public DbSet<PatientInfoDocumentModel> SHExmInfoDocument { get; set; }

        public DbSet<WebErrorsModel> SHWebErrors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-L8EIGER\\SQLEXPRESS;Initial Catalog=StellarHealthcare;Integrated Security=True;Trust Server Certificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure primary key for Login
            modelBuilder.Entity<PatientObjectiveModel>()
        .HasKey(i => new { i.PatientID, i.ClinicID, i.VisitID });


            modelBuilder.Entity<ClinicAdminModel>()
       .HasKey(i => new { i.ClinicId });

            modelBuilder.Entity<PatientRegistrationModel>()
                .HasKey(i => new { i.PatientID });


            modelBuilder.Entity<PatientExaminationModel>()
        .HasKey(i => new { i.PatientID,i.ClinicID,i.VisitID,i.ExaminationID });

            modelBuilder.Entity<PatExmSymptomsSeverity>()
        .HasKey(i => new { i.PatientID, i.ClinicID, i.VisitID, i.ExaminationID, i.Severity });

            modelBuilder.Entity<PatientVisitIntoDocumentModel>()
        .HasKey(i => new { i.PatientID, i.ClinicID, i.VisitID });

            modelBuilder.Entity<PatientFHPHModel>()
        .HasKey(i => new { i.PatientID, i.Question, i.Type });

            modelBuilder.Entity<PatientFHPHModel1>()
       .HasKey(i => new { i.PatientID, i.Question, i.Type });

            modelBuilder.Entity<PatientInfoDocumentModel>()
       .HasKey(i => new { i.PatientID, i.ClinicID, i.VisitID });

            modelBuilder.Entity<WebErrorsModel>()
        .HasKey(i => new { i.ErrodDesc, i.ErrDateTime, i.ScreenName });


            modelBuilder.Entity<PatientObjectiveModel>()
       .Property(i => i.lastUpdatedDate)
       .ValueGeneratedOnUpdate()
       .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }


        public DbSet<PatientFHPHModel1> PatientFHPHModel1 { get; set; } = default!;

    }
    
}
