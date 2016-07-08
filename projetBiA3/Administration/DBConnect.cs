using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;

namespace Administration
{
    public class DBConnect
    {
        #region Attributes
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        #endregion

        public DBConnect()
        {
            Initialize();
        }

        private void Initialize()
        {
            server = "localhost";
            database = "administration";
            uid = "root";
            password = "Azerty123@";
            string ConnectionString;
            ConnectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";Convert Zero Datetime=True;Allow Zero Datetime=True";

            connection = new MySqlConnection(ConnectionString);
        }

        #region Manage connection
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Data);
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
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Data);
                return false;
            }
        }
        #endregion

        #region Select from DB
        public List<Client> SelectClient()
        {
            List<Client> listeClient = new List<Client>();
            string query = "SELECT * FROM Client";
            if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Client cli = new Client(true);
                    cli.Id = Convert.ToInt32(dataReader["Id_Client"]);
                    cli.Nom = dataReader["Nom_Client"].ToString();
                    cli.Prenom = dataReader["Prenom_Client"].ToString();
                    cli.Civilite = dataReader["Civilite_Client"].ToString();
                    cli.Age = Convert.ToInt32(dataReader["Age_Client"]);
                    cli.Adresse = dataReader["Adresse_Client"].ToString();
                    cli.Ville = dataReader["Ville_Client"].ToString();
                    cli.Pays = dataReader["Pays_Client"].ToString();
                    listeClient.Add(cli);
                }
            }
            return listeClient;
        }

        public List<ProduitAdministration> SelectProduits()
        {
            List<ProduitAdministration> listeProduit = new List<ProduitAdministration>();
            string query = "SELECT * FROM Produits";
            if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    ProduitAdministration pro = new ProduitAdministration(true);
                    pro.Id = Convert.ToInt32(dataReader["Id_Produit"].ToString());
                    pro.Nom = dataReader["Nom_Produit"].ToString();
                    pro.Reference = dataReader["Reference_Produit"].ToString();
                    pro.Prix = Convert.ToDecimal(dataReader["Prix_Produit"].ToString());
                    listeProduit.Add(pro);
                }
            }
            return listeProduit;
        }

        public List<CommandeAdministration> SelectCommande()
        {
            List<CommandeAdministration> listeCommande = new List<CommandeAdministration>();
            string query = "SELECT * FROM Commande";
            if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    CommandeAdministration com = new CommandeAdministration(true);
                    com.Reference = dataReader["Reference_Commande"].ToString();
                    com.Date = Convert.ToDateTime(dataReader["Date_Commande"]);
                    com.DatePrevisionnelle = Convert.ToDateTime(dataReader["Date_Livraison_Previsionnelle_Commande"]);
                    com.DateEffective = dataReader["Date_Livraison_Effective_Commande"] as DateTime?;
                    com.Prix = Convert.ToDecimal(dataReader["Prix_Commande"]);
                    com.State = (CommandeAdministration.Etat)dataReader["Etat_Commande"];
                    com.IdClient = Convert.ToInt32(dataReader["Id_Client"]);
                    listeCommande.Add(com);
                }
            }
            return listeCommande;
        }

        public List<CommandeAdministration> SelectCommande(int nombreCommandes)
        {
            List<CommandeAdministration> listeCommande = new List<CommandeAdministration>();
            string query = "SELECT * FROM Commande ORDER BY Id_Commande DESC LIMIT " + nombreCommandes;
            if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    CommandeAdministration com = new CommandeAdministration(true);
                    com.IdCommande = Convert.ToInt32(dataReader["Id_Commande"].ToString());
                    com.Reference = dataReader["Reference_Commande"].ToString();
                    com.Date = Convert.ToDateTime(dataReader["Date_Commande"]);
                    com.DatePrevisionnelle = Convert.ToDateTime(dataReader["Date_Livraison_Previsionnelle_Commande"]);
                    com.DateEffective = dataReader["Date_Livraison_Effective_Commande"] as DateTime?;
                    com.Prix = Convert.ToDecimal(dataReader["Prix_Commande"]);
                    com.State = (CommandeAdministration.Etat)dataReader["Etat_Commande"];
                    com.RetourClientCommande = Convert.ToInt32(dataReader["Retour_Client_Commande"]);
                    com.IdClient = Convert.ToInt32(dataReader["Id_Client"]);
                    listeCommande.Add(com);
                }
            }
            return listeCommande;
        }
        #endregion

        #region Insert to DB
        public void InsertDT(DataTable dataTable, string tableName)
        {
            connection.Open();

            string TempCSVFile = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\dump.csv";
            using (StreamWriter writer = new StreamWriter(TempCSVFile))
            {
                Rfc4180Writer.WriteDataTable(dataTable, writer, false);
            }

            var msbl = new MySqlBulkLoader(connection);
            string query = "SET FOREIGN_KEY_CHECKS=0;";
            new MySqlCommand(query, connection);
            msbl.TableName = tableName;
            msbl.FileName = TempCSVFile;
            msbl.FieldTerminator = ",";
            msbl.FieldQuotationCharacter = '"';
            msbl.Load();
            File.Delete(TempCSVFile);

            connection.Close();
        }
        #endregion
    }
    #region DataTable writer class
    public static class Rfc4180Writer
    {
        public static void WriteDataTable(DataTable sourceTable, TextWriter writer, bool includeHeaders)
        {
            if (includeHeaders)
            {
                IEnumerable<String> headerValues = sourceTable.Columns
                    .OfType<DataColumn>()
                    .Select(column => QuoteValue(column.ColumnName));

                writer.WriteLine(String.Join(",", headerValues));
            }

            IEnumerable<String> items = null;

            foreach (DataRow row in sourceTable.Rows)
            {
                items = row.ItemArray.Select(o => o.ToString());
                List<string> newItems = items.ToList();
                DateTime dateValue;
                //Check if DateTime to convert it into MySql format
                for (int i = 0; i < items.Count(); i++)
                    if (DateTime.TryParse(newItems[i], out dateValue))
                        newItems[i] = dateValue.ToString("yyyy-MM-dd HH:mm:ss");
                    else if (newItems[i] == "")
                        newItems[i] = null;
                writer.WriteLine(String.Join(",", newItems));
            }

            writer.Flush();
        }

        private static string QuoteValue(string value)
        {
            return String.Concat("\"",
            value.Replace("\"", "\"\""), "\"");
        }
    }
    #endregion
}