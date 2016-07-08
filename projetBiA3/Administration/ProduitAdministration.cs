using Fabrication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administration
{
    public class ProduitAdministration : Fabrication.Produit
    {
        public ProduitAdministration(bool isFromDatabase) : base(isFromDatabase)
        {
        }

        #region Getters and setters
        public bool isFromDatabase { get; set; }
        #endregion

        #region Methods for DB
        new public static List<ProduitAdministration> GetProduitsFromDataBase()
        {
            DBConnect connect = new Administration.DBConnect();
            
            List<ProduitAdministration> listeProduits = connect.SelectProduits();
            return listeProduits;
        }

        internal DateTime GenerateRandomDate()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
