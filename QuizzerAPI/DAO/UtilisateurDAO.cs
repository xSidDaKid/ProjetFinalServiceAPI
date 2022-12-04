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

        public static List<Utilisateur> GetAll()
        {
            List<Utilisateur> resultats = new List<Utilisateur>();
            Utilisateur user;

            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = connexion;

            cnx.Open();

            DbCommand cmd = new MySqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "SELECT * FROM utilisateur";
            cmd.CommandType = CommandType.Text;

            DbDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                user = new Utilisateur();

                user.idUtilisateur = (int)dr["idUtilisateur"];
                user.courriel = (string)dr["courriel"];
                user.nomUtilisateur = (string)dr["nomUtilisateur"];
                user.motDePasse = (string)dr["motDePasse"];
                resultats.Add(user);
            }
            cnx.Close();
            return resultats;
        }

        public static List<Utilisateur> GetByID(string id)
        {

            List<Utilisateur> resultats = new List<Utilisateur>();
            Utilisateur user;

            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = connexion;

            cnx.Open();

            DbCommand cmd = new MySqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "SELECT * FROM utilisateur WHERE idUtilisateur=@Id";
            cmd.CommandType = CommandType.Text;

            MySqlParameter idQuiz = new MySqlParameter("@Id", MySqlDbType.Int32);
            idQuiz.Value = Int32.Parse(id);
            cmd.Parameters.Add(idQuiz);

            DbDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                user = new Utilisateur();

                user.idUtilisateur = (int)dr["idUtilisateur"];
                user.courriel = (string)dr["courriel"];
                user.nomUtilisateur = (string)dr["nomUtilisateur"];
                user.motDePasse = (string)dr["motDePasse"];
                resultats.Add(user);
            }
            cnx.Close();
            return resultats;
        }

        public static void AjouterUtilisateur(Utilisateur user)
        {

            DbConnection cnx = new MySqlConnection();

            cnx.ConnectionString = connexion;

            cnx.Open();

            DbCommand cmd = new MySqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "INSERT INTO utilisateur (idUtilisateur,courriel,nomUtilisateur,motDePasse) VALUES (@IdUtilisateur,@Courriel,@nomUtilisateur,@motDePasse);";
            cmd.CommandType = CommandType.Text;

            MySqlParameter idUtilisateur = new MySqlParameter("@IdUtilisateur", MySqlDbType.Int32);
            MySqlParameter courriel = new MySqlParameter("@Courriel", MySqlDbType.VarChar);
            MySqlParameter nomUtilisateur = new MySqlParameter("@NomUtilisateur", MySqlDbType.VarChar);
            MySqlParameter motDePasse = new MySqlParameter("@motDePasse", MySqlDbType.VarChar);


            idUtilisateur.Value = user.idUtilisateur;
            courriel.Value = user.courriel;
            nomUtilisateur.Value = user.nomUtilisateur;
            motDePasse.Value = user.motDePasse;

            cmd.Parameters.Add(idUtilisateur);
            cmd.Parameters.Add(courriel);
            cmd.Parameters.Add(nomUtilisateur);
            cmd.Parameters.Add(motDePasse);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }


        public static void UpdateUtilisateur(Utilisateur user)
        {
            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = connexion;

            cnx.Open();

            DbCommand cmd = new MySqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "UPDATE utilisateur SET courriel=@Courriel,nomUtilisateur=@NomUtilisateur, motDePasse= @MotDePasse WHERE idUtilisateur = @Id";
            cmd.CommandType = CommandType.Text;


            MySqlParameter idUtilisateur = new MySqlParameter("@IdUtilisateur", MySqlDbType.Int32);
            MySqlParameter courriel = new MySqlParameter("@Courriel", MySqlDbType.VarChar);
            MySqlParameter nomUtilisateur = new MySqlParameter("@NomUtilisateur", MySqlDbType.VarChar);
            MySqlParameter motDePasse = new MySqlParameter("@motDePasse", MySqlDbType.VarChar);


            idUtilisateur.Value = user.idUtilisateur;
            courriel.Value = user.courriel;
            nomUtilisateur.Value = user.nomUtilisateur;
            motDePasse.Value = user.motDePasse;


            cmd.Parameters.Add(idUtilisateur);
            cmd.Parameters.Add(courriel);
            cmd.Parameters.Add(nomUtilisateur);
            cmd.Parameters.Add(motDePasse);


            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public static void DeleteUtilisateur(string id)
        {
            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = connexion;

            cnx.Open();

            DbCommand cmd = new MySqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "DELETE FROM utilisateur WHERE idUtilisateur=@Id";
            cmd.CommandType = CommandType.Text;

            MySqlParameter idUtilisateur = new MySqlParameter("@Id", MySqlDbType.Int32);
            idUtilisateur.Value = Int32.Parse(id);
            cmd.Parameters.Add(idUtilisateur);


            cmd.Prepare();
            cmd.ExecuteNonQuery();

        }

    }
}