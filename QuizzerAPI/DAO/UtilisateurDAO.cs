using QuizzerAPI.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace QuizzerAPI.DAO
{
    public class UtilisateurDAO
    {
        public static string connexion = "server=localhost;port=3306;user=root;database=quizzer;";

        public static List<Quiz> GetAll()
        {
            List<Quiz> resultats = new List<Quiz>();
            Quiz quiz;

            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = connexion;

            cnx.Open();

            DbCommand cmd = new MySqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "SELECT * FROM quiz";
            cmd.CommandType = CommandType.Text;

            DbDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                quiz = new Quiz();

                quiz.idQuiz = (int)dr["idQuiz"];
                quiz.idCreateurQuiz = (int)dr["idCreateurQuiz"];
                quiz.titre = (string)dr["titre"];
                quiz.question = (string)dr["question"];
                quiz.choix = (string)dr["choix"];
                quiz.reponses = (string)dr["reponses"];

                resultats.Add(quiz);
            }
            cnx.Close();
            return resultats;
        }
    }
}