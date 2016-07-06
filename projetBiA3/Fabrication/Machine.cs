using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabrication
{
    public class Machine
    {
        public static Random random = new Random();
        public int RendementPrevu { get; set; }
        public int RendementReel { get; set; }
    }
}
