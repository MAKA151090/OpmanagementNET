using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NonFactors.Mvc.Grid;
using System.Data;
using Xceed.Document.NET;
using Xceed.Words.NET;
using Microsoft.AspNetCore.Authorization;
using DocumentFormat.OpenXml.InkML;

namespace HealthCare.Business
{
    public class BusinessClassPatientPrescription
    {

        private readonly HealthcareContext _healthcareContext;

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



        public List<PrescriptionTableModel> GetPrescription(string  patientID,string casevisitID,string drugID,string facility)
        {
            var result = (from p in _healthcareContext.SHprsPrescription
                          join d in _healthcareContext.SHstkDrugInventory on p.DrugID equals d.DrugId
                          where p.PatientID == patientID && p.CaseVisitID == casevisitID &&p.IsDelete == false  && p.FacilityID == facility
                          select new PrescriptionTableModel
                          {
                              PatientID = p.PatientID,
                              CaseVisitID = p.CaseVisitID,
                              OrderID = p.OrderID,
                              DrugID = p.DrugID,
                              DrugName = d.ModelName,
                              Morningunit=p.Morningunit,
                              Afternoonunit=p.Afternoonunit,
                              Eveningunit=p.Eveningunit,
                              Nightunit=p.Nightunit,
                              RouteAdmin = p.RouteAdmin
                              
                             
                          }).ToList();
            return result;
        }


        public List<PrescriptionTableModel> GetPrescriptionTable(string patientID, string casevisitID, string facility)
        {
            var result = (from p in _healthcareContext.SHprsPrescription
                          join d in _healthcareContext.SHstkDrugInventory on p.DrugID equals d.DrugId
                          where p.PatientID == patientID && p.CaseVisitID == casevisitID && p.IsDelete == false && p.FacilityID == facility
                          select new PrescriptionTableModel
                          {
                              PatientID = p.PatientID,
                              CaseVisitID = p.CaseVisitID,
                              OrderID = p.OrderID,
                              DrugID = p.DrugID,
                              DrugName = d.ModelName,
                              Morningunit = p.Morningunit,
                              Afternoonunit = p.Afternoonunit,
                              Eveningunit = p.Eveningunit,
                              Nightunit = p.Nightunit,
                              RouteAdmin = p.RouteAdmin
                          }).ToList();
            return result;
        }


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

        public List<DrugInventoryModel> GetDrugid(string facilityId)
        {
            var drugid = (
                    from pr in _healthcareContext.SHstkDrugInventory
                    where pr.FacilityID == facilityId
                    select new DrugInventoryModel
                    {
                        DrugId = pr.DrugId,
                        ModelName = pr.ModelName,

                    }
                ).ToList();

            return drugid;
        }

        public List<PatientEPrescriptionModel> Getvisit(string facilityId)
        {
            var visitid = (
                    from pr in _healthcareContext.SHprsPrescription
                    where pr.FacilityID == facilityId
                    select new PatientEPrescriptionModel
                    {
                       CaseVisitID = pr.CaseVisitID,
                       PrescriptionDate = pr.PrescriptionDate,
                       
                    }
                ).ToList();

            return visitid;
        }




        public List<StaffAdminModel> Getdocid(string facilityId,string docidstaff)
        {
            var docid = (
                    from pr in _healthcareContext.SHclnStaffAdminModel
                    join p in _healthcareContext.SHclnResourseTypeMaster on pr.ResourceTypeID equals p.ResourceTypeID
                    where pr.FacilityID == facilityId && pr.StrStaffID == docidstaff
                    select new StaffAdminModel
                    {
                        StrStaffID = pr.StrStaffID
                    }
                    ).ToList();

            return docid;
        }

        //get doctor facility
        public List<StaffAdminModel> Getdocfacility(string facilityId)
        {
            var docfac = (
                    from pr in _healthcareContext.SHclnStaffAdminModel
                    join p in _healthcareContext.SHclnResourseTypeMaster on pr.ResourceTypeID equals p.ResourceTypeID
                    where p.ResourceTypeName == "Doctor" && pr.FacilityID == facilityId
                    select new StaffAdminModel
                    {
                       FacilityID = pr.FacilityID
                    }
                    ).ToList();

            return docfac;
        }




        public byte[] ModifyBillDoc(string pfilepath, DataTable pbillData)
        {
            // Path to your existing Word document
            string filePath = pfilepath;

            // Open the document
            using (var document = DocX.Load(filePath))
            {


                // Replace placeholders with dynamic data
                document.ReplaceText("<<facilityname>>", pbillData.Rows[0]["FacilityName"].ToString());
                document.ReplaceText("<<doctorname>>", pbillData.Rows[0]["DoctorName"].ToString());
                document.ReplaceText("<<suffix>>", pbillData.Rows[0]["Suffix"].ToString());
                document.ReplaceText("<<patientname>>", pbillData.Rows[0]["PatientName"].ToString());
                document.ReplaceText("<<age>>", pbillData.Rows[0]["Age"].ToString());
                document.ReplaceText("<<gender>>", pbillData.Rows[0]["Gender"].ToString());
                document.ReplaceText("<<date>>", pbillData.Rows[0]["Date"].ToString());
                document.ReplaceText("<<complaint>>", pbillData.Rows[0]["Complaint"].ToString());
                document.ReplaceText("<<procedure>>", pbillData.Rows[0]["Procedure"].ToString());
                document.ReplaceText("<<followupDate>>", pbillData.Rows[0]["FollowUpDate"].ToString());
                document.ReplaceText("<<facilityAddress>>", pbillData.Rows[0]["FacilityAddress"].ToString());


                //document.ReplaceText("{Placeholder2}", "Dynamic Value 2");

                // Insert a new paragraph
                //  document.InsertParagraph("This is a new paragraph added to the document.").FontSize(14).Bold();

                // Add a table
                var table = document.AddTable(pbillData.Rows.Count + 1, 9);
                table.Rows[0].Cells[0].Paragraphs[0].Append("MedicineName");
                table.Rows[0].Cells[1].Paragraphs[0].Append("Dosage");
                table.Rows[0].Cells[2].Paragraphs[0].Append("Morningunit");
                table.Rows[0].Cells[3].Paragraphs[0].Append("Afternoonunit");
                table.Rows[0].Cells[4].Paragraphs[0].Append("Eveningunit");
                table.Rows[0].Cells[5].Paragraphs[0].Append("Nightunit");
                table.Rows[0].Cells[6].Paragraphs[0].Append("When");
                table.Rows[0].Cells[7].Paragraphs[0].Append("Instruction");
                table.Rows[0].Cells[8].Paragraphs[0].Append("NoOfDays");


                int rowcount = 1;
                //Row data
                foreach (DataRow objRow in pbillData.Rows)
                {

                    table.Rows[rowcount].Cells[0].Paragraphs[0].Append(objRow["MedicineName"].ToString());
                    table.Rows[rowcount].Cells[1].Paragraphs[0].Append(objRow["Dosage"].ToString());
                    table.Rows[rowcount].Cells[2].Paragraphs[0].Append(objRow["Morningunit"].ToString());
                    table.Rows[rowcount].Cells[3].Paragraphs[0].Append(objRow["Afternoonunit"].ToString());
                    table.Rows[rowcount].Cells[4].Paragraphs[0].Append(objRow["Eveningunit"].ToString());
                    table.Rows[rowcount].Cells[5].Paragraphs[0].Append(objRow["Nightunit"].ToString());
                    table.Rows[rowcount].Cells[6].Paragraphs[0].Append(objRow["When"].ToString());
                    table.Rows[rowcount].Cells[7].Paragraphs[0].Append(objRow["Instruction"].ToString());
                    table.Rows[rowcount].Cells[8].Paragraphs[0].Append(objRow["NoOfDays"].ToString());

                    rowcount++;
                }

                string searchText = "<<drugdetails>>";
                Paragraph paragraph = document.Paragraphs.FirstOrDefault(p => p.Text.Contains(searchText));

                if (paragraph != null)
                {
                    paragraph.InsertTableAfterSelf(table);
                }

                document.ReplaceText("<<drugdetails>>", String.Empty);

                // Save the document to a MemoryStream
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    document.SaveAs(memoryStream);

                    // Convert the MemoryStream to a byte array
                    return memoryStream.ToArray();
                }

            }
            return null;
        }

        public byte[] PrintBillDetails(DataTable billDetails,string facility)
        {

            string templatePath = Path.Combine("..\\HealthCare\\Template", facility + ".docx");

            return ModifyBillDoc(templatePath, billDetails);
        }

    }
}
