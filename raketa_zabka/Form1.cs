using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;

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

        private int srdceCooldown = 0;
        private string playerName = "Hráč";

        public Form1()
        {
            InitializeComponent();

            // Vytvoření tabulky pokud neexistuje
            string cesta = "Data Source=databaze.db";
            using (var conn = new SQLiteConnection(cesta))
            {
                conn.Open();
                string sql = @"CREATE TABLE IF NOT EXISTS ScoreLog (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Jmeno TEXT,
                    Skore INT,
                    Zivoty INT,
                    Palivo INT,
                    Datum TEXT
                  );";
                using (var cmd = new SQLiteCommand(sql, conn))
                    cmd.ExecuteNonQuery();
            }

            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;

            // Inicializace pozic
            Raketa.Left = hraciPlocha.Width / 2 - Raketa.Width / 2;
            Raketa.Top = hraciPlocha.Height - Raketa.Height - 10;

            // Meteory
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

            // Timer (nepustíme ho hned - spustíme po zadání jména)
            Casovac.Interval = 50;
            Casovac.Tick += GameLoop;

            // Nastav textBoxJmeno neinteraktivní (bude nastaven po zadání jména)
            textBoxJmeno.TabStop = false;
            textBoxJmeno.ReadOnly = true;
            textBoxJmeno.Enabled = false;

            // Zeptej se na jméno hráče a spusť hru
            playerName = AskForPlayerName();
            textBoxJmeno.Text = playerName;
            StartGameAfterName();
        }

        private string AskForPlayerName()
        {
            // Jednoduchý modalní dialog vytvořený za běhu (nemusíš přidávat další soubory)
            using (Form f = new Form())
            {
                f.StartPosition = FormStartPosition.CenterParent;
                f.FormBorderStyle = FormBorderStyle.FixedDialog;
                f.ClientSize = new Size(400, 120);
                f.Text = "Zadej jméno hráče";

                Label lbl = new Label() { Left = 12, Top = 15, Width = 370, Text = "Prosím zadej své jméno (bude použito pro ukládání skóre):" };
                TextBox txt = new TextBox() { Left = 12, Top = 40, Width = 370 };
                Button ok = new Button() { Text = "OK", Left = 220, Width = 80, Top = 72, DialogResult = DialogResult.OK };
                Button cancel = new Button() { Text = "Zrušit", Left = 310, Width = 80, Top = 72, DialogResult = DialogResult.Cancel };

                ok.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                cancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

                f.Controls.AddRange(new Control[] { lbl, txt, ok, cancel });
                f.AcceptButton = ok;
                f.CancelButton = cancel;

                while (true)
                {
                    var dr = f.ShowDialog(this);
                    if (dr == DialogResult.OK)
                    {
                        var name = txt.Text?.Trim();
                        if (!string.IsNullOrEmpty(name))
                            return name;
                        // pokud prázdné, ukaž warning a opakuj dialog
                        MessageBox.Show(this, "Jméno nesmí být prázdné.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue;
                    }
                    else
                    {
                        // uživatel zrušil -> vrátíme default
                        return "Hráč";
                    }
                }
            }
        }

        private void StartGameAfterName()
        {
            // Zajistí, že textBoxJmeno nebude interaktivní a hra se spustí
            textBoxJmeno.Text = playerName;
            textBoxJmeno.Enabled = false;
            textBoxJmeno.ReadOnly = true;
            textBoxJmeno.TabStop = false;

            // Spustit timer hry
            Casovac.Start();

            // Aktualizovat GUI aktuálním stavem
            AktualizujZivoty();
            AktualizujGUI();

            // Ujistit se, že focus není v textboxu
            this.ActiveControl = null;
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

        // Herní smyčka
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

            // Srdce
            if (srdceCooldown > 0)
                srdceCooldown--;

            if (!srdce.Visible && srdceCooldown == 0)
            {
                // pokud má hráč plné životy, neukazujeme
                if (zivoty < 3)
                {
                    srdce.Left = rnd.Next(0, hraciPlocha.Width - srdce.Width);
                    srdce.Top = 0;
                    srdce.Visible = true;
                }

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

            // Konec hry (když dojdou životy nebo palivo)
            if (zivoty <= 0 || palivo <= 0)
            {
                Casovac.Stop();
                UlozSkoreDoDatabaze();
                DialogResult result = MessageBox.Show(
                    this,
                    $"Konec hry!\nTvoje skóre: {skore}\nChceš hrát znovu?",
                    "Game Over",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    buttonReset_Click(null, null);
                    // Po resetu znovu nastavíme jméno a spustíme
                    textBoxJmeno.Text = playerName;
                    Casovac.Start();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void button1_Click_Results(object sender, EventArgs e)
        {
            FormSkore f = new FormSkore();
            f.Show();
        }

        private void UlozSkoreDoDatabaze()
        {
            string cesta = "Data Source=databaze.db";

            using (SQLiteConnection conn = new SQLiteConnection(cesta))
            {
                conn.Open();

                string sql = "INSERT INTO ScoreLog (Jmeno, Skore, Zivoty, Palivo, Datum) VALUES (@j, @s, @z, @p, @d)";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@j", playerName ?? "Hráč");
                    cmd.Parameters.AddWithValue("@s", skore);
                    cmd.Parameters.AddWithValue("@z", zivoty);
                    cmd.Parameters.AddWithValue("@p", palivo);
                    cmd.Parameters.AddWithValue("@d", DateTime.Now.ToString("dd.MM.yyyy HH:mm"));

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Pomocné metody
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

        // Ovládání kláves
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

        // Ovládací prvky
        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (!Casovac.Enabled)
                Casovac.Start();

            buttonStart.Enabled = false;
            buttonStop.Enabled = true;
            buttonReset.Enabled = true;

            trackBarSpeed.Enabled = true;

            this.ActiveControl = null;

            ResetGame();
            btnStart.Enabled = false;

            // Aktivovat prvky až při startu hry
            Zivot1.Visible = true;
            Zivot2.Visible = true;
            Zivot3.Visible = true;

            progressBarPalivo.Enabled = true;
            trackBarRychlost.Enabled = true;
            btnNacistSkore.Enabled = true;
            boxSkore.Enabled = true;
            boxPalivo.Enabled = true;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            Casovac.Stop();
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
            buttonReset.Enabled = true;

            trackBarSpeed.Enabled = true;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            Casovac.Stop();

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

            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
            buttonReset.Enabled = true;
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

        private void label1_Click(object sender, EventArgs e)
        {
            FormSkore f = new FormSkore();
            f.Show();
        }
    }
}
