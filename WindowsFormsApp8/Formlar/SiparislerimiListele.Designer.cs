namespace WindowsFormsApp8.Formlar
{
    partial class SiparislerimiListele
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SiparislerimiListele));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tamamsip_listele = new Bunifu.Framework.UI.BunifuThinButton2();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.aktifsip_listele = new Bunifu.Framework.UI.BunifuThinButton2();
            this.button1 = new System.Windows.Forms.Button();
            this.Siparislistele_datagird = new Bunifu.UI.WinForms.BunifuDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Siparislistele_datagird)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.pictureBox1.Image = global::WindowsFormsApp8.Properties.Resources.icons8_purchase_order_24;
            this.pictureBox1.Location = new System.Drawing.Point(443, 100);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 86;
            this.pictureBox1.TabStop = false;
            // 
            // tamamsip_listele
            // 
            this.tamamsip_listele.ActiveBorderThickness = 3;
            this.tamamsip_listele.ActiveCornerRadius = 20;
            this.tamamsip_listele.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.tamamsip_listele.ActiveForecolor = System.Drawing.Color.White;
            this.tamamsip_listele.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.tamamsip_listele.BackColor = System.Drawing.SystemColors.Control;
            this.tamamsip_listele.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tamamsip_listele.BackgroundImage")));
            this.tamamsip_listele.ButtonText = "Tamamlanmış Siparişler";
            this.tamamsip_listele.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tamamsip_listele.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tamamsip_listele.ForeColor = System.Drawing.Color.SeaGreen;
            this.tamamsip_listele.IdleBorderThickness = 1;
            this.tamamsip_listele.IdleCornerRadius = 20;
            this.tamamsip_listele.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.tamamsip_listele.IdleForecolor = System.Drawing.Color.White;
            this.tamamsip_listele.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.tamamsip_listele.Location = new System.Drawing.Point(433, 82);
            this.tamamsip_listele.Margin = new System.Windows.Forms.Padding(5);
            this.tamamsip_listele.Name = "tamamsip_listele";
            this.tamamsip_listele.Size = new System.Drawing.Size(259, 58);
            this.tamamsip_listele.TabIndex = 85;
            this.tamamsip_listele.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tamamsip_listele.Click += new System.EventHandler(this.tamamsip_listele_Click_1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.pictureBox2.Image = global::WindowsFormsApp8.Properties.Resources.icons8_purchase_order_24;
            this.pictureBox2.Location = new System.Drawing.Point(133, 100);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 84;
            this.pictureBox2.TabStop = false;
            // 
            // aktifsip_listele
            // 
            this.aktifsip_listele.ActiveBorderThickness = 3;
            this.aktifsip_listele.ActiveCornerRadius = 20;
            this.aktifsip_listele.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.aktifsip_listele.ActiveForecolor = System.Drawing.Color.White;
            this.aktifsip_listele.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.aktifsip_listele.BackColor = System.Drawing.SystemColors.Control;
            this.aktifsip_listele.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("aktifsip_listele.BackgroundImage")));
            this.aktifsip_listele.ButtonText = "Aktif Siparişler";
            this.aktifsip_listele.Cursor = System.Windows.Forms.Cursors.Hand;
            this.aktifsip_listele.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aktifsip_listele.ForeColor = System.Drawing.Color.SeaGreen;
            this.aktifsip_listele.IdleBorderThickness = 1;
            this.aktifsip_listele.IdleCornerRadius = 20;
            this.aktifsip_listele.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.aktifsip_listele.IdleForecolor = System.Drawing.Color.White;
            this.aktifsip_listele.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.aktifsip_listele.Location = new System.Drawing.Point(123, 82);
            this.aktifsip_listele.Margin = new System.Windows.Forms.Padding(5);
            this.aktifsip_listele.Name = "aktifsip_listele";
            this.aktifsip_listele.Size = new System.Drawing.Size(259, 58);
            this.aktifsip_listele.TabIndex = 83;
            this.aktifsip_listele.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.aktifsip_listele.Click += new System.EventHandler(this.aktifsip_listele_Click_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Window;
            this.button1.Image = global::WindowsFormsApp8.Properties.Resources.outline_arrow_back_ios_white_24dp1;
            this.button1.Location = new System.Drawing.Point(1, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 23);
            this.button1.TabIndex = 82;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Siparislistele_datagird
            // 
            this.Siparislistele_datagird.AllowCustomTheming = false;
            this.Siparislistele_datagird.AllowUserToAddRows = false;
            this.Siparislistele_datagird.AllowUserToDeleteRows = false;
            this.Siparislistele_datagird.AllowUserToResizeColumns = false;
            this.Siparislistele_datagird.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.Siparislistele_datagird.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Siparislistele_datagird.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Siparislistele_datagird.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Siparislistele_datagird.BackgroundColor = System.Drawing.Color.White;
            this.Siparislistele_datagird.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Siparislistele_datagird.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.Siparislistele_datagird.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Siparislistele_datagird.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Siparislistele_datagird.ColumnHeadersHeight = 40;
            this.Siparislistele_datagird.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.Siparislistele_datagird.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.Siparislistele_datagird.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.Siparislistele_datagird.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.Siparislistele_datagird.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.Siparislistele_datagird.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.Siparislistele_datagird.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.Siparislistele_datagird.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.Siparislistele_datagird.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.Siparislistele_datagird.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.Siparislistele_datagird.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.Siparislistele_datagird.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.Siparislistele_datagird.CurrentTheme.Name = null;
            this.Siparislistele_datagird.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.Siparislistele_datagird.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.Siparislistele_datagird.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.Siparislistele_datagird.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.Siparislistele_datagird.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Siparislistele_datagird.DefaultCellStyle = dataGridViewCellStyle3;
            this.Siparislistele_datagird.EnableHeadersVisualStyles = false;
            this.Siparislistele_datagird.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.Siparislistele_datagird.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.Siparislistele_datagird.HeaderBgColor = System.Drawing.Color.Empty;
            this.Siparislistele_datagird.HeaderForeColor = System.Drawing.Color.White;
            this.Siparislistele_datagird.Location = new System.Drawing.Point(57, 147);
            this.Siparislistele_datagird.Margin = new System.Windows.Forms.Padding(2);
            this.Siparislistele_datagird.MultiSelect = false;
            this.Siparislistele_datagird.Name = "Siparislistele_datagird";
            this.Siparislistele_datagird.ReadOnly = true;
            this.Siparislistele_datagird.RowHeadersVisible = false;
            this.Siparislistele_datagird.RowHeadersWidth = 51;
            this.Siparislistele_datagird.RowTemplate.Height = 40;
            this.Siparislistele_datagird.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Siparislistele_datagird.Size = new System.Drawing.Size(709, 209);
            this.Siparislistele_datagird.TabIndex = 88;
            this.Siparislistele_datagird.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            // 
            // SiparislerimiListele
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Siparislistele_datagird);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tamamsip_listele);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.aktifsip_listele);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SiparislerimiListele";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Siparişlerimi Listele";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SiparislerimiListele_FormClosing);
            this.Load += new System.EventHandler(this.SiparislerimiListele_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Siparislistele_datagird)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Bunifu.Framework.UI.BunifuThinButton2 aktifsip_listele;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuThinButton2 tamamsip_listele;
        public Bunifu.UI.WinForms.BunifuDataGridView Siparislistele_datagird;
    }
}