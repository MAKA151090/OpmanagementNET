using System;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Office.Interop.Word;

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
   
    public byte[] GenerateDocument(string patientId, string visitId, string clinicId)
        {
            // Retrieve data from database
            using (var dbContext = new HealthcareContext())
            {
                var patientObjective = dbContext.SHExmPatientObjective
                   .FirstOrDefault(p => p.PatientID == patientId && p.VisitID == visitId && p.ClinicID == clinicId);

                if (patientObjective == null)
                {
                    throw new Exception("Patient information not found.");
                }
                var patientInfo = dbContext.SHPatientRegistration
                   .FirstOrDefault(p => p.PatientID == patientId && p.ClinicID == clinicId);

                var patientFamilyHistory = dbContext.SHExmPatientFHPH
                    .FirstOrDefault(p => p.PatientID == patientId);

                var patientHealthHistory = dbContext.SHExmPatientFHPH1
                    .FirstOrDefault(p => p.PatientID == patientId);

                var patientExamination = dbContext.SHExmPatientExamination
                    .FirstOrDefault(p => p.PatientID == patientId && p.VisitID == visitId && p.ClinicID == clinicId);

                var patExmSymptomsSeverity = dbContext.SHExmSeverity
                    .FirstOrDefault(p => p.PatientID == patientId && p.VisitID == visitId && p.ClinicID == clinicId);

                // Generate the populated document
                byte[] generatedDocument = PopulateWordTemplate(patientInfo,
                     patientObjective, patientFamilyHistory,
                    patientHealthHistory, patientExamination, patExmSymptomsSeverity);

                return generatedDocument;
            }
        }
        private byte[] PopulateWordTemplate(PatientRegistrationModel patientRegistration,
             PatientObjectiveModel patientObjective,
            PatientFHPHModel patientFamilyHistory, PatientFHPHModel1 patientHealthHistory,
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
        public List<PatientFHPHMasterModel> GetHistoryQuestions (String Type)
        {

         var patExmQuestion= (from q in objSearchContext.PatExmFHPH
                                  where q.Type == Type
                                  select new PatientFHPHMasterModel{ Question = q.Question,QuestionID=q.QuestionID}).ToList();



            return patExmQuestion;
                    
        }
        public async Task<List<PatExamSearchModel>> GetPatientObjectiveData(string patientID, string visitID, string clinicID, string patientName, string visitDate, string clinicName)
        {
            var patExamSearch = (from r in objSearchContext.SHPatientRegistration
                                 join e in objSearchContext.SHExmPatientObjective
                                 on r.PatientID equals e.PatientID into PatReg
                                 from re in PatReg.DefaultIfEmpty()
                                 join c in objSearchContext.SHclnClinicAdmin
                                 on re.ClinicID equals c.ClinicId into PatClinc
                                 from rec in PatClinc.DefaultIfEmpty()
                                 where (r.PatientID == patientID || r.FullName == patientName) ||
                                                      (re.VisitID == visitID || re.VisitDate == visitDate || re.VisitID == null) ||
                                                      (re.ClinicID == clinicID || rec.ClinicName == clinicName || re.ClinicID == null)
                                 select new PatExamSearchModel
                                 {

                                     PatientID = r.PatientID,

                                     FullName = r.FullName,

                                     VisitID = re != null ? re.VisitID : null,

                                     VisitDate = re != null ? re.VisitDate : null,

                                     ClinicID = rec != null ? rec.ClinicId : null,

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

            var patitentObjectiveDataSubmit = await objSearchContext.SHExmPatientObjective.FirstOrDefaultAsync(x =>
                    x.PatientID == patientID  && x.ClinicID == clinicID && x.VisitID==visitID);



            if (existingIds.Count == 0)
            {
                return 1;
            }
            else
            {
    }

                List<int> idIntegers = existingIds.Select(int.Parse).ToList();
                int maxId = idIntegers.Max();
                return maxId + 1;
            }
        }
        public async Task<PatientObjectiveModel> GetPatientObjectiveSubmit(string patientID, string visitID, string clinicID)
        {
            String strNewCliniid = clinicID;

            if (string.IsNullOrEmpty(visitID))
            {
                // Generate the next visit ID for the patient
                visitID = GetNextVisitIdForPatient(patientID).ToString();

                strNewCliniid = await objSearchContext.SHclnClinicAdmin
            .Where(x => x.ClinicName == "Stellar")
            .Select(x => x.ClinicId)
            .FirstOrDefaultAsync();

                var newPatientObjective = new PatientObjectiveModel
                {
                    PatientID = patientID,
                    ClinicID = strNewCliniid,
                    VisitID = visitID,

                };


                objSearchContext.SHExmPatientObjective.Add(newPatientObjective);

                await objSearchContext.SaveChangesAsync();
            }


            
            var patientObjectiveDataSubmit = await objSearchContext.SHExmPatientObjective.FirstOrDefaultAsync(x =>
                x.PatientID == patientID && x.VisitID == visitID && x.ClinicID == strNewCliniid);

            return patientObjectiveDataSubmit;

        }



}


}
