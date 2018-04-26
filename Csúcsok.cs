//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace HegyekMo
{
    class Csúcsok
    {
        public string HegycsúcsNeve { get; private set; }
        public string Hegység { get; private set; }
        public int Magasság { get; private set; }
        public double MagasságLábban
        {
            get
            {
                return Magasság * 3.280839895;
            }
        }
        public Csúcsok(string rekord)
        {
            string[] mezők = rekord.Split(';');
            HegycsúcsNeve = mezők[0];
            Hegység = mezők[1];
            Magasság = int.Parse(mezők[2]);
        }
        
    }
}
