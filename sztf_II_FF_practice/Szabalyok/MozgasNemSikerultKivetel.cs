using System;
using OE.Prog2.Jatek.Jatekter;

namespace OE.Prog2.Jatek.Szabalyok
{
    public class MozgasNemSikerultKivetel : Exception
    {
        public JatekElem Elem
        {
            get { return jatekElem; }
        }

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return Y; }
        }

        private JatekElem jatekElem;
        private int x;
        private int y;

        public MozgasNemSikerultKivetel(int x, int y, JatekElem jatekElem)
        {
            this.x = x;
            this.y = y;
            this.jatekElem = jatekElem;
        }
    }
}