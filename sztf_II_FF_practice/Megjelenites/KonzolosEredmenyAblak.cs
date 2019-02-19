using OE.Prog2.Jatek.Szabalyok;

namespace OE.Prog2.Jatek.Megjelenites
{
    public class KonzolosEredmenyAblak
    {
        private int pozX;
        private int pozY;
        private int maxSorSzam;
        private int sor;

        public void JatekosFeliratkozas(Jatekos jatekos)
        {
            jatekos.JatekosValtozas += JatekosValtozasTortent;
        }

        private void JatekosValtozasTortent(Jatekos jatekos, int ujPontszam, int ujEletero)
        {
            string szoveg = $"játékos neve: {jatekos.Nev}, pontszáma:{jatekos.Pontszam}, életereje:{jatekos.Eletero} ";
            SzalbiztosKonzol.KiirasXY(pozX, pozY + sor, szoveg);
            sor++;
            if (sor > maxSorSzam)
            {
                sor = 0;
            }
        }

        public KonzolosEredmenyAblak(int pozX, int pozY, int maxSorSzam)
        {
            this.pozX = pozX;
            this.pozY = pozY;
            this.maxSorSzam = maxSorSzam;
        }
    }
}