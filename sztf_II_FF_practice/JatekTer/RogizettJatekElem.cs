using System;

namespace OE.Prog2.Jatek.Jatekter
{
    public class RogizettJatekElem : JatekElem
    {
        public RogizettJatekElem(int x, int y, JatekTer ter) : base(x, y, ter)
        {
        }

        public override double Meret { get; }
        public override void Utkozes(JatekElem jatekElem)
        {
            throw new NotImplementedException();
        }
    }
}