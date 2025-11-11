using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace raketa_zabka
{
    public partial class Form1 : Form
    {
        int raketaRychlost = 10;
        int meteoritRychlost = 10;
        int skore = 0;
        int zivoty = 3;
        int palivo = 100;
        Random rnd = new Random();

        bool pohybVlevo = false;
        bool pohybVpravo = false;

        PictureBox[] meteory;
        PictureBox srdce;
        Timer Casovac = new Timer();
        private int pohybovyTik = 0;

        // Nová proměnná pro cooldown srdce
        private int srdceCooldown = 0;

        public Form1()
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;

            // Inicializace rakety
            Raketa.Left = hraciPlocha.Width / 2 - Raketa.Width / 2;
            Raketa.Top = hraciPlocha.Height - Raketa.Height - 10;

            // Inicializace meteorů
            PictureBox meteor1 = Meteorit;
            PictureBox meteor2 = VytvorMeteor(meteor1);
            PictureBox meteor3 = VytvorMeteor(meteor1);

            meteory = new PictureBox[] { meteor1, meteor2, meteor3 };
            foreach (var meteor in meteory)
                ResetujMeteor(meteor);

            // Bonusové srdce
            srdce = new PictureBox();
            srdce.Size = new Size(25, 25);
            srdce.Image = Zivot1.Image;
            srdce.SizeMode = PictureBoxSizeMode.Zoom;
            srdce.Visible = false;
            hraciPlocha.Controls.Add(srdce);

            Casovac.Interval = 50;
            Casovac.Tick += GameLoop;
            Casovac.Start();
        }

        private PictureBox VytvorMeteor(PictureBox vzor)
        {
            PictureBox m = new PictureBox();
            m.Size = vzor.Size;
            m.Image = vzor.Image;
            m.BackColor = Color.Transparent;
            m.SizeMode = PictureBoxSizeMode.Zoom;
            m.Top = -vzor.Height;
            m.Left = rnd.Next(0, hraciPlocha.Width - vzor.Width);
            hraciPlocha.Controls.Add(m);
            return m;
        }

        // ===================== Herní smyčka =====================
        private void GameLoop(object sender, EventArgs e)
        {
            bool hybeSe = false;

            // Pohyb rakety
            if (pohybVlevo && Raketa.Left > 0)
            {
                Raketa.Left -= raketaRychlost;
                hybeSe = true;
            }
            if (pohybVpravo && Raketa.Right < hraciPlocha.Width)
            {
                Raketa.Left += raketaRychlost;
                hybeSe = true;
            }

            // Ubývání paliva jen při pohybu
            if (hybeSe)
            {
                pohybovyTik++;
                if (pohybovyTik >= 5)
                {
                    palivo--;
                    pohybovyTik = 0;
                }
            }

            if (palivo < 0) palivo = 0;

            // Pohyb meteorů
            foreach (var meteor in meteory)
            {
                meteor.Top += meteoritRychlost;

                if (meteor.Top > hraciPlocha.Height)
                {
                    skore++;
                    ResetujMeteor(meteor);
                }

                if (Raketa.Bounds.IntersectsWith(meteor.Bounds))
                {
                    ResetujMeteor(meteor);
                    ZtrataZivota();
                }
            }

            // Bonusové srdce s cooldownem
            if (srdceCooldown > 0)
                srdceCooldown--;

            if (!srdce.Visible && srdceCooldown == 0)
            {
                // Nastavení srdce
                srdce.Left = rnd.Next(0, hraciPlocha.Width - srdce.Width);
                srdce.Top = 0;
                srdce.Visible = true;

                // Cooldown podle rychlosti
                srdceCooldown = Math.Max(20, 200 - meteoritRychlost * 10);
            }

            if (srdce.Visible)
            {
                srdce.Top += meteoritRychlost;
                if (srdce.Top > hraciPlocha.Height)
                    srdce.Visible = false;

                if (Raketa.Bounds.IntersectsWith(srdce.Bounds))
                {
                    if (zivoty < 3)
                    {
                        zivoty++;
                        AktualizujZivoty();
                    }
                    srdce.Visible = false;
                }
            }

            AktualizujGUI();

            // Konec hry
            if (zivoty <= 0 || palivo <= 0)
            {
                Casovac.Stop();
                DialogResult result = MessageBox.Show(
                    $"Konec hry!\nTvoje skóre: {skore}\nChceš hrát znovu?",
                    "Game Over",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    buttonReset_Click(null, null);
                }
                else
                {
                    this.Close();
                }
            }
        }

        // ===================== Pomocné metody =====================
        private void ResetujMeteor(PictureBox meteor)
        {
            meteor.Top = -rnd.Next(50, 300);
            meteor.Left = rnd.Next(0, hraciPlocha.Width - meteor.Width);
        }

        private void ZtrataZivota()
        {
            zivoty--;
            AktualizujZivoty();
        }

        private void AktualizujZivoty()
        {
            Zivot1.Visible = zivoty >= 1;
            Zivot2.Visible = zivoty >= 2;
            Zivot3.Visible = zivoty >= 3;
        }

        // ===================== Ovládání kláves =====================
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                pohybVlevo = true;
            if (e.KeyCode == Keys.Right)
                pohybVpravo = true;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                pohybVlevo = false;
            if (e.KeyCode == Keys.Right)
                pohybVpravo = false;
        }

        private void txt_heading_Click(object sender, EventArgs e) { }

        // ===================== OVLÁDACÍ PRVKY =====================
        private void buttonStart_Click(object sender, EventArgs e)
        {
            Casovac.Start();
            buttonStart.Enabled = false;    // Start je teď šedé, protože hra běží
            buttonStop.Enabled = true;      // Stop povolené
            buttonReset.Enabled = true;     // Reset vždy povolené

            trackBarSpeed.Enabled = true;
            if (boxPalivo != null) boxPalivo.Enabled = false;
            if (boxSkore != null) boxSkore.Enabled = false;

            this.ActiveControl = null; // focus na formulář
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            Casovac.Stop();
            buttonStart.Enabled = true;    // po pauze můžeme znovu spustit hru
            buttonStop.Enabled = false;    // Stop šedé
            buttonReset.Enabled = true;    // Reset stále povolené

            trackBarSpeed.Enabled = true;
            if (boxPalivo != null) boxPalivo.Enabled = false;
            if (boxSkore != null) boxSkore.Enabled = false;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            Casovac.Stop();

            // Reset hodnot
            skore = 0;
            zivoty = 3;
            palivo = 100;
            pohybVlevo = false;
            pohybVpravo = false;

            AktualizujGUI();
            AktualizujZivoty();

            foreach (var meteor in meteory)
                ResetujMeteor(meteor);

            Raketa.Left = hraciPlocha.Width / 2 - Raketa.Width / 2;
            Raketa.Top = hraciPlocha.Height - Raketa.Height - 10;

            if (progressBarFuel != null)
                progressBarFuel.Value = 100;

            // Správný stav tlačítek
            buttonStart.Enabled = true;   // Start aktivní
            buttonStop.Enabled = false;   // Stop šedé
            buttonReset.Enabled = true;   // Reset aktivní

            trackBarSpeed.Enabled = true;
            if (boxPalivo != null) boxPalivo.Enabled = false;
            if (boxSkore != null) boxSkore.Enabled = false;
        }



        private void trackBarSpeed_Scroll(object sender, EventArgs e)
        {
            raketaRychlost = trackBarSpeed.Value;
            meteoritRychlost = trackBarSpeed.Value;
            Casovac.Interval = Math.Max(10, 60 - trackBarSpeed.Value);
            labelSpeedValue.Text = raketaRychlost.ToString();
            this.ActiveControl = null;
        }

        private void AktualizujGUI()
        {
            if (boxSkore != null)
                boxSkore.Text = skore.ToString();

            if (boxPalivo != null)
                boxPalivo.Text = palivo.ToString();

            if (progressBarFuel != null)
                progressBarFuel.Value = Math.Max(0, Math.Min(palivo, 100));

            if (labelInfo != null)
                labelInfo.Text = $"Skóre: {skore} | Životy: {zivoty} | Palivo: {palivo}%";
        }
    }
}
