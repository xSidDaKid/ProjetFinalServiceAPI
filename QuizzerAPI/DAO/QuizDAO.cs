using QuizzerAPI.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace QuizzerAPI.DAO
{
    public class QuizDAO
    {
        public List<Quiz> GetAll()
        {
            DbConnection cnx = new MySqlConnection();

            cnx.ConnectionString = "server=localhost;port=3306;user=root;database=;";

            cnx.Open();

            DbCommand cmd = new MySqlCommand(); //Ou : MySqlCommand cmd = cnx.CreateCommand();
            cmd.Connection = cnx;
            return null;
        }
    }
}