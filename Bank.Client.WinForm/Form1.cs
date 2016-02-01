using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank.Client.WinForm
{
    public partial class Form1 : Form
    {

        static BetterBankBL.Interfaces.KundenFactory KundenFactory = new BetterBankBL.TestMockUps.KundenFactory();
        static BetterBankBL.Interfaces.KontenFactory KontenFactory = new BetterBankBL.TestMockUps.KontenFactory();


        IEnumerable<KundenViewModel> CreateKundenliste()
        {
            return Bankhaus.AlleKunden.Select(r => new KundenViewModel(r));
        }


        // Bankhaus als Singelton: dieses Objkekt wird die Gesamte Laufzeit über existieren
        BetterBankBL.Interfaces.Bank Bankhaus;

        public Form1()
        {
            InitializeComponent();

            Text = Properties.Settings.Default.Programmtitel;

            Bankhaus = new  BetterBankBL.Interfaces.Bank(KundenFactory, KontenFactory, "Dagobert");

            KundenBindingSource.DataSource = CreateKundenliste();
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnKundeNeu_Click(object sender, EventArgs e)
        {
            Bankhaus.NeuerKundeAnlegen(tbxName.Text);

            toolStripStatusLabel1.Text =  "Der neue Kunde" + tbxName.Text + " wurde angelegt";

            KundenBindingSource.DataSource = CreateKundenliste();
            KundenBindingSource.ResetBindings(false);   

        }
    }
}
