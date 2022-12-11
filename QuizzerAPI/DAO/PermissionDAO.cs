using QuizzerAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using MySql.Data.MySqlClient;
using System.Data;

namespace QuizzerAPI.DAO
{
    public class PermissionDAO
    {
        private static string connexion = "server=localhost;port=3306;user=root;database=quizzer;";

        public static List<Permission> GetAll()
        {
            List<Permission> resultats = new List<Permission>();
            Permission permission;

            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = connexion;

            cnx.Open();

            DbCommand cmd = new MySqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "SELECT * FROM permission";
            cmd.CommandType = CommandType.Text;

            DbDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                permission = new Permission();
                permission.idQuiz = (int)dr["idQuiz"];
                permission.idUtilisateur = (int)dr["idUtilisateur"];
                permission.score = (int)dr["score"];


                resultats.Add(permission);
            }
            cnx.Close();
            return resultats;
        }

        public static List<Permission> GetByIDUtilisateur(string id)
        {

            List<Permission> resultats = new List<Permission>();
            Permission permission;

            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = connexion;

            cnx.Open();

            DbCommand cmd = new MySqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = $"SELECT * FROM permission WHERE idUtilisateur={id}";
            cmd.CommandType = CommandType.Text;

            DbDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                permission = new Permission();
                permission.idQuiz = (int)dr["idQuiz"];
                permission.idUtilisateur = (int)dr["idUtilisateur"];
                permission.score = (int)dr["score"];


                resultats.Add(permission);
            }
            cnx.Close();
            return resultats;
        }

        public static List<Permission> GetByIDQuiz(string id)
        {

            List<Permission> resultats = new List<Permission>();
            Permission permission;

            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = connexion;

            cnx.Open();

            DbCommand cmd = new MySqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = $"SELECT * FROM permission WHERE idQuiz={id}";
            cmd.CommandType = CommandType.Text;

            DbDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                permission = new Permission();
                permission.idQuiz = (int)dr["idQuiz"];
                permission.idUtilisateur = (int)dr["idUtilisateur"];
                permission.score = (int)dr["score"];


                resultats.Add(permission);
            }
            cnx.Close();
            return resultats;
        }

        public static void AjouterPermission(Permission permission)
        {

            DbConnection cnx = new MySqlConnection();

            cnx.ConnectionString = connexion;

            cnx.Open();

            DbCommand cmd = new MySqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = $"INSERT INTO permission (idQuiz,idUtilisateur,score) VALUES ({permission.idQuiz},{permission.idUtilisateur},{permission.score});";
            cmd.CommandType = CommandType.Text;

            cmd.Prepare();
            cmd.ExecuteNonQuery();
            cnx.Close();
        }

        public static void AjouterPermissionParam(string idQuiz, string idUtilisateur, string score)
        {
            int idQuizINT = int.Parse(idQuiz);
            int idUtilisateurINT = int.Parse(idUtilisateur);
            int scoreINT = int.Parse(score);

            DbConnection cnx = new MySqlConnection();

            cnx.ConnectionString = connexion;

            cnx.Open();

            DbCommand cmd = new MySqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = $"INSERT INTO permission (idQuiz,idUtilisateur,score) VALUES ({idQuizINT},{idUtilisateurINT},{scoreINT});";
            cmd.CommandType = CommandType.Text;

            cmd.Prepare();
            cmd.ExecuteNonQuery();
            cnx.Close();
        }

        public static bool UpdatePermission(Permission permission)
        {
            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = connexion;

            cnx.Open();

            DbCommand cmd = new MySqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = $"UPDATE permission SET score={permission.score} WHERE idQuiz={permission.idQuiz} AND idUtilisateur = {permission.idUtilisateur}";
            cmd.CommandType = CommandType.Text;

            cmd.Prepare();
            bool res = cmd.ExecuteNonQuery() > 0;
            cnx.Close();
            return res;
        }
        
        public static bool UpdatePermissionParam(string score, string idQuiz, string idUtilisateur)
        {
            int idQuizINT = int.Parse(idQuiz);
            int idUtilisateurINT = int.Parse(idUtilisateur);
            int scoreINT = int.Parse(score);

            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = connexion;

            cnx.Open();

            DbCommand cmd = new MySqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = $"UPDATE permission SET score={scoreINT} WHERE idQuiz={idQuizINT} AND idUtilisateur = {idUtilisateurINT}";
            cmd.CommandType = CommandType.Text;

            cmd.Prepare();
            bool res = cmd.ExecuteNonQuery() > 0;
            cnx.Close();
            return res;
        }

        public static bool DeletePermission(Permission permission)
        {
            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = connexion;

            cnx.Open();

            DbCommand cmd = new MySqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = $"DELETE FROM permission WHERE idQuiz={permission.idQuiz} AND idUtilisateur = {permission.idUtilisateur}";
            cmd.CommandType = CommandType.Text;

            cmd.Prepare();
            bool res = cmd.ExecuteNonQuery() > 0;
            cnx.Close();

            return res;
        }
    }
}