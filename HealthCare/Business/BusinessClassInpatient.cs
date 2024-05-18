﻿using System;
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
            this.objInpatientDb = objInpatientDb;
        }

        public async Task<InpatientObservationViewModel> GetInpatientObs(string potObservationID)
        {
            InpatientObservationViewModel Inconfirmationobs = new InpatientObservationViewModel();

            Inconfirmationobs.SHviewInpatientObs = GetInpatientViewObs(potObservationID); 

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

        public List<InpatientObservationModel> GetInpatientViewObs(string potObservationID)
        {

            var result = (
                from e in objInpatientDb.SHclnEWSMaster
                join Inp in objInpatientDb.SHipmInpatientobservation
                    on e.ObservationTypeID equals Inp.ObservationID into InpGroup
                from Inp in InpGroup.DefaultIfEmpty()
                where Inp == null || (Inp.BedNoID == potObservationID && Inp.PatientID == potObservationID)
                select new InpatientObservationModel
                          {
                              ObservationName = e.ObservationName,
                               Answer = Inp!= null? Inp.Answer : string.Empty,
                               Unit = e.Unit,
                              Range = e.Range,
                              Frequency = e.Frequency,

                          }).ToList();
            return result;

        }
    }
}
