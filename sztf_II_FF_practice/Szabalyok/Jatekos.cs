using System;
using OE.Prog2.Jatek.Jatekter;
using OE.Prog2.Jatek.Megjelenites;

namespace OE.Prog2.Jatek.Szabalyok
{
    public delegate void JatekosValtozasKezelo(Jatekos jatekos, int ujPontszam, int ujEletero);

    public class Jatekos : MozgoJatekElem, IKirajzolhato, IMegjelenitheto
    {
        private readonly JatekTer ter;
        private int eletero = 100;
        private int pontszam = 0;
        private string nev;

        public event JatekosValtozasKezelo JatekosValtozas;

        public string Nev
        {
            get { return nev; }
            set { nev = value; }
        }

        public virtual char  Alak
        {
            get { return Aktiv ? '\u263A' : '\u263B'; }
        }

        public int Eletero
        {
            get { return eletero; }
        }

        public override double Meret { get; } = 0.2d;

        public int[] MegjelenitendoMeret
        {
            get { return ter.MegjelenitendoMeret; }
        }

        public int Pontszam
        {
            get { return pontszam; }
        }

        public IKirajzolhato[] MegjelenitendoElemek()
        {
            int count = 0;
            JatekElem[] nearbyElems = ter.MegadottHelyenLevok(X, Y, 5);
            foreach (JatekElem elem in nearbyElems)
            {
                if (elem is IKirajzolhato)
                {
                    count++;
                }
            }

            IKirajzolhato[] elemsToDisplay = new IKirajzolhato[count];
            count = 0;
            foreach (JatekElem elem in nearbyElems)
            {
                if (elem is IKirajzolhato)
                {
                    elemsToDisplay[count++] = elem as IKirajzolhato;
                }
            }
            return elemsToDisplay;
        }

        public override void Utkozes(JatekElem jatekElem)
        {

        }

        public void Serul(int sebzes)
        {
            if (Eletero == 0)
            {
                return;
            }
            if (Eletero - sebzes < 0)
            {
                eletero = 0;
                Aktiv = false;
            }
            else
            {
                eletero = Eletero - sebzes;
            }

            JatekosValtozas?.Invoke(this, Pontszam, eletero);
        }

        public void PontotSzerez(int pont)
        {
            pontszam = Pontszam + pont;
            JatekosValtozas?.Invoke(this, Pontszam, eletero);
        }

        public void Megy(int rx, int ry)
        {
            int ujx = X + rx;
            int ujy = Y + ry;

            AtHelyez(ujx, ujy);
        }

        public Jatekos(int x, int y, JatekTer ter) : base(x, y, ter)
        {
            this.ter = ter;
        }


    }
}