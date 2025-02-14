using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models
{
    public class EmployeePayMaster
    {
        public EmployeePayMaster() { }

        private string staffpayid;
        private string staffname;
        private string payhead;
        private string headtype;
        private long id;
        private bool isDelete;
        private string facilityID;
        private String lastUpdatedUser;
        private String lastUpdatedDate;
        private String lastUpdatedMachine;


        [MaxLength(100)]
        public string Staffpayid { get => staffpayid; set => staffpayid = value; }

        [MaxLength(30)]
        public string Staffname { get => staffname; set => staffname = value; }

        [MaxLength(50)]
        public string? Payhead { get => payhead; set => payhead = value ?? string.Empty; }

        [MaxLength(50)]
        public string? Headtype { get => headtype; set => headtype = value ?? string.Empty; }
        public long Id { get => id; set => id = value; }
        public bool IsDelete { get => isDelete; set => isDelete = value; }
        public string FacilityID { get => facilityID; set => facilityID = value ?? string.Empty; }

        [MaxLength(50)]
        public string? LastUpdatedUser { get => lastUpdatedUser; set => lastUpdatedUser = value ?? string.Empty; }

        [MaxLength(50)]
        public string? LastUpdatedDate { get => lastUpdatedDate; set => lastUpdatedDate = value ?? string.Empty; }

        [MaxLength(50)]
        public string? LastUpdatedMachine { get => lastUpdatedMachine; set => lastUpdatedMachine = value ?? string.Empty; }
    }
}
