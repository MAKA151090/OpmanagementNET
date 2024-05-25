using System;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Office.Interop.Word;
using System.Threading.Tasks;

namespace HealthCare.Business
{
    public class BusinessClassExamination
    {
        private readonly HealthcareContext objSearchContext;

        public BusinessClassExamination(HealthcareContext serviceContext)
        {
            objSearchContext = serviceContext;
        }

        public async Task<bool> SavePatientExaminationAndSeverity(PatientExaminationModel patientExamination, PatExmSymptomsSeverity severity)
        {

            patientExamination.lastUpdatedDate = DateTime.Now.ToString();
            patientExamination.lastUpdatedUser = "Myself";

            // Add patient examination
            objSearchContext.SHExmPatientExamination.Add(patientExamination);
            await objSearchContext.SaveChangesAsync();

            // Assign the patientExaminationId to severity and save severity
            severity.PatientID = patientExamination.PatientID;
            objSearchContext.SHExmSeverity.Add(severity);
            await objSearchContext.SaveChangesAsync();

            return true;
        }

        public byte[] GenerateDocument(string patientId, string visitId, string FacilityID)
        {
            // Retrieve data from database
            using (var dbContext = new HealthcareContext())
            {
                var patientObjective = dbContext.SHExmPatientObjective
                   .FirstOrDefault(p => p.PatientID == patientId && p.VisitID == visitId && p.FacilityID == FacilityID);

                if (patientObjective == null)
                {
                    throw new Exception("Patient information not found.");
                }
                var patientInfo = dbContext.SHPatientRegistration
                   .FirstOrDefault(p => p.PatientID == patientId && p.FacilityID == FacilityID);

                var patientFamilyHistory = dbContext.SHExmPatientFHPH
                    .FirstOrDefault(p => p.PatientID == patientId);



                var patientExamination = dbContext.SHExmPatientExamination
                    .FirstOrDefault(p => p.PatientID == patientId && p.VisitID == visitId && p.FacilityID == FacilityID);

                var patExmSymptomsSeverity = dbContext.SHExmSeverity
                    .FirstOrDefault(p => p.PatientID == patientId && p.VisitID == visitId && p.FacilityID == FacilityID);

                // Generate the populated document
                byte[] generatedDocument = PopulateWordTemplate(patientInfo,
                     patientObjective, patientFamilyHistory
                     , null, patientExamination, patExmSymptomsSeverity);

                return generatedDocument;
            }
        }
        private byte[] PopulateWordTemplate(PatientRegistrationModel patientRegistration,
             PatientObjectiveModel patientObjective,
            PatientFHPHModel patientFamilyHistory, PatientFHPHModel patientHealthHistory,
            PatientExaminationModel patientExamination, PatExmSymptomsSeverity patExmSymptomsSeverity)
        {
            // Load the existing template document
            byte[] templateBytes = File.ReadAllBytes("C:\\Users\\admin\\Downloads\\PatientChartTemplate.docx");

            using (MemoryStream mem = new MemoryStream()) 
            {
                mem.Write(templateBytes, 0, templateBytes.Length);

                using (WordprocessingDocument doc = WordprocessingDocument.Open(mem, true))
                {
                    // Access the main part of the document
                    MainDocumentPart mainPart = doc.MainDocumentPart;
                    if (mainPart == null)
                    {
                        throw new InvalidOperationException("Template document is invalid.");
                    }

                    // Replace placeholders with actual values
                    ReplacePlaceholder(mainPart, "Full Name", patientRegistration.FullName);
                    ReplacePlaceholder(mainPart, "Age", patientRegistration.Age.ToString());
                    ReplacePlaceholder(mainPart, "Gender", patientRegistration.Gender);
                    ReplacePlaceholder(mainPart, "Visit ID", patientObjective.VisitID);
                    ReplacePlaceholder(mainPart, "VisitDate", patientObjective.VisitDate.ToString());
                    ReplacePlaceholder(mainPart, "Main Complaint", patientObjective.CheifComplaint);
                    ReplacePlaceholder(mainPart, "Height", patientObjective.Height);
                    ReplacePlaceholder(mainPart, "Weight", patientObjective.Weight);
                    ReplacePlaceholder(mainPart, "BP", patientObjective.BloodPressure);
                    ReplacePlaceholder(mainPart, "Heart Rate", patientObjective.HeartRate);
                    ReplacePlaceholder(mainPart, "Temperature", patientObjective.Temperature);
                    ReplacePlaceholder(mainPart, "Respiratory Rate", patientObjective.ResptryRate);
                    ReplacePlaceholder(mainPart, "Oxygen Saturaion", patientObjective.OxySat);
                    ReplacePlaceholder(mainPart, "Pulse Rate", patientObjective.PulseRate);
                    ReplacePlaceholder(mainPart, "Blood Glucose Level", patientObjective.BldGluLvl);
                    ReplacePlaceholder(mainPart, "Complaints", patientExamination.Complaint);
                    ReplacePlaceholder(mainPart, "Diagnosis", patientExamination.Diagnosis);
                    ReplacePlaceholder(mainPart, "Prescription", patientExamination.Prescription);
                    ReplacePlaceholder(mainPart, "Followupdate", patientExamination.FollowUp);
                    // ReplacePlaceholder(mainPart, "<DoctorName>", patientExamination.DoctorName);
                    //ReplacePlaceholder(mainPart, "<Signature>", patientExamination.DoctorName);



                    // Save changes to the document
                    mainPart.Document.Save();
                }

                // Return the updated document as byte array
                return mem.ToArray();
            }
        }

        private void ReplacePlaceholder(MainDocumentPart mainPart, string placeholder, string value)
        {

            foreach (var textElement in mainPart.Document.Body.Descendants<Text>())
            {
                if (textElement.Text == placeholder)
                {
                    textElement.Text = value;
                }
            }


        }
        public List<PatientExamListModel> GetHistoryQuestions(String Type,string patientID,string QuestionID)
        {

            var addQus = objSearchContext.PatExmFHPH.Select(e => e).Where(e=>e.Type==Type).ToList();
            foreach (var item in addQus)
            {
                var objFHPH = (objSearchContext.SHExmPatientFHPH.FirstOrDefault(x =>
                x.PatientID == patientID && x.Type==Type &&x.QuestionID==QuestionID));

                if (objFHPH == null)
                {
                    var newFHPH = new PatientFHPHModel
                    {
                        QuestionID= item.QuestionID,
                        PatientID = patientID,
                        Type=Type
                       
                    };
                    objSearchContext.SHExmPatientFHPH.Add(newFHPH);
                    
                }

             
            }
            objSearchContext.SaveChanges();

            var patExmQuestion = (from q in objSearchContext.PatExmFHPH
                                  join a in objSearchContext.SHExmPatientFHPH
                  on q.QuestionID equals a.QuestionID 
                                  where q.Type == Type && a.PatientID==patientID
                                  select new PatientExamListModel{ Question = q.Question, QuestionID = q.QuestionID, Answer = a.Answer }).ToList();



            return patExmQuestion;

        }
        public List<OTSummaryModel> GetOtSummaryview(string potScheduleID, string answer)
        {


            var objnew = (objSearchContext.SHOTsummary.Where(x =>
                x.OtscheduleID == potScheduleID).Count());

            if (objnew <= 0)
            {
                var addSumm = objSearchContext.SHclnOtSummaryMaster.Select(e => e).ToList();

                foreach (var item in addSumm)
                {
                    var newObservation = new OTSummaryModel
                    {
                        QuestionID = item.QuestionID,
                        Question = item.Question,
                        Answer = answer,
                        OtscheduleID = potScheduleID
                    };
                    objSearchContext.SHOTsummary.Add(newObservation);

                }
                objSearchContext.SaveChanges();
            }

            var result = (
           from e in objSearchContext.SHclnOtSummaryMaster
           join o in objSearchContext.SHOTsummary
               on e.QuestionID equals o.QuestionID into otGroup
           from o in otGroup.DefaultIfEmpty()
           where (o.OtscheduleID == potScheduleID)
           select new OTSummaryModel
           {
               Question = e.Question,
               QuestionID=e.QuestionID,
               Answer = o != null ? o.Answer : string.Empty,

           }).ToList();

            return result;
        }

       


        public async Task<List<PatExamSearchModel>> GetPatientObjectiveData(string patientID, string visitID, string FacilityID, string patientName, string visitDate, string clinicName)
        {
            var patExamSearch = (from r in objSearchContext.SHPatientRegistration
                                 join e in objSearchContext.SHExmPatientObjective
                                 on r.PatientID equals e.PatientID into PatReg
                                 from re in PatReg.DefaultIfEmpty()
                                 join c in objSearchContext.SHclnClinicAdmin
                                 on re.FacilityID equals c.FacilityID into PatClinc
                                 from rec in PatClinc.DefaultIfEmpty()
                                 where (r.PatientID == patientID || r.FullName == patientName) ||
                                                      (re.VisitID == visitID || re.VisitDate == visitDate || re.VisitID == null) ||
                                                      (re.FacilityID == FacilityID || rec.ClinicName == clinicName || re.FacilityID == null)
                                 select new PatExamSearchModel
                                 {

                                     PatientID = r.PatientID,

                                     FullName = r.FullName,

                                     VisitID = re != null ? re.VisitID : null,

                                     VisitDate = re != null ? re.VisitDate : null,

                                     FacilityID = rec != null ? rec.FacilityID : null,

                                     ClinicName = rec != null ? rec.ClinicName : null,



                                 }).ToListAsync().Result;

            return patExamSearch;



        }

        public int GetNextVisitIdForPatient(String patientId)
        {

            var existingIds = objSearchContext.SHExmPatientObjective
                .Where(v => v.PatientID == patientId && !string.IsNullOrEmpty(v.VisitID))
                .Select(v => v.VisitID)
                .ToList();



            if (existingIds.Count == 0)
            {
                return 1;
            }
            else
            {


                List<int> idIntegers = existingIds.Select(int.Parse).ToList();
                int maxId = idIntegers.Max();
                return maxId + 1;
            }
        }
        public async Task<PatientObjectiveModel> GetPatientObjectiveSubmit(string patientID, string visitID, string FacilityID)
        {
            String strNewCliniid = FacilityID;

            if (string.IsNullOrEmpty(visitID))
            {
                // Generate the next visit ID for the patient
                visitID = GetNextVisitIdForPatient(patientID).ToString();

                strNewCliniid = await objSearchContext.SHclnClinicAdmin
            .Where(x => x.ClinicName == "Stellar")
            .Select(x => x.FacilityID)
            .FirstOrDefaultAsync();

                var newPatientObjective = new PatientObjectiveModel
                {
                    PatientID = patientID,
                    FacilityID = strNewCliniid,
                    VisitID = visitID,

                };


                objSearchContext.SHExmPatientObjective.Add(newPatientObjective);

                await objSearchContext.SaveChangesAsync();
            }



            var patientObjectiveDataSubmit = await objSearchContext.SHExmPatientObjective.FirstOrDefaultAsync(x =>
                x.PatientID == patientID && x.VisitID == visitID && x.FacilityID == strNewCliniid);

            return patientObjectiveDataSubmit;

        }

        public async Task<List<PatientViewResultModel>> GetTestResults(string patientId, string FacilityID)
        {
            var testResults = await (
                from pt in objSearchContext.SHPatientTest
                join tm in objSearchContext.SHTestMaster on pt.TestID equals tm.TestID
                join ca in objSearchContext.SHclnStaffAdminModel on pt.ReferDocID equals ca.StrStaffID
                join p in objSearchContext.SHPatientRegistration on pt.PatientID equals p.PatientID
                join c in objSearchContext.SHclnClinicAdmin on pt.FacilityID equals c.FacilityID
                where pt.PatientID == patientId && pt.FacilityID == FacilityID
                select new PatientViewResultModel
                {
                    TestID = pt.TestID,
                    TestName = tm.TestName,
                    Range = tm.Range,
                    TestDate = pt.TestDateTime,
                    Result = pt.TestResult,
                    DoctorName = ca.StrFullName,
                    PatientName = p.FullName,
                    ClinicName = c.ClinicName

                }).ToListAsync();

            return testResults;

        }

      

        public async Task<OTConfirmationModel> GetOTConfirmation(string potScheduleID)
        {
            OTConfirmationModel oTConfirmation = new OTConfirmationModel();

            oTConfirmation.OtviewModel = GetOtViewdata(potScheduleID);

            var result = await (from ot in objSearchContext.SHotScheduling
                          join t in objSearchContext.SHotTableMaster on ot.TableID equals t.TableID
                          select new OTConfirmationModel
                          {
                              OtScheduleID = ot.OtScheduleID,
                              TableName = t.TableName,
                              TeamName = ot.TeamName,
                              Date=ot.StartDate,
                              Duration=ot.Duration,
                              RoomName=t.RoomName,
                              ConfirmDate=ot.ConfirmDate,
                              ConfirmBy=ot.ConfirmBy
                              

                          }).FirstOrDefaultAsync();

            oTConfirmation.OtScheduleID = 
                result.OtScheduleID;
            oTConfirmation.TableName=result.TableName;
            oTConfirmation.TeamName = result.TeamName;
            oTConfirmation.Date=result.Date;
            oTConfirmation.Duration=result.Duration;
            oTConfirmation.RoomName=result.RoomName;
            oTConfirmation.ConfirmDate=result.ConfirmDate;
            oTConfirmation.ConfirmBy=result.ConfirmBy;


            return oTConfirmation;


        }

        public List<OtConfirmViewModel> GetOtViewdata(string potscheduleID)
        {

            var result = (from ot in objSearchContext.SHotScheduling
                                 join sm in objSearchContext.OtSurgeryModel on ot.OtScheduleID equals sm.OtScheduleID
                                 join ots in objSearchContext.SHclnSurgeryMaster on sm.SurgeryID equals ots.SurgeryID
                               
                                join t in objSearchContext.SHotTableMaster on ot.TableID equals t.TableID
                                where ot.OtScheduleID == potscheduleID && ot.IsDeleted!=false && ot.Status!="Confirmed"
                                select new OtConfirmViewModel
                                {
                                    OtscheduleID = ot.OtScheduleID,
                                    SurgeryName = ots.SurgeryName,
                                    TeamName = ot.TeamName,
                                    Date = ot.StartDate,
                                    Duration = ot.Duration,
                                    TableName = ot.TeamName,
                                    RoomName = t.TableName,



                                }).ToList();
            return result;

        }

        public async Task<bool> UpdateOTConfirmation(string otScheduleID, string status)
        {
            
            var scheduling = await objSearchContext.SHotScheduling.FirstOrDefaultAsync(x => x.OtScheduleID == otScheduleID);

            if (scheduling != null)
            {
                if (status == "Confirmed")
                {
                    scheduling.Status = "Confirmed";
                    scheduling.IsDeleted = true;
                    
                }
                else if (status == "cancel")
                {
                    scheduling.Status = "cancel";
                    scheduling.IsDeleted = false;
                }

                await objSearchContext.SaveChangesAsync();
                
            }
            return true;
        }
    }
}
