//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 31.1.2016
//
//  Projekt.......: BetterBankBL.Interfaces
//  Name..........: IKunde.cs
//  Aufgabe/Fkt...: Schnittstelle zum Objekt eines Bankkunden
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

namespace BetterBankBL.Interfaces
{
    public interface IKonto
    {
        /// <summary>
        /// eindeutige Kontonummer 
        /// </summary>
        string KtoNr { get; }

        /// <summary>
        /// Verweis auf den Kunde, dem das Konto gehört
        /// </summary>
        IKunde Kunde { get; }

        /// <summary>
        /// aktueller Guthabenstand
        /// </summary>
        double Guthaben { get; }

        /// <summary>
        /// Betrag auf Konto einzahlen- Guthaben erhöht sich
        /// </summary>
        /// <param name="betrag"></param>
        void Einzahlen(double betrag);


        /// <summary>
        /// Betrag vom Konto abheben- Guthaben vermindert sich
        /// </summary>
        /// <param name="betrag"></param>
        void Abheben(double betrag);

        /// <summary>
        /// Gewährtes Überziehung
        /// </summary>
        double Dispolimit {get; set;}

        /// <summary>
        /// Event, feuert, wenn das gewährte Dispolimit überzogen wurde
        /// </summary>
        event Action<double> Ueberzogen;

    }
}
