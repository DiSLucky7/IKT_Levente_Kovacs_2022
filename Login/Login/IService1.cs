using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Login
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(Method = "*",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedResponse,
            UriTemplate = "getUser/{id}")
            ]
        User getOne(string id);


        [OperationContract]//*Ok
        [WebInvoke(Method = "*",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Bare,
           UriTemplate = "getUsers")
           ]
        List<User> getAll();


        [OperationContract]//*Ok
        [WebInvoke(Method = "*",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedResponse,
            UriTemplate = "post")
            ]
        string post(User user);


        [OperationContract]//*OK
        [WebInvoke(Method = "*",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedResponse,
            UriTemplate = "patch")
            ]
        string patch(User user);


        [OperationContract]//*OK
        [WebInvoke(Method = "*",
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          BodyStyle = WebMessageBodyStyle.WrappedResponse,
          UriTemplate = "delete/{id}")
          ]
        string delete(string id);


        [OperationContract]
        [WebInvoke(Method = "*",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedResponse,
            UriTemplate = "login/{UName}/{Pwd}")
            ]
        User login(string UName, string Pwd);



        //[OperationContract]//*Ok
        //[WebInvoke(Method = "*",
        //   RequestFormat = WebMessageFormat.Json,
        //   ResponseFormat = WebMessageFormat.Json,
        //   BodyStyle = WebMessageBodyStyle.WrappedResponse,
        //   UriTemplate = "postUser/{id}/{name}/{age}/{city}")
        //   ]
        //string postUser(string id, string name, string age, string city);

    }

}
