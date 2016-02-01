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
        public IEnumerable<Girokonto> AlleGirokonten
        {
            get
            {
                return _AlleGirokonten;
            }
        }

        List<Girokonto> _AlleGirokonten = new List<Girokonto>();

        public IEnumerable<Kunde> AlleKunden
        {
            get
            {
                return _AlleKunden;
            }            
        }

        private List<Kunde> _AlleKunden = new List<Kunde>();


        public void NeuerKundeAnlegen(string Name)
        {

            // Prüfen, ob Kunde mit dem Namen nicht bereits existiert
            if (_AlleKunden.Any(r => r.Name == Name))
                throw new Exception("Der Kunde mit dem Namen " + Name + " existiert bereits.");

            try
            {
                _AlleKunden.Add(new Kunde(Name));
            }
            catch (Exception ex)
            {
                throw new Exception("Beim Anlegen des Kunden " + Name, ex);
            }
        }

        public void NeuesKontoEröffnen(string KtoNr, Kunde Kunde)
        {
            // neues Konto als Objekt erzeugen
            var neuesKonto = new Girokonto(KtoNr, Kunde);            

            // neues Konto im Verzeichnis aller Konten aufnehmen
            _AlleGirokonten.Add(neuesKonto);

            // Beziehung zwischen Kunde und Konto definieren
            Kunde.NeuesKonto(neuesKonto);            
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
            Kontoinhaber.KontoSchließen(Konto);

        }

    }
}
