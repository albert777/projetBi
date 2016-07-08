using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using Fabrication;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;

namespace Fabrication
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
            database = "fabrication";
            uid = "root";
            password = "Azerty123@";
            string ConnectionString;
            ConnectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(ConnectionString);
        }

        public List<Produit> SelectProduits()
        {
            List<Produit> listeProduit = new List<Produit>();
            string query = "SELECT * FROM Produit";

            if(OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while(dataReader.Read())
                {
                    Produit pro = new Produit(true);
                    pro.Nom = dataReader["Nom_Produit"].ToString();
                    pro.Reference = dataReader["Reference_Produit"].ToString();
                    pro.Prix = Convert.ToDecimal(dataReader["Prix_Produit"]);
                    pro.DateDebutAssemblage = Convert.ToDateTime(dataReader["Date_Debut_Assemblage_Produit"]);
                    pro.DateFinAssemblage = Convert.ToDateTime(dataReader["Date_Fin_Assemblage_Produit"]);
                    pro.Stock = Convert.ToInt32(dataReader["Stock_Produit"]);
                    pro.LigneProduit = dataReader["Ligne_Produit"].ToString();
                    listeProduit.Add(pro);
                }
                CloseConnection();
            }
            return listeProduit;
        }

        public List<Machine> SelectMachine()
        {
            List<Machine> listeMachine = new List<Machine>();
            string query = "SELECT * FROM machine";

            if(OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    //    Machine_Conditionnement machineCond = new Machine_Conditionnement();
                    //    Machine_Fabrication machineFab = new Machine_Fabrication();
                    Machine machine = new Machine();
                    machine.ID = Convert.ToInt32(dataReader["Id_Machine"]);
                    machine.TypeMachine = dataReader["Type_Machine"].ToString();
                    machine.ProduitsFabriques = Convert.ToInt32(dataReader["Produits_Fabriques_Machine"]);
                    
                    listeMachine.Add(machine);
                }

                CloseConnection();
            }

            return listeMachine;
        }

        public void InsertEventInDatabase(DataTable dataTable, string tableName)
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
            //File.Delete(TempCSVFile);
            connection.Close();
        }

        public void InsertInDatabase(DataTable dataTable, string tableName)
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

        public int CountInDataBase(string tableName)
        {
            int compte = 0;
            string query = "SELECT COUNT(*) FROM " + tableName;

            if(OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                compte = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return compte;
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

        #endregion




    }

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

}
