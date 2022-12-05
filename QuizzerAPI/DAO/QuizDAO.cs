using QuizzerAPI.DTO;
using System.Collections.Generic;
using System.Data.Common;
using MySql.Data.MySqlClient;
using System.Data;

namespace QuizzerAPI.DAO
{
    public static class QuizDAO
    {
        private static string connexion = "server=localhost;port=3306;user=root;database=quizzer;";

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

        public static List<Quiz> GetByID(string id)
        {

            List<Quiz> resultats = new List<Quiz>();
            Quiz quiz;

            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = connexion;

            cnx.Open();

            DbCommand cmd = new MySqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = $"SELECT * FROM quiz WHERE idQuiz={id}";
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

        public static void AjouterQuiz(Quiz quiz)
        {

            DbConnection cnx = new MySqlConnection();

            cnx.ConnectionString = connexion;

            cnx.Open();

            DbCommand cmd = new MySqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = $"INSERT INTO quiz (idCreateurQuiz,titre,question,choix,reponses) VALUES ({quiz.idCreateurQuiz},'{quiz.titre}','{quiz.question}','{quiz.choix}','{quiz.reponses}');";
            cmd.CommandType = CommandType.Text;

            cmd.Prepare();
            cmd.ExecuteNonQuery();
            cnx.Close();
        }

        public static bool UpdateQuiz(Quiz quiz)
        {
            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = connexion;

            cnx.Open();

            DbCommand cmd = new MySqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = $"UPDATE quiz SET idCreateurQuiz={quiz.idCreateurQuiz},titre= '{quiz.titre}', question= '{quiz.question}', choix= '{quiz.choix}', reponses= '{quiz.reponses}' WHERE idQuiz = {quiz.idQuiz}";
            cmd.CommandType = CommandType.Text;

            cmd.Prepare();
            bool res = cmd.ExecuteNonQuery() > 0;
            cnx.Close();
            return res;
        }

        public static bool DeleteQuiz(string id)
        {
            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = connexion;

            cnx.Open();

            DbCommand cmd = new MySqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = $"DELETE FROM quiz WHERE idQuiz={id}";
            cmd.CommandType = CommandType.Text;

            cmd.Prepare();
            bool res = cmd.ExecuteNonQuery() > 0;
            cnx.Close();
            return res;

        }
    }
}