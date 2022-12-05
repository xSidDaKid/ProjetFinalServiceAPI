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
    public class PermissionDAOTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            Console.WriteLine("GET ALL");
            Assert.AreEqual(1, PermissionDAO.GetAll().Count());
        }

        [TestMethod()]
        public void GetByIDUtilisateurTest()
        {
            Assert.IsNotNull(PermissionDAO.GetByIDUtilisateur("1"));
        }

        [TestMethod()]
        public void GetByIDQuizTest()
        {
            Assert.IsNotNull(PermissionDAO.GetByIDQuiz("1"));
        }

        [TestMethod()]
        public void AjouterPermissionTest()
        {
            Permission permission = new Permission();
            permission.score = 1;
            permission.idUtilisateur = 1;
            permission.idQuiz = 1;
            Assert.AreEqual(2, PermissionDAO.GetAll().Count());
        }

        [TestMethod()]
        public void UpdatePermissionTest()
        {
            Permission permission = new Permission();
            permission.score = 100;
            permission.idUtilisateur = 1;
            permission.idQuiz = 1;

            bool res = PermissionDAO.UpdatePermission(permission);
            Assert.IsTrue(res);
        }

        [TestMethod()]
        public void DeletePermissionTest()
        {
            Permission permission = new Permission();
            permission.score = 100;
            permission.idUtilisateur = 1;
            permission.idQuiz = 1;

            bool res = PermissionDAO.DeletePermission(permission);
            Assert.Fail();
        }
    }
}