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

        //Insert
        [OperationContract]
        [WebInvoke(Method = "POST",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "AddQuizParam/{titre}/{choix}/{idUser}/{reponses}/{question}")]
        void AjouterQuizParam(string titre, string choix, string idUser, string reponses, string question);

        //Update
        [OperationContract]
        [WebInvoke(Method = "PUT",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "UpdateQuiz")]
        bool UpdateQuiz(Quiz quiz);

        //Delete
        [OperationContract]
        [WebInvoke(Method = "DELETE",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "DeleteQuiz/{id}")]
        bool DeleteQuiz(string id);


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

        [OperationContract]
        [WebInvoke(Method = "POST",
                 RequestFormat = WebMessageFormat.Json,
                 ResponseFormat = WebMessageFormat.Json,
                 UriTemplate = "AddUtilisateur/{courriel}/{nomUtilisateur}/{motDePasse}")]
        void AjouterUtilisateurParam(string courriel, string nomUtilisateur, string motDePasse);

        //Update
        [OperationContract]
        [WebInvoke(Method = "PUT",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "UpdateUtilisateur")]
        bool UpdateUtilisateur(Utilisateur user);
        
        [OperationContract]
        [WebInvoke(Method = "PUT",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "UpdateUtilisateur/{courriel}/{nomUtilisateur}/{motDePasse}/{idUtilisateur}")]
        bool UpdateUtilisateurParam(string courriel, string nomUtilisateur, string motDePasse, string idUtilisateur);

        //Delete
        [OperationContract]
        [WebInvoke(Method = "DELETE",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "DeleteUtilisateur/{id}")]
        bool DeleteUtilisateur(string id);

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
                UriTemplate = "PermissionUtilisateurQuiz/{idQuiz}")]
        IEnumerable<Permission> GetPermissionByIdQuiz(string idQuiz);

        //Get By IDUtilisateur
        [OperationContract]
        [WebInvoke(Method = "GET",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "PermissionUtilisateur/{idUtilisateur}")]
        IEnumerable<Permission> GetPermissionByIdUtilisateur(string idUtilisateur);



        //Insert
        [OperationContract]
        [WebInvoke(Method = "POST",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "AddPermission")]
        void AjouterPermission(Permission permission);
        
        [OperationContract]
        [WebInvoke(Method = "POST",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "AddPermission/{idQuiz}/{idUtilisateur}/{score}")]
        void AjouterPermissionParam(string idQuiz, string idUtilisateur, string score);

        //Update
        [OperationContract]
        [WebInvoke(Method = "PUT",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "UpdatePermission")]
        bool UpdatePermission(Permission permission);
        
        [OperationContract]
        [WebInvoke(Method = "PUT",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "UpdatePermission/{score}/{idQuiz}/{idUtilisateur}")]
        bool UpdatePermissionParam(string score, string idQuiz, string idUtilisateur);

        //Delete
        [OperationContract]
        [WebInvoke(Method = "DELETE",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "DeleteUtilisateur")]
        bool DeletePermission(Permission permission);
    }
}
