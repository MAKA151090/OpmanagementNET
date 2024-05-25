using Microsoft.IdentityModel.Protocols.OpenIdConnect;
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
        public string TableName { get => _tableName; set => _tableName = value; }
        public string UpdatedColumns { get => _UpdatedColumns; set => _UpdatedColumns = value; }
        public string OldValues { get => _OldValues; set => _OldValues = value; }
        public string NewValues { get => _NewValues; set => _NewValues = value; }
        public string ModifedTime1 { get => ModifedTime; set => ModifedTime = value; }
    }
}
