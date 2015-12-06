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
    public class ClientDao
    {
        public static Client RechercheClient(String mailClient)
        {
            DataBase.getInstance().open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = DataBase.getInstance().getConnection();
            sqlCommand.CommandText = "RechercheClient";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add(new SqlParameter
            {
                ParameterName = "mailClient",
                Value = mailClient,
                SqlDbType = SqlDbType.VarChar
            });
            SqlDataReader reader = sqlCommand.ExecuteReader();
            Client client=new Client();
            bool cli=false;
            while (reader.Read())
            {
                cli = true;
                client = new Client(reader["AdresseMail"].ToString(), reader["Nom"].ToString(), reader["Prenom"].ToString(), reader["AdressePostale"].ToString(), reader["NumeroTel"].ToString(), reader["MdpClient"].ToString(), (DateTime)reader["DateNaissance"]);
            }
            reader.Close();
            DataBase.getInstance().close();
            if (cli)
            {
                return client;
            }
            return null;
        }

        public static void AjouterClient(String mailClient, string nom, string prenom, string adressePostale, string numeroTel, string mdpClient, DateTime dateNaissance)
        {
            DataBase.getInstance().open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = DataBase.getInstance().getConnection();
            sqlCommand.CommandText = "ajoutClient";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add(new SqlParameter
            {
                ParameterName = "mailClient",
                Value = mailClient,
                SqlDbType = SqlDbType.VarChar
            });
            sqlCommand.Parameters.Add(new SqlParameter
            {
                ParameterName = "nom",
                Value = nom,
                SqlDbType = SqlDbType.VarChar
            });
            sqlCommand.Parameters.Add(new SqlParameter
            {
                ParameterName = "prenom",
                Value = prenom,
                SqlDbType = SqlDbType.VarChar
            });
            sqlCommand.Parameters.Add(new SqlParameter
            {
                ParameterName = "adressePostale",
                Value = adressePostale,
                SqlDbType = SqlDbType.VarChar
            });
            sqlCommand.Parameters.Add(new SqlParameter
            {
                ParameterName = "numeroTel",
                Value = numeroTel,
                SqlDbType = SqlDbType.VarChar
            });
            sqlCommand.Parameters.Add(new SqlParameter
            {
                ParameterName = "mdpClient",
                Value = mdpClient,
                SqlDbType = SqlDbType.VarChar
            });
            sqlCommand.Parameters.Add(new SqlParameter
            {
                ParameterName = "dateNaissance",
                Value = dateNaissance,
                SqlDbType = SqlDbType.DateTime
            });
            sqlCommand.ExecuteNonQuery();

            DataBase.getInstance().close();
        }
    }
}