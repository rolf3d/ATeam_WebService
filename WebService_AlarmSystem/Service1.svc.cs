using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WebService_AlarmSystem
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        const string ConnString = @"Server=tcp:csorensenserver.database.windows.net,1433;
                                      Initial Catalog = StudentDb; Persist Security Info=False;
                                      User ID = casper; Password=Knoxville2;MultipleActiveResultSets=False;Encrypt=True;
                                      TrustServerCertificate=False;Connection Timeout = 30;";
        /// <summary>
        /// Returns the State of the alarm 0 is off, 1 is on.
        /// </summary>
        /// <returns></returns>
        public int GetAlarmStatus()
        {
            int ggg;
            SqlConnection conn = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand("Select TOP 1 AlarmState from AlarmStatus order by AlarmStateID Desc");

            cmd.Connection = conn;

            conn.Open();
            ggg = (int)cmd.ExecuteScalar();
            conn.Close();
            return ggg;
        }

        /// <summary>
        /// Returns all alarms in the Db
        /// </summary>
        /// <returns></returns>
        public IList<AlarmLog> GetAllAlarms()
        {
            List<AlarmLog> temp_list = new List<AlarmLog>();
            using (SqlConnection conn = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandText = "Select * from AlarmLog";
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        temp_list.Add(new AlarmLog()
                        {
                            Id = (int)reader[0],
                            AlarmTime = (DateTime)reader[1],
                            Log = (String)reader[2]
                        });
                    }
                    return temp_list;
                }
            }
        }

        /// <summary>
        /// Posts an Alarm into the Db
        /// </summary>
        /// <param name="Log"></param>
        public void PostRaspAlarm(string Log)
        {
            SqlConnection conn = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand("INSERT INTO AlarmLog (Log) VALUES (@log)");

            //Kalde metoden neden under
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@log", Log);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //Funktion der updater i databasen
        public void ResetRaspAlarm()
        {
            SqlConnection conn = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand("INSERT INTO AlarmStatus (Alarmstate) VALUES (0)");
            cmd.Connection = conn;
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
