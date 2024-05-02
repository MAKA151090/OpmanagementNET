using Microsoft.EntityFrameworkCore;
using HealthCare.Models;

namespace HealthCare.Context

{
    public class HealthcareContext : DbContext
    {
        public HealthcareContext() { }
        public HealthcareContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<PatientObjectiveModel> SHExmPatientObjective { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure primary key for Login
            modelBuilder.Entity<PatientObjectiveModel>()
        .HasKey(i => new { i.PatientID, i.ClinicID, i.VisitID });

            modelBuilder.Entity<PatientObjectiveModel>()
       .Property(i => i.lastUpdatedDate)
       .ValueGeneratedOnUpdate()
       .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }

    }
}
