using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuizzerAPI.DAO;
using QuizzerAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzerAPI.DAO.Tests
{
    [TestClass()]
    public class QuizDAOTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            Assert.AreEqual(1, QuizDAO.GetAll().Count());
        }

        [TestMethod()]
        public void GetByIDTest()
        {
            Assert.IsNotNull(QuizDAO.GetByID("1"));
        }

        [TestMethod()]
        public void AjouterQuizTest()
        {
            Quiz quiz = new Quiz();
            quiz.titre = "Titre";
            quiz.question = "Question";
            quiz.choix = "c1,c2,c3,c4";
            quiz.reponses = "c1:r1,c2:r2,c3:r3,c4:r4";
            quiz.idCreateurQuiz = 1;
            Assert.AreEqual(2, QuizDAO.GetAll().Count());
        }

        [TestMethod()]
        public void UpdateQuizTest()
        {
            Quiz quiz = new Quiz();
            quiz.titre = "TitreNEW";
            quiz.question = "Question";
            quiz.choix = "c1,c2,c3,c4";
            quiz.reponses = "c1:r1,c2:r2,c3:r3,c4:r4";
            quiz.idCreateurQuiz = 1;
            quiz.idQuiz = 1;
            bool res = QuizDAO.UpdateQuiz(quiz);
            Assert.IsTrue(res);
        }

        [TestMethod()]
        [Ignore]
        public void DeleteQuizTest()
        {
            bool res = QuizDAO.DeleteQuiz("1");
            Assert.IsTrue(res);
        }
    }
}