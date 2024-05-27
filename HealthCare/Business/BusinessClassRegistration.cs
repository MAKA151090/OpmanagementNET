﻿using System;
using System.IO;
using System.Linq;
using DocumentFormat.OpenXml;
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
    public class BusinessClassRegistration
    {

        private readonly HealthcareContext objDbContext;

        public BusinessClassRegistration(HealthcareContext serviceContext)
        {
            objDbContext = serviceContext;
        }
        public async Task<PatientRegistrationModel> GetPatientObjectiveSubmit(string patientID, string FacilityID)
        {
            var patitentRegDataSubmit = await objDbContext.SHPatientRegistration.FirstOrDefaultAsync(x =>
                    x.PatientID == patientID && x.FacilityID == FacilityID);

            return patitentRegDataSubmit;
        }

        //Patient Scheduling DropDown

        public List<StaffAdminModel> GetStaffDropDown()
        {
            var staffDPD = (
                    from pr in objDbContext.SHclnStaffAdminModel
                    select new StaffAdminModel
                    {
                        StrStaffID = pr.StrStaffID,
                        StrFullName = pr.StrFullName,

                    }
                ).ToList();

            return staffDPD;
        }
        public List<PatientRegistrationModel> GetpatientIDDPD()
        {
            var patIDDPD = (
                    from pr in objDbContext.SHPatientRegistration
                    select new PatientRegistrationModel
                    {
                        PatientID = pr.PatientID,
                        FullName = pr.FullName
                    }
                ).ToList();

            return patIDDPD;
        }

        public List<ClinicAdminModel> GetFacilityID()
        {
            var FacDPD = (
                    from pr in objDbContext.SHclnClinicAdmin
                    select new ClinicAdminModel
                    {
                        FacilityID = pr.FacilityID,
                        ClinicName = pr.ClinicName,
                    }
                ).ToList();

            return FacDPD;
        }

        public IEnumerable<PatientShceduleViewModel> GetAvailableSchedules(string staffID, string facilityID, string date)
        {
            var query = from s in objDbContext.SHclnResourceSchedule
                        join sa in objDbContext.SHclnStaffAdminModel on s.StaffID equals sa.StrStaffID
                        join ca in objDbContext.SHclnClinicAdmin on s.FacilityID equals ca.FacilityID
                        where s.StaffID == staffID && s.FacilityID == facilityID && s.Date == date
                              && s.Holiday == false && s.Blocker == false && s.Active == false && s.PatientID == null
                        select new PatientShceduleViewModel
                        {
                            ScheduleID = s.SlotsID,
                            StaffID = s.StaffID,
                            StaffName = sa.StrFullName,
                            FacilityName = ca.ClinicName,
                            StartTime = s.StartTime,
                            Duration = s.Duration
                        };

            return query.ToList();
        }

        public void SaveSelectedSchedules(string patientID, List<string> selectedSchedules)
        {
            foreach (var selectslot in selectedSchedules)
            {
                var schedules = objDbContext.SHclnResourceSchedule
                         .Where(schedules => schedules.SlotsID == selectslot).First();

                schedules.PatientID = patientID;


            }
            objDbContext.SaveChanges();
        }



        ///blood group  
        ///

        public List<BloodGroupModel> GetBloodGroup()
        {
            var bldgrpid = (
                    from pr in objDbContext.SHclnBloodGroup
                    select new BloodGroupModel
                    {
                        BloodGroup = pr.BloodGroup
                    }
               ).ToList();

            return bldgrpid;
        }


        public List<ClinicAdminModel> GetFacilityid()
        {
            var Facid = (
                    from pr in objDbContext.SHclnClinicAdmin
                    select new ClinicAdminModel
                    {
                        FacilityID = pr.FacilityID,
                        ClinicName = pr.ClinicName,
                    }
                ).ToList();

            return Facid;



        }
    }


    }
