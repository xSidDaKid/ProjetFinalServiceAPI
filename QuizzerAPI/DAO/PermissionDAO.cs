using QuizzerAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;


namespace QuizzerAPI.DAO
{
    public class PermissionDAO
    {
        public static List<Permission> GetAll()
        {
            List<Permission> resultats = new List<Permission>();
            Permission permission;

            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = "server=localhost;port=3306;user=root;database=quizzer;";

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