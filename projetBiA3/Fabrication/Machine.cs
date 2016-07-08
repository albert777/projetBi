using System;

namespace Fabrication
{
    public class Machine
    {
        public static Random random = new Random();
        public int ID { get; set; }
        public string TypeMachine { get; set; }
        public int RendementPrevu { get; set; }
        public int RendementReel { get; set; }
        public int ProduitsFabriques { get; set; }
    }
}