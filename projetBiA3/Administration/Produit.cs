using Fabrication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administration
{
    public class Produit
    {
        #region Constructors
        public Produit(string nom, string refer, decimal prix, int rC, string lP, List<Piece> lP2)
        {
            Nom = nom;
            Reference = refer;
            Prix = prix;
            RetourClient = rC;
            LigneProduit = lP;
            ListPiece = lP2;
        }
        public Produit(bool selectFromDB)
        {

        }
        #endregion

        #region Getters and setters
        public string Nom { get; set; }
        public string Reference { get; set; }
        public decimal Prix { get; set; }
        public int RetourClient { get; set; }
        public string LigneProduit { get; set; }
        public List<Piece> ListPiece { get; set; }
        #endregion

        #region Methods for DB
        public static List<Produit> GetProduitsFromDataBase()
        {
            DBConnect.DBConnect connect = new DBConnect.DBConnect();
            List<Produit> listeProduits = connect.SelectProduits();
            return listeProduits;
        }
        #endregion
    }
}
