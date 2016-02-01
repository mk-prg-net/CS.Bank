using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankBL
{
    public class Kunde
    {        

        public Kunde(string Name)
        {
            this.Name = Name;
        }

        /// <summary>
        /// Name des Kunden: Les- und schreibbare Eigenschaft
        /// </summary>
        public string Name { get; set; }


        public string Kontenübersicht
        {
            get
            {
                StringBuilder bld = new StringBuilder();
                foreach (var str in Konten.Select(r => "KtoNr= " + r.KtoNr + " Guthaben= " + r.Guthaben.ToString("N2")))
                {
                    bld.Append(str);
                    bld.Append(", ");
                }

                return bld.ToString();
            }
        }


        public IEnumerable<Girokonto> Konten
        {
            get
            {
                return _Konten;
            }
        }
        private List<Girokonto> _Konten = new List<Girokonto>();

        /// <summary>
        /// Pflegen der Beziehung Kunde <-->> Konto
        /// </summary>
        /// <param name="NeuesKonto"></param>
        public void NeuesKonto(Girokonto NeuesKonto)
        {
            _Konten.Add(NeuesKonto);
        }

        /// <summary>
        /// Kundokonto schließen
        /// </summary>
        /// <param name="Konto"></param>
        public void KontoSchließen(Girokonto Konto)
        {
            _Konten.Remove(Konto);
        }

    }
}
