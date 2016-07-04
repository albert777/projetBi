using System;

namespace Fabrication
{
    public class Piece
    {
        private String nom;
        private String reference;
        private Decimal prix;
        private String couleur;
        private DateTime dateDebut;
        private DateTime dateFin;
        private Int32 stock;

        public String Nom { get; set; }
        public String Reference { get; set; }
        public Decimal Prix { get; set; }
        public String Couleur { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public Int32 Stock { get; set; }


    }
}
