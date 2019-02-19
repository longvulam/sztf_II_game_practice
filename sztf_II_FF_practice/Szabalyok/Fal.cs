using OE.Prog2.Jatek.Jatekter;
using OE.Prog2.Jatek.Megjelenites;

namespace OE.Prog2.Jatek.Szabalyok
{
    public class Fal : RogizettJatekElem, IKirajzolhato
    {
        public override double Meret { get; } = 1d;
        public char Alak
        {
            get { return '\u2593'; }
        }


        public override void Utkozes(JatekElem jatekElem)
        {

        }

        public Fal(int x, int y, JatekTer ter) : base(x, y, ter)
        {
        }
    }
}