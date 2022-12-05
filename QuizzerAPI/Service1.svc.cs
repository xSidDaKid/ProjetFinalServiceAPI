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

        public void UpdateQuiz(Quiz quiz)
        {
            QuizDAO.UpdateQuiz(quiz);
        }

        public void DeleteQuiz(string id)
        {
            QuizDAO.DeleteQuiz(id);
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

        public void UpdateUtilisateur(Utilisateur user)
        {
            UtilisateurDAO.UpdateUtilisateur(user);
        }

        public void DeleteUtilisateur(string id)
        {
            UtilisateurDAO.DeleteUtilisateur(id);
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

        public void UpdatePermission(Permission permission)
        {
            PermissionDAO.UpdatePermission(permission);
        }

        public void DeletePermission(Permission permission)
        {
            PermissionDAO.DeletePermission(permission);
        }
    }
}
