using OE.Prog2.Jatek.Jatekter;

namespace OE.Prog2.Jatek.Szabalyok
{
    public class GonoszGepiJatekos : GepiJatekos
    {
        public override char Alak { get; } = '\u2642';

        public override void Utkozes(JatekElem jatekElem)
        {
            base.Utkozes(jatekElem);
            Jatekos jatekos = jatekElem as Jatekos;
            if (this.Aktiv && jatekos != null)
            {
                jatekos.Serul(10);
            }
        }

        public GonoszGepiJatekos(int x, int y, JatekTer ter) : base(x, y, ter)
        {
        }
    }
}