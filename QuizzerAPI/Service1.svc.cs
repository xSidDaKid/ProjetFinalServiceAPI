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
        public IEnumerable<Quiz> GetAll()
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
    }
}
