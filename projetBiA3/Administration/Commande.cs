using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Administration
{
    public class Commande
    {
        #region Attributes
        private const int NOMBRE_DE_GENERATIONS = 10000;
        private static Random random = new Random();
        private static List<Client> listeClient = Client.GetClientsFromDataBase();
        public enum Etat { Annule, EnCours, Termine, Livre };
        #endregion

        #region Constructors
        public Commande(List<Produit> listProduitBDD)
        {
            Reference = RandomString();
            State = RandomEtat();
            Date = RandomDate(null);
            DatePrevisionnelle = RandomDate(Date);
            DateEffective = (State == Etat.Livre) ? (DateTime?)RandomDate(Date) : null;
            RetourClientCommande = RandomInt(0, 6);
            ListProduit = RandomList(listProduitBDD);
            Prix = SommePrixProduits();
            IdClient = RandomIdClient();
        }
        public Commande(bool selectFromDB)
        {

        }

        public Commande()
        {

        }
        #endregion

        #region Random methods
        private string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 10)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private DateTime RandomDate(DateTime? DateCommande)
        {
            DateTime start = (DateCommande == null) ? new DateTime(2016, 4, 1) : (DateTime)DateCommande;
            int range = ((DateTime.Today - start).Days) + ((Date == null) ? 0 : 30);
            return start.AddDays(random.Next(range));
        }

        private int RandomInt(int min, int max)
        {
            return random.Next(min, max);
        }

        private Etat RandomEtat()
        {
            Array values = Enum.GetValues(typeof(Etat));
            return (Etat)values.GetValue(random.Next(values.Length));
        }

        private decimal SommePrixProduits()
        {
            return Math.Round(ListProduit.Select(p => p.Prix).Sum());
        }

        private List<Produit> RandomList(List<Produit> listProduitBDD)
        {
            List<Produit> listProduit = new List<Produit>();
            int length = random.Next(1, 10);
            for (int i = 0; i < length; i++)
            {
                int nombreProduits = random.Next(0, listProduitBDD.Count());
                listProduit.Add(listProduitBDD[nombreProduits]);
            }
            return listProduit;
        }
        private int RandomIdClient()
        {
            int randomIdClient = random.Next(0, listeClient.Count);
            int idClient = (int)listeClient[randomIdClient].Id;
            return idClient;
        }
        #endregion

        #region Getters and setters
        public int IdCommande { get; set; }
        public string Reference { get; set; }
        public DateTime Date { get; set; }
        public DateTime? DatePrevisionnelle { get; set; }
        public DateTime? DateEffective { get; set; }
        public decimal Prix { get; set; }
        public Etat State { get; set; }
        public int RetourClientCommande { get; set; }
        public List<Produit> ListProduit { get; set; }
        public int IdClient { get; set; }
        #endregion

        #region Methods for DB

        public static List<Commande> GenerateRandomCommandes()
        {
            List<Commande> listeCommande = new List<Commande>();
            List<Produit> listeProduits = new List<Produit>();
            listeProduits = Produit.GetProduitsFromDataBase();
            for (int i = 0; i < NOMBRE_DE_GENERATIONS; i++)
            {
                listeCommande.Add(new Commande(listeProduits));
            }
            DBConnect.DBConnect connect = new DBConnect.DBConnect();
            var listFinaleCommande = listeCommande.Select(item => new { item.IdCommande, item.Reference, item.Date, item.DatePrevisionnelle, item.DateEffective, item.Prix, item.State, item.IdClient });
            connect.InsertDT(CreateDataTable(listFinaleCommande), "commande");
            return listeCommande;
        }

        public static List<Commande> GetCommandesFromDataBase()
        {
            List<Commande> listeCommandes = new List<Commande>();

            DBConnect.DBConnect connect = new DBConnect.DBConnect();
            listeCommandes = connect.SelectCommande();

            return listeCommandes;
        }
        #endregion

        #region DataTable
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
        #endregion
    }
}
