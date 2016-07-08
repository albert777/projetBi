using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Préparation
{
    public class Commande
    {
        public int IdCommande { get; set; }
        public string Reference { get; set; }
        public TimeSpan Temps { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }

        public static DataTable CreateDataTable<T>(IEnumerable<T> list)
        {
            Type type = typeof(T);
            var properties = type.GetProperties();

            DataTable dt = new DataTable();
            foreach (PropertyInfo info in properties)
            {
                dt.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
            }

            foreach (T entity in list)
            {
                object[] value = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    value[i] = properties[i].GetValue(entity);
                }
                dt.Rows.Add(value);
            }
            return dt;
        }

        public static List<Commande> GetCommandesFromDataBase(int nombreDeCommandes)
        {
            List<Commande> listeCommandes = new List<Commande>();

            DBConnect connect = new DBConnect();
            listeCommandes = connect.SelectCommande(nombreDeCommandes);

            return listeCommandes;
        }
    }
}
