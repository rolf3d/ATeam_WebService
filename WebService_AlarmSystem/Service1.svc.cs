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

        const string ConnectionString = "connection string";

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public IList<string> GetAllRaspAlarms()
        {

            List<string> temp_list = new List<string>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();

                    cmd.CommandText = "Select * from databasen";
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        //temp_list.Add(new object()
                        //{
                        //    //Id = (int)reader[0],
                        //    //DishWasher = (bool)reader[7],
                        //    //Location = (string)reader[2],
                        //    //NoRoom = (int)reader[5],
                        //    //PostalCode = (int)reader[3],
                        //    //Price = (int)reader[1],
                        //    //Size = (int)reader[4], 
                        //});
                    }
                    return temp_list;
                }
            }
        }

        public void InsertRaspAlarm()
        {
            //Skal kunne modtage en RaspData-ting
            //og indsætte den i databasen 
        }
    }
}
