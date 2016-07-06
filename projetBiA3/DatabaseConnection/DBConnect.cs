using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DBConnect
{
    public class DatabaseConnexion
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string pasword;

        public DBConnect()
        {
            Initialize();
        }

        private void Initialize()
        {
            server = "localhost";
            database = "administration";
            uid = "root";
            password = "root";
            string ConnectionString;
            ConnectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(ConnectionString);
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch(MySqlException ex)
            {
                return false;
            }
        }
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch(MySqlException ex)
            {
                return false;
            }
        }

        public void Insert()
        {
            string query = "INSERT INTO Client (Nom_Client, Prenom_Client, Civilite_Client, Age_Client, Adresse_Client, Ville_Client, Pays_Client) VALUES"
        }

        pubic void Delete()
        {

        }

        public List<string> [] Select()
        {

        }

        public int Count()
        {

        }

        public void Backup()
        {

        }

        public void Restore()
        {

        }
    }
}
