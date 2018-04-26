//using System;
using System.Collections.Generic;
using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace HegyekMo
{
    class Beolvas
    {
        public List<string> Rekordok { get; private set; }
        public Beolvas(string fileNeve, bool fejlécRekord)
        {
            Rekordok = new List<string>();
            foreach (var i in File.ReadAllLines(fileNeve)) 
            {
                Rekordok.Add(i);
            }
            if (fejlécRekord)  
            {
                Rekordok.RemoveAt(0);
            }
        }
    }
}
