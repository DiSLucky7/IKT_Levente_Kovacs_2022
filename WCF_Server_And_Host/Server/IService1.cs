using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Server
{

    [ServiceContract]
    public interface IService1
    {
        [OperationContract]

        Kutya EgyKutyaGetCS();

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,

            UriTemplate = "/EgyKutyaAdatai/"
            )]
        Kutya EgyKutyaGet();

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/EgyKutyaHozzaAdas/"
            )]
        Kutya EgyKutyaPost();

        [OperationContract]
        Kutya EgyKutyaPostCS();


        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/Kutyak/"
            )]
        List<Kutya> KutyakListaja();

        [OperationContract]
        List<Kutya> KutyakListajaCS();

        [OperationContract]
        string EgyKutyaAddCS(Kutya kutya);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/EgyKutyaAdd/"
            )]
        string EgyKutyaAdd(Kutya kutya);

    }

    [DataContract]

    public class Record
    {
        [DataMember]

        public int? ID { get; set; }
    }

    [DataContract]

    public class Kutya : Record
    {
        [DataMember(IsRequired = true)]

        public string Nev { get; set; }

        [DataMember(IsRequired = true)]

        public string Fajta { get; set; }

        [DataMember(IsRequired = true)]

        public byte Eletkor { get; set; }

        [DataMember(IsRequired = true)]

        public bool? Neme { get; set; }

        [DataMember(IsRequired =true)]

        public string Gazdi { get; set;}

        [DataMember(IsRequired = true)]

        public byte LabakSzama { get; set; }

        [OperationContract]
        public override string ToString()
        {
            return $"ID: {ID}\nNév: {Nev}\nGazdi neve: {Gazdi}\n Fajta: {Fajta}\nÉletkor: {Eletkor}\nNeme: {Neme}";
        }

    }
}
