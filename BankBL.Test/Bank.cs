﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BankBL.Test
{
    [TestClass]
    public class Bank
    {
        [TestMethod]
        public void Bank_KontoTests()
        {
            var DonaldsKonto = new BankBL.Girokonto("4711", null);
            Kontotransaktionen(DonaldsKonto);


        }

        private static void Kontotransaktionen(BankBL.Girokonto DonaldsKonto)
        {


            // Eine Behauptung prüfen im Rahmen des Testframeworks
            Assert.AreEqual(0.0, DonaldsKonto.Guthaben);

            var neueGuthaben = DonaldsKonto.Einzahlen(500);
            Assert.IsTrue(neueGuthaben == 500.0);
            Assert.AreEqual(500.0, DonaldsKonto.Guthaben);

            neueGuthaben = DonaldsKonto.Abheben(200);
            Assert.IsTrue(neueGuthaben == 300.0);
            //Assert.AreEqual(500.0, DonaldsKonto.Guthaben);
            Assert.AreEqual(300.0, DonaldsKonto.Guthaben);
        }


        [TestMethod]
        public void Bank_BankhausTests()
        {
            var BankhausDagobert = new BankBL.Bankhaus();

            // Neue Kunden anlegen
            BankhausDagobert.NeuerKundeAnlegen("Donald");
            var Donald = BankhausDagobert.AlleKunden.FirstOrDefault(r => r.Name == "Donald");
            Assert.IsNotNull(Donald, "Kunde Donald sollte angelegt werden");

            BankhausDagobert.NeuerKundeAnlegen("Daisy");
            var Daisy = BankhausDagobert.AlleKunden.Single(r => r.Name == "Daisy");
            Assert.IsNotNull(Daisy, "Kunde Daisy sollte angelegt werden");

            if (BankhausDagobert.AlleKunden.Count() == 2)
            {

                // Konten für die Kunden eröffnen
                BankhausDagobert.NeuesKontoEröffnen("4711", Donald);
                var DonaldsKonto = BankhausDagobert.AlleGirokonten.FirstOrDefault(r => r.KtoNr == "4711");
                Assert.IsNotNull(DonaldsKonto, "Konto von Donald sollte angelegt werden");

                BankhausDagobert.NeuesKontoEröffnen("0815", Daisy);
                var DaisyKonto = BankhausDagobert.AlleGirokonten.FirstOrDefault(r => r.KtoNr == "0815");
                Assert.IsNotNull(DaisyKonto, "Konto von Daisy sollte angelegt werden");

                if (BankhausDagobert.AlleGirokonten.Count() == 2)
                {
                    // Ist die Beziehung zw. Konten und Kunde von NeuesKontoEröffnen richtig gesetzt worden
                    Assert.IsTrue(Donald.Konten.Count() == 1);

                    Kontotransaktionen(DonaldsKonto);
                    Kontotransaktionen(DaisyKonto);
                }
            }

        }

    }
}
