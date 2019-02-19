using System;
using OE.Prog2.Jatek.Jatekter;
using OE.Prog2.Jatek.Megjelenites;

namespace OE.Prog2.Jatek.Szabalyok
{
    public delegate void KincsFelvetelKezelo(Kincs kincs, Jatekos jatekos);

    public class Kincs : RogizettJatekElem, IKirajzolhato
    {
        private IKirajzolhato kirajzolhatoImplementation;
        public override double Meret { get; } = 1;

        public event KincsFelvetelKezelo KincsFelvetel;

        public char Alak
        {
            get { return '\u2666'; }
        }

        public override void Utkozes(JatekElem jatekElem)
        {
            Jatekos jatekos = jatekElem as Jatekos;
            if (jatekos != null)
            {
                KincsFelvetel?.Invoke(this, jatekos);
                jatekos.PontotSzerez(50);
                ter.Torles(this);
            }
        }

        public Kincs(int x, int y, JatekTer ter) : base(x, y, ter)
        {
        }
    }
}
