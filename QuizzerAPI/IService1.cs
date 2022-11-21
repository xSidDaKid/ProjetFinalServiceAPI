using QuizzerAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace QuizzerAPI
{
    [ServiceContract]
    public interface IService1
    {
        //Get All
        [OperationContract]
        [WebInvoke(Method = "GET",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "Quiz")]
        IEnumerable<Quiz> GetAll();

        //Get By ID
        [OperationContract]
        [WebInvoke(Method = "GET",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "Quiz/{id}")]
        IEnumerable<Quiz> GetGetByID(string id);

        //Insert
        [OperationContract]
        [WebInvoke(Method = "POST",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "AddQuiz")]
        void AjouterQuiz(Quiz quiz);

        //Update
        [OperationContract]
        [WebInvoke(Method = "PUT",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "UpdateQuiz")]
        void UpdateQuiz(Quiz quiz);

        //Delete
        [OperationContract]
        [WebInvoke(Method = "DELETE",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "DeleteQuiz/{id}")]
        void DeleteQuiz(string id);
    }
}
