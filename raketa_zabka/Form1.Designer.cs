namespace raketa_zabka
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Vyčistí všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">true, pokud by se měly spravované prostředky odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txt_heading = new System.Windows.Forms.Label();
            this.txtSkore = new System.Windows.Forms.Label();
            this.txtZivoty = new System.Windows.Forms.Label();
            this.txtPalivo = new System.Windows.Forms.Label();
            this.boxSkore = new System.Windows.Forms.MaskedTextBox();
            this.boxPalivo = new System.Windows.Forms.MaskedTextBox();
            this.Zivot3 = new System.Windows.Forms.PictureBox();
            this.Zivot2 = new System.Windows.Forms.PictureBox();
            this.Zivot1 = new System.Windows.Forms.PictureBox();
            this.hraciPlocha = new System.Windows.Forms.GroupBox();
            this.Meteorit = new System.Windows.Forms.PictureBox();
            this.Raketa = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Zivot3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Zivot2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Zivot1)).BeginInit();
            this.hraciPlocha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Meteorit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Raketa)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_heading
            // 
            this.txt_heading.AutoSize = true;
            this.txt_heading.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_heading.Location = new System.Drawing.Point(337, 19);
            this.txt_heading.Name = "txt_heading";
            this.txt_heading.Size = new System.Drawing.Size(103, 20);
            this.txt_heading.TabIndex = 0;
            this.txt_heading.Text = "RocketShoot";
            this.txt_heading.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.txt_heading.Click += new System.EventHandler(this.txt_heading_Click);
            // 
            // txtSkore
            // 
            this.txtSkore.AutoSize = true;
            this.txtSkore.Location = new System.Drawing.Point(23, 416);
            this.txtSkore.Name = "txtSkore";
            this.txtSkore.Size = new System.Drawing.Size(35, 13);
            this.txtSkore.TabIndex = 2;
            this.txtSkore.Text = "Skóre";
            // 
            // txtZivoty
            // 
            this.txtZivoty.AutoSize = true;
            this.txtZivoty.Location = new System.Drawing.Point(330, 416);
            this.txtZivoty.Name = "txtZivoty";
            this.txtZivoty.Size = new System.Drawing.Size(36, 13);
            this.txtZivoty.TabIndex = 3;
            this.txtZivoty.Text = "Životy";
            // 
            // txtPalivo
            // 
            this.txtPalivo.AutoSize = true;
            this.txtPalivo.Location = new System.Drawing.Point(621, 416);
            this.txtPalivo.Name = "txtPalivo";
            this.txtPalivo.Size = new System.Drawing.Size(36, 13);
            this.txtPalivo.TabIndex = 4;
            this.txtPalivo.Text = "Palivo";
            // 
            // boxSkore
            // 
            this.boxSkore.Location = new System.Drawing.Point(64, 413);
            this.boxSkore.Name = "boxSkore";
            this.boxSkore.Size = new System.Drawing.Size(71, 20);
            this.boxSkore.TabIndex = 5;
            // 
            // boxPalivo
            // 
            this.boxPalivo.BackColor = System.Drawing.SystemColors.Window;
            this.boxPalivo.Location = new System.Drawing.Point(663, 413);
            this.boxPalivo.Name = "boxPalivo";
            this.boxPalivo.Size = new System.Drawing.Size(71, 20);
            this.boxPalivo.TabIndex = 6;
            // 
            // Zivot3
            // 
            this.Zivot3.Image = ((System.Drawing.Image)(resources.GetObject("Zivot3.Image")));
            this.Zivot3.Location = new System.Drawing.Point(448, 413);
            this.Zivot3.Name = "Zivot3";
            this.Zivot3.Size = new System.Drawing.Size(32, 20);
            this.Zivot3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Zivot3.TabIndex = 9;
            this.Zivot3.TabStop = false;
            // 
            // Zivot2
            // 
            this.Zivot2.Image = ((System.Drawing.Image)(resources.GetObject("Zivot2.Image")));
            this.Zivot2.Location = new System.Drawing.Point(410, 413);
            this.Zivot2.Name = "Zivot2";
            this.Zivot2.Size = new System.Drawing.Size(32, 20);
            this.Zivot2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Zivot2.TabIndex = 8;
            this.Zivot2.TabStop = false;
            // 
            // Zivot1
            // 
            this.Zivot1.Image = ((System.Drawing.Image)(resources.GetObject("Zivot1.Image")));
            this.Zivot1.Location = new System.Drawing.Point(372, 413);
            this.Zivot1.Name = "Zivot1";
            this.Zivot1.Size = new System.Drawing.Size(32, 20);
            this.Zivot1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Zivot1.TabIndex = 7;
            this.Zivot1.TabStop = false;
            // 
            // hraciPlocha
            // 
            this.hraciPlocha.BackColor = System.Drawing.SystemColors.MenuText;
            this.hraciPlocha.BackgroundImage = global::raketa_zabka.Properties.Resources.Poznámka_2022_10_06_113933;
            this.hraciPlocha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.hraciPlocha.Controls.Add(this.Meteorit);
            this.hraciPlocha.Controls.Add(this.Raketa);
            this.hraciPlocha.Location = new System.Drawing.Point(-4, -5);
            this.hraciPlocha.Name = "hraciPlocha";
            this.hraciPlocha.Size = new System.Drawing.Size(793, 398);
            this.hraciPlocha.TabIndex = 1;
            this.hraciPlocha.TabStop = false;
            // 
            // Meteorit
            // 
            this.Meteorit.BackColor = System.Drawing.Color.Transparent;
            this.Meteorit.Image = global::raketa_zabka.Properties.Resources.pngtree_meteor_fall_with_fire_png_image_13382941;
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
            this.Raketa.Image = global::raketa_zabka.Properties.Resources.pngtree_missile_rocket_ammunition_war_conflict_military_warhead_nuclear_weapon_bomb_3d_png_image_16644986;
            this.Raketa.Location = new System.Drawing.Point(384, 119);
            this.Raketa.Name = "Raketa";
            this.Raketa.Size = new System.Drawing.Size(71, 83);
            this.Raketa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Raketa.TabIndex = 0;
            this.Raketa.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 450);
            this.Controls.Add(this.Zivot3);
            this.Controls.Add(this.Zivot2);
            this.Controls.Add(this.Zivot1);
            this.Controls.Add(this.boxPalivo);
            this.Controls.Add(this.boxSkore);
            this.Controls.Add(this.txtPalivo);
            this.Controls.Add(this.txtZivoty);
            this.Controls.Add(this.txtSkore);
            this.Controls.Add(this.hraciPlocha);
            this.Controls.Add(this.txt_heading);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "Form1";
            this.Text = "RocketShoot";
            ((System.ComponentModel.ISupportInitialize)(this.Zivot3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Zivot2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Zivot1)).EndInit();
            this.hraciPlocha.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Meteorit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Raketa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txt_heading;
        private System.Windows.Forms.GroupBox hraciPlocha;
        private System.Windows.Forms.Label txtSkore;
        private System.Windows.Forms.Label txtZivoty;
        private System.Windows.Forms.Label txtPalivo;
        private System.Windows.Forms.MaskedTextBox boxSkore;
        private System.Windows.Forms.MaskedTextBox boxPalivo;
        private System.Windows.Forms.PictureBox Raketa;
        private System.Windows.Forms.PictureBox Meteorit;
        private System.Windows.Forms.PictureBox Zivot1;
        private System.Windows.Forms.PictureBox Zivot2;
        private System.Windows.Forms.PictureBox Zivot3;
    }
}