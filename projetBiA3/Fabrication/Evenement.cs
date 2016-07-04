using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabrication
{
    public class Evenement
    {
        private Machine machine;
        private DateTime dateDebutEvenement;
        private DateTime dateFinEvenement;
        private Event typeEvenement;
        private String commentaires;

        public enum Event {Panne, Maintenance};

        public Machine Machine { get; set; }
        public DateTime DateDebutEvenement { get; set; }
        public DateTime DateFinEvenement { get; set; }
        public Event TypeEvenement { get; set; }
        public String Commentaires { get; set; }

    }
}
