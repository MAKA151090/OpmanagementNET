﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthCare.Models
{
    public class LogsModel
    {
        private String logMessage;
        private String machineName;
        private String logDate;
        private String userName;
        private String logScreen;
        private String logType;
        private int logID;
        private int? att1;

        [MaxLength(30)]
        public String? LogMessage { get => logMessage; set => logMessage = value; }
        [MaxLength(30)]
        public String? MachineName { get => machineName; set => machineName = value; }
        [MaxLength(30)]
        public String? LogDate { get => logDate; set => logDate = value; }
        [MaxLength(30)]
        public String? UserName { get => userName; set => userName = value; }
        [MaxLength(30)]
        public String? LogScreens { get => logScreen; set => logScreen = value; }
        [MaxLength(30)]
        public String? LogType { get => logType; set => logType = value; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LogID { get => logID; set => logID = value; }
        public int? Att1 { get => att1; set => att1 = value; }
    }
}
