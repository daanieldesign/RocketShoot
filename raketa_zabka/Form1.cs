using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;

namespace raketa_zabka
{
    public partial class Form1 : Form
    {
        // --- HERNÍ PROMĚNNÉ ---
        int raketaRychlost = 10;
        int meteoritRychlost = 10;
        int skore = 0;
        int zivoty = 3;
        int palivo = 100;

        Random rnd = new Random();

        bool pohybVlevo = false;
        bool pohybVpravo = false;

        PictureBox[] meteory;
        PictureBox srdce; // Objekt pro padající bonus
        Timer Casovac = new Timer();

        private int pohybovyTik = 0;
        private int srdceCooldown = 0; // Odpočet do dalšího srdce
        private string playerName = "Hráč";

        public Form1()
        {
            InitializeComponent();

            // 1. Databáze
            InicializujDatabazi();

            // 2. Klávesnice
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;

            // 3. Raketa
            Raketa.Parent = hraciPlocha;
            Raketa.Left = hraciPlocha.Width / 2 - Raketa.Width / 2;
            Raketa.Top = hraciPlocha.Height - Raketa.Height - 10;
            Raketa.BringToFront();

            // 4. Meteory
            Meteorit.Parent = hraciPlocha;
            PictureBox meteor1 = Meteorit;
            PictureBox meteor2 = VytvorMeteor(meteor1);
            PictureBox meteor3 = VytvorMeteor(meteor1);

            meteory = new PictureBox[] { meteor1, meteor2, meteor3 };
            foreach (var meteor in meteory)
            {
                ResetujMeteor(meteor);
                meteor.BringToFront();
            }

            // 5. NASTAVENÍ PADAJÍCÍHO SRDÍČKA
            srdce = new PictureBox();
            srdce.Size = new Size(30, 30); // Velikost srdíčka

            // Vezmeme obrázek z ukazatele životů (pokud existuje)
            if (Zivot1.Image != null)
                srdce.Image = Zivot1.Image;
            else
                srdce.BackColor = Color.Red; // Kdyby nebyl obrázek, bude to červený čtverec

            srdce.SizeMode = PictureBoxSizeMode.Zoom;
            srdce.BackColor = Color.Transparent;
            srdce.Visible = false; // Na začátku není vidět
            srdce.Parent = hraciPlocha; // Důležité pro průhlednost
            hraciPlocha.Controls.Add(srdce);
            srdce.BringToFront();

            // 6. Timer
            Casovac.Interval = 50;
            Casovac.Tick += GameLoop;

            // 7. GUI stav
            NastavStavHry(false);

            // Start
            ZiskejJmenoASpust();
        }

        // --- ŘEŠENÍ OVLÁDÁNÍ (aby fungovaly šipky i při zablokovaných tlačítkách) ---
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (Casovac.Enabled)
            {
                if (keyData == Keys.Left)
                {
                    pohybVlevo = true;
                    return true;
                }
                if (keyData == Keys.Right)
                {
                    pohybVpravo = true;
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void GameLoop(object sender, EventArgs e)
        {
            // 1. POHYB RAKETY
            if (pohybVlevo && Raketa.Left > 0) Raketa.Left -= raketaRychlost;
            if (pohybVpravo && Raketa.Right < hraciPlocha.Width) Raketa.Left += raketaRychlost;

            // 2. PALIVO
            bool hybeSe = pohybVlevo || pohybVpravo;
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

            // 3. METEORY (Pohyb a kolize)
            foreach (var meteor in meteory)
            {
                meteor.Top += meteoritRychlost;

                // Propadl dolů -> bod
                if (meteor.Top > hraciPlocha.Height)
                {
                    skore++;
                    ResetujMeteor(meteor);
                }

                // Srážka s raketou -> ubrat život
                if (Raketa.Bounds.IntersectsWith(meteor.Bounds))
                {
                    ResetujMeteor(meteor);
                    ZtrataZivota(); // Ubere život
                }
            }

            // 4. LOGIKA PRO PADAJÍCÍ SRDCE (Doplnění života)

            // Odpočet (aby nepadala pořád)
            if (srdceCooldown > 0) srdceCooldown--;

            // Pokud srdce není na scéně a odpočet doběhl
            if (!srdce.Visible && srdceCooldown <= 0)
            {
                // Srdce pošleme dolů jen pokud hráč není plně uzdravený (má méně než 3 životy)
                // Pokud chceš, aby padala i tak (třeba pro skóre), smaž podmínku "zivoty < 3"
                if (zivoty < 3)
                {
                    srdce.Left = rnd.Next(0, hraciPlocha.Width - srdce.Width);
                    srdce.Top = -srdce.Height;
                    srdce.Visible = true;
                    srdce.BringToFront(); // Ujistíme se, že je vidět nad pozadím
                }

                // Nastavíme náhodný čas, kdy zkusit poslat další (cca každých 100-300 tiků)
                srdceCooldown = rnd.Next(100, 300);
            }

            // Pohyb srdce
            if (srdce.Visible)
            {
                srdce.Top += meteoritRychlost; // Padá stejně rychle jako meteory

                // Pokud propadne dolů, zmizí
                if (srdce.Top > hraciPlocha.Height)
                {
                    srdce.Visible = false;
                }

                // HRÁČ CHYTIL SRDCE
                if (Raketa.Bounds.IntersectsWith(srdce.Bounds))
                {
                    if (zivoty < 3)
                    {
                        zivoty++; // Přidat život
                        AktualizujZivoty();
                    }
                    // Můžeme přidat i skóre za sebrání srdce
                    skore += 50;

                    srdce.Visible = false; // Skrýt srdce po sebrání
                }
            }

            // 5. UPDATE GUI
            AktualizujGUI();

            // 6. KONEC HRY
            if (zivoty <= 0 || palivo <= 0) GameOver();
        }

        // --- ZBYTEK FUNKCÍ (Iniciatlizace, Reset, GUI atd.) ---

        private void InicializujDatabazi()
        {
            string cesta = "Data Source=databaze.db";
            using (var conn = new SQLiteConnection(cesta))
            {
                conn.Open();
                string sql = @"CREATE TABLE IF NOT EXISTS ScoreLog (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Jmeno TEXT, Skore INT, Zivoty INT, Palivo INT, Datum TEXT);";
                using (var cmd = new SQLiteCommand(sql, conn)) cmd.ExecuteNonQuery();
            }
        }

        private void ZiskejJmenoASpust()
        {
            playerName = AskForPlayerName();
            textBoxJmeno.Text = playerName;
            StartGame();
        }

        private string AskForPlayerName()
        {
            using (Form f = new Form())
            {
                f.StartPosition = FormStartPosition.CenterScreen;
                f.FormBorderStyle = FormBorderStyle.FixedDialog;
                f.ControlBox = false;
                f.ClientSize = new Size(400, 120);
                f.Text = "Zadej jméno hráče";
                Label lbl = new Label() { Left = 12, Top = 15, Width = 370, Text = "Prosím zadej své jméno:" };
                TextBox txt = new TextBox() { Left = 12, Top = 40, Width = 370 };
                Button ok = new Button() { Text = "Hrát", Left = 150, Width = 100, Top = 72, DialogResult = DialogResult.OK };
                f.Controls.AddRange(new Control[] { lbl, txt, ok });
                f.AcceptButton = ok;

                while (true)
                {
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        var name = txt.Text?.Trim();
                        if (!string.IsNullOrEmpty(name)) return name;
                        MessageBox.Show("Jméno nesmí být prázdné.");
                    }
                    else return "Hráč";
                }
            }
        }

        private void NastavStavHry(bool hrajeme)
        {
            // Tlačítka
            buttonStart.Enabled = !hrajeme;
            buttonReset.Enabled = !hrajeme;
            buttonStop.Enabled = hrajeme;
            button1.Enabled = !hrajeme;

            // TabStop = false, aby nekradla focus
            buttonStop.TabStop = false;
            buttonStart.TabStop = false;
            buttonReset.TabStop = false;

            // Ostatní
            trackBarSpeed.Enabled = !hrajeme;
            textBoxJmeno.Enabled = !hrajeme;
            boxSkore.Enabled = !hrajeme;
            boxPalivo.Enabled = !hrajeme;

            // Focus na formulář
            if (hrajeme)
            {
                this.ActiveControl = null;
                this.Focus();
                hraciPlocha.Focus();
            }
        }

        private void StartGame()
        {
            NastavStavHry(true);
            if (!Casovac.Enabled) Casovac.Start();
            AktualizujZivoty();
            AktualizujGUI();
            this.ActiveControl = null;
        }

        private PictureBox VytvorMeteor(PictureBox vzor)
        {
            PictureBox m = new PictureBox();
            m.Size = vzor.Size;
            m.Image = vzor.Image;
            m.BackColor = Color.Transparent;
            m.SizeMode = PictureBoxSizeMode.Zoom;
            m.Parent = hraciPlocha;
            m.Top = -vzor.Height;
            m.Left = rnd.Next(0, hraciPlocha.Width - vzor.Width);
            hraciPlocha.Controls.Add(m);
            m.BringToFront();
            return m;
        }

        private void GameOver()
        {
            Casovac.Stop();
            NastavStavHry(false);
            UlozSkoreDoDatabaze();
            DialogResult result = MessageBox.Show(this, $"Konec hry!\nSkóre: {skore}\nHrát znovu?", "Game Over", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) { ResetGameData(); StartGame(); }
            else this.Close();
        }

        private void UlozSkoreDoDatabaze()
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection("Data Source=databaze.db"))
                {
                    conn.Open();
                    string sql = "INSERT INTO ScoreLog (Jmeno, Skore, Zivoty, Palivo, Datum) VALUES (@j, @s, @z, @p, @d)";
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@j", playerName);
                        cmd.Parameters.AddWithValue("@s", skore);
                        cmd.Parameters.AddWithValue("@z", zivoty);
                        cmd.Parameters.AddWithValue("@p", palivo);
                        cmd.Parameters.AddWithValue("@d", DateTime.Now.ToString("dd.MM.yyyy HH:mm"));
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception) { }
        }

        private void ResetujMeteor(PictureBox meteor)
        {
            meteor.Top = -rnd.Next(50, 400);
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

        private void AktualizujGUI()
        {
            if (boxSkore != null) boxSkore.Text = skore.ToString();
            if (boxPalivo != null) boxPalivo.Text = palivo.ToString();
            if (progressBarFuel != null) progressBarFuel.Value = Math.Max(0, Math.Min(palivo, 100));
            if (labelInfo != null) labelInfo.Text = $"Skóre: {skore} | Životy: {zivoty} | Palivo: {palivo}%";
        }

        private void ResetGameData()
        {
            skore = 0;
            zivoty = 3;
            palivo = 100;
            pohybVlevo = false;
            pohybVpravo = false;
            srdce.Visible = false; // Reset srdce
            srdceCooldown = 100;

            AktualizujGUI();
            AktualizujZivoty();

            foreach (var meteor in meteory) ResetujMeteor(meteor);

            Raketa.Left = hraciPlocha.Width / 2 - Raketa.Width / 2;
            Raketa.Top = hraciPlocha.Height - Raketa.Height - 10;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) { }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) pohybVlevo = false;
            if (e.KeyCode == Keys.Right) pohybVpravo = false;
        }
        private void buttonStart_Click(object sender, EventArgs e) { StartGame(); }
        private void buttonStop_Click(object sender, EventArgs e) { Casovac.Stop(); NastavStavHry(false); }
        private void buttonReset_Click(object sender, EventArgs e) { Casovac.Stop(); ResetGameData(); NastavStavHry(false); }
        private void trackBarSpeed_Scroll(object sender, EventArgs e)
        {
            raketaRychlost = trackBarSpeed.Value;
            meteoritRychlost = trackBarSpeed.Value;
            Casovac.Interval = Math.Max(10, 60 - trackBarSpeed.Value);
            labelSpeedValue.Text = raketaRychlost.ToString();
            this.ActiveControl = null;
        }
        private void button1_Click_Results(object sender, EventArgs e) { new FormSkore().ShowDialog(); }
        private void txt_heading_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
    }
}