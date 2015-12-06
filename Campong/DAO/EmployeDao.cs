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
    public class EmployeDao
    {
        private static readonly String ADD_SQL = "INSERT  INTO Employe(nomUtilisateur,nom,prenom,mdpEmploye,affectation) VALUES (@nomUtilisateur,@nom,@prenom,@mdpEmploye,@affectation)";
        private static readonly String GET_ALL_SQL = "SELECT * FROM Employe";
        private static readonly String DELETE_SQL = "DELETE FROM Employe where nomUtilisateur=@nomUtilisateur";
        private static readonly String MODIFIER_SQL = "UPDATE Employe SET nom=@nom,prenom=@prenom,mdpEmploye=@mdpEmploye,affectation=@affectation where nomUtilisateur=@nomUtilisateur";

        public static Employe RechercheEmploye(String nomUtilisateur)
        {
            DataBase.getInstance().open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = DataBase.getInstance().getConnection();
            sqlCommand.CommandText = "rechercheEmploye";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add(new SqlParameter
            {
                ParameterName = "NomUtilisateur",
                Value = nomUtilisateur,
                SqlDbType = SqlDbType.VarChar
            });
            SqlDataReader reader = sqlCommand.ExecuteReader();
            Employe employe = new Employe();
            bool empl = false;
            while (reader.Read())
            {
                empl = true;
                employe = new Employe(reader["NomUtilisateur"].ToString(), reader["Nom"].ToString(), reader["Prenom"].ToString(), reader["MdpEmploye"].ToString(), reader["Affectation"].ToString());
            }
            reader.Close();
            DataBase.getInstance().close();
            if (empl)
            {
                return employe;
            }
            return null;
        }
        public static void add(Employe employe)
        {
            DataBase.getInstance().open();

            SqlCommand query = new SqlCommand(ADD_SQL, DataBase.getInstance().getConnection());
            query.Parameters.AddWithValue("nomUtilisateur",employe.NomUtilisateur);
            query.Parameters.AddWithValue("nom", employe.Nom);
            query.Parameters.AddWithValue("prenom", employe.Prenom);
            query.Parameters.AddWithValue("mdpEmploye", employe.MdpEmploye);
            query.Parameters.AddWithValue("affectation", employe.Affectation);
           
            query.ExecuteNonQuery();

            DataBase.getInstance().close();
        }
        public static Employe[] getAll()
        {
            List<Employe> employes = new List<Employe>();
            DataBase.getInstance().open();
            SqlCommand query = new SqlCommand(GET_ALL_SQL, DataBase.getInstance().getConnection());
            SqlDataReader reader = query.ExecuteReader();

            while (reader.Read())
            {
                Employe employe = new Employe(reader["nomUtilisateur"].ToString(),reader["nom"].ToString(), reader["prenom"].ToString(), reader["mdpEmploye"].ToString(), reader["affectation"].ToString());

                employes.Add(employe);

            }

            reader.Close();
            DataBase.getInstance().close();
            return employes.ToArray();
        }

        public static void delete(String nomUtilisateur)
        {
            DataBase.getInstance().open();
            SqlCommand query = new SqlCommand(DELETE_SQL, DataBase.getInstance().getConnection());
            query.Parameters.AddWithValue("nomUtilisateur", nomUtilisateur);
            query.ExecuteNonQuery();
            DataBase.getInstance().close();
        }

        public static void modifier(String nomUtilisateur, Employe employe)
        {
            DataBase.getInstance().open();

            SqlCommand query = new SqlCommand(MODIFIER_SQL, DataBase.getInstance().getConnection());

            query.Parameters.AddWithValue("NomUtilisateur", employe.NomUtilisateur);
            query.Parameters.AddWithValue("nom", employe.Nom);
            query.Parameters.AddWithValue("prenom", employe.Prenom);
            query.Parameters.AddWithValue("mdpEmploye", employe.MdpEmploye);
            query.Parameters.AddWithValue("affectation", employe.Affectation);
            
            query.ExecuteNonQuery();

            DataBase.getInstance().close();

        }
    }
}
