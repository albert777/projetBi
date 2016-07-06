using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabrication
{
    public class Machine_Conditionnement : Machine
    {
        public Machine_Conditionnement(int rendementPrevu)
        {
            RendementPrevu = rendementPrevu;
            RendementReel = random.Next(0, RendementPrevu + 20);
        }
    }
}
