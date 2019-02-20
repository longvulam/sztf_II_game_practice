using System;
using OE.Prog2.Jatek.Automatizmus;
using OE.Prog2.Jatek.Jatekter;
using OE.Prog2.Jatek.Megjelenites;
using OE.Prog2.Jatek.Szabalyok;

namespace OE.Prog2.Jatek.Keret
{
    class Keret
    {
        private const int PALYA_MERET_X = 21;
        private const int PALYA_MERET_Y = 11;
        private const int KINCSEK_SZAMA = 10;
        private readonly JatekTer ter;
        private bool jatekVege;
        private readonly Random random = new Random();
        private readonly OrajelGenerator generator;
        private int megtalaltKincsek = 0;

        private void PalyaGeneralas()
        {
            for (int i = 0; i <= PALYA_MERET_X; i++)
            {
                new Fal(i, 0, ter);
                new Fal(i, PALYA_MERET_Y, ter);
            }

            for (int i = 1; i < PALYA_MERET_Y; i++)
            {
                new Fal(0, i, ter);
                new Fal(PALYA_MERET_X, i, ter);
            }

            for (int i = 0; i < KINCSEK_SZAMA; i++)
            {
                int ranX = random.Next(1, PALYA_MERET_X);
                int ranY = random.Next(1, PALYA_MERET_Y);
                JatekElem[] foundElems = ter.MegadottHelyenLevok(ranX, ranY);
                while (ranX == 1 && ranY == 1
                       || foundElems.Length == 1 && foundElems[0] is Kincs)
                {
                    ranX = random.Next(1, PALYA_MERET_X);
                    ranY = random.Next(1, PALYA_MERET_Y);
                    foundElems = ter.MegadottHelyenLevok(ranX, ranY);
                }

                var kincs = new Kincs(ranX, ranY, ter);
                kincs.KincsFelvetel += KincsFelvetelTortent;
            }
        }

        public void Futtatas()
        {
            Jatekos jatekos = new Jatekos(1, 1, ter)
            {
                Nev = "Béla",
                Aktiv = true
            };

            KonzolosEredmenyAblak eredmenyAblak = new KonzolosEredmenyAblak(0, 12, 5);
            eredmenyAblak.JatekosFeliratkozas(jatekos);
            jatekos.JatekosValtozas += JatekosValtozasTortent;
            GepiJatekos gep = new GepiJatekos(PALYA_MERET_X - 2, 1, ter)
            {
                Nev = "Kati",
                Aktiv = true
            };

            GonoszGepiJatekos gonoszGep = new GonoszGepiJatekos(1, PALYA_MERET_Y - 1, ter)
            {
                Nev = "Laci",
                Aktiv = true
            };

            generator.Felvetel(gep);
            generator.Felvetel(gonoszGep);

            KonzolosMegjelenito allDisplayer = new KonzolosMegjelenito(ter, 0, 0);
            KonzolosMegjelenito playerDisplayer = new KonzolosMegjelenito(jatekos, 25, 0);
            KonzolosMegjelenito cpuDisplayer = new KonzolosMegjelenito(gep, 50, 0);
            KonzolosMegjelenito evilCpuDisplayer = new KonzolosMegjelenito(gonoszGep, 75, 0);
            generator.Felvetel(allDisplayer);
            generator.Felvetel(playerDisplayer);
            generator.Felvetel(cpuDisplayer);
            generator.Felvetel(evilCpuDisplayer);

            do
            {
                try
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.LeftArrow) jatekos.Megy(-1, 0);
                    if (key.Key == ConsoleKey.RightArrow) jatekos.Megy(1, 0);
                    if (key.Key == ConsoleKey.UpArrow) jatekos.Megy(0, -1);
                    if (key.Key == ConsoleKey.DownArrow) jatekos.Megy(0, 1);
                    if (key.Key == ConsoleKey.Escape) jatekVege = true;
                }
                catch (MozgasHelyHianyMiattNemSikerult e)
                {
                    Console.Beep(500 + e.Elemek.Length * 100, 10);
                } 
               
            } while (!jatekVege);

        }

        private void KincsFelvetelTortent(Kincs kincs, Jatekos jatekos)
        {
            megtalaltKincsek++;
            if (megtalaltKincsek == KINCSEK_SZAMA)
            {
                jatekVege = true;
            }
        }

        private void JatekosValtozasTortent(Jatekos jatekos, int ujPontszam, int ujEletero)
        {
            if (ujEletero == 0)
            {
                jatekVege = true;
            }
        }

        public Keret()
        {
            this.generator = new OrajelGenerator();
            ter = new JatekTer(PALYA_MERET_X, PALYA_MERET_Y);
            PalyaGeneralas();
        }

    }
}