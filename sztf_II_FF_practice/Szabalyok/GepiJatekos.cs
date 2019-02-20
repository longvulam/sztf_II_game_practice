using System;
using OE.Prog2.Jatek.Automatizmus;
using OE.Prog2.Jatek.Jatekter;

namespace OE.Prog2.Jatek.Szabalyok
{
    public class GepiJatekos : Jatekos, IAutomatikusanMukodo
    {
        private static readonly Random Rand = new Random();

        public override char Alak { get; } = '\u2640';
        public int MukodesIntervallum { get; } = 2;

        public void Mukodik()
        {
            Mozgas();
        }

        public void Mozgas()
        {
            bool eThrown;
            do
            {
                try
                {
                    eThrown = false;
                    Move();
                }
                catch (MozgasHelyHianyMiattNemSikerult e)
                {
                    eThrown = true;
                }
            } while (eThrown);
        }

        private void Move()
        {
            int r = Rand.Next(4);
            if (r == 0) Megy(-1, 0);
            if (r == 1) Megy(1, 0);
            if (r == 2) Megy(0, -1);
            if (r == 3) Megy(0, 1);
        }

        public GepiJatekos(int x, int y, JatekTer ter) : base(x, y, ter)
        {
        }


    }
}