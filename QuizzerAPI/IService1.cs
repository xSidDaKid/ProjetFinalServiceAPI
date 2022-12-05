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
        IEnumerable<Quiz> GetAllQuiz();

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


        //Utilisateurs----------
        //Get All
        [OperationContract]
        [WebInvoke(Method = "GET",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "Utilisateur")]
        IEnumerable<Utilisateur> GetAllUtilisateur();

        //Get By ID
        [OperationContract]
        [WebInvoke(Method = "GET",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "Utilisateur/{id}")]
        IEnumerable<Utilisateur> GetUtilisateurById(string id);


        //Insert
        [OperationContract]
        [WebInvoke(Method = "POST",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "AddUtilisateur")]
        void AjouterUtilisateur(Utilisateur user);

        //Update
        [OperationContract]
        [WebInvoke(Method = "PUT",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "UpdateUtilisateur")]
        void UpdateUtilisateur(Utilisateur user);

            //Delete
        [OperationContract]
        [WebInvoke(Method = "DELETE",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "DeleteUtilisateur/{id}")]
        void DeleteUtilisateur(string id);

        //Permission----------
        //Get All
        [OperationContract]
        [WebInvoke(Method = "GET",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "Permission")]
        IEnumerable<Permission> GetAllPermission();

        //Get By IDQuiz
        [OperationContract]
        [WebInvoke(Method = "GET",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "Utilisateur/{idQuiz}")]
        IEnumerable<Utilisateur> GetPermissionByIdQuiz(string id);

        //Get By IDUtilisateur
        [OperationContract]
        [WebInvoke(Method = "GET",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "Utilisateur/{idUtilisateur}")]
        IEnumerable<Utilisateur> GetPermissionByIdUtilisateur(string id);



        //Insert
        [OperationContract]
        [WebInvoke(Method = "POST",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "AddPermission")]
        void AjouterPermission(Permission permission);

        //Update
        [OperationContract]
        [WebInvoke(Method = "PUT",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "UpdatePermission")]
        void UpdatePermission(Permission permission);

        //Delete
        [OperationContract]
        [WebInvoke(Method = "DELETE",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "DeleteUtilisateur")]
        void DeletePermission(Permission permission);
    }
}
