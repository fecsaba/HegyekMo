using System;
using System.Collections.Generic;
using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace HegyekMo
{
    class Kiír
    {
        private string sorszám;
        private string kiírandó;
        public Kiír(int ssz, string ki)
        {
            sorszám = ssz.ToString();
            kiírandó = ki;
            Console.WriteLine($"{sorszám}. feladat: {kiírandó}");
        }
        public Kiír(string ki)
        {
            kiírandó = ki;
            Console.WriteLine($"{kiírandó}");
        }
        public Kiír(List<string> fájlba)
        {
            File.WriteAllLines("bukk-videk.txt", fájlba);
        }
    }
}
