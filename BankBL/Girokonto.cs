using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankBL
{
    public class Girokonto
    {
        /// <summary>
        /// Kontonummer als Eigenschaft
        /// </summary>
        public string KtoNr { get; set; }


        public double Guthaben
        {
            get
            {
                return _Guthaben;
            }
        }
        /// <summary>
        /// _Guthaben ist ein Implementierungsdetail. Konvention: Name beginnt mit _
        /// </summary>
        private double _Guthaben;

        /// <summary>
        /// Methode: Erhöht Guthaben um Betrag
        /// </summary>
        /// <param name="Betrag">Einzuzahlender Betrag</param>
        /// <returns></returns>
        public double Einzahlen(double Betrag)
        {
            _Guthaben += Betrag;
            return _Guthaben;
        }

        /// <summary>
        /// Abheben eines Betrages
        /// </summary>
        /// <param name="Betrag"></param>
        /// <returns></returns>
        public double Abheben(double Betrag)
        {
            // Folgender Ausdruck ist semantisch Äquivalent zu: _Guthaben = _Guthaben - Betrag;
            _Guthaben -= Betrag;
            return _Guthaben;
        }

    }
}
