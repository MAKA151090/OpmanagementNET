using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Models
{
    public class WebLogsModel
    {
        private long _id;
        private string _tableName;
        private string _UpdatedColumns;
        private string _OldValues;
        private string _NewValues;
        private string ModifedTime;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get => _id; set => _id = value; }

        [MaxLength(30)]
        public string TableName { get => _tableName; set => _tableName = value; }

        [MaxLength(30)]
        public string UpdatedColumns { get => _UpdatedColumns; set => _UpdatedColumns = value; }

        [MaxLength(30)]
        public string OldValues { get => _OldValues; set => _OldValues = value; }

        [MaxLength(30)]
        public string NewValues { get => _NewValues; set => _NewValues = value; }

        [MaxLength(30)]
        public string ModifedTime1 { get => ModifedTime; set => ModifedTime = value; }
    }
}
