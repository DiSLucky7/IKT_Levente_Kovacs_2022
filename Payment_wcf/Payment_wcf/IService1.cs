using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Payment_wcf
{
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebInvoke(Method = "*",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedResponse,
            UriTemplate = "getCustomer/{id}")
            ]
        Customer getCustomer(string id);

        [OperationContract]//*Ok
        [WebInvoke(Method = "*",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Bare,
           UriTemplate = "getCustomers")
           ]
        List<Customer> getCustomers();

        [OperationContract]//*Ok
        [WebInvoke(Method = "*",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.WrappedResponse,
           UriTemplate = "postCustomer/{id}/{name}/{age}/{city}")
           ]

        string postCustomer(string id, string name, string age, string city);


        [OperationContract]//*Ok
        [WebInvoke(Method = "*",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   BodyStyle = WebMessageBodyStyle.WrappedResponse,
                   UriTemplate = "putCustomer")
                   ]
        string putCustomer(Customer customer);


        [OperationContract]//*OK
        [WebInvoke(Method = "*",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.WrappedResponse,
          UriTemplate = "deleteCustomer/{id}")
          ]
        string deleteCustomer(string id);


        [OperationContract]//*OK
        [WebInvoke(Method = "*",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.WrappedResponse,
          UriTemplate = "patchCustomer")
          ]
        string patchCustomer(Customer sustomer);

    }

   
}
