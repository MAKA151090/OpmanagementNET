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
               where (Inp.BedNoID == BedNoID && Inp.PatientID == patientID && Inp.ObservationID==ObservationID)
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

        public List<StaffAdminModel> GetConDocId()
        {
            var condocid = (
                    from pr in objInpatientDb.SHclnStaffAdminModel
                    join p in objInpatientDb.SHclnResourseTypeMaster on pr.ResourceTypeID equals p.ResourceTypeID
                    where p.ResourceTypeName == "Doctor"
                    select new StaffAdminModel
                    {
                        StrStaffID = pr.StrStaffID,
                        StrFullName = pr.StrFullName
                    }
                ).ToList();

            return condocid;
        }


        public List<StaffAdminModel> Getdutydocid()
        {
            

            var dutydocid = (
                    from pr in objInpatientDb.SHclnStaffAdminModel
                    join p in objInpatientDb.SHclnResourseTypeMaster on pr.ResourceTypeID equals p.ResourceTypeID
                    where p.ResourceTypeName== "Doctor"
                    select new StaffAdminModel
                    {
                        StrStaffID = pr.StrStaffID,
                        StrFullName = pr.StrFullName
                    }
                ).ToList();

            return dutydocid;
        }


        public List<StaffAdminModel> GetRefDocId()
        {
            var refocid = (
                     from pr in objInpatientDb.SHclnStaffAdminModel
                     join p in objInpatientDb.SHclnResourseTypeMaster on pr.ResourceTypeID equals p.ResourceTypeID
                     where p.ResourceTypeName == "Doctor"
                     select new StaffAdminModel
                     {
                         StrStaffID = pr.StrStaffID,
                         StrFullName = pr.StrFullName
                     }
                ).ToList();

            return refocid;
        }

        public List<StaffAdminModel> GetAddcondocid()
        {
            var addcondocid = (
                   from pr in objInpatientDb.SHclnStaffAdminModel
                   join p in objInpatientDb.SHclnResourseTypeMaster on pr.ResourceTypeID equals p.ResourceTypeID
                   where p.ResourceTypeName == "Doctor"
                   select new StaffAdminModel
                   {
                       StrStaffID = pr.StrStaffID,
                       StrFullName = pr.StrFullName
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



///inpaient case sheet 
///

        public List<PatientRegistrationModel> GetpateintID()
        {
            var patientID = (
                    from pr in objInpatientDb.SHPatientRegistration
                    select new PatientRegistrationModel
                    {
                        PatientID = pr.PatientID,
                        FullName = pr.FullName,
                    }
                ).ToList();

            return patientID;
        }

        public List<InpatientAdmissionModel> GetCaseid()
        {
            var caseid = (
                    from pr in objInpatientDb.SHInpatientAdmission
                    select new InpatientAdmissionModel
                    {
                       CaseID = pr.CaseID,
                    }
                ).ToList();

            return caseid;
        }

        public List<HospitalBedMasterModel> GetBedID()
        {
            var bedid = (
                    from pr in objInpatientDb.SHclnHospitalBedMaster
                    select new HospitalBedMasterModel
                    {
                        BedID = pr.BedID,
                        BedName = pr.BedName,

                    }
                ).ToList();

            return bedid;
        }

        //In Patient Discharge

        public List<PatientRegistrationModel> GetPatientID()
        {
            var PatientID = (
                    from pr in objInpatientDb.SHPatientRegistration
                    select new PatientRegistrationModel
                    {
                        PatientID = pr.PatientID,
                        FullName = pr.FullName,

                    }
                ).ToList();

            return PatientID;
        }

        public List<InpatientAdmissionModel> GetCaseID()
        {
            var CaseID = (
                    from pr in objInpatientDb.SHInpatientAdmission
                    select new InpatientAdmissionModel
                    {
                       CaseID = pr.CaseID,

                    }
                ).ToList();

            return CaseID;
        }

       public List<ResourceTypeMasterModel> GetDoctorID()
        {
            var DoctorID = (
                    from pr in objInpatientDb.SHclnResourseTypeMaster
                    select new ResourceTypeMasterModel
                    {
                        ResourceTypeID = pr.ResourceTypeID,
                        ResourceTypeName = pr.ResourceTypeID,

                    }
                ).ToList();

            return DoctorID;
        }


        // In Patient Discharge summary

        public List<PatientRegistrationModel> getPatientID()
        {
            var PatientId = (
                    from pr in objInpatientDb.SHPatientRegistration
                    select new PatientRegistrationModel
                    {
                        PatientID = pr.PatientID,
                        FullName = pr.FullName,

                    }
                ).ToList();

            return PatientId;
        }


        // Ip patient Transfer

        public List<PatientRegistrationModel> GetPatID()
        {
            var patientID = (
                    from pr in objInpatientDb.SHPatientRegistration
                    select new PatientRegistrationModel
                    {
                        PatientID =pr.PatientID, FullName = pr.FullName,

                    }
                ).ToList();

            return patientID;
        }



        public List<InpatientAdmissionModel> GetCaseId()
        {
            var CaseID = (
                    from pr in objInpatientDb.SHInpatientAdmission
                    select new InpatientAdmissionModel
                    {
                        CaseID = pr.CaseID

                    }
                ).ToList();

            return CaseID;
        }

        public List<HospitalBedMasterModel> GetBedId()
        {
            var bedid = (
                    from pr in objInpatientDb.SHclnHospitalBedMaster
                    select new HospitalBedMasterModel
                    {
                        BedID = pr.BedID,
                        BedName = pr.BedName,

                    }
                ).ToList();

            return bedid;
        }



//In Patient Observation


        public List<HospitalBedMasterModel> Getbedid()
        {
            var bedid = (
                    from pr in objInpatientDb.SHclnHospitalBedMaster
                    select new HospitalBedMasterModel
                    {
                        BedID = pr.BedID,
                        BedName = pr.BedName,

                    }
                ).ToList();

            return bedid;
        }


        public List<PatientRegistrationModel> GetPatientid()
        {
            var patientID = (
                    from pr in objInpatientDb.SHPatientRegistration
                    select new PatientRegistrationModel
                    {
                        PatientID = pr.PatientID,
                        FullName = pr.FullName,

                    }
                ).ToList();

            return patientID;
        }


       















        public List<NurseStationMasterModel>GetnurseDWID()
        {
            var nurseDWid = (
                      from nr in objInpatientDb.SHclnNurseStationMaster
                      select new NurseStationMasterModel
                      {
                          NurseStationID = nr.NurseStationID,
                          StationName = nr.StationName
                      }

                ).ToList();
            return nurseDWid;
        }
    }

}
