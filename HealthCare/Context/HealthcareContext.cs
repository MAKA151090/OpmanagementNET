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

        public DbSet<BloodGroupModel> SHclnBloodGroup { get; set; }

        public DbSet<StaffAdminModel> SHclnStaffAdminModel {  get; set; }


        public DbSet<PatientRegistrationModel> SHPatientRegistration { get; set; }

        public DbSet<PatientScheduleModel> SHPatientSchedule { get; set; }


        public DbSet<PatientExaminationModel> SHExmPatientExamination { get; set; }

        public DbSet<PatExmSymptomsSeverity> SHExmSeverity { get; set; }

        //public DbSet<PatientVisitIntoDocumentModel>SHExmPatientDocument { get; set; }

        public DbSet<PatientFHPHModel>SHExmPatientFHPH { get; set; }

        public DbSet<PatientFHPHMasterModel> PatExmFHPH {  get; set; }

     
        public DbSet<RadiologyMasterModel> SHRadioMaster { get; set; }
        public DbSet<PatientInfoDocumentModel> SHExmInfoDocument { get; set; }

        public DbSet<WebErrorsModel> SHWebErrors { get; set; }

        public DbSet<LogsModel> SHLogs { get; set; }

        public DbSet<PatientTestModel> SHPatientTest { get; set; }

        public DbSet<TestMasterModel> SHTestMaster { get; set; }

        public DbSet<DrugCategoryModel>SHstkDrugCategory { get; set; }

        public DbSet<SeverityModel> SHSeverityModel { get; set; }

        public DbSet<DrugInventoryModel> SHstkDrugInventory { get; set; }


        public DbSet<DrugTypeModel>SHstkDrugType { get; set; }
        public DbSet<UpdateRadiologyResultsModel> SHUpdateRadiologyResult {  get; set; }

        public DbSet<DrugStockModel> SHstkDrugStock { get; set; }

        public DbSet<PatientRadiolodyModel> SHPatientRadiology { get; set; }   



        public DbSet<DrugRackModel> SHstkDrugRack {  get; set; }

        public DbSet<DrugGroupModel> SHstkDrugGroup { get; set; }

        public DbSet<PatientEPrescriptionModel>SHprsPrescription { get; set; }
        
        public DbSet<PatientEPrescriptionPrintModel>SHprsPrescriptionPrint { get; set; }

        public DbSet<OTSchedulingModel>SHotScheduling { get; set; }
        public DbSet<OTNotesModel>SHotNotes { get; set; }
        public DbSet<OtTableMasterModel>SHotTableMaster { get; set; }
        public DbSet<ClinicSurgeryMasterModel>SHclnSurgeryMaster { get; set; }
        public DbSet<SurgeryTypeMasterModel>SHotSurgerTypeymaster { get; set; }

        public DbSet<InternalDepartmentMasterModel>SHotInternalDepartmentMaster { get; set; }

        public DbSet<DoctorScheduleModel> SHcllDoctorScheduleModel { get; set; }


        public DbSet<InpatientAdmissionModel> SHInpatientAdmission { get; set; }

        public DbSet<HospitalBedMasterModel> SHclnHospitalBedMaster { get; set; }



        public DbSet<NurseStationMasterModel> SHclnNurseStationMaster { get; set; }

        public DbSet<IPTypeMasterModel> SHclnIPTypeMaster { get; set; }

        public DbSet<RoomTypeMasterModel> SHclnRoomTypeMaster { get; set; }

        public DbSet<StaffAttendanceModel> SHStaffAttendance { get; set; }

        public DbSet<RollAccessModel> SHClnRollAccess { get; set; }

        public DbSet<ScreenMasterModel>SHClnScreenMaster { get; set; }



        public DbSet<OpCheckingModel> SHfdOpCheckingModel { get; set; }

        public DbSet<EWSMasterModel>SHclnEWSMaster { get; set; }


        //InPatient

        public DbSet<InPatientCaseSheetModel> SHipmInPatientCaseSheet { get; set; }

        public DbSet<InPatientDocVisitModel> SHipmInPatientDocVisit { get; set; }

        public DbSet<InpatientObservationModel> SHipmInpatientobservation {  get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-L8EIGER\\SQLEXPRESS;Initial Catalog=StellarHealthcare;Integrated Security=True;Trust Server Certificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InpatientObservationModel>().HasKey(i => new { i.PatientID, i.ObservationID, i.BedNoID });
            modelBuilder.Entity<EWSMasterModel>().HasKey(i => new { i.ObservationTypeID });
            modelBuilder.Entity<DoctorScheduleModel>().HasKey(i => new { i.PatientID, i.ClinicID, i.SlotsID });
            modelBuilder.Entity<InPatientCaseSheetModel>().HasKey(i => new { i.StrPatientId,i.StrCaseId });

            modelBuilder.Entity<InPatientDocVisitModel>().HasKey(i => new { i.PatientId,i.CaseId });
            modelBuilder.Entity<OpCheckingModel>().HasKey(i => new { i.PatientId });

            // modelBuilder.Entity<DoctorScheduleModel>().HasKey(i => new { i.DoctorID, i.ClinicID, i.SlotsID });

            modelBuilder.Entity<PatientEPrescriptionModel>().HasKey(i => new { i.PatientID, i.CaseVisitID, i.OrderID, i.DrugID });

            modelBuilder.Entity<PatientEPrescriptionModel>().Property(p => p.EpressID).ValueGeneratedOnAdd();

            modelBuilder.Entity<PatientEPrescriptionPrintModel>().HasKey(i => new { i.PatientID, i.CaseVisitID, i.OrderID });

            modelBuilder.Entity<DrugRackModel>().HasKey(i => new { i.RackID, i.RackName });

            modelBuilder.Entity<DrugTypeModel>().HasKey(i => new { i.TypeID });

            modelBuilder.Entity<DrugCategoryModel>().HasKey(i => new { i.CategoryID });

            modelBuilder.Entity<PatientFHPHMasterModel>().HasKey(i => new { i.QuestionID });

            modelBuilder.Entity<TestMasterModel>().HasKey(i => new { i.TestID });


            modelBuilder.Entity<SeverityModel>().HasKey(i => new { i.SeverityID });

            modelBuilder.Entity<DrugInventoryModel>().HasKey(i => new { i.DrugId });


            modelBuilder.Entity<PatientTestModel>().HasKey(i => new { i.PatientID,i.ClinicID,i.TestID });
            modelBuilder.Entity<PatientTestModel>().HasKey(i => new { i.PatientID,i.ClinicID,i.TestID ,i.TestDateTime});

            modelBuilder.Entity<OTSchedulingModel>().HasKey(i => new { i.OtScheduleID });
            modelBuilder.Entity<OTNotesModel>().HasKey(i => new { i.OtScheduleID });
            modelBuilder.Entity<ClinicSurgeryMasterModel>().HasKey(i => new { i.SurgeryID });
            modelBuilder.Entity<OtTableMasterModel>().HasKey(i => new { i.TableID });
            modelBuilder.Entity<SurgeryTypeMasterModel>().HasKey(i => new { i.SurgeryTypeID });
            modelBuilder.Entity<InternalDepartmentMasterModel>().HasKey(i => new { i.DepartmentID });
            modelBuilder.Entity<OtSurgeryModel>().HasKey(i => new { i.OtScheduleID,i.SurgeryID });


            // Configure primary key for Login
            modelBuilder.Entity<PatientObjectiveModel>()
        .HasKey(i => new { i.PatientID, i.ClinicID, i.VisitID });


            modelBuilder.Entity<ClinicAdminModel>()
       .HasKey(i => new { i.ClinicId });

            modelBuilder.Entity<BloodGroupModel>()
                .HasKey(i => new { i.IntBg_Id, i.BloodGroup});

            modelBuilder.Entity<StaffAdminModel>()
                .HasKey(i => new { i.StrStaffID });

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

            modelBuilder.Entity<PatientRadiolodyModel>()
                 .HasKey(i => new { i.RadioID , i.ClinicID , i.PatientID , i.ScreeningDate });

            modelBuilder.Entity<RadiologyMasterModel>()
                .HasKey(i => new { i.RadioID });

            modelBuilder.Entity<PatientInfoDocumentModel>()
       .HasKey(i => new { i.PatientID, i.ClinicID, i.VisitID });

            modelBuilder.Entity<WebErrorsModel>()
        .HasKey(i => new { i.ErrodDesc, i.ErrDateTime, i.ScreenName });

            modelBuilder.Entity<LogsModel>()
        .HasKey(i => new { i.LogID });

            modelBuilder.Entity<UpdateRadiologyResultsModel>()
                .HasKey(i => new { i.PatientID, i.ClinicID,i.RadioID });


            modelBuilder.Entity<DrugGroupModel>()
                .HasKey(i => new { i.GroupTypeName, i.GroupTypeID });

            modelBuilder.Entity<DrugStockModel>()
                .HasKey(i => new { i.IDNumber, i.DrugID });

            modelBuilder.Entity<InpatientAdmissionModel>()
                 .HasKey(i => new { i.PatientID, i.CaseID });

            modelBuilder.Entity<HospitalBedMasterModel>()
                .HasKey(i => new { i.BedID });

            modelBuilder.Entity<NurseStationMasterModel>()
                .HasKey(i => new { i.NurseStationID });

            modelBuilder.Entity<IPTypeMasterModel>()
                .HasKey(i => new { i.IPTypeID });

            modelBuilder.Entity<RoomTypeMasterModel>()
                .HasKey(i => new { i.RoomTypeID });

            modelBuilder.Entity<StaffAttendanceModel>()
                .HasKey(i => new { i.StaffID });

            modelBuilder.Entity<RollAccessModel>()
                .HasKey(i => new { i.RollID });

            modelBuilder.Entity<ScreenMasterModel>()
                .HasKey(i => new { i.ScreenId });


            modelBuilder.Entity<PatientObjectiveModel>()
       .Property(i => i.lastUpdatedDate)
       .ValueGeneratedOnUpdate()
       .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }

        internal async Task FindAsync(string strPatientId, string strCaseId)
        {
            throw new NotImplementedException();
        }

        public DbSet<HealthCare.Models.OtSurgeryModel> OtSurgeryModel { get; set; } = default!;


    }
    
}
