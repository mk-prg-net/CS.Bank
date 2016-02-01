//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 31.1.2016
//
//  Projekt.......: BetterBankBL.TestMockUps
//  Name..........: Kunde.cs
//  Aufgabe/Fkt...: Attrappe eines Kunden zum Testen
//                  
//
//
//
//
//<unit_environment>
//------------------------------------------------------------------
//  Zielmaschine..: PC 
//  Betriebssystem: Windows 7 mit .NET 4.5
//  Werkzeuge.....: Visual Studio 2013
//  Autor.........: Martin Korneffel (mko)
//  Version 1.0...: 
//
// </unit_environment>
//
//<unit_history>
//------------------------------------------------------------------
//
//  Version.......: 1.1
//  Autor.........: Martin Korneffel (mko)
//  Datum.........: 
//  Änderungen....: 
//
//</unit_history>
//</unit_header>        
        
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterBankBL.TestMockUps
{
    public class Kunde : Interfaces.IKunde
    {

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }
        string _Name;

        public IEnumerable<Interfaces.IKonto> Konten
        {
            get { return _Konten; }
        }

        List<Interfaces.IKonto> _Konten = new List<Interfaces.IKonto>();


        public void KontoOeffnen(Interfaces.IKonto Konto)
        {
            if (_Konten.Any(r => r.KtoNr == Konto.KtoNr))
                throw new Exception("Der Kunde hat bereits ein Konto mit der Kontonummer " + Konto.KtoNr);

            _Konten.Add(Konto);

        }

        public void KontoSchliessen(string ktoNr)
        {
            if (!_Konten.Exists(r => r.KtoNr == ktoNr))
                throw new Exception("Beim KontoSchliessen: Der Kunde besitzt kein Konto mit der Nummer " + ktoNr);

            _Konten.Remove(_Konten.Single(r => r.KtoNr == ktoNr));
        }
    }
}
