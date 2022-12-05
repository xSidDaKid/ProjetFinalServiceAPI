using QuizzerAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using MySql.Data.MySqlClient;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace QuizzerAPI.DAO
{
    public class PermissionDAO
    {
        public static string connexion = "server=localhost;port=3306;user=root;database=quizzer;";

        public static List<Permission> GetAll()
        {
            List<Permission> resultats = new List<Permission>();
            Permission permission;

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
                permission = new Permission();
                permission.idQuiz= (int)dr["idQuiz"];
                permission.idUtilisateur = (int)dr["idUtilisateur"];
                permission.score= (int)dr["score"];

                
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
            cmd.CommandText = "SELECT * FROM permission WHERE idUtilisateur=@Id";
            cmd.CommandType = CommandType.Text;

            MySqlParameter idQuiz = new MySqlParameter("@Id", MySqlDbType.Int32);
            idQuiz.Value = Int32.Parse(id);
            cmd.Parameters.Add(idQuiz);

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
            cmd.CommandText = "SELECT * FROM permission WHERE idQuiz=@Id";
            cmd.CommandType = CommandType.Text;

            MySqlParameter idQuiz = new MySqlParameter("@Id", MySqlDbType.Int32);
            idQuiz.Value = Int32.Parse(id);
            cmd.Parameters.Add(idQuiz);

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
            cmd.CommandText = "INSERT INTO permission (idQuiz,idUtilisateur,score) VALUES (@IdQuiz,@IdUtilisateur,@Score);";
            cmd.CommandType = CommandType.Text;

            MySqlParameter idQuiz = new MySqlParameter("@IdQuiz", MySqlDbType.Int32);
            MySqlParameter idUtilisateur = new MySqlParameter("@IdUtilisateur", MySqlDbType.Int32);
            MySqlParameter score = new MySqlParameter("@Score", MySqlDbType.Int32);


            idQuiz.Value = permission.idQuiz;
            idUtilisateur.Value = permission.idUtilisateur;
            score.Value = permission.score;

            cmd.Parameters.Add(idQuiz);
            cmd.Parameters.Add(idUtilisateur);
            cmd.Parameters.Add(score);


            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public static void UpdatePermission(Permission permission)
        {
            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = connexion;

            cnx.Open();

            DbCommand cmd = new MySqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "UPDATE permission SET score=@Score WHERE idQuiz=@IdQuiz AND idUtilisateur = @IdUtilisateur";
            cmd.CommandType = CommandType.Text;

            MySqlParameter idQuiz = new MySqlParameter("@IdQuiz", MySqlDbType.Int32);
            MySqlParameter idUtilisateur = new MySqlParameter("@IdUtilisateur", MySqlDbType.Int32);
            MySqlParameter score = new MySqlParameter("@Score", MySqlDbType.Int32);
            

            score.Value=permission.score;
            cmd.Parameters.Add(score);
            cmd.Parameters.Add(idQuiz);
            cmd.Parameters.Add(idUtilisateur);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public static void DeletePermission(Permission permission)
        {
            DbConnection cnx = new MySqlConnection();
            cnx.ConnectionString = connexion;

            cnx.Open();

            DbCommand cmd = new MySqlCommand();
            cmd.Connection = cnx;
            cmd.CommandText = "DELETE FROM permission WHERE idQuiz=@IdQuiz AND idUtilisateur = @IdUtilisateur";
            cmd.CommandType = CommandType.Text;

            MySqlParameter idQuiz = new MySqlParameter("@IdQuiz", MySqlDbType.Int32);
            MySqlParameter idUtilisateur = new MySqlParameter("@IdUtilisateur", MySqlDbType.Int32);

            idQuiz.Value = permission.idQuiz;
            idUtilisateur.Value = permission.idUtilisateur;
            cmd.Parameters.Add(idQuiz);
            cmd.Parameters.Add(idUtilisateur);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}