using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankBL.Test
{
    [TestClass]
    public class Bank
    {
        [TestMethod]
        public void Bank_KontoTests()
        {
             var DonaldsKonto = new BankBL.Girokonto();
            Kontotransaktionen(DonaldsKonto);


        }

        private static void Kontotransaktionen(BankBL.Girokonto DonaldsKonto)
        {
           

            DonaldsKonto.KtoNr = "4711";

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
            var Donalds = BankhausDagobert.NeuerKundeAnlegen("Donald");
            var Daisy = BankhausDagobert.NeuerKundeAnlegen("Daisy");

            Assert.IsTrue(BankhausDagobert.AlleKunden.Length == 2);

            // Konten für die Kunden eröffnen
            var DonaldsKonto =  BankhausDagobert.NeuesKontoEröffnen("4711", Donalds);
            var DaisyKonto = BankhausDagobert.NeuesKontoEröffnen("0815", Daisy);

            Assert.IsTrue(BankhausDagobert.AlleGirokonten.Length == 2);

            // Ist die Beziehung zw. Konten und Kunde von NeuesKontoEröffnen richtig gesetzt worden
            Assert.IsTrue(Donalds.Konten.Length == 1);

            Kontotransaktionen(DonaldsKonto);
            Kontotransaktionen(DaisyKonto);

        }

    }
}
