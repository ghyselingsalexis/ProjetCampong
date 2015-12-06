using Campong.Modele;
using Campong.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Campong.DAO
{
    public class LivreOrDao
    {
        public static List<LivreOrClient> getAll()
        {
            List<LivreOrClient> livres = new List<LivreOrClient>();
            DataBase.getInstance().open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = DataBase.getInstance().getConnection();
            sqlCommand.CommandText = "rechercheLivreOr";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                LivreOrClient livre = new LivreOrClient((DateTime)reader["DateRedaction"], reader["Texte"].ToString(),reader["Nom"].ToString(),reader["Prenom"].ToString());
                livre.Id = (int)reader["Id"];
                livre.MailClient = reader["MailClient"].ToString();
                livres.Add(livre);
            }

            reader.Close();
            DataBase.getInstance().close();
            return livres;
        }

        public static void add(String mailClient,DateTime dateRedaction,String texte)
        {
            DataBase.getInstance().open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = DataBase.getInstance().getConnection();
            sqlCommand.CommandText = "ajoutLivreOr";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add(new SqlParameter
            {
                ParameterName = "mailClient",
                Value = mailClient,
                SqlDbType = SqlDbType.VarChar
            });
            sqlCommand.Parameters.Add(new SqlParameter
            {
                ParameterName = "dateRedaction",
                Value = dateRedaction,
                SqlDbType = SqlDbType.DateTime
            });
            sqlCommand.Parameters.Add(new SqlParameter
            {
                ParameterName = "texte",
                Value = texte,
                SqlDbType = SqlDbType.VarChar
            });

            sqlCommand.ExecuteNonQuery();

            DataBase.getInstance().close();
        }
    }
}