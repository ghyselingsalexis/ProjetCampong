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
    public class EmplacementDao
    {
        private static readonly String ADD_SQL = "INSERT  INTO Emplacement(type,surface,nbPlaces,prixBase,prixEnfSup,prixAdultSup,prixVehicule,prixElectricite) VALUES (@type,@surface,@nbPlaces,@prixBase,@prixEnfSup,@prixAdultSup,@prixVehicule,@prixElectricite)";
        private static readonly String GET_ALL_SQL = "SELECT * FROM Emplacement";
        private static readonly String DELETE_SQL = "DELETE FROM Emplacement where numero=@numero";
        private static readonly String MODIFIER_SQL = "UPDATE Emplacement SET type=@type,surface=@surface,nbPlaces=@nbPlaces,prixBase=@prixBase,prixEnfSup=@prixEnfSup,prixAdultSup=@prixAdultSup, dateDebMaintenance=@dateDebMaintenance,dateFinMaintenance=@dateFinMaintenance, prixVehicule=@prixVehicule,prixElectricite=@prixElectricite where numero=@numero";
        private static readonly String MODIFIER_SANS_DATE_SQL = "UPDATE Emplacement SET type=@type,surface=@surface,nbPlaces=@nbPlaces,prixBase=@prixBase,prixEnfSup=@prixEnfSup,prixAdultSup=@prixAdultSup ,dateDebMaintenance=null,dateFinMaintenance=null , prixVehicule=@prixVehicule,prixElectricite=@prixElectricite where numero=@numero";


        public static void add(Emplacement emplacement)
        {
            DataBase.getInstance().open();

            SqlCommand query = new SqlCommand(ADD_SQL, DataBase.getInstance().getConnection());
            query.Parameters.AddWithValue("type", emplacement.Type);
            query.Parameters.AddWithValue("surface", emplacement.Surface);
            query.Parameters.AddWithValue("nbPlaces", emplacement.NbPlaces);
            query.Parameters.AddWithValue("prixBase", emplacement.PrixBase);
            query.Parameters.AddWithValue("prixEnfSup", emplacement.PrixEnfSup);
            query.Parameters.AddWithValue("prixAdultSup", emplacement.PrixAdultSup);
            query.Parameters.AddWithValue("prixVehicule", emplacement.PrixVehicule);
            query.Parameters.AddWithValue("prixElectricite", emplacement.PrixElectricite);
            query.ExecuteNonQuery();

            DataBase.getInstance().close();
        }
        public static Emplacement[] getAll()
        {
            List<Emplacement> emplacements = new List<Emplacement>();
            DataBase.getInstance().open();
            SqlCommand query = new SqlCommand(GET_ALL_SQL, DataBase.getInstance().getConnection());
            SqlDataReader reader = query.ExecuteReader();

            while (reader.Read())
            {
                if (reader["dateDebMaintenance"].ToString() == "" || reader["dateFinMaintenance"].ToString() == "")
                {
                    Emplacement emplace = new Emplacement(reader["type"].ToString(), (int)reader["surface"], (int)reader["nbPlaces"], (float)reader["prixBase"], (float)reader["prixEnfSup"], (float)reader["prixAdultSup"], (float)reader["prixVehicule"], (float)reader["prixElectricite"]);
                    emplace.Numero = (int)reader["numero"];
                    emplacements.Add(emplace);
                }
                else
                {
                    Emplacement emplace = new Emplacement(reader["type"].ToString(), (int)reader["surface"], (int)reader["nbPlaces"], (float)reader["prixBase"], (float)reader["prixEnfSup"], (float)reader["prixAdultSup"], (DateTime)reader["dateDebMaintenance"], (DateTime)reader["dateFinMaintenance"], (float)reader["prixVehicule"], (float)reader["prixElectricite"]);
                    emplace.Numero = (int)reader["numero"];
                    emplacements.Add(emplace);
                }

            }

            reader.Close();
            DataBase.getInstance().close();
            return emplacements.ToArray();
        }

        public static void delete(int numero)
        {
            DataBase.getInstance().open();
            SqlCommand query = new SqlCommand(DELETE_SQL, DataBase.getInstance().getConnection());
            query.Parameters.AddWithValue("numero", numero);
            query.ExecuteNonQuery();
            DataBase.getInstance().close();
        }

        public static List<Emplacement> getEmplacementsMaintenance(DateTime dateDeb, DateTime dateFin, int id)
        {
            List<Emplacement> emplacements = new List<Emplacement>();
            DataBase.getInstance().open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = DataBase.getInstance().getConnection();
            sqlCommand.CommandText = "rechercheEmplacementsMaintenance";
            sqlCommand.CommandType = CommandType.StoredProcedure;
          
            sqlCommand.Parameters.Add(new SqlParameter
            {
                ParameterName = "DateDeb",
                Value = dateDeb,
                SqlDbType = SqlDbType.Date
            });
            sqlCommand.Parameters.Add(new SqlParameter
            {
                ParameterName = "DateFin",
                Value = dateFin,
                SqlDbType = SqlDbType.Date
            });
             sqlCommand.Parameters.Add(new SqlParameter
            {
                ParameterName = "Id",
                Value = id,
                SqlDbType = SqlDbType.Int
            });
            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Emplacement emplacement = new Emplacement(reader["type"].ToString(), (int)reader["surface"], (int)reader["nbPlaces"], (float)reader["prixBase"], (float)reader["prixEnfSup"], (float)reader["prixAdultSup"], (float)reader["prixVehicule"], (float)reader["prixElectricite"]);
                emplacement.Numero = (int)reader["numero"];
                emplacements.Add(emplacement);

            }

            reader.Close();
            DataBase.getInstance().close();
            return emplacements;
        }

    

    public static void modifier(int numero , Emplacement emplacement)
        {
            DataBase.getInstance().open();

            SqlCommand query;
            var dateDeb = emplacement.DateDebMaintenance;
            DateTime dt = Convert.ToDateTime("01-02-2000");
            if (emplacement.DateDebMaintenance==dt)
            {
                 query = new SqlCommand(MODIFIER_SANS_DATE_SQL, DataBase.getInstance().getConnection());
                query.Parameters.AddWithValue("type", emplacement.Type);
                query.Parameters.AddWithValue("surface", emplacement.Surface);
                query.Parameters.AddWithValue("nbPlaces", emplacement.NbPlaces);
                query.Parameters.AddWithValue("prixBase", emplacement.PrixBase);
                query.Parameters.AddWithValue("prixEnfSup", emplacement.PrixEnfSup);
                query.Parameters.AddWithValue("prixAdultSup", emplacement.PrixAdultSup);
                query.Parameters.AddWithValue("prixVehicule", emplacement.PrixVehicule);
                query.Parameters.AddWithValue("prixElectricite", emplacement.PrixElectricite);

            }
            else
            {
                query = new SqlCommand(MODIFIER_SQL, DataBase.getInstance().getConnection());
                query.Parameters.AddWithValue("type", emplacement.Type);
                query.Parameters.AddWithValue("surface", emplacement.Surface);
                query.Parameters.AddWithValue("nbPlaces", emplacement.NbPlaces);
                query.Parameters.AddWithValue("prixBase", emplacement.PrixBase);
                query.Parameters.AddWithValue("prixEnfSup", emplacement.PrixEnfSup);
                query.Parameters.AddWithValue("prixAdultSup", emplacement.PrixAdultSup);
                query.Parameters.AddWithValue("dateDebMaintenance", emplacement.DateDebMaintenance);
                 query.Parameters.AddWithValue("dateFinMaintenance", emplacement.DateFinMaintenance);
                query.Parameters.AddWithValue("prixVehicule", emplacement.PrixVehicule);
                query.Parameters.AddWithValue("prixElectricite", emplacement.PrixElectricite);
            }
            
            query.Parameters.AddWithValue("numero", numero);           
            query.ExecuteNonQuery();

            DataBase.getInstance().close();

        }
    }

}
