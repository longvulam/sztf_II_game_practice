using System;

namespace OE.Prog2.Jatek.Megjelenites
{
    public interface IMegjelenitheto
    {
        int[] MegjelenitendoMeret { get; }
        IKirajzolhato[] MegjelenitendoElemek();
    }

    public interface IKirajzolhato
    {
        int X { get; set; }
        int Y { get; set; }
        char Alak { get; }
    }
}