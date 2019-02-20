using System;
using System.Linq;
using OE.Prog2.Jatek.Megjelenites;
using OE.Prog2.Jatek.Szabalyok;

namespace OE.Prog2.Jatek.Jatekter
{
    public class JatekTer : IMegjelenitheto
    {
        private const int MAX_ELEMSZAM = 1000;

        private int elemN;
        private JatekElem[] elemek = new JatekElem[MAX_ELEMSZAM];

        private int meretX;

        public int MeretX
        {
            get { return meretX; }
        }

        private int meretY;

        public int MeretY
        {
            get { return meretY; }
        }

        public int[] MegjelenitendoMeret
        {
            get { return new[] { meretX, meretY }; }
        }

        public IKirajzolhato[] MegjelenitendoElemek()
        {
            int count = 0;
            foreach (JatekElem elem in elemek)
            {
                if (elem is IKirajzolhato)
                {
                    count++;
                }
            }

            IKirajzolhato[] elemsToDisplay = new IKirajzolhato[count];
            count = 0;
            foreach (JatekElem elem in elemek)
            {
                if (elem is IKirajzolhato)
                {
                    elemsToDisplay[count++] = elem as IKirajzolhato;
                }
            }

            return elemsToDisplay;
        }

        public void Felvetel(JatekElem jatekElem)
        {
            elemek[elemN++] = jatekElem;
        }

        public void Torles(JatekElem jatekElem)
        {
            int i = 0;
            while (i <= elemN && elemek[i] != jatekElem)
            {
                i++;
            }

            if (i > elemN)
            {
                return;

            }

            JatekElem latest = elemek[elemN - 1];
            elemek[i] = latest;
            elemek[elemN - 1] = null;
            elemN--;
        }

        public JatekElem[] MegadottHelyenLevok(int x, int y, int range)
        {
            int foundElems = 0;
            for (int i = 0; i < elemN; i++)
            {
                JatekElem currentElem = elemek[i];
                int xDiff = Math.Abs(currentElem.X - x);
                int yDiff = Math.Abs(currentElem.Y - y);
                if (xDiff + yDiff <= range)
                {
                    foundElems++;
                }
            }

            JatekElem[] elems = new JatekElem[foundElems];
            int n = 0;

            for (int i = 0; i < elemN; i++)
            {
                JatekElem currentElem = elemek[i];
                int xDiff = Math.Abs(currentElem.X - x);
                int yDiff = Math.Abs(currentElem.Y - y);
                if (xDiff + yDiff <= range)
                {
                    elems[n++] = currentElem;
                }
            }

            return elems;
        }

        public JatekElem[] MegadottHelyenLevok(int x, int y)
        {
            return MegadottHelyenLevok(x, y, 0);
        }

        public JatekTer(int meretX, int meretY)
        {
            this.meretX = meretX;
            this.meretY = meretY;
        }
    }
}