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
    public class UtilisateurDAOTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            Assert.AreEqual(1, UtilisateurDAO.GetAll().Count());
        }

        [TestMethod()]
        public void GetByIDTest()
        {
            Assert.IsNotNull(UtilisateurDAO.GetByID("1"));
        }

        [TestMethod()]
        public void AjouterUtilisateurTest()
        {
            Utilisateur user = new Utilisateur();
            user.nomUtilisateur = "nomUser";
            user.courriel = "a@a.com";
            user.motDePasse = "password";
            Assert.AreEqual(2, UtilisateurDAO.GetAll().Count());
        }

        [TestMethod()]
        public void UpdateUtilisateurTest()
        {
            Utilisateur user = new Utilisateur();
            user.nomUtilisateur = "nomUser";
            user.courriel = "a@gmail.com";
            user.motDePasse = "password123";
            bool res = UtilisateurDAO.UpdateUtilisateur(user);
            Assert.IsTrue(res);
        }

        [TestMethod()]
        public void DeleteUtilisateurTest()
        {
            bool res = UtilisateurDAO.DeleteUtilisateur("1");
            Assert.IsTrue(res);
        }
    }
}