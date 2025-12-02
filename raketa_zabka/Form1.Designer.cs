namespace raketa_zabka
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label txt_heading;
        private System.Windows.Forms.GroupBox hraciPlocha;
        private System.Windows.Forms.PictureBox Raketa;
        private System.Windows.Forms.PictureBox Meteorit;
        private System.Windows.Forms.PictureBox Zivot1;
        private System.Windows.Forms.PictureBox Zivot2;
        private System.Windows.Forms.PictureBox Zivot3;
        private System.Windows.Forms.Label txtZivoty;
        private System.Windows.Forms.Label txtPalivo;
        private System.Windows.Forms.MaskedTextBox boxPalivo;
        private System.Windows.Forms.MaskedTextBox boxSkore;
        private System.Windows.Forms.Button button1; // zobrazit výsledky
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.TrackBar trackBarSpeed;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.Label labelSpeedValue;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.ProgressBar progressBarFuel;
        private System.Windows.Forms.Label txtSkore;
        private System.Windows.Forms.TextBox textBoxJmeno;
        private System.Windows.Forms.Label label1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txt_heading = new System.Windows.Forms.Label();
            this.hraciPlocha = new System.Windows.Forms.GroupBox();
            this.Meteorit = new System.Windows.Forms.PictureBox();
            this.Raketa = new System.Windows.Forms.PictureBox();
            this.Zivot1 = new System.Windows.Forms.PictureBox();
            this.Zivot2 = new System.Windows.Forms.PictureBox();
            this.Zivot3 = new System.Windows.Forms.PictureBox();
            this.txtZivoty = new System.Windows.Forms.Label();
            this.txtPalivo = new System.Windows.Forms.Label();
            this.boxPalivo = new System.Windows.Forms.MaskedTextBox();
            this.boxSkore = new System.Windows.Forms.MaskedTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.trackBarSpeed = new System.Windows.Forms.TrackBar();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.labelSpeedValue = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.progressBarFuel = new System.Windows.Forms.ProgressBar();
            this.txtSkore = new System.Windows.Forms.Label();
            this.textBoxJmeno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxOvladani = new System.Windows.Forms.GroupBox();
            this.hraciPlocha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Meteorit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Raketa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Zivot1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Zivot2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Zivot3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).BeginInit();
            this.groupBoxOvladani.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_heading
            // 
            this.txt_heading.AutoSize = true;
            this.txt_heading.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txt_heading.Location = new System.Drawing.Point(337, 19);
            this.txt_heading.Name = "txt_heading";
            this.txt_heading.Size = new System.Drawing.Size(103, 20);
            this.txt_heading.TabIndex = 0;
            this.txt_heading.Text = "RocketShoot";
            // 
            // hraciPlocha
            // 
            this.hraciPlocha.BackColor = System.Drawing.SystemColors.ControlDark;
            this.hraciPlocha.BackgroundImage = global::raketa_zabka.Properties.Resources.Poznámka_2022_10_06_113933;
            this.hraciPlocha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.hraciPlocha.Controls.Add(this.Meteorit);
            this.hraciPlocha.Controls.Add(this.Raketa);
            this.hraciPlocha.Location = new System.Drawing.Point(-4, -5);
            this.hraciPlocha.Name = "hraciPlocha";
            this.hraciPlocha.Size = new System.Drawing.Size(811, 398);
            this.hraciPlocha.TabIndex = 1;
            this.hraciPlocha.TabStop = false;
            // 
            // Meteorit
            // 
            this.Meteorit.BackColor = System.Drawing.Color.Transparent;
            this.Meteorit.BackgroundImage = global::raketa_zabka.Properties.Resources.pngtree_meteor_fall_with_fire_png_image_13382941;
            this.Meteorit.Location = new System.Drawing.Point(346, 52);
            this.Meteorit.Name = "Meteorit";
            this.Meteorit.Size = new System.Drawing.Size(50, 52);
            this.Meteorit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Meteorit.TabIndex = 1;
            this.Meteorit.TabStop = false;
            // 
            // Raketa
            // 
            this.Raketa.BackColor = System.Drawing.Color.Transparent;
            this.Raketa.BackgroundImage = global::raketa_zabka.Properties.Resources.pngtree_missile_rocket_ammunition_war_conflict_military_warhead_nuclear_weapon_bomb_3d_png_image_16644986;
            this.Raketa.Location = new System.Drawing.Point(384, 119);
            this.Raketa.Name = "Raketa";
            this.Raketa.Size = new System.Drawing.Size(71, 83);
            this.Raketa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Raketa.TabIndex = 0;
            this.Raketa.TabStop = false;
            // 
            // Zivot1
            // 
            this.Zivot1.Location = new System.Drawing.Point(192, 413);
            this.Zivot1.Name = "Zivot1";
            this.Zivot1.Size = new System.Drawing.Size(32, 20);
            this.Zivot1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Zivot1.TabIndex = 7;
            this.Zivot1.TabStop = false;
            // 
            // Zivot2
            // 
            this.Zivot2.Location = new System.Drawing.Point(230, 413);
            this.Zivot2.Name = "Zivot2";
            this.Zivot2.Size = new System.Drawing.Size(32, 20);
            this.Zivot2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Zivot2.TabIndex = 8;
            this.Zivot2.TabStop = false;
            // 
            // Zivot3
            // 
            this.Zivot3.Location = new System.Drawing.Point(268, 413);
            this.Zivot3.Name = "Zivot3";
            this.Zivot3.Size = new System.Drawing.Size(32, 20);
            this.Zivot3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Zivot3.TabIndex = 9;
            this.Zivot3.TabStop = false;
            // 
            // txtZivoty
            // 
            this.txtZivoty.AutoSize = true;
            this.txtZivoty.Location = new System.Drawing.Point(150, 416);
            this.txtZivoty.Name = "txtZivoty";
            this.txtZivoty.Size = new System.Drawing.Size(36, 13);
            this.txtZivoty.TabIndex = 17;
            this.txtZivoty.Text = "Životy";
            // 
            // txtPalivo
            // 
            this.txtPalivo.AutoSize = true;
            this.txtPalivo.Location = new System.Drawing.Point(306, 416);
            this.txtPalivo.Name = "txtPalivo";
            this.txtPalivo.Size = new System.Drawing.Size(36, 13);
            this.txtPalivo.TabIndex = 16;
            this.txtPalivo.Text = "Palivo";
            // 
            // boxPalivo
            // 
            this.boxPalivo.Location = new System.Drawing.Point(348, 413);
            this.boxPalivo.Name = "boxPalivo";
            this.boxPalivo.ReadOnly = true;
            this.boxPalivo.Size = new System.Drawing.Size(71, 20);
            this.boxPalivo.TabIndex = 13;
            this.boxPalivo.TabStop = false;
            // 
            // boxSkore
            // 
            this.boxSkore.Location = new System.Drawing.Point(64, 413);
            this.boxSkore.Name = "boxSkore";
            this.boxSkore.ReadOnly = true;
            this.boxSkore.Size = new System.Drawing.Size(71, 20);
            this.boxSkore.TabIndex = 15;
            this.boxSkore.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button1.Location = new System.Drawing.Point(444, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(237, 46);
            this.button1.TabIndex = 8;
            this.button1.Text = "Zobrazit výsledky";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_Results);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(20, 25);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(100, 25);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(180, 25);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 2;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // trackBarSpeed
            // 
            this.trackBarSpeed.Location = new System.Drawing.Point(270, 20);
            this.trackBarSpeed.Maximum = 25;
            this.trackBarSpeed.Minimum = 5;
            this.trackBarSpeed.Name = "trackBarSpeed";
            this.trackBarSpeed.Size = new System.Drawing.Size(150, 45);
            this.trackBarSpeed.TabIndex = 9;
            this.trackBarSpeed.TickFrequency = 5;
            this.trackBarSpeed.Value = 10;
            this.trackBarSpeed.Scroll += new System.EventHandler(this.trackBarSpeed_Scroll);
            // 
            // labelSpeed
            // 
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Location = new System.Drawing.Point(270, 65);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(51, 13);
            this.labelSpeed.TabIndex = 10;
            this.labelSpeed.Text = "Rychlost:";
            // 
            // labelSpeedValue
            // 
            this.labelSpeedValue.AutoSize = true;
            this.labelSpeedValue.Location = new System.Drawing.Point(330, 65);
            this.labelSpeedValue.Name = "labelSpeedValue";
            this.labelSpeedValue.Size = new System.Drawing.Size(19, 13);
            this.labelSpeedValue.TabIndex = 11;
            this.labelSpeedValue.Text = "10";
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.labelInfo.Location = new System.Drawing.Point(426, 57);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(281, 24);
            this.labelInfo.TabIndex = 12;
            this.labelInfo.Text = "Skóre: 0 | Životy: 3 | Palivo: 100%";
            // 
            // progressBarFuel
            // 
            this.progressBarFuel.Location = new System.Drawing.Point(639, 413);
            this.progressBarFuel.Name = "progressBarFuel";
            this.progressBarFuel.Size = new System.Drawing.Size(150, 23);
            this.progressBarFuel.TabIndex = 14;
            this.progressBarFuel.Value = 100;
            // 
            // txtSkore
            // 
            this.txtSkore.AutoSize = true;
            this.txtSkore.Location = new System.Drawing.Point(23, 416);
            this.txtSkore.Name = "txtSkore";
            this.txtSkore.Size = new System.Drawing.Size(35, 13);
            this.txtSkore.TabIndex = 18;
            this.txtSkore.Text = "Skóre";
            // 
            // textBoxJmeno
            // 
            this.textBoxJmeno.Location = new System.Drawing.Point(499, 413);
            this.textBoxJmeno.Name = "textBoxJmeno";
            this.textBoxJmeno.ReadOnly = true;
            this.textBoxJmeno.Size = new System.Drawing.Size(100, 20);
            this.textBoxJmeno.TabIndex = 11;
            this.textBoxJmeno.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(425, 416);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Jméno hráče";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBoxOvladani
            // 
            this.groupBoxOvladani.Controls.Add(this.button1);
            this.groupBoxOvladani.Controls.Add(this.buttonStart);
            this.groupBoxOvladani.Controls.Add(this.buttonStop);
            this.groupBoxOvladani.Controls.Add(this.buttonReset);
            this.groupBoxOvladani.Controls.Add(this.trackBarSpeed);
            this.groupBoxOvladani.Controls.Add(this.labelSpeed);
            this.groupBoxOvladani.Controls.Add(this.labelSpeedValue);
            this.groupBoxOvladani.Controls.Add(this.labelInfo);
            this.groupBoxOvladani.Location = new System.Drawing.Point(12, 440);
            this.groupBoxOvladani.Name = "groupBoxOvladani";
            this.groupBoxOvladani.Size = new System.Drawing.Size(777, 100);
            this.groupBoxOvladani.TabIndex = 10;
            this.groupBoxOvladani.TabStop = false;
            this.groupBoxOvladani.Text = "Ovládání";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 554);
            this.Controls.Add(this.textBoxJmeno);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Zivot3);
            this.Controls.Add(this.Zivot2);
            this.Controls.Add(this.Zivot1);
            this.Controls.Add(this.boxPalivo);
            this.Controls.Add(this.progressBarFuel);
            this.Controls.Add(this.boxSkore);
            this.Controls.Add(this.txtPalivo);
            this.Controls.Add(this.txtZivoty);
            this.Controls.Add(this.txtSkore);
            this.Controls.Add(this.hraciPlocha);
            this.Controls.Add(this.txt_heading);
            this.Controls.Add(this.groupBoxOvladani);
            this.Name = "Form1";
            this.Text = "RocketShoot";
            this.hraciPlocha.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Meteorit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Raketa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Zivot1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Zivot2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Zivot3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSpeed)).EndInit();
            this.groupBoxOvladani.ResumeLayout(false);
            this.groupBoxOvladani.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.GroupBox groupBoxOvladani;
    }
}
