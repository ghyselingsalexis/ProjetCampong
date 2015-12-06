using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Campong.Models
{
    public class DataBase
    {
        private static DataBase instance;
        private SqlConnection connection;
        private readonly String cDC = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='D:\Ecole\C#\github\Campong\Campong\App_Data\Campong.mdf';Integrated Security=True";

        private DataBase()
        {
            connection = new SqlConnection(cDC);
        }

        public static DataBase getInstance()
        {
            if (instance == null)
            {
                instance = new DataBase();
            }
            return instance;
        }
        public void open()
        {
            getInstance().connection.Open();
        }
        public void close()
        {
            getInstance().connection.Close();
        }
        public SqlConnection getConnection()
        {
            return connection;
        }
    }
}
