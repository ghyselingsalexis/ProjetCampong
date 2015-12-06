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
    public class AdministrateurDao
    {
        public static Administrateur RechercheAdministrateur(String nomUtilisateur)
        {
            DataBase.getInstance().open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = DataBase.getInstance().getConnection();
            sqlCommand.CommandText = "rechercheAdministrateur";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add(new SqlParameter
            {
                ParameterName = "NomUtilisateur",
                Value = nomUtilisateur,
                SqlDbType = SqlDbType.VarChar
            });
            SqlDataReader reader = sqlCommand.ExecuteReader();
            Administrateur administrateur = new Administrateur();
            bool admin = false;
            while (reader.Read())
            {
                admin = true;
                administrateur = new Administrateur(reader["NomUtilisateur"].ToString(), reader["Nom"].ToString(), reader["Prenom"].ToString(), reader["MdpAdministrateur"].ToString());
            }
            reader.Close();
            DataBase.getInstance().close();
            if (admin)
            {
                return administrateur;
            }
            return null;
        }
    }
}