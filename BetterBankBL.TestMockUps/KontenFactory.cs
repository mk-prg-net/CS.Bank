
//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 31.1.2016
//
//  Projekt.......: BetterBankBL.TestMockUps
//  Name..........: KundenFactory.cs
//  Aufgabe/Fkt...: Klassenfabrik, die Konten- Attrappen zum Testen erstellt
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
    public class KontenFactory : Interfaces.KontenFactory
    {
        public override Interfaces.IKonto Create(string ktoNr, Interfaces.IKunde Kunde)
        {
            return new Konto(ktoNr, Kunde);
        }
    }
}
