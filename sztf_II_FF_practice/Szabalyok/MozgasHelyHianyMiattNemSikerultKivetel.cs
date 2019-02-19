using OE.Prog2.Jatek.Jatekter;

namespace OE.Prog2.Jatek.Szabalyok
{
    public class MozgasHelyHianyMiattNemSikerultKivetel : MozgasNemSikerultKivetel
    {
        public MozgasHelyHianyMiattNemSikerultKivetel(int x, int y, JatekElem jatekElem, JatekElem[] elemek)
            : base(x, y, jatekElem)
        {
            this.elemek = elemek;
        }

        private JatekElem[] elemek;

        public JatekElem[] Elemek
        {
            get { return elemek; }
        }
    }
}