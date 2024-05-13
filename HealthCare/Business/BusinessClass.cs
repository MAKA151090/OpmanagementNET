using System;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using HealthCare.Context;
using HealthCare.Models;
using Microsoft.Office.Interop.Word;

namespace HealthCare.Business
{
    public class BusinessClass
    {
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


            /* var texts = mainPart.Document.Descendants<Text>()
          .Where(t => t.Text.Contains(placeholder));

             foreach (var text in texts)
             {
                 if (text.Text.Contains(placeholder))
                 {
                     text.Text = text.Text.Replace(placeholder, value ?? string.Empty);
                 }
             }*/

            foreach (var textElement in mainPart.Document.Body.Descendants<Text>())
            {
                if (textElement.Text == placeholder)
                {
                    textElement.Text = value;
                }
            }

            /*var docText = mainPart.Document.Body.Descendants<Text>()
                .FirstOrDefault(t => t.Text.Contains(placeholder));

            if (docText != null)
            {
                docText.Text = docText.Text.Replace(placeholder, value);
            }*/
        }
        
    }
}
