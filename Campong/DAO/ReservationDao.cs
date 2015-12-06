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
    public class ReservationDao
    {
        private static readonly String DATEFERME = "SELECT * FROM Reservation where dateFerme=0 and confirmation=1";
        private static readonly String GET_ALL_SQL = "SELECT * FROM Reservation where confirmation=0";
        private static readonly String CONFIRMATION = "UPDATE Reservation SET confirmation = 1  where id=@id";
        private static readonly String DATEFERMECHANGE = "UPDATE Reservation SET dateFin = @dateFin, dateFerme=1 where id=@id";

        public static void ConfirmationReservation(int id)
        {
            DataBase.getInstance().open();

            SqlCommand query = new SqlCommand(CONFIRMATION, DataBase.getInstance().getConnection());

            query.Parameters.AddWithValue("id", id);

            query.ExecuteNonQuery();

            DataBase.getInstance().close();
        }
        public static void DateFerme(int id,DateTime dateFin)
        {
            DataBase.getInstance().open();

            SqlCommand query = new SqlCommand(DATEFERMECHANGE, DataBase.getInstance().getConnection());

            query.Parameters.AddWithValue("dateFin", dateFin);
            query.Parameters.AddWithValue("id", id);

            query.ExecuteNonQuery();

            DataBase.getInstance().close();
        }

        public static Reservation[] getAll()
        {
            List<Reservation> reserv = new List<Reservation>();
            DataBase.getInstance().open();
            SqlCommand query = new SqlCommand(GET_ALL_SQL, DataBase.getInstance().getConnection());
            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {
                
                Reservation reservation = new Reservation(reader["mailCLient"].ToString(), (int)reader["numeroEmplacement"], (DateTime)reader["dateDeb"], (DateTime)reader["dateFin"], (bool)reader["dateFerme"], (int)reader["nbAdultes"], (int)reader["nbEnfants"],(int)reader["nbVehicule"],(bool)reader["electricite"]);
                reservation.Id = (int)reader["id"];
                reserv.Add(reservation);

            }

            reader.Close();
            DataBase.getInstance().close();
            return reserv.ToArray();
        }
        public static Reservation[] getAllReserv()
        {
            List<Reservation> reserv = new List<Reservation>();
            DataBase.getInstance().open();
            SqlCommand query = new SqlCommand(DATEFERME, DataBase.getInstance().getConnection());
            SqlDataReader reader = query.ExecuteReader();
            while (reader.Read())
            {

                Reservation reservation = new Reservation(reader["mailCLient"].ToString(), (int)reader["numeroEmplacement"], (DateTime)reader["dateDeb"], (DateTime)reader["dateFin"], (bool)reader["dateFerme"], (int)reader["nbAdultes"], (int)reader["nbEnfants"], (int)reader["nbVehicule"], (bool)reader["electricite"]);
                reservation.Id = (int)reader["id"];
                reserv.Add(reservation);

            }

            reader.Close();
            DataBase.getInstance().close();
            return reserv.ToArray();
        }
        public static void AjouterReservation(String mailClient, int numeroEmplacement,DateTime dateDeb,DateTime dateFin,bool dateFerme, int nbAdultes,int nbEnfants, int nbVehicule,bool electricite,bool confirmation)
        {
            DataBase.getInstance().open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = DataBase.getInstance().getConnection();
            sqlCommand.CommandText = "AjoutReservation";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add(new SqlParameter
            {
                ParameterName = "mailClient",
                Value = mailClient,
                SqlDbType = SqlDbType.VarChar
            });
            sqlCommand.Parameters.Add(new SqlParameter
            {
                ParameterName = "NumeroEmplacement",
                Value = numeroEmplacement,
                SqlDbType = SqlDbType.Int
            });
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
                ParameterName = "DateFerme",
                Value = dateFerme,
                SqlDbType = SqlDbType.Bit
            });
            sqlCommand.Parameters.Add(new SqlParameter
            {
                ParameterName = "nbAdultes",
                Value = nbAdultes,
                SqlDbType = SqlDbType.Int
            });
            sqlCommand.Parameters.Add(new SqlParameter
            {
                ParameterName = "nbEnfants",
                Value = nbEnfants,
                SqlDbType = SqlDbType.Int
            });
            sqlCommand.Parameters.Add(new SqlParameter
            {
                ParameterName = "NbVehicule",
                Value = nbVehicule,
                SqlDbType = SqlDbType.Int
            });
            sqlCommand.Parameters.Add(new SqlParameter
            {
                ParameterName = "Electricite",
                Value = electricite,
                SqlDbType = SqlDbType.Bit
            });
            sqlCommand.Parameters.Add(new SqlParameter
            {
                ParameterName = "Confirmation",
                Value = confirmation,
                SqlDbType = SqlDbType.Bit
            });
            sqlCommand.ExecuteNonQuery();

            DataBase.getInstance().close();
        }



        public static List<Emplacement> getListEmplacementsParDate(DateTime dateDeb,DateTime dateFin)
        {
            List<Emplacement> emplacements=new List<Emplacement>();
            DataBase.getInstance().open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = DataBase.getInstance().getConnection();
            sqlCommand.CommandText = "rechercheEmplacementsReservation";
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
           

            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Emplacement emplacement=new Emplacement(reader["type"].ToString(), (int)reader["surface"], (int)reader["nbPlaces"], (float)reader["prixBase"], (float)reader["prixEnfSup"], (float)reader["prixAdultSup"],(float)reader["prixVehicule"],(float)reader["prixElectricite"]);
                emplacement.Numero = (int)reader["numero"];
                emplacements.Add(emplacement);

            }

            reader.Close();
            DataBase.getInstance().close();
            return emplacements;
        }
      
    }
}