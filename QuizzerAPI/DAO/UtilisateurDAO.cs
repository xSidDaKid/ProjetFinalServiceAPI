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
        private static string connexion = "server=localhost;port=3306;user=root;password=admin;database=quizzer;";

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
            cmd.CommandText = $"SELECT * FROM utilisateur WHERE idUtilisateur={id}";
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

        public static void AjouterUtilisateur(Utilisateur user)
        {

            DbConnection cnx = new MySqlConnection();

            cnx.ConnectionString = connexion;

            cnx.Open();

            DbCommand cmd = new MySqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = $"INSERT INTO utilisateur (idUtilisateur,courriel,nomUtilisateur,motDePasse) VALUES ({user.idUtilisateur},'{user.courriel}','{user.nomUtilisateur}','{user.motDePasse}');";
            cmd.CommandType = CommandType.Text;

            cmd.Prepare();
            cmd.ExecuteNonQuery();
            cnx.Close();
        }


        public static bool UpdateUtilisateur(Utilisateur user)
        {
            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = connexion;

            cnx.Open();

            DbCommand cmd = new MySqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = $"UPDATE utilisateur SET courriel='{user.courriel}',nomUtilisateur='{user.nomUtilisateur}', motDePasse='{user.motDePasse}' WHERE idUtilisateur = {user.idUtilisateur}";
            cmd.CommandType = CommandType.Text;

            cmd.Prepare();
            bool res = cmd.ExecuteNonQuery() > 0;
            cnx.Close();
            return res;
        }

        public static bool DeleteUtilisateur(string id)
        {
            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = connexion;

            cnx.Open();

            DbCommand cmd = new MySqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = $"DELETE FROM utilisateur WHERE idUtilisateur={id}";
            cmd.CommandType = CommandType.Text;

            cmd.Prepare();
            bool res = cmd.ExecuteNonQuery() > 0;
            cnx.Close();
            return res;
        }

    }
}