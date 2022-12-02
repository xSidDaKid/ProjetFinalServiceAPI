using QuizzerAPI.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;

/*
public string titre { get; set; }

[DataMember]
public string question { get; set; }

[DataMember]
public List<String> choix { get; set; }

[DataMember]
public Dictionary<String, String> reponses { get; set; }
*/
namespace QuizzerAPI.DAO
{
    public static class QuizDAO
    {
        public static List<Quiz> GetAll()
        {
            List<Quiz> resultats = new List<Quiz>();
            Quiz quiz;

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

        public static List<Quiz> GetByID(string id)
        {
            
            List<Quiz> resultats = new List<Quiz>();
            Quiz quiz;

            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = "server=localhost;port=3306;user=root;database=quizzer;";

            cnx.Open();

            DbCommand cmd = new MySqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "SELECT * FROM quiz WHERE idQuiz=@Id";
            cmd.CommandType = CommandType.Text;

            MySqlParameter idQuiz = new MySqlParameter("@Id", MySqlDbType.Int32);
            idQuiz.Value = Int32.Parse(id);
            cmd.Parameters.Add(idQuiz);

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

            cnx.ConnectionString = "server=localhost; port=3306;user=root;database=quizzer;";

            cnx.Open();

            DbCommand cmd = new MySqlCommand(); 
            cmd.Connection = cnx;
            cmd.CommandText = "INSERT INTO quiz (idCreateurQuiz,titre,question,choix,reponses) VALUES (@IdCreateurQuiz,@Titre,@Question,@Choix,@Reponses);";
            cmd.CommandType = CommandType.Text;

            MySqlParameter idCreateurQuiz = new MySqlParameter("@IdCreateurQuiz", MySqlDbType.Int32);
            MySqlParameter titre = new MySqlParameter("@Titre", MySqlDbType.VarChar);
            MySqlParameter question = new MySqlParameter("@Question", MySqlDbType.VarChar);
            MySqlParameter choix = new MySqlParameter("@Choix", MySqlDbType.VarChar);
            MySqlParameter reponses = new MySqlParameter("@Reponses", MySqlDbType.VarChar);


            titre.Value = quiz.titre;
            question.Value = quiz.question;
            choix.Value = quiz.choix;
            reponses.Value = quiz.reponses;

            cmd.Parameters.Add(titre);
            cmd.Parameters.Add(question);
            cmd.Parameters.Add(choix);
            cmd.Parameters.Add(reponses);


            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public static void UpdateQuiz(Quiz quiz)
        {
            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = "server=localhost;port=3306;user=root;database=quizzer;";

            cnx.Open();

            DbCommand cmd = new MySqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "UPDATE quiz SET idCreateurQuiz=@IdCreateurQuiz,titre= @Titre, question= @Question, choix= @Choix, reponses= @Reponses WHERE idQuiz = @Id";
            cmd.CommandType = CommandType.Text;

            MySqlParameter idCreateurQuiz = new MySqlParameter("@IdCreateurQuiz", MySqlDbType.Int32);
            MySqlParameter id = new MySqlParameter("@Id", MySqlDbType.Int32);
            MySqlParameter titre = new MySqlParameter("@Titre", MySqlDbType.VarChar);
            MySqlParameter question = new MySqlParameter("@Question", MySqlDbType.VarChar);
            MySqlParameter choix = new MySqlParameter("@Choix", MySqlDbType.VarChar);
            MySqlParameter reponses = new MySqlParameter("@Reponses", MySqlDbType.VarChar);


            id.Value = quiz.idQuiz;
            idCreateurQuiz.Value = quiz.idCreateurQuiz;
            titre.Value = quiz.titre;
            question.Value = quiz.question;
            choix.Value = quiz.choix;
            reponses.Value = quiz.reponses;

            cmd.Parameters.Add(id);
            cmd.Parameters.Add(idCreateurQuiz);
            cmd.Parameters.Add(titre);
            cmd.Parameters.Add(question);
            cmd.Parameters.Add(choix);
            cmd.Parameters.Add(reponses);


            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public static void DeleteQuiz(string id)
        {
            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = "server=localhost;port=3306;user=root;database=quizzer;";

            cnx.Open();

            DbCommand cmd = new MySqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "DELETE FROM quiz WHERE idQuiz=@Id";
            cmd.CommandType = CommandType.Text;

            MySqlParameter idQuiz = new MySqlParameter("@Id", MySqlDbType.Int32);
            idQuiz.Value = Int32.Parse(id);
            cmd.Parameters.Add(idQuiz);


            cmd.Prepare();
            cmd.ExecuteNonQuery();

        }
    }
}