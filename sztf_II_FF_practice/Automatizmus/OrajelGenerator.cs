using System;
using System.IO;
using System.Threading;

namespace OE.Prog2.Jatek.Automatizmus
{
    public class OrajelGenerator
    {
        const int MAX_MUKODO = 1000;
        int mukodoN;
        readonly IAutomatikusanMukodo[] mukodok = new IAutomatikusanMukodo[MAX_MUKODO];
        Timer timer;

        public OrajelGenerator()
        {
            timer = new Timer(Aktivalas, null, 0, 100);
        }

        int aktivalasN = 0;
        bool feldolgozasAlatt = false;
        public void Aktivalas(Object state)
        {
            // ha tul lassu lenne a kirajzolas, es az elozo orajel feldolgozasa elott ujra meghivodna, akkor azt atlepi
            // nem lock, mivel ilyenkor szandekosan kihagyja ezt a ciklust, igy nem fog feltorlodni
            if (!feldolgozasAlatt)
            {
                feldolgozasAlatt = true;
                // szamoljuk, hogy hanyadik orajelnel jarunk
                aktivalasN++;
                // akinek most epp aktualis, az kap egy orajelet
                for (int i = 0; i < mukodoN; i++)
                {
                    if (aktivalasN % mukodok[i].MukodesIntervallum == 0)
                    {
                        try
                        {
                            mukodok[i].Mukodik();
                        }
                        catch (Exception e)
                        {
                            File.AppendAllText("log.txt", e.ToString());
                        }
                    }
                }

                feldolgozasAlatt = false;
            }
        }

        // feliratkozas
        public void Felvetel(IAutomatikusanMukodo mukodo)
        {
            mukodok[mukodoN++] = mukodo;
        }

        // feliratkozas
        public void Levetel(IAutomatikusanMukodo mukodo)
        {
            int i = 0;
            while (mukodok[i] != mukodo) i++;
            mukodoN--;
            mukodok[i] = mukodok[mukodoN];
        }
    }
}