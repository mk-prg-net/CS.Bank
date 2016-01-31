using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankBL
{
    public class Bankhaus
    {
        /// <summary>
        /// Liste aller Konten
        /// </summary>
        public Girokonto[] AlleGirokonten
        {
            get
            {
                return _AlleGirokonten.ToArray();
            }
        }

        List<Girokonto> _AlleGirokonten = new List<Girokonto>();

        public Kunde[] AlleKunden
        {
            get
            {
                return _AlleKunden.ToArray();
            }            
        }

        public List<Kunde> _AlleKunden = new List<Kunde>();


        public Kunde NeuerKundeAnlegen(string Name)
        {
            var Kunde = new Kunde();
            Kunde.Name = Name;
            _AlleKunden.Add(Kunde);

            return Kunde;
        }

        public Girokonto NeuesKontoEröffnen(string Kontonummer, Kunde Kunde)
        {
            // neues Konto als Objekt erzeugen
            var neuesKonto = new Girokonto();
            neuesKonto.KtoNr = Kontonummer;

            // neues Konto im Verzeichnis aller Konten aufnehmen
            _AlleGirokonten.Add(neuesKonto);

            // Beziehung zwischen Kunde und Konto definieren
            Kunde.NeueKontoEröffnen(neuesKonto);

            return neuesKonto;
        }


        public void KontoSchließen(string Kontonummer)
        {
            // Konto suchen im Kontoverzeichnis
            var Konto = _AlleGirokonten.Single(r => r.KtoNr == Kontonummer);

            // ... aus dem Verzeichnis löschen
            _AlleGirokonten.Remove(Konto);


            // Kontoinhaber suchen
            var Kontoinhaber = _AlleKunden.Single(r => r.Konten.Any(rr => rr.KtoNr == Kontonummer));

            // Konto aus Liste den Kontoinhaber löschen
            Kontoinhaber.KontoSchließen(Konto);

        }

    }
}
