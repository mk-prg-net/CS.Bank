using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterBankBL.Interfaces
{
    public abstract class KontenFactory
    {
        /// <summary>
        /// Erzeugt ein neues Konto
        /// </summary>
        /// <param name="ktoNr">Kontonummer</param>
        /// <param name="Kunde">Kunde, dem das neue Konto zugeordnet ist</param>
        /// <returns></returns>
        public abstract IKonto Create(string ktoNr, IKunde Kunde);
    }
}
