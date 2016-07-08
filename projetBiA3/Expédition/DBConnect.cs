using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace Expédition
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
            database = "expedition";
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
