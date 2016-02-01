//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 31.1.2016
//
//  Projekt.......: BetterBankBL.TestMockUps
//  Name..........: KundenFactory.cs
//  Aufgabe/Fkt...: Klassenfabrik, die Kunden- Attrappen zum Testen 
//                  erstellt.
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
    public class KundenFactory : Interfaces.KundenFactory
    {
        public override Interfaces.IKunde Create(string Name)
        {
            return new Kunde() { Name = Name };
        }
    }
}
