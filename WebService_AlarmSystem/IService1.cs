using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WebService_AlarmSystem
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        //Kommentar fra Søren
        //[OperationContract]
        [WebInvoke(Method = "GET",
                    ResponseFormat = WebMessageFormat.Json,
                    RequestFormat = WebMessageFormat.Json,
                    UriTemplate = "Test")]
        string GetData();

        //urllen skal sættes
        [OperationContract]
        [WebInvoke(Method = "GET",
                    ResponseFormat = WebMessageFormat.Json,
                    RequestFormat = WebMessageFormat.Json,
                    UriTemplate = "Alarms")]
        IList<AlarmLog> GetAllAlarms();

        //urllen skal sættes
        [OperationContract]
        [WebInvoke(Method = "POST",
                    ResponseFormat = WebMessageFormat.Json,
                    RequestFormat = WebMessageFormat.Json,
                    UriTemplate = "Alarm")]
        void PostRaspAlarm(string Log);
    }   
}
