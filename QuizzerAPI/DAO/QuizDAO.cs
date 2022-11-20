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
    public class QuizDAO
    {
        public List<Quiz> GetAll()
        {
            List<Quiz> resultats = new List<Quiz>();
            Quiz quiz;

            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = "server=localhost;port=3306;user=root;database=;";

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
                quiz.titre = (string)dr["titre"];
                quiz.question = (string)dr["question"];
                /*quiz.choix = dr["question"] as List<string>;
                quiz.reponses = dr["choix"] as Dictionary<string>;*/

                resultats.Add(quiz);
            }
            cnx.Close();
            return null;
        }

        public List<Quiz> GetByID(int id)
        {
            List<Quiz> resultats = new List<Quiz>();
            Quiz quiz;

            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = "server=localhost;port=3306;user=root;database=;";

            cnx.Open();

            DbCommand cmd = new MySqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "SELECT * FROM quiz WHERE idQuiz=" + id;
            cmd.CommandType = CommandType.TableDirect;

            DbDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                quiz = new Quiz();

                quiz.idQuiz = (int)dr["idQuiz"];
                quiz.titre = (string)dr["titre"];
                quiz.question = (string)dr["question"];
                /*quiz.choix = dr["question"] as List<string>;
                quiz.reponses = dr["choix"] as Dictionary<string>;*/

                resultats.Add(quiz);
            }
            cnx.Close();
            return null;
        }

        public void AjouterQuiz(Quiz quiz)
        {

            DbConnection cnx = new MySqlConnection();

            cnx.ConnectionString = "server=localhost; port=3306;user=root;database=journaliste;";

            cnx.Open();

            DbCommand cmd = new MySqlCommand(); //Ou : MySqlCommand cmd = cnx.CreateCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "INSERT INTO quiz (titre,question,choix,reponses) VALUES (@Titre,@Question,@Choix,@Reponses);";

            MySqlParameter titre = new MySqlParameter("@Titre", MySqlDbType.VarChar);
            MySqlParameter question = new MySqlParameter("@Question", MySqlDbType.VarChar);
            /*MySqlParameter choix = new MySqlParameter("@Choix", MySqlDbType.List);
            MySqlParameter reponses = new MySqlParameter("@Reponses", MySqlDbType.Int32);*/


            titre.Value = quiz.titre;
            question.Value = quiz.question;
            /*choix.Value = quiz.choix;
            reponses.Value = quiz.reponses;*/

            cmd.Parameters.Add(titre);
            cmd.Parameters.Add(question);
            /*cmd.Parameters.Add(choix);
            cmd.Parameters.Add(reponses);*/


            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public void UpdateQuiz(Quiz quiz)
        {

            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = "server=localhost;port=3306;user=root;database=;";

            cnx.Open();

            DbCommand cmd = new MySqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "UPDATE quiz SET titre= @Titre, question= @Question, choix= @Choix, reponses= @Reponses WHERE id = @Id";
            cmd.CommandType = CommandType.Text;

            MySqlParameter titre = new MySqlParameter("@Titre", MySqlDbType.VarChar);
            MySqlParameter question = new MySqlParameter("@Question", MySqlDbType.VarChar);
            /*MySqlParameter choix = new MySqlParameter("@Choix", MySqlDbType.List);
            MySqlParameter reponses = new MySqlParameter("@Reponses", MySqlDbType.Int32);*/


            titre.Value = quiz.titre;
            question.Value = quiz.question;
            /*choix.Value = quiz.choix;
            reponses.Value = quiz.reponses;*/

            cmd.Parameters.Add(titre);
            cmd.Parameters.Add(question);
            /*cmd.Parameters.Add(choix);
            cmd.Parameters.Add(reponses);*/


            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public void DeleteQuiz(int id)
        {
            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = "server=localhost;port=3306;user=root;database=;";

            cnx.Open();

            DbCommand cmd = new MySqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "DELETE FROM quiz WHERER id =  @Id";
            cmd.CommandType = CommandType.Text;

            MySqlParameter idQuiz = new MySqlParameter("@Id", MySqlDbType.Int32);


            idQuiz.Value = id;

            cmd.Parameters.Add(id);

            cmd.Prepare();
            cmd.ExecuteNonQuery();

        }
    }
}