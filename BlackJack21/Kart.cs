using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack21
{
    internal class Kart
    {
        public string KartAdı { get; set; }
        public int KartDegeri { get; set; }
        public override string ToString()
        {
            return KartAdı + "(" + KartDegeri + ")";
        }
    }
}
