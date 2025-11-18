using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace raketa_zabka
{
    public partial class FormSkore : Form
    {
        public FormSkore()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=databaze.db"))
            {
                conn.Open();

                SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM ScoreLog ORDER BY Id DESC", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }
    }
}
