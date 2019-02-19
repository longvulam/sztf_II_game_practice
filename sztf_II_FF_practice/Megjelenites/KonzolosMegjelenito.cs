using System.Linq;
using OE.Prog2.Jatek.Automatizmus;
using OE.Prog2.Jatek.Szabalyok;

namespace OE.Prog2.Jatek.Megjelenites
{
    class KonzolosMegjelenito : IAutomatikusanMukodo
    {
        private readonly IMegjelenitheto forras;
        private readonly int pozX;
        private readonly int pozY;
        public int MukodesIntervallum { get; } = 1;

        public void Mukodik()
        {
            Megjelenites();
        }

        public void Megjelenites()
        {
            IKirajzolhato[] elemek = forras.MegjelenitendoElemek();
            int[] meretek = forras.MegjelenitendoMeret;

            for (int x = 0; x <= meretek[0]; x++)
            {
                for (int y = 0; y <= meretek[1]; y++)
                {
                    int i = 0;
                    while (i < elemek.Length && (elemek[i].X != x || elemek[i].Y != y))
                    {
                        i++;
                    }

                    SzalbiztosKonzol.KiirasXY(x + pozX, y + pozY, i < elemek.Length ? elemek[i].Alak : ' ');
                }
                SzalbiztosKonzol.KiirasXY(x + pozX, meretek[1] + pozY, '\n');
            }
        }

        public KonzolosMegjelenito(IMegjelenitheto forras, int pozX, int pozY)
        {
            this.forras = forras;
            this.pozX = pozX;
            this.pozY = pozY;
        }
    }
}