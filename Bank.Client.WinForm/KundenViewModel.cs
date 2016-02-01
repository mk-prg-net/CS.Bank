using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Client.WinForm
{
    public class KundenViewModel : BetterBankBL.Interfaces.IKunde
    {
        BetterBankBL.Interfaces.IKunde _Kunde;

        public KundenViewModel(BetterBankBL.Interfaces.IKunde Kunde)
        {
            _Kunde = Kunde;
        }

        public string Name
        {
            get
            {
                return _Kunde.Name;
            }
            set
            {
                _Kunde.Name = value;
            }
        }

        public IEnumerable<BetterBankBL.Interfaces.IKonto> Konten
        {
            get { return _Kunde.Konten; }
        }

        public string Kontenuebersicht
        {
            get
            {
                if (Konten.Any())
                {
                    System.Text.StringBuilder bld = new StringBuilder();
                    foreach (var kto in Konten)
                    {
                        bld.Append(kto.KtoNr + ": " + kto.Guthaben + " €;");
                    }
                    bld.Remove(bld.Length - 1, 1);
                    return bld.ToString();
                }
                else
                {
                    return "";
                }
            }
        }


        public void KontoOeffnen(BetterBankBL.Interfaces.IKonto Konto)
        {
            _Kunde.KontoOeffnen(Konto);
        }

        public void KontoSchliessen(string ktoNr)
        {
            _Kunde.KontoSchliessen(ktoNr);
        }

    }
}
