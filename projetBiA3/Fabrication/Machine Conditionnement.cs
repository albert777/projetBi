namespace Fabrication
{
    public class Machine_Conditionnement : Machine
    {
        public Machine_Conditionnement(int rendementPrevu)
        {
            RendementPrevu = rendementPrevu;
            RendementReel = random.Next(0, RendementPrevu + 20);
        }
        public Machine_Conditionnement() { }

        //public int ProduitsFabriques { get; set; }
    }
}
