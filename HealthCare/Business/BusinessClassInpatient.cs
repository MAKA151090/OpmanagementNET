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

            

                     
            var result = await (from  Ipu in objInpatientDb.SHipmInPatientTransferUpdate
                                join  Inp in objInpatientDb.SHInpatientAdmission on Ipu.PatientId equals Inp.PatientID
                                join    e in objInpatientDb.SHclnHospitalBedMaster on Inp.BedID equals e.BedID
                                where Inp.BedID == BedId && Inp.PatientID == PatientId && Inp.CaseID == CaseId
                                select new InPatientTransferUpdateModel
                                {
                                    PatientId = Inp.PatientID,
                                    CaseId = Inp.CaseID,
                                    BedId = e.BedID,
                                    RoomTypeFrom = e.RoomType,
                                    BedIdFrom =Inp.BedID,
                                    BedIdTo = Inp.BedID,
                                    RoomTypeTo = e.RoomType,
                                    TransferNotes= Ipu.TransferNotes,
                                    DocId=Ipu.DocId,
                                    ChangeDate=Ipu.ChangeDate
                                  
                                }).FirstAsync();
    
            return result;
        }




        public async Task<InpatientObservationViewModel> GetInpatientObs(string potObservationID, string patiendID, string BedNoID,string ObservationID,string observationTypeID)
        {
            InpatientObservationViewModel Inconfirmationobs = new InpatientObservationViewModel();

            Inconfirmationobs.SHviewInpatientObs = GetInpatientViewObs(potObservationID, patiendID, BedNoID,ObservationID,observationTypeID);

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
        public List<InpatientObservationModel> GetInpatientViewObs(string potObservationID, string BedNoID, string patientID, string ObservationID, string observationtypeID)
        {


            /* var objnew = (objInpatientDb.SHipmInpatientobservation.Where(x =>
                 x.PatientID == patientID && x.BedNoID == BedNoID && x.ObservationID == potObservationID).Count());*/


            var addEWS = objInpatientDb.SHclnEWSMaster.Select(e => e).ToList();

            foreach (var item in addEWS)
            {
                var objnew = (objInpatientDb.SHipmInpatientobservation.FirstOrDefault(x =>
                x.BedNoID == BedNoID && x.PatientID == patientID && x.ObservationID == potObservationID));

                if (objnew == null)
                {
                    var newObservation = new InpatientObservationModel
                    {
                        ObservationTypeID = item.ObservationTypeID,
                        PatientID = patientID,
                        BedNoID = BedNoID,
                        ObservationID = ObservationID
                    };
                    objInpatientDb.SHipmInpatientobservation.Add(newObservation);
                    objInpatientDb.SaveChanges();
                }


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
                   ObservationTypeID = e.ObservationTypeID,

               }).ToList();


            return result;

        }

        ///inpatient admission dropdown.
 
        public List<PatientRegistrationModel> Getpatid()
        {
            var patid = (
                    from pr in objInpatientDb.SHPatientRegistration
                    select new PatientRegistrationModel
                    {
                        PatientID = pr.PatientID,
                        FullName = pr.FullName
                    }
                ).ToList();

            return patid;
        }

        public List<ClinicAdminModel> Getfaid()
        {
            var faid = (
                    from pr in objInpatientDb.SHclnClinicAdmin
                    select new ClinicAdminModel
                    {
                        FacilityID = pr.FacilityID,
                        ClinicName = pr.ClinicName,
                    }
                ).ToList();

            return faid;
        }

        public List<ResourceTypeMasterModel> GetConDocId()
        {
            var condocid = (
                    from pr in objInpatientDb.SHclnResourseTypeMaster
                    select new ResourceTypeMasterModel
                    {
                        ResourceTypeID = pr.ResourceTypeID,
                        ResourceTypeName = pr.ResourceTypeName
                    }
                ).ToList();

            return condocid;
        }


        public List<ResourceTypeMasterModel> Getdutydocid()
        {
            var dutydocid = (
                    from pr in objInpatientDb.SHclnResourseTypeMaster
                    select new ResourceTypeMasterModel
                    {
                        ResourceTypeID = pr.ResourceTypeID,
                        ResourceTypeName = pr.ResourceTypeName
                    }
                ).ToList();

            return dutydocid;
        }


        public List<ResourceTypeMasterModel> GetRefDocId()
        {
            var refocid = (
                    from pr in objInpatientDb.SHclnResourseTypeMaster
                    select new ResourceTypeMasterModel
                    {
                        ResourceTypeID = pr.ResourceTypeID,
                        ResourceTypeName = pr.ResourceTypeName
                    }
                ).ToList();

            return refocid;
        }

        public List<ResourceTypeMasterModel> GetAddcondocid()
        {
            var addcondocid = (
                    from pr in objInpatientDb.SHclnResourseTypeMaster
                    select new ResourceTypeMasterModel
                    {
                        ResourceTypeID = pr.ResourceTypeID,
                        ResourceTypeName = pr.ResourceTypeName
                    }
                ).ToList();

            return addcondocid;
        }


        public List<HospitalBedMasterModel> GetBedid()
        {
            var bedid = (
                    from pr in objInpatientDb.SHclnHospitalBedMaster
                    select new HospitalBedMasterModel
                    {
                        BedID = pr.BedID,
                        BedName = pr.BedName
                    }
                ).ToList();

            return bedid;
        }

        public List<InternalDepartmentMasterModel> Getcondepid()
        {
            var condepid = (
                    from pr in objInpatientDb.SHotInternalDepartmentMaster
                    select new InternalDepartmentMasterModel
                    {
                        DepartmentID = pr.DepartmentID,
                        DepartmentName  = pr.DepartmentName
                    }
                ).ToList();

            return condepid;
        }

        public List<IPTypeMasterModel> Getinpattype()
        {
            var pattypeid = (
                    from pr in objInpatientDb.SHclnIPTypeMaster
                    select new IPTypeMasterModel
                    {
                        IPTypeID = pr.IPTypeID,
                        IPTypeName = pr.IPTypeName
                    }
                ).ToList();

            return pattypeid;
        }
    }

}
