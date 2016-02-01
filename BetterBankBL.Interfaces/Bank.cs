//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 31.1.2016
//
//  Projekt.......: BetterBankBL.Interfaces
//  Name..........: Bank.cs
//  Aufgabe/Fkt...: Bank bildet die Geschäftsprozesse eines Bankhauses ab.
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
    public class Bank
    {
        /// <summary>
        /// Klassenfabriken
        /// </summary>
        KundenFactory Kunde;
        KontenFactory Konto;

        /// <summary>
        /// Bank wird nach dem Muster der Dependency Injection (DI) implementiert.
        /// Dabei werden für alle Klassen, von denen Bank abhängt, wie z.B. Kunde und Konto, Klassenfabriken
        /// als Parameter dem Konstruktor übergeben. Man spricht auch vom "injezieren" der Klassen.
        /// Vorteil: Die Implementierungen für Konto und Kunde sind zur Laufzeit auswählbar. Damit sind Tests 
        ///          für das Bank- Objket einfacher zu implementieren
        /// </summary>
        /// <param name="Kunden"></param>
        /// <param name="Konten"></param>
        /// <param name="Name"></param>
        public Bank(KundenFactory KundeFactory, KontenFactory KontoFactory, string Name)
        {
            this.Kunde = KundeFactory;
            this.Konto = KontoFactory;
        }


        /// <summary>
        /// Liste aller Konten
        /// </summary>
        public IEnumerable<IKonto> AlleGirokonten
        {
            get
            {
                return _AlleGirokonten;
            }
        }

        List<IKonto> _AlleGirokonten = new List<IKonto>();

        public IEnumerable<IKunde> AlleKunden
        {
            get
            {
                return _AlleKunden;
            }
        }

        private List<IKunde> _AlleKunden = new List<IKunde>();


        public void NeuerKundeAnlegen(string Name)
        {

            // Prüfen, ob Kunde mit dem Namen nicht bereits existiert
            if (_AlleKunden.Any(r => r.Name == Name))
                throw new Exception("Der Kunde mit dem Namen " + Name + " existiert bereits.");

            try
            {
                // Dank DI wird hier kein Kunde von einem festgelegten Typ mit new angelegt. 
                // Der exakte Typ ist durch die im Konstruktor übergebene Klassenfabrik bestimmt !
                _AlleKunden.Add(Kunde.Create(Name));
            }
            catch (Exception ex)
            {
                throw new Exception("Beim Anlegen des Kunden " + Name, ex);
            }
        }

        public void NeuesKontoEröffnen(string KtoNr, IKunde Kunde)
        {
            // neues Konto als Objekt erzeugen
            // Dank DI wird hier kein Konto von einem festgelegten Typ mit new angelegt. 
            // Der exakte Typ ist durch die im Konstruktor übergebene Klassenfabrik bestimmt !
            var neuesKonto = Konto.Create(KtoNr, Kunde);

            // neues Konto im Verzeichnis aller Konten aufnehmen
            _AlleGirokonten.Add(neuesKonto);

            // Beziehung zwischen Kunde und Konto definieren
            Kunde.KontoOeffnen(neuesKonto);
        }


        public void KontoSchließen(string Kontonummer)
        {
            // Konto suchen im Kontoverzeichnis
            var Konto = _AlleGirokonten.Single(r => r.KtoNr == Kontonummer);

            // ... aus dem Verzeichnis löschen
            _AlleGirokonten.Remove(Konto);

            // Beziehung Kunde <-->> Konto aktualisieren
            // Kontoinhaber suchen
            var Kontoinhaber = _AlleKunden.Single(r => r.Konten.Any(rr => rr.KtoNr == Kontonummer));

            // Konto aus Liste den Kontoinhaber löschen
            Kontoinhaber.KontoSchliessen(Konto.KtoNr);

        }

    }
}
