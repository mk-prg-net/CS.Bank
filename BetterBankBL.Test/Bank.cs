using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BetterBankBL.Test
{
    [TestClass]
    public class Bank
    {
        static BetterBankBL.Interfaces.KundenFactory KundenFactory;
        static BetterBankBL.Interfaces.KontenFactory KontenFactory;

        [ClassInitialize]
        public static void TestClassInit(TestContext ctx)
        {
            KundenFactory = new BetterBankBL.TestMockUps.KundenFactory();
            KontenFactory = new BetterBankBL.TestMockUps.KontenFactory();
        }


        /// <summary>
        /// Initialisierung vor jedem Test
        /// </summary>
        [TestInitialize]
        public void TestInit()
        {

        }

        /// <summary>
        /// Aufräumarbeiten nach jedem Test
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {

        }

        [TestMethod]
        public void Bank_KontoTests()
        {
            

            var DonaldsKonto = KontenFactory.Create("4711", null);
            Kontotransaktionen(DonaldsKonto);


        }

        private static void Kontotransaktionen(BetterBankBL.Interfaces.IKonto Konto)
        {
            // Eine Behauptung prüfen im Rahmen des Testframeworks
            Assert.AreEqual(0.0, Konto.Guthaben);

            Konto.Einzahlen(500);
            
            Assert.IsTrue(Konto.Guthaben == 500.0);
            Assert.AreEqual(500.0, Konto.Guthaben);

            Konto.Abheben(200);
            Assert.IsTrue(Konto.Guthaben == 300.0);
            //Assert.AreEqual(500.0, DonaldsKonto.Guthaben);
            Assert.AreEqual(300.0, Konto.Guthaben);
        }


        [TestMethod]
        public void Bank_BankhausTests()
        {
            // DI- Pattern: Auflösen der Abhängigkeiten durch übergeben der Klassenfabriken an den Konstruktor
            var BankhausDagobert = new BetterBankBL.Interfaces.Bank(KundenFactory, KontenFactory, "Dagobert");

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
