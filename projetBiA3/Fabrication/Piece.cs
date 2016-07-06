using System;

namespace Fabrication
{
    public class Piece
    {
        #region Attributes
        private static Random random = new Random();
        #endregion

        #region Constructors
        public Piece(string nom, string reference, decimal prix, string couleur)
        {
            Nom = nom;
            Reference = reference;
            Prix = prix;
            Couleur = couleur;
            DateDebut = RandomDate(null);
            DateFin = RandomDate(DateDebut);
            Stock = RandomStock();
        }
        #endregion

        #region Random methods
        public DateTime RandomDate(DateTime? DateDebut)
        {
            DateTime start = (DateDebut == null) ? new DateTime(2014, 1, 1) : (DateTime)DateDebut;
            int range = (DateTime.Today - start).Days;
            return start.AddDays(random.Next(range));
        }

        public int RandomStock()
        {
            return random.Next(0, 1) == 1 ? random.Next(0, 1) : 0;
        }
        #endregion

        #region Getters and setters
        public string Nom { get; set; }
        public string Reference { get; set; }
        public decimal Prix { get; set; }
        public string Couleur { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public int Stock { get; set; }
        #endregion
    }
}
