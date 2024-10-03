using Microsoft.EntityFrameworkCore;
using HealthCare.Models;
using HealthCare.Business;
using ClassLibrary1;

namespace HealthCare.Context

{
    public class HealthcareContext : DbContext
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public HealthcareContext() { }

        public HealthcareContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

     

        
        public DbSet<ClinicAdminModel> SHclnClinicAdmin { get; set; }

        public DbSet<BloodGroupModel> SHclnBloodGroup { get; set; }

        public DbSet<StaffAdminModel> SHclnStaffAdminModel {  get; set; }


        public DbSet<PatientRegistrationModel> SHPatientRegistration { get; set; }


        public DbSet<RollTypeMaster> Shclnrolltypemaster { get; set; }

        public DbSet<RollAccessMaster> ShclnrollAccessmaster { get; set; }

        public DbSet<ScreenNameMasterModel> shdbscreenname { get; set; }

        public DbSet<WebErrorsModel> SHWebErrors { get; set; }

        public DbSet<LogsModel> SHLogs { get; set; }

        public DbSet<DrugCategoryModel> SHstkDrugCategory { get; set; }

        public DbSet<DrugInventoryModel> SHstkDrugInventory { get; set; }


        public DbSet<DrugTypeModel> SHstkDrugType { get; set; }

        public DbSet<DrugStockModel> SHstkDrugStock { get; set; }

        public DbSet<DrugRackModel> SHstkDrugRack { get; set; }

        public DbSet<DrugGroupModel> SHstkDrugGroup { get; set; }

        public DbSet<PatientEPrescriptionModel> SHprsPrescription { get; set; }

        public DbSet<RollAccessModel> SHClnRollAccess { get; set; }


        public DbSet<GenericReportsModel> SHRepGenericReports { get; set; }

        public DbSet<ResourceTypeMasterModel> SHclnResourseTypeMaster { get; set; }

        public DbSet<WebLogsModel> SHWebLogs { get; set; }


        //Not using Tables

          public DbSet<PatientObjectiveModel> SHExmPatientObjective { get; set; }

         public DbSet<PatientScheduleModel> SHPatientSchedule { get; set; }



         public DbSet<PatientExaminationModel> SHExmPatientExamination { get; set; }

         public DbSet<PatExmSymptomsSeverity> SHExmSeverity { get; set; }

        // public DbSet<PatientVisitIntoDocumentModel>SHExmPatientDocument { get; set; }

         public DbSet<PatientFHPHModel>SHExmPatientFHPH { get; set; }

         public DbSet<PatientFHPHMasterModel> PatExmFHPH {  get; set; }


         public DbSet<RadiologyMasterModel> SHRadioMaster { get; set; }
         public DbSet<PatientInfoDocumentModel> SHExmInfoDocument { get; set; }



          public DbSet<PatientTestModel> SHPatientTest { get; set; }

          public DbSet<TestMasterModel> SHTestMaster { get; set; }
  


         public DbSet<SeverityModel> SHSeverityModel { get; set; }


          public DbSet<UpdateRadiologyResultsModel> SHUpdateRadiologyResult {  get; set; }



         public DbSet<PatientRadiolodyModel> SHPatientRadiology { get; set; }   
 




        public DbSet<PatientEPrescriptionPrintModel>SHprsPrescriptionPrint { get; set; }

        public DbSet<OTSchedulingModel>SHotScheduling { get; set; }
        public DbSet<OTNotesModel>SHotNotes { get; set; }
        public DbSet<OtTableMasterModel>SHotTableMaster { get; set; }
        public DbSet<ClinicSurgeryMasterModel>SHclnSurgeryMaster { get; set; }
        public DbSet<SurgeryTypeMasterModel>SHotSurgerTypeymaster { get; set; }

        public DbSet<InternalDepartmentMasterModel>SHotInternalDepartmentMaster { get; set; }

     


        public DbSet<InpatientAdmissionModel> SHInpatientAdmission { get; set; }

        public DbSet<InpatientDischargeModel> SHInpatientDischarge { get; set; }

        public DbSet<StaffFacilityMappingModel> SHclnStaffFacilityMapping { get; set; }

        public DbSet<HospitalBedMasterModel> SHclnHospitalBedMaster { get; set; }



        public DbSet<NurseStationMasterModel> SHclnNurseStationMaster { get; set; }

        public DbSet<IPTypeMasterModel> SHclnIPTypeMaster { get; set; }

        public DbSet<RoomTypeMasterModel> SHclnRoomTypeMaster { get; set; }

        public DbSet<StaffAttendanceModel> SHStaffAttendance { get; set; }




         public DbSet<ScreenMasterModel>SHClnScreenMaster { get; set; }

         public DbSet<HospitalRegistrationModel>SHHospitalRegistration { get; set; }

         public DbSet<HospitalFacilityMappingModel>SHHospitalFacilityMapping { get; set; }

         public DbSet<DiagnosisMasterModel>SHclnDiagnosisMaster { get; set; }

         public DbSet<ProcedureCodeMasterModel> SHclnProcedureCodeMaster { get; set; }





         public DbSet<OpCheckingModel> SHfdOpCheckingModel { get; set; }

         public DbSet<EWSMasterModel>SHclnEWSMaster { get; set; }

         public DbSet<PatientDiagnosisModel>SHEXMdiagnosis { get; set; }

         public DbSet<PatientProcedureModel>SHEXMprocedure { get; set; }


        //InPatient

         public DbSet<InPatientCaseSheetModel> SHipmInPatientCaseSheet { get; set; }

         public DbSet<InPatientDocVisitModel> SHipmInPatientDocVisit { get; set; }


         public DbSet<InPatientTransferUpdateModel> SHipmInPatientTransferUpdate { get; set; }

         public DbSet<InpatientObservationModel> SHipmInpatientobservation {  get; set; }

         public DbSet<OTSummaryMasterModel>SHclnOtSummaryMaster { get; set; }

         public DbSet<OTSummaryModel>SHOTsummary { get; set; }

         public DbSet<DoctorScheduleModel>SHclnResourceSchedule { get; set; }    

         public DbSet<ResourceScheduleModel> SHclnViewResourceSchedule { get; set; }
 


           public DbSet<PatientBillModel> SHPatientBill { get; set; }

           public DbSet<PatientBillDetailsModel> SHPatientBillDetails { get; set; }

           public DbSet<PatientPaymentModel> SHPatientPayment { get; set; }

           public DbSet<PatientPaymentBillDetailsModel> SHPatientPaymentBillDetails { get; set; }

           public DbSet<PayrollModel>SHpayroll { get; set; }

           public DbSet<LeaveTypeMaster>SHLeaveTypeMaster { get; set; }

           public DbSet<StaffLeaveModel>SHStaffLeave { get; set; }

           public DbSet<EmployeeHierarchymaster> SHEmpHierarchy {  get; set; }


           public DbSet<TaxModel> SHTaxModel { get; set; }

           public DbSet<StaffBankDetailsModel> SHBankdetails { get; set; }

           public DbSet<PayrollTaxModel>SHpayrollTax { get; set; }

          /* public DbSet<ProductMatserModel> SHProductMaster { get; set; }

           public DbSet<CategoryMasterModel> SHCategoryMaster { get; set; }

           public DbSet<BilingSysytemModel> SHCustomerBilling { get; set; }

           public DbSet<CustomerMasterModel> SHCustomerMaster { get; set; }

           public DbSet<DiscountCategoryMasterModel> SHDiscountCategory {  get; set; }

           public DbSet<GSTMasterModel> SHGSTMaster { get; set; }

           public DbSet<VoucherCustomerDetailModel> SHVoucherDetails { get; set; }

           public DbSet<GodownModel> SHGodown { get; set; }

           public DbSet<NetDicsountMasterModel> SHNetDiscountMaster { get; set; }

           public DbSet<VoucherMasterModel> SHVoucherMaster { get; set; }

           public DbSet<RackPatrionProductModel> SHRackPartionProduct { get; set; }

           public DbSet<RackMasterModel> SHRackMaster { get; set; }

           public DbSet<PointsReedemDetailsModel>  SHPointsReedemDetails { get; set; }

           public DbSet<PointsMasterModel>  SHPointsMaster { get; set; }
   
*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-L8EIGER\\SQLEXPRESS;Initial Catalog=StellarHealthcare;Integrated Security=True;Trust Server Certificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //ForeignKey for DoctorShcedule
            // modelBuilder.Entity<DoctorScheduleModel>()
            //.HasOne(d => d.SlotsID)
            //.WithMany()
            //.HasForeignKey(d => d.Viewslot,);

            modelBuilder.Entity<RollTypeMaster>().HasKey(i => new { i.RollID,i.FacilityID });
            modelBuilder.Entity<RollAccessMaster>().HasKey(i => new { i.StaffID, i.RollID,i.FacilityID });
            modelBuilder.Entity<ScreenNameMasterModel>().HasKey(i => new { i.ScreenName });

            modelBuilder.Entity<PatientEPrescriptionModel>().HasKey(i => new { i.PatientID, i.CaseVisitID, i.DrugID, i.FacilityID });

          //  modelBuilder.Entity<PatientEPrescriptionModel>().Property(p => p.EpressID).ValueGeneratedOnAdd();

            modelBuilder.Entity<DrugRackModel>().HasKey(i => new { i.RackID, i.RackName });

            modelBuilder.Entity<DrugTypeModel>().HasKey(i => new { i.TypeID, i.FacilityID });

            modelBuilder.Entity<DrugCategoryModel>().HasKey(i => new { i.CategoryID, i.FacilityID });

            modelBuilder.Entity<DrugInventoryModel>().Property(i => i.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<DrugInventoryModel>().HasKey(i => new { i.Id, i.FacilityID });

            modelBuilder.Entity<WebLogsModel>().HasKey(i => new { i.Id });


            modelBuilder.Entity<ClinicAdminModel>()
     .HasKey(i => new { i.FacilityID });

            modelBuilder.Entity<BloodGroupModel>()
                .HasKey(i => new { i.IntBg_Id, i.FacilityID });

            modelBuilder.Entity<StaffAdminModel>()
                .HasKey(i => new { i.StrStaffID, i.FacilityID });


            modelBuilder.Entity<PatientRegistrationModel>()
      .Property(i => i.Id)
      .ValueGeneratedOnAdd();
            modelBuilder.Entity<PatientRegistrationModel>().HasKey(i => new { i.Id, i.FacilityID });

            modelBuilder.Entity<WebErrorsModel>()
      .HasKey(i => new { i.ErrodDesc, i.ErrDateTime, i.ScreenName });

            modelBuilder.Entity<LogsModel>()
        .HasKey(i => new { i.LogID });

            modelBuilder.Entity<DrugGroupModel>()
               .HasKey(i => new { i.GroupTypeName, i.GroupTypeID, i.FacilityID });

            modelBuilder.Entity<DrugStockModel>()
                .HasKey(i => new { i.IDNumber, i.DrugID, i.FacilityID });

            modelBuilder.Entity<ResourceTypeMasterModel>()
               .HasKey(i => new { i.ResourceTypeID, i.FacilityID });

            modelBuilder.Entity<GenericReportsModel>()
                .HasKey(i => new { i.ReportId });

            modelBuilder.Entity<RollAccessModel>()
              .HasKey(i => new { i.RollID, i.ScreenID, i.FacilityID });





             modelBuilder.Entity<PayrollModel>().HasKey(i => new {i.StaffID,i.PayrollID});
             modelBuilder.Entity<StaffLeaveModel>().HasKey(i => new { i.LeaveID, i.StaffID,i.LeaveType });
             modelBuilder.Entity<LeaveTypeMaster>().HasKey(i => new {i.StaffID,i.LeaveType});
             modelBuilder.Entity<EmployeeHierarchymaster>().HasKey(i => new {i.EmpStaffID,i.MgrStaffID});
             modelBuilder.Entity<TaxModel>().HasKey(i => new {i.TaxID,i.TaxType});
             modelBuilder.Entity<StaffBankDetailsModel>().HasKey(i => new {i.StaffID,i.AccountNumber});
             modelBuilder.Entity<PayrollTaxModel>().HasKey(i => new {i.PayrollID,i.TaxSlotID,i.StaffID});


             modelBuilder.Entity<PatientBillModel>().HasKey(i => new { i.BillID, i.CaseVisitID, i.PatientID });
             modelBuilder.Entity<PatientBillDetailsModel>().HasKey(i => new { i.BillID, i.DetailID });

           /*  modelBuilder.Entity<CategoryMasterModel>().HasKey(i => new { i.CategoryID });

             modelBuilder.Entity<ProductMatserModel>().HasKey(i => new { i.ProductID });

             modelBuilder.Entity<CustomerMasterModel>().HasKey(i => new { i.CustomerID });

             modelBuilder.Entity<DiscountCategoryMasterModel>().HasKey(i => new { i.DiscountPrice });

             modelBuilder.Entity<GSTMasterModel>().HasKey(i => new { i.TaxID});

             modelBuilder.Entity<VoucherCustomerDetailModel>().HasKey(i => new { i.VoucherID});

             modelBuilder.Entity<BilingSysytemModel>().HasKey(i => new { i.BillID});

             modelBuilder.Entity<GodownModel>().HasKey(i => new { i.ProductID });

             modelBuilder.Entity<NetDicsountMasterModel>().HasKey(i => new { i.NetDiscountID });

             modelBuilder.Entity<VoucherMasterModel>().HasKey(i => new { i.VoucherID });

             modelBuilder.Entity<RackPatrionProductModel>().HasKey(i => new { i.PartitionID });

             modelBuilder.Entity<RackMasterModel>().HasKey(i => new { i.PartitionID, i.RackID });

             modelBuilder.Entity<PointsReedemDetailsModel>().HasKey(i => new { i.CustomerID });

             modelBuilder.Entity<PointsMasterModel>().HasKey(i => new { i.PointsID}); 
*/

             modelBuilder.Entity<PatientPaymentModel>().HasKey(i => new { i.PaymentID, i.PatientID, i.CaseVisitID });

             modelBuilder.Entity<PatientPaymentBillDetailsModel>().HasKey(i => new { i.PaymentID, i.PaymentDetailID });

             modelBuilder.Entity<ResourceScheduleModel>().HasKey(i => new { i.StaffID, i.FacilityID,i.Viewslot });

             modelBuilder.Entity<OTSummaryModel>().HasKey(i => new { i.OtscheduleID , i.QuestionID});
             modelBuilder.Entity<OTSummaryMasterModel>().HasKey(i => new { i.QuestionID });

             modelBuilder.Entity<InPatientTransferUpdateModel>().HasKey(i => new { i.PatientId, i.CaseId, i.BedId,i.TranferID });

             modelBuilder.Entity<PatientProcedureModel>().HasKey(i => new { i.PatientID, i.VisitID, i.ExamID,i.ProcedureID });
             modelBuilder.Entity<PatientDiagnosisModel>().HasKey(i => new { i.PatientID, i.VisitID, i.ExamID,i.DiagnosisID });
             modelBuilder.Entity<InpatientObservationModel>().HasKey(i => new { i.PatientID, i.ObservationID, i.BedNoID,i.ObservationTypeID });
             modelBuilder.Entity<EWSMasterModel>().HasKey(i => new { i.ObservationTypeID });

             modelBuilder.Entity<InPatientCaseSheetModel>().HasKey(i => new { i.StrPatientId,i.StrCaseId });

             modelBuilder.Entity<InPatientDocVisitModel>().HasKey(i => new { i.PatientId,i.CaseId,i.VisitID});
             modelBuilder.Entity<OpCheckingModel>().HasKey(i => new { i.PatientId });
 


            
                        modelBuilder.Entity<PatientEPrescriptionPrintModel>().HasKey(i => new { i.PatientID, i.CaseVisitID, i.OrderID });
            


              modelBuilder.Entity<PatientFHPHMasterModel>().HasKey(i => new { i.QuestionID });

              modelBuilder.Entity<TestMasterModel>().HasKey(i => new { i.TestID });


              modelBuilder.Entity<SeverityModel>().HasKey(i => new { i.SeverityID });

  



             modelBuilder.Entity<PatientTestModel>().HasKey(i => new { i.PatientID,i.FacilityID,i.TestID });
             modelBuilder.Entity<PatientTestModel>().HasKey(i => new { i.PatientID,i.FacilityID,i.TestID ,i.TestDateTime});

             modelBuilder.Entity<OTSchedulingModel>().HasKey(i => new { i.OtScheduleID });
             modelBuilder.Entity<OTNotesModel>().HasKey(i => new { i.OtScheduleID });
             modelBuilder.Entity<ClinicSurgeryMasterModel>().HasKey(i => new { i.SurgeryID });
             modelBuilder.Entity<OtTableMasterModel>().HasKey(i => new { i.TableID });
             modelBuilder.Entity<SurgeryTypeMasterModel>().HasKey(i => new { i.SurgeryTypeID });
             modelBuilder.Entity<InternalDepartmentMasterModel>().HasKey(i => new { i.DepartmentID,i.FacilityID });
             modelBuilder.Entity<OtSurgeryModel>().HasKey(i => new { i.OtScheduleID,i.SurgeryID });

             modelBuilder.Entity<DoctorScheduleModel>().HasKey(i => new { i.StaffID, i.FacilityID, i.SlotsID,i.Viewslot });



            // Configure primary key for Login
              modelBuilder.Entity<PatientObjectiveModel>()
          .HasKey(i => new { i.PatientID, i.FacilityID, i.VisitID });
  



             modelBuilder.Entity<PatientScheduleModel>()
                  .HasKey(i => new { i.PatientID });

              modelBuilder.Entity<PatientExaminationModel>()
          .HasKey(i => new { i.PatientID, i.FacilityID, i.VisitID, i.ExaminationID });

              modelBuilder.Entity<PatExmSymptomsSeverity>()
          .HasKey(i => new { i.PatientID, i.FacilityID, i.VisitID, i.ExaminationID, i.Symptoms });



              modelBuilder.Entity<PatientFHPHModel>()
          .HasKey(i => new { i.PatientID, i.QuestionID, i.Type });

              modelBuilder.Entity<PatientRadiolodyModel>()
                   .HasKey(i => new { i.RadioID , i.FacilityID , i.PatientID , i.ScreeningDate });

              modelBuilder.Entity<RadiologyMasterModel>()
                  .HasKey(i => new { i.RadioID });

              modelBuilder.Entity<PatientInfoDocumentModel>()
         .HasKey(i => new { i.PatientID, i.FacilityID, i.VisitID });


            
                        modelBuilder.Entity<UpdateRadiologyResultsModel>()
                            .HasKey(i => new { i.PatientID, i.FacilityID,i.RadioID,i.ImageID });
            



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
                  .HasKey(i => new { i.StaffID,i.Date,i.AttendanceID });



              modelBuilder.Entity<ScreenMasterModel>()
                  .HasKey(i => new { i.ScreenId });

              modelBuilder.Entity<ScreenMasterModel>()
                .ToTable(tb => tb.HasTrigger("dbo.Trigger_shclnscreenmaster"));

              modelBuilder.Entity<HospitalRegistrationModel>()
                  .HasKey(i => new { i.HospitalID });

              modelBuilder.Entity<HospitalFacilityMappingModel>()
                  .HasKey(i => new { i.HospitalID, i.FacilityID });

              modelBuilder.Entity<DiagnosisMasterModel>()
                  .HasKey(i => new { i.DiagnosisID });

              modelBuilder.Entity<ProcedureCodeMasterModel>()
                  .HasKey(i => new { i.ProcedureID });

              modelBuilder.Entity<InpatientDischargeModel>()
                  .HasKey(i => new { i.PatientID, i.CaseID });

              modelBuilder.Entity<StaffFacilityMappingModel>()
                  .HasKey(i => new { i.StaffId, i.FacilityID });
  


            /* modelBuilder.Entity<PatientObjectiveModel>()
        .Property(i => i.lastUpdatedDate)
        .ValueGeneratedOnUpdate()
        .HasDefaultValueSql("CURRENT_TIMESTAMP");*/

        }

        internal async Task FindAsync(string strPatientId, string strCaseId)
        {
            throw new NotImplementedException();
        }

        public DbSet<HealthCare.Models.OtSurgeryModel> OtSurgeryModel { get; set; } = default!;







        // Override SaveChangesAsync to auto-generate the Ids for various screens with the prefix
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            var facility = _httpContextAccessor.HttpContext?.Session.GetString("FacilityID");
            

            //Product Master
            var patMas = ChangeTracker
                        .Entries<PatientRegistrationModel>()
                        .Where(e => e.State == EntityState.Added)
                        .ToList();

            if (patMas.Any())
            {
                // Get the latest BillNumber from the database
                var lastProd = await this.SHPatientRegistration.Where(x => x.FacilityID == facility).OrderByDescending(b => b.Id).FirstOrDefaultAsync();
                int lastProdNumber = 100; // Starting point, e.g., Bill_100

                if (lastProd != null)
                {
                    // Extract the numeric part of the last BillNumber and increment it
                    string lastProdNum = lastProd.PatientID.Replace("Pat_", "");
                    if (int.TryParse(lastProdNum, out int number))
                    {
                        lastProdNumber = number;
                    }
                }

                // Assign the new BillNumber for each new bill
                foreach (var billEntry in patMas)
                {
                    lastProdNumber++;
                    billEntry.Entity.PatientID = $"Pat_{lastProdNumber}";
                }
            }




            //Drug Master
            var drugtMas = ChangeTracker
                        .Entries<DrugInventoryModel>()
                        .Where(e => e.State == EntityState.Added)
                        .ToList();

            if (drugtMas.Any())
            {
                // Get the latest BillNumber from the database
                var lastdrug = await this.SHstkDrugInventory.Where(x => x.FacilityID == facility).OrderByDescending(b => b.Id).FirstOrDefaultAsync();
                int lastdrugNumber = 100; // Starting point, e.g., Bill_100

                if (lastdrug != null)
                {
                    // Extract the numeric part of the last BillNumber and increment it
                    string lastdrugNum = lastdrug.DrugId.Replace("Drug_", "");
                    if (int.TryParse(lastdrugNum, out int number))
                    {
                        lastdrugNumber = number;
                    }
                }

                // Assign the new BillNumber for each new bill
                foreach (var billEntry in drugtMas)
                {
                    lastdrugNumber++;
                    billEntry.Entity.DrugId = $"Drug_{lastdrugNumber}";
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }


    }

    }
