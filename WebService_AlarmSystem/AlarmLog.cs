using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService_AlarmSystem
{
    public class AlarmLog
    {
        #region Properties
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime alarmTime;

        public DateTime AlarmTime
        {
            get { return alarmTime; }
            set { alarmTime = value; }
        }

        private string log;

        public string Log
        {
            get { return log; }
            set { log = value; }
        }

        #endregion

        public AlarmLog()
        {

        }

        public AlarmLog(int Id, DateTime datetime, String log)
        {
            this.Id = id;
            this.Log = log;
            this.AlarmTime = datetime;
        }
    }
}