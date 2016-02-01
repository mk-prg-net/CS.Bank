//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 31.1.2016
//
//  Projekt.......: BetterBankBL.TestMockUps
//  Name..........: Konto.cs
//  Aufgabe/Fkt...: Konto- Atrappe zum Testen
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
    public class Konto : Interfaces.IKonto
    {

        public Konto(string KtoNr, Interfaces.IKunde Kunde)
        {
            _KtoNr = KtoNr;
            _Kunde = Kunde;
        }

        public string KtoNr
        {
            get {
                return _KtoNr;
            }
        }
        string _KtoNr;

        public Interfaces.IKunde Kunde
        {
            get { return _Kunde; }
        }
        Interfaces.IKunde _Kunde;

        public double Guthaben
        {
            get { return _Guthaben; }
        }
        double _Guthaben;

        public void Einzahlen(double betrag)
        {
            _Guthaben += betrag;
        }

        public void Abheben(double betrag)
        {
            _Guthaben -=betrag;
            if (_Guthaben < _Dispolimit && Ueberzogen != null)
                Ueberzogen(betrag);
        }

        public double Dispolimit
        {
            get
            {
                return _Dispolimit;
            }
            set
            {
                _Dispolimit = value;
            }
        }
        double _Dispolimit;

        public event Action<double> Ueberzogen;
    }
}
