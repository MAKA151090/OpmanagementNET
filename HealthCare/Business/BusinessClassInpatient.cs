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
using System.Diagnostics;

namespace HealthCare.Business
{
    public class BusinessClassInpatient
    {
        private readonly HealthcareContext objInpatientDb;

        public BusinessClassInpatient(HealthcareContext serviceContext)
        {
            this.objInpatientDb = serviceContext;
        }
     public async Task<InPatientTransferUpdateModel> InPatientTransfer(string PatientId, string CaseId, string BedId)
        {
         
             var result = await (from Inp in objInpatientDb.SHInpatientAdmission
                                join e in objInpatientDb.SHclnHospitalBedMaster on Inp.BedID equals e.BedID
                                where Inp.BedID == BedId && Inp.PatientID == PatientId && Inp.CaseID == CaseId
                                select new InPatientTransferUpdateModel
                                {
                                    PatientId = Inp.PatientID,
                                    CaseId = Inp.CaseID,
                                    BedId = Inp.BedID,
                                    RoomTypeFrom = e.RoomType,
                                    BedIdFrom =Inp.BedID
                                  
                                }).FirstOrDefaultAsync();

            return result;
        }




        public async Task<InpatientObservationViewModel> GetInpatientObs(string potObservationID, string patiendID, string BedNoID,string ObservationID)
        {
            InpatientObservationViewModel Inconfirmationobs = new InpatientObservationViewModel();

            Inconfirmationobs.SHviewInpatientObs = GetInpatientViewObs(potObservationID, patiendID, BedNoID,ObservationID);

            var result = await (from Inp in objInpatientDb.SHipmInpatientobservation
                                join e in objInpatientDb.SHclnEWSMaster on Inp.ObservationID equals e.ObservationTypeID
                                select new InpatientObservationViewModel
                                {
                                    ObservationID = Inp.ObservationID,
                                    PatientID = Inp.PatientID,
                                    BedNoID = Inp.BedNoID,
                                    DateTime = Inp.DateTime,
                                    NurseID = Inp.NurseID,
                                }).FirstOrDefaultAsync();

            Inconfirmationobs.ObservationID = result.ObservationID;
            Inconfirmationobs.PatientID = result.PatientID;
            Inconfirmationobs.BedNoID = result.BedNoID;
            Inconfirmationobs.DateTime = result.DateTime;
            Inconfirmationobs.NurseID = result.NurseID;

            return Inconfirmationobs;
        }

        public List<InpatientObservationModel> GetInpatientViewObs(string potObservationID, string patientID, string BedNoID,string ObservationID)
        {


            var objnew = (objInpatientDb.SHipmInpatientobservation.Where(x =>
                x.PatientID == patientID && x.BedNoID == BedNoID && x.ObservationID == potObservationID).Count());

            if (objnew <=0)
            {
                var addEWS = objInpatientDb.SHclnEWSMaster.Select(e => e).ToList();

                foreach (var item in addEWS)
                {
                    var newObservation = new InpatientObservationModel
                    {
                        ObservationTypeID = item.ObservationTypeID,
                        PatientID = patientID,
                        BedNoID = BedNoID,
                        ObservationID=ObservationID
                    };
                    objInpatientDb.SHipmInpatientobservation.Update(newObservation);
                   
                }
                objInpatientDb.SaveChanges();
            }

            var result = (
               from e in objInpatientDb.SHclnEWSMaster
               join Inp in objInpatientDb.SHipmInpatientobservation
                   on e.ObservationTypeID equals Inp.ObservationTypeID into InpGroup
               from Inp in InpGroup.DefaultIfEmpty()
               where (Inp.BedNoID == BedNoID && Inp.PatientID == patientID)
               select new InpatientObservationModel
               {
                   ObservationName = e.ObservationName,
                   Answer = Inp != null ? Inp.Answer : string.Empty,
                   Unit = e.Unit,
                   Range = e.Range,
                   Frequency = e.Frequency,

               }).ToList();

            return result;

        }
    }
}
