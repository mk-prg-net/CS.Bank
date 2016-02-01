//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 31.1.2016
//
//  Projekt.......: BetterBankBL.Interfaces
//  Name..........: IKunde.cs
//  Aufgabe/Fkt...: Schnittstelle eines Kundenobjekts
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
    public interface IKunde
    {
        /// <summary>
        /// Name des Kunden
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Alle Konten, die dem Kunden zugerodnet sind. Implementiert die Beziuehung Kunde 1--n Konto
        /// </summary>
        IEnumerable<IKonto> Konten { get; }

        /// <summary>
        /// Ein neues Konto dem Kunden zuweisen
        /// </summary>
        /// <param name="Konto"></param>
        void KontoOeffnen(IKonto Konto);


        /// <summary>
        /// Ein Konton des Kunden schliessen
        /// </summary>
        /// <param name="ktoNr"></param>
        void KontoSchliessen(string ktoNr);


    }
}
