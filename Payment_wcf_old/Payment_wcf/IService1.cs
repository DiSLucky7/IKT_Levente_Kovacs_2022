using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Payment_wcf
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/CustomerGet/"
            )]
        Customer CustomerGet();

        [OperationContract]
        Customer CustomerGetCS();


        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/CustomerPost/{id}/{name}/{city}"
            )]
        Customer CustomerPost(string id, string name, string city);

        //[OperationContract]
        //Customer CustomerPostCS();


        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/Customerk/"
            )]
        List<Customer> CustomerkListaja();

        //[OperationContract]
        //List<Customer> CustomerkListajaCS();


        [OperationContract]
        string CustomerAddCS(Customer kutya);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/CustomerAdd"
            )]
        string CustomerAdd(Customer kutya);

        [OperationContract]
        string CustomerPutCS(Customer kutya);


        [OperationContract]
        [WebInvoke(Method = "PUT",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/CustomerPut"
            )]
        string CustomerPut(Customer kutya);

        [OperationContract]
        string CustomerPatchCS(Customer kutya);


        [OperationContract]
        [WebInvoke(Method = "PATCH",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/CustomerModosit2"
            )]
        string CustomerPatch(Customer kutya);



        [OperationContract]
        string CustomerDeleteCS(string ID);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/CustomerTorol"
            )]
        string CustomerDelete(string ID);


        [OperationContract]
        [WebInvoke(Method = "DELETE",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/CustomerDelete/{ID}"
            )]
        string CustomerDeleteID(string ID);


        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/CustomerGetID/{ID}"
            )]
        Customer CustomerGetID(string ID);

    }

    //public class Record
    //{
    //    [DataMember]

    //    public int? ID { get; set; }
    //}


    //[DataContract]
    //public class Customer : Record
    //{
    //    [DataMember(IsRequired = true)]

    //    public string Name { get; set; }

    //    [DataMember(IsRequired = true)]

    //    public string City { get; set; }


    //    //[OperationContract]
    //    //public override string ToString()
    //    //{
    //    //    return $"ID: {ID}\nNév: {Nev}\nGazdi neve: {Gazdi}\n Fajta: {Fajta}\nÉletkor: {Eletkor}\nNeme: {Neme}";
    //    //}

    //}


}
