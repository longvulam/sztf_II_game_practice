namespace OE.Prog2.Jatek.Jatekter
{
    public abstract class JatekElem
    {

        public JatekElem(int x, int y, JatekTer ter)
        {
            this.x = x;
            this.y = y;
            this.ter = ter;
            ter.Felvetel(this);
        }

        protected JatekTer ter;
        public abstract double Meret { get; }
        public abstract void Utkozes(JatekElem jatekElem);

        private int x;

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        private int y;

        public int Y
        {
            get { return y; }
            set { y = value; }
        }
    }
}