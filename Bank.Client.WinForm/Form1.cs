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
        // Bankhaus als Singelton: dieses Objkekt wird die Gesamte Laufzeit über existieren
        BankBL.Bankhaus Bankhaus = new BankBL.Bankhaus();

        public Form1()
        {
            InitializeComponent();

            Text = Properties.Settings.Default.Programmtitel;

            KundenBindingSource.DataSource = Bankhaus.AlleKunden;
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnKundeNeu_Click(object sender, EventArgs e)
        {
            Bankhaus.NeuerKundeAnlegen(tbxName.Text);

            toolStripStatusLabel1.Text =  "Der neue Kunde" + tbxName.Text + " wurde angelegt";

            KundenBindingSource.DataSource = Bankhaus.AlleKunden;
            KundenBindingSource.ResetBindings(false);           



        }
    }
}
