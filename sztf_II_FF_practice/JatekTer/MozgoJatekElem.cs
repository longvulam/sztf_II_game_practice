using System;
using OE.Prog2.Jatek.Szabalyok;

namespace OE.Prog2.Jatek.Jatekter
{
    public class MozgoJatekElem : JatekElem
    {
        public MozgoJatekElem(int x, int y, JatekTer ter) : base(x, y, ter)
        {
        }

        private bool aktiv;
        public bool Aktiv
        {
            get { return aktiv; }
            set { aktiv = value; }
        }

        public override double Meret { get; }

        public override void Utkozes(JatekElem jatekElem)
        {
            throw new NotImplementedException();
        }

        public void AtHelyez(int ujX, int ujY)
        {
            JatekElem[] foundInNewCoord = ter.MegadottHelyenLevok(ujX, ujY);
            foreach (JatekElem elem in foundInNewCoord)
            {
                elem.Utkozes(this);
                Utkozes(elem);

                if (!Aktiv)
                {
                    throw new MozgasHalalMiattNemSikerultKivetel(X,Y,this);
                    return;
                }
            }

            JatekElem[] stillActives = ter.MegadottHelyenLevok(ujX, ujY);
            var meretOssz = 0d;
            foreach (JatekElem elem in stillActives)
            {
                meretOssz += elem.Meret;
            }

            if (meretOssz + Meret < 1)
            {
                X = ujX;
                Y = ujY;
            }
            else
            {
                throw new MozgasHelyHianyMiattNemSikerult(X, Y, this, stillActives);
            }
        }
    }
}