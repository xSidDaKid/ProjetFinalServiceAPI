using QuizzerAPI.DAO;
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
    public class Service1 : IService1
    {
        public IEnumerable<Quiz> GetAllQuiz()
        {
            return QuizDAO.GetAll();
        }

        public IEnumerable<Quiz> GetGetByID(string id)
        {
            return QuizDAO.GetByID(id);
        }
        public void AjouterQuiz(Quiz quiz)
        {
            QuizDAO.AjouterQuiz(quiz);
        }

        public bool UpdateQuiz(Quiz quiz)
        {
            return QuizDAO.UpdateQuiz(quiz);
        }

        public bool DeleteQuiz(string id)
        {
            return QuizDAO.DeleteQuiz(id);
        }

        public IEnumerable<Utilisateur> GetAllUtilisateur()
        {
            return UtilisateurDAO.GetAll();
        }

        public IEnumerable<Utilisateur> GetUtilisateurById(string id)
        {
            return UtilisateurDAO.GetByID(id);
        }

        public void AjouterUtilisateur(Utilisateur user)
        {
            UtilisateurDAO.AjouterUtilisateur(user);
        }

        public void AjouterUtilisateurParam(string courriel, string nomUtilisateur, string motDePasse)
        {
            UtilisateurDAO.AjouterUtilisateur(courriel, nomUtilisateur, motDePasse);
        }

        public bool UpdateUtilisateur(Utilisateur user)
        {
            return UtilisateurDAO.UpdateUtilisateur(user);
        }

        public bool UpdateUtilisateurParam(string courriel, string nomUtilisateur, string motDePasse, string idUtilisateur)
        {
            return UtilisateurDAO.UpdateUtilisateur(courriel, nomUtilisateur, motDePasse, idUtilisateur);
        }

        public bool DeleteUtilisateur(string id)
        {
            return UtilisateurDAO.DeleteUtilisateur(id);
        }

        public IEnumerable<Permission> GetAllPermission()
        {
            return PermissionDAO.GetAll();
        }

        public IEnumerable<Permission> GetPermissionByIdQuiz(string id)
        {
            return PermissionDAO.GetByIDQuiz(id);
        }

        public IEnumerable<Permission> GetPermissionByIdUtilisateur(string id)
        {
            return PermissionDAO.GetByIDUtilisateur(id);
        }

        public void AjouterPermission(Permission permission)
        {
            PermissionDAO.AjouterPermission(permission);
        }
        
        public void AjouterPermissionParam(string idQuiz, string idUtilisateur, string score)
        {
            PermissionDAO.AjouterPermissionParam(idQuiz, idUtilisateur, score);
        } 

        public bool UpdatePermission(Permission permission)
        {
            return PermissionDAO.UpdatePermission(permission);
        }

        public bool DeletePermission(Permission permission)
        {
            return PermissionDAO.DeletePermission(permission);
        }



        public void AjouterQuizParam(string titre, string choix, string idUser, string reponses, string question)
        {
            QuizDAO.AjouterQuizParam(titre, choix, idUser, reponses, question);
        }
    }
}
