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

        public Form1()
        {
            InitializeComponent();

            // Zachycení pohybu kláves
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

            // Inicializace bonusového srdce
            srdce = new PictureBox();
            srdce.Size = new Size(25, 25);
            srdce.Image = Zivot1.Image;
            srdce.SizeMode = PictureBoxSizeMode.Zoom;
            srdce.Visible = false;
            hraciPlocha.Controls.Add(srdce);

            // Nastavení timeru
            Casovac.Interval = 50;
            Casovac.Tick += GameLoop;
            Casovac.Start();
        }

        // Funkce pro vytvoření kopie meteoritu
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

            // Pomalu ubývá palivo jen při pohybu
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
            boxPalivo.Text = palivo.ToString();

            // Pohyb meteorů
            foreach (var meteor in meteory)
            {
                meteor.Top += meteoritRychlost;

                // Reset mimo obraz
                if (meteor.Top > hraciPlocha.Height)
                {
                    skore++;
                    boxSkore.Text = skore.ToString();
                    ResetujMeteor(meteor);
                }

                // Kolize s raketou
                if (Raketa.Bounds.IntersectsWith(meteor.Bounds))
                {
                    ResetujMeteor(meteor);
                    ZtrataZivota();
                }
            }

            // Bonusové srdce (náhodně)
            if (!srdce.Visible && rnd.Next(0, 250) == 1)
            {
                srdce.Left = rnd.Next(0, hraciPlocha.Width - srdce.Width);
                srdce.Top = 0;
                srdce.Visible = true;
            }

            if (srdce.Visible)
            {
                srdce.Top += 5;
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

            // Konec hry
            if (zivoty <= 0 || palivo <= 0)
            {
                Casovac.Stop();
                MessageBox.Show($"Konec hry!\nTvoje skóre: {skore}", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
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

        private void txt_heading_Click(object sender, EventArgs e)
        {

        }

        private void ResetMeteor(PictureBox meteor)
        {
            meteor.Top = -meteor.Height;
            meteor.Left = rnd.Next(0, hraciPlocha.Width - meteor.Width);
        }
    }
}