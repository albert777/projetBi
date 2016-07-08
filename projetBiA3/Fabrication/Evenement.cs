using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabrication
{
    public class Evenement
    {
        #region Attributes
        private static Random random = new Random();
        
        private static List<string> Quotes = new List<string>();
        public enum Event { Panne, Maintenance };
        
        #endregion

        #region Constructors
        public Evenement()
        {
            //Machine = RandomMachine();
            DateDebutEvenement = RandomDate(null);
            DateFinEvenement = RandomDate(DateDebutEvenement);
            TypeEvenement = RandomEvent();
            Commentaires = RandomCommentaires();
        }

        public Evenement(Machine machine, DateTime dateDebutEvenement, DateTime dateFinEvenement, Event typeEvenement, string commentaires)
        {
            //Machine = machine;
            DateDebutEvenement = dateDebutEvenement;
            DateFinEvenement = dateFinEvenement;
            TypeEvenement = typeEvenement;
            Commentaires = commentaires;
        }
        #endregion

        #region Random methods
        public Machine RandomMachine()
        {
            return (random.Next(0, 2) == 0) ? new Machine_Fabrication(180) : (Machine)new Machine_Conditionnement(200);
        }

        public DateTime RandomDate(DateTime? DateDebut)
        {
            DateTime start = (DateDebut == null) ? new DateTime(2016, 1, 1) : (DateTime)DateDebut;
            int range = (DateTime.Today - start).Days;
            return start.AddDays(random.Next(range));
        }

        public Event RandomEvent()
        {
            Array values = Enum.GetValues(typeof(Event));
            return (Event)values.GetValue(random.Next(values.Length));
        }

        public string RandomCommentaires()
        {
            Quotes.Add("L'opération a rencontré un problème");
            Quotes.Add("Quelque chose est cassé");
            Quotes.Add("La machine a pris feu");
            Quotes.Add("Je ne sais pas ce qui se passe");
            Quotes.Add("AU SECOURS !");
            
            return Quotes[random.Next(0, Quotes.Count - 1)];
        }
        #endregion

        #region Getters and setters
        //public Machine Machine { get; set; }
        public int Id { get; set; }
        public DateTime DateDebutEvenement { get; set; }
        public DateTime DateFinEvenement { get; set; }
        public Event TypeEvenement { get; set; }
        public string Commentaires { get; set; }
        public int IdMachine { get; set; }
        #endregion
    }
}
