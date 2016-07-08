using Fabrication;
using Préparation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace Administration
{
    public class CommandeAdministration : Commande
    {
        #region Attributes
        private const int NOMBRE_DE_GENERATIONS = 10000;
        private static Random random = new Random();
        public enum Etat { Annule, EnCours, Termine, Livre };
        private static List<Client> listeClient = Client.GetClientsFromDataBase();
        #endregion

        public CommandeAdministration(List<ProduitAdministration> listProduitBDD)
        {
            Reference = RandomString();
            State = RandomEtat();
            Date = RandomDate(null);
            DatePrevisionnelle = RandomDate(Date, Date + new TimeSpan(10, 0, 0, 0));
            DateExpedition = RandomDate(Date, Date + new TimeSpan(random.Next(5, 15), 0, 0, 0));
            DateEffective = (State == Etat.Livre) ? (DateTime?)RandomDate(DateExpedition, DateExpedition + new TimeSpan(random.Next(1, 10), 0, 0, 0)) : null;
            DateDebut = Date;
            DateFin = DateExpedition;
            Temps = DateFin - DateDebut;
            RetourClientCommande = RandomInt(0, 6);
            ListProduit = RandomList(listProduitBDD);
            Prix = SommePrixProduits();
            IdClient = RandomIdClient();
        }

        #region Constructors

        public CommandeAdministration(bool selectFromDB)
        {

        }

        public CommandeAdministration()
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

        private static DateTime RandomDate(DateTime startDate, DateTime endDate)
        {
            TimeSpan timeSpan = endDate - startDate;
            TimeSpan newSpan = new TimeSpan(0, random.Next(0, (int)timeSpan.TotalMinutes), 0);
            return startDate + newSpan;
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


        private int RandomIdClient()
        {
            int randomIdClient = random.Next(0, listeClient.Count);
            int idClient = (int)listeClient[randomIdClient].Id;
            return idClient;
        }

        private List<ProduitAdministration> RandomList(List<ProduitAdministration> listProduitBDD)
        {
            List<ProduitAdministration> listProduit = new List<ProduitAdministration>();
            int length = random.Next(1, 10);
            for (int i = 0; i < length; i++)
            {
                int nombreProduits = random.Next(0, listProduitBDD.Count());
                listProduit.Add(listProduitBDD[nombreProduits]);
            }
            return listProduit;
        }
        #endregion

        #region Getters and setters
        public DateTime Date { get; set; }
        public DateTime DateExpedition { get; set; }
        public DateTime DatePrevisionnelle { get; set; }
        public DateTime? DateEffective { get; set; }
        public decimal Prix { get; set; }
        public Etat State { get; set; }
        public int RetourClientCommande { get; set; }
        public List<ProduitAdministration> ListProduit { get; set; }
        public int IdClient { get; set; }
        #endregion

        #region Methods for DB
        public static List<CommandeAdministration> GenerateRandomCommandes(int nombreCommandes)
        {
            //Administration
            List<CommandeAdministration> listeCommande = new List<CommandeAdministration>();
            List<ProduitAdministration> listeProduits = new List<ProduitAdministration>();
            listeProduits = ProduitAdministration.GetProduitsFromDataBase();
            for (int i = 0; i < nombreCommandes; i++)
            {
                listeCommande.Add(new CommandeAdministration(listeProduits));
            }

            foreach (CommandeAdministration com in listeCommande)
            {
                foreach (ProduitAdministration pro in com.ListProduit)
                {
                    pro.DateDebutAssemblage = RandomDate(com.Date, com.DatePrevisionnelle);
                    pro.DateFinAssemblage = RandomDate(pro.DateDebutAssemblage, com.DatePrevisionnelle);
                }
            }
            Administration.DBConnect connect = new Administration.DBConnect();
            var listFinaleCommande = listeCommande.Select(item => new { item.IdCommande, item.Reference, item.Date, item.DatePrevisionnelle, item.DateEffective, item.Prix, item.State, item.RetourClientCommande, item.IdClient });
            connect.InsertDT(CreateDataTable(listFinaleCommande), "commande");

            List<CommandeAdministration> listeCommandesFromDB = CommandeAdministration.GetCommandesFromDataBase(nombreCommandes);
            for (int i = 0; i < listeCommandesFromDB.Count(); i++)
            {
                listeCommandesFromDB[i].ListProduit = listeCommande[i].ListProduit;
                listeCommandesFromDB[i].RetourClientCommande = listeCommande[i].RetourClientCommande;
            }

            foreach (var commande in listeCommandesFromDB)
            {
                List<KeyValuePair<int, int>> contient = new List<KeyValuePair<int, int>>();
                foreach (var produit in commande.ListProduit)
                    contient.Add(new KeyValuePair<int, int>((int)produit.Id, commande.IdCommande));

                connect.InsertDT(Commande.CreateDataTable(contient), "contient");
            }

            //Fabrication
            List<Produit> listePro = new List<Produit>();
            foreach (CommandeAdministration commande in listeCommande)
            {
                foreach (ProduitAdministration proA in commande.ListProduit)
                {
                    Produit tempPro = new Produit(true);
                    tempPro.Nom = proA.Nom;
                    tempPro.Prix = proA.Prix;
                    tempPro.ListPiece = proA.ListPiece;
                    tempPro.LigneProduit = proA.LigneProduit;
                    tempPro.Reference = proA.Reference;
                    tempPro.RetourClient = proA.RetourClient;
                    tempPro.Stock = proA.Stock + commande.State == Etat.Annule ? 1 : 0;
                    tempPro.DateDebutAssemblage = proA.DateDebutAssemblage;
                    tempPro.DateFinAssemblage = proA.DateFinAssemblage;
                    listePro.Add(tempPro); //on cast les ProduitAdministration en Produits, pour les passer en Fabrication
                }
            }

            Produit.MakeProduit(listePro);

            //Expédition
            var listFinaleCommandeExpedition = listeCommande.Select(item => new { item.IdCommande, item.Reference, item.Date, item.DateExpedition, item.IdClient });
            Expédition.DBConnect connectExpe = new Expédition.DBConnect();
            connectExpe.InsertDT(CreateDataTable(listFinaleCommandeExpedition), "commande");

            //Préparation
            var listFinaleCommandePreparation = listeCommande.Select(item => new { item.IdCommande, item.Reference, item.Temps, item.DateDebut, item.DateFin });
            Préparation.DBConnect connectPrep = new Préparation.DBConnect();
            connectPrep.InsertDT(CreateDataTable(listFinaleCommandePreparation), "commande");

            List<Commande> listeCommandesFromDBPrep = Commande.GetCommandesFromDataBase(nombreCommandes);
            List<CommandeAdministration> listFinaleCommandePrep = new List<CommandeAdministration>();
            foreach (var commande in listeCommandesFromDBPrep)
            {
                CommandeAdministration ca = new CommandeAdministration();
                ca.IdCommande = commande.IdCommande;
                ca.ListProduit = listeCommande.Where(o => o.Reference == commande.Reference).First().ListProduit;
                listFinaleCommandePrep.Add(ca);
            }
            foreach (var commande in listFinaleCommandePrep)
            {
                List<KeyValuePair<int, int>> contient = new List<KeyValuePair<int, int>>();
                foreach (var produit in commande.ListProduit)
                    contient.Add(new KeyValuePair<int, int>(commande.IdCommande, (int)produit.Id));

                connectPrep.InsertDT(Commande.CreateDataTable(contient), "contient");
            }

            return listeCommande;
        }

        public static List<CommandeAdministration> GetCommandesFromDataBase()
        {
            List<CommandeAdministration> listeCommandes = new List<CommandeAdministration>();

            Administration.DBConnect connect = new Administration.DBConnect();
            listeCommandes = connect.SelectCommande();

            return listeCommandes;
        }

        public static new List<CommandeAdministration> GetCommandesFromDataBase(int nombreCommandes)
        {
            List<CommandeAdministration> listeCommandes = new List<CommandeAdministration>();

            DBConnect connect = new DBConnect();
            listeCommandes = connect.SelectCommande(nombreCommandes);

            return listeCommandes;
        }
        #endregion
    }
}