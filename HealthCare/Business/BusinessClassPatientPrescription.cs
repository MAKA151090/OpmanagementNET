using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Business
{
    public class BusinessClassPatientPrescription : Controller
    {

        private HealthcareContext _healthcareContext;

        public BusinessClassPatientPrescription(HealthcareContext healthcareContext)
        {
            _healthcareContext = healthcareContext;
        }

        public async Task<List<PatientEPrescriptionPrintModel>> GetPrescriptionPrint(string patientID, string casevisitID, string orderID)
        {
            var prescription = await (
                    from pp in _healthcareContext.SHprsPrescription
                    join di in _healthcareContext.SHstkDrugInventory on pp.DrugID equals di.DrugId
                    join p in _healthcareContext.SHPatientRegistration on pp.PatientID equals p.PatientID
                    join d in _healthcareContext.SHclnStaffAdminModel on pp.DoctorID equals d.StrStaffID
                    where pp.PatientID == patientID && pp.CaseVisitID == casevisitID && pp.OrderID == orderID
                    select new PatientEPrescriptionPrintModel
                    {
                        PatientID = pp.PatientID,
                        CaseVisitID = pp.CaseVisitID,
                        OrderID = pp.OrderID,
                        PatientName = p.FullName,
                        MedicactionName = di.ModelName,
                        Unit = pp.Unit,
                        UnitCategory = pp.UnitCategory,
                        Frequency = pp.Frequency,
                        FrequencyUnit = pp.FrequencyUnit,
                        Duration = pp.Duration,
                        Quantity = pp.Quantity,
                        EndDate = pp.EndDate,
                        Instructions = pp.Instructions,
                        DoctorName = d.StrFullName

                    }).ToListAsync();
            return prescription;

        }



        public List<PrescriptionTableModel> GetPrescription(string  patientID,string casevisitID,string orderID,string drugID)
        {
            var result = (from p in _healthcareContext.SHprsPrescription
                          join d in _healthcareContext.SHstkDrugInventory on p.DrugID equals d.DrugId
                          where p.PatientID == patientID && p.CaseVisitID == casevisitID &&p.OrderID==orderID&&p.DrugID==drugID
                          select new PrescriptionTableModel
                          {
                              PatientID = p.PatientID,
                              CaseVisitID = p.CaseVisitID,
                              OrderID = p.OrderID,
                              DrugID = p.DrugID,
                              DrugName = d.ModelName,
                              Frequency = p.Frequency,
                              Duration = p.Duration,
                              Dosage = d.Dosage,
                              Unit = p.Unit
                          }).ToList();
            return result;
        }

       /* public async Task<PrescriptionTableModel> GetViewPrescription(string patientID, string casevisitID, string orderID, string drugID)
        {
            PrescriptionTableModel prescriptionView = new PrescriptionTableModel();

            prescriptionView.Viewprescription = GetPrescription(patientID, casevisitID, orderID, drugID);

            var result = await (from p in _healthcareContext.SHprsPrescription
                                join d in _healthcareContext.SHstkDrugInventory on p.DrugID equals d.DrugId
                                select new PrescriptionTableModel
                                {
                                     PatientID = p.PatientID,
                                     CaseVisitID=p.CaseVisitID,
                                     OrderID=p.OrderID,
                                     DrugID = d.DrugId,
                                     DrugName=d.ModelName,
                                     Dosage=d.Dosage,
                                     PrescriptionDate=p.PrescriptionDate,
                                     Unit=p.Unit,
                                     UnitCategory=p.UnitCategory,
                                     Frequency=p.Frequency,
                                     FrequencyUnit=p.FrequencyUnit,
                                     Duration=p.Duration,
                                     Quantity=p.Quantity,
                                     EndDate=p.EndDate,
                                     RouteAdmin=p.RouteAdmin,
                                     Instructions=p.Instructions,
                                     Comments=p.Comments,
                                     FillDate=p.FillDate,
                                     Result=p.Result
                                }).FirstOrDefaultAsync();

            prescriptionView.PatientID =
                result.PatientID;
            prescriptionView.CaseVisitID = result.CaseVisitID;
            prescriptionView.OrderID = result.OrderID;
            prescriptionView.DrugID = result.DrugID;
            prescriptionView.DrugName = result.DrugName;
            prescriptionView.Dosage = result.Dosage;
            prescriptionView.PrescriptionDate = result.PrescriptionDate;
            prescriptionView.Unit = result.Unit;
            prescriptionView.UnitCategory = result.UnitCategory;
            prescriptionView.Frequency = result.Frequency;
            prescriptionView.FrequencyUnit = result.FrequencyUnit;
            prescriptionView.Duration = result.Duration;
            prescriptionView.Quantity = result.Quantity;
            prescriptionView.EndDate = result.EndDate;
            prescriptionView.RouteAdmin = result.RouteAdmin;
            prescriptionView.Instructions = result.Instructions;
            prescriptionView.Comments = result.Comments;
            prescriptionView.FillDate = result.FillDate;
            prescriptionView.Result = result.Result;


            return prescriptionView;


        }*/



        ///patiwnt e prescription.
        public List<PatientRegistrationModel> GetPatientId()
        {
            var patientid = (
                    from pr in _healthcareContext.SHPatientRegistration
                    select new PatientRegistrationModel
                    {
                        PatientID = pr.PatientID,
                        FullName = pr.FullName
                    }
                ).ToList();

            return patientid;
        }

        public List<DrugInventoryModel> GetDrugid()
        {
            var drugid = (
                    from pr in _healthcareContext.SHstkDrugInventory
                    select new DrugInventoryModel
                    {
                        DrugId = pr.DrugId,
                        ModelName = pr.ModelName,

                    }
                ).ToList();

            return drugid;
        }

        public List<StaffAdminModel> Getdocid()
        {
            var docid = (
                    from pr in _healthcareContext.SHclnStaffAdminModel
                    join p in _healthcareContext.SHclnResourseTypeMaster on pr.ResourceTypeID equals p.ResourceTypeID
                    where p.ResourceTypeName == "Doctor"
                    select new StaffAdminModel
                    {
                        StrStaffID = pr.StrStaffID,
                        StrFullName = pr.StrFullName
                    }
                    ).ToList();

            return docid;
        }


    }
}
