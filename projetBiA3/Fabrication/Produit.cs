using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Fabrication
{
    public class Produit
    {
        #region Constructor
        public Produit(bool isFromDatabase) { }
        #endregion

        #region Attributes
        private static Random random = new Random();
        public int? Id { get; set; }
        public string Nom { get; set; }
        public string Reference { get; set; }
        public decimal Prix { get; set; }
        public DateTime DateDebutAssemblage { get; set; }
        public DateTime DateFinAssemblage { get; set; }
        public int Stock { get; set; }
        public string LigneProduit { get; set; }
        public List<Piece> ListPiece { get; set; }
        public int RetourClient { get; set; }
        #endregion

        #region Methods
        public static List<Produit> GetProduitsFromDataBase()
        {
            DBConnect connect = new DBConnect();
            List<Produit> listeProduits = connect.SelectProduits();
            return listeProduits;
        }

        public static void MakeProduit(List<Produit> listePro)
        {
            DBConnect connect = new DBConnect();

            List<Machine> listeMachines = connect.SelectMachine();
            List<Machine_Conditionnement> listeCond = new List<Machine_Conditionnement>();
            List<Evenement> listeEvenement = new List<Evenement>();
            foreach (Machine machine in listeMachines)
            {
                if(machine.TypeMachine.Contains("Conditionnement"))
                {
                    Machine_Conditionnement machCond = new Machine_Conditionnement();
                    machCond.ID = machine.ID;
                    machCond.TypeMachine = machine.TypeMachine;
                    machCond.ProduitsFabriques = machine.ProduitsFabriques;
                    machCond.RendementPrevu = machine.RendementPrevu;
                    machCond.RendementReel = machine.RendementReel;
                    listeCond.Add(machCond);
                }
            }
            foreach (Produit pro in listePro)
            {
                listeCond[random.Next(0, listeCond.Count)].ProduitsFabriques++;
                foreach (Machine_Conditionnement machineCondit in listeCond)
                {
                    if(random.Next(0,2) == 1)
                    {
                        Evenement evenement = new Evenement();
                        evenement.IdMachine = machineCondit.ID;
                        //evenement.Machine = machineCondit;
                        listeEvenement.Add(evenement);
                    }
                }
            }
            connect.InsertEventInDatabase(CreateDataTable(listeEvenement), "evenement_machines");
            connect.InsertInDatabase(CreateDataTable(listePro), "produit");
            int test = connect.CountInDataBase("produit");
        }

        private static DataTable CreateDataTable<T>(IEnumerable<T> list)
        {
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
        }
        #endregion
    }
}