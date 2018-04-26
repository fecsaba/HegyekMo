using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace HegyekMo
{
    class HegyekMo
    {
        static void Ki(int s, String ki)
        {
            if (s != 0)
            {
                Kiír k = new Kiír(s, ki);
            }
            else 
            
            {
                Kiír k = new Kiír(ki);
            }
            
        }
        static string SzámKufircolás(double vesszősSzám, string formátum)
        {
            string s = string.Format("{0:__}", vesszősSzám).Replace("__", formátum);
            double t = double.Parse(s);
            return t.ToString(CultureInfo.InvariantCulture.NumberFormat);
        }
        static void Main(string[] args)
        {

            //1.A feladat megoldásához hozzon létre grafikus vagy konzol alkalmazást(projektet) HegyekMo azonosítóval!
            //2.Az UTF - 8 kódolású hegyekMo.txt állomány Magyarország legmagasabb hegyeinek adatait tartalmazza
            //      a következő minta szerint(forrás: wikipedia.hu): 
            //      Hegycsúcs neve; Hegység; Magasság
            //      Ágasvár; Mátra; 789
            //      Bálvány; Bükk - vidék; 956
            //      Büszkés - hegy; Bükk - vidék; 952
            //      Cserepes - kő; Bükk - vidék; 823
            //      Az állományban a hegycsúcs nevét, a hegység megnevezését és a hegycsúcs magasságát(méter) tároltuk.
            //      Az adatokat pontosvessző választja el.
            //      Olvassa be a hegyekMo.txt állományban lévő adatokat és tárolja el egy olyan adatszerkezetben,
            //      ami a további feladatok megoldására alkalmas!A fájlban legfeljebb 1000 sor lehet!Ügyeljen rá,
            //      hogy az állomány első sora az adatok fejlécét tartalmazza!


            List<Csúcsok> cs = new List<Csúcsok>();
            Beolvas rekordok = new Beolvas("hegyekMo.txt", true);
            foreach (var i in rekordok.Rekordok)
            {
                cs.Add(new Csúcsok(i));
            }
            String Eredmény;
            //3.Határozza meg és írja ki a képernyőre a minta szerint, hogy hány hegy található az állományban!
            int db = cs.Count();
            Eredmény = $"Hegycsúcsok száma: {db} db. ";
            Ki(3, Eredmény);

            //4.Határozza meg és írja ki a képernyőre a minta szerint az állományba található hegyek átlagmagasságát!

            int magasság = 0;
            foreach (var i in cs)
            {
                magasság += i.Magasság;
            }
            Eredmény = $"Hegycsúcsok átlagos magassága: {(double)magasság / db:F2} m";
            Ki(4, Eredmény);

            //5.Határozza meg és írja ki a képernyőre a minta szerint, a legmagasabb hegy adatait!Feltételezheti, hogy nem alakult ki holtverseny!
            int legmagasabbHegy = 0;
            string legmagasabbHegyNeve=null;
            string legmagasabbHegyetMagábaFoglalóHegység=null;
            foreach (var i in cs)
            {
                if (i.Magasság>legmagasabbHegy)
                {
                    legmagasabbHegy = i.Magasság;
                    legmagasabbHegyNeve = i.HegycsúcsNeve;
                    legmagasabbHegyetMagábaFoglalóHegység = i.Hegység;

                }
            }
            Eredmény = $"A legmagasabb hegycsúcs adatai:\n\t" +
                $"Név: {legmagasabbHegyNeve}\n\t" +
                $"Hegység: {legmagasabbHegyetMagábaFoglalóHegység}\n\t" +
                $"Magasság: {legmagasabbHegy}";
            Ki(5, Eredmény);

            //6.Kérjen be a felhasználótól egy magasság értéket!A bevitt adatot nem kell ellenőriznie!Döntse el,
            //      hogy a Börzsöny hegységben található - e a megadott értéknél magasabb hegycsúcs!
            //A keresését ne folytassa, ha a választ meg tudja adni!A képernyőre írást a minta szerint végezze!
            int m;

            Console.Write("6. feladat: Kérek egy magasságot: ");
            
            m = int.Parse(Console.ReadLine());
            bool van = false;
            foreach (var i in cs)
            {
                if (i.Magasság > m && i.Hegység=="Börzsöny")
                {
                    Ki(0, $"{m} méternél magasabb a Börzsönyben pl. a {i.HegycsúcsNeve}");
                    van = true;
                    break;
                }
            }
            if (!van)
            {
                Ki(0, $"Nincs {m} méternél magasabb hegy a Börzsönyben");
            }
            Ki(0, "\nSzerintem így elegánsabb lett volna a feladat kiírása:\n" +
                " ...hogy a Börzsöny hegységben található összes, a megadott értéknél magasabb hegycsúcsok!\n ");
            List<string> Börzsöny = new List<string>();
            foreach (var i in cs)
            {
                if (i.Magasság > m && i.Hegység == "Börzsöny")
                {
                    Börzsöny.Add(i.HegycsúcsNeve);
                }
            }
            if (Börzsöny.Count() != 0)
            {
                Ki(0, $"{m} méternél magasabb hegyek a Börzsönyben:");
                foreach (var i in Börzsöny)
                {
                    Ki(0, $"\t{i}");
                }
            }
            else
            {
                Ki(0, $"Nincs {m} méternél magasabb hegy a Börzsönyben");
            }

            //7.Határozza meg és írja ki a képernyőre a minta szerint azoknak a hegycsúcsoknak a számát, melyek 3000 lábnál magasabbak!
            //      Az átváltáshoz az 1 m = 3.280839895 láb értékkel dolgozzon!

            int darab = 0;
            foreach (var i in cs)
            {
                if (i.MagasságLábban>3000)
                {
                    darab++;
                }
            }
            Ki(7, $"3000 lábnál magasabb csúcsok száma {darab} db.");

            //8.Készítsen statisztikát hegységek szerint a hegycsúcsok számáról!
            //      A megoldást úgy készítse el, hogy az input állományba később más hegységek is bekerülhetnek!
            //      A képernyőre írást a minta szerint végezze!
            Dictionary<string, int> Stat = new Dictionary<string, int>();
            Ki(8, $"Hegység statisztika");
            foreach (var i in cs)
            {
                if (!Stat.ContainsKey(i.Hegység))
                {
                    Stat.Add(i.Hegység, 1);
                }
                else
                {
                    Stat[i.Hegység] += 1;
                }
            }
            foreach (var i in Stat)
            {
                Ki(0, $"\t{i.Key} - {i.Value}");
            }

            //9.A bukk - videk.txt állományba írja ki azoknak a hegycsúcsoknak nevét és magasságát a minta szerint, melyek a Bükk-vidéken magasodnak!
            //      Az állomány első sora az adatok fejlécét tartalmazza!A magasságokat egy tizedesjegyre kerekítve,
            //      lábban kell kiírnia!Az átváltáshoz az 1 m = 3.280839895 láb értékkel dolgozzon!
            //      A magasság egész részét a tizedes résztől a pont karakterrel válassza el!
            //      Ha a kerekített valós szám .0 - ra végződik, akkor ezt a két karaktert(tizedespontot és az értéktelen nullát)
            //      ne írja az egész rész után!
            Ki(9, $"Fájlba vele...");
            
            string magasságPonttal;
            List<string> rögzít = new List<string>();
            rögzít.Add( "Hegycsúcs neve;Magasság láb");
            foreach (var i in cs)
            {
                magasságPonttal = SzámKufircolás(i.MagasságLábban, "F1");
                if (i.Hegység == "Bükk-vidék")
                {
                    rögzít.Add( $"{i.HegycsúcsNeve};{magasságPonttal}");
                }
            }
            Kiír k = new Kiír(rögzít);

            Console.ReadKey();
        }
    }
}
