using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OE.Prog2.Jatek.Automatizmus
{
    public interface IAutomatikusanMukodo
    {
        void Mukodik();
        int MukodesIntervallum { get; }
    }
}