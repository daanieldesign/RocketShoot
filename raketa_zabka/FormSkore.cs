using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace raketa_zabka
{
    public partial class FormSkore : Form
    {
        public FormSkore()
        {
            InitializeComponent();

            // Načteme data při otevření (Show / ShowDialog)
            this.Shown += FormSkore_Shown;
        }

        private void FormSkore_Shown(object sender, EventArgs e)
        {
            NactiVysledky();
        }

        private void btnNacist_Click(object sender, EventArgs e)
        {
            NactiVysledky();
        }

        private void NactiVysledky()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection("Data Source=databaze.db"))
                {
                    conn.Open();

                    SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT Id, Jmeno, Skore, Zivoty, Palivo, Datum FROM ScoreLog ORDER BY Id DESC", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Pokud byly starší návrhy s názvy dataGridView1/ dataGridViewSkore, použijeme dataGridView1
                    dataGridView1.DataSource = dt;
                    dataGridView1.AutoResizeColumns();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Chyba při načítání výsledků: " + ex.Message, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
