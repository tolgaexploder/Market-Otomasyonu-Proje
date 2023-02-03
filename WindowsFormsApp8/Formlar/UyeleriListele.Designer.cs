namespace WindowsFormsApp8.Formlar
{
    partial class UyeleriListele
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UyeleriListele));
            this.baslik_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.onaylibakiye = new System.Windows.Forms.Label();
            this.pasifbakiye = new System.Windows.Forms.Label();
            this.parabirimibaslik = new System.Windows.Forms.Label();
            this.doviz_txt = new System.Windows.Forms.TextBox();
            this.pasifbakiye_txt = new System.Windows.Forms.TextBox();
            this.bakiye_txt = new System.Windows.Forms.TextBox();
            this.username_txt = new System.Windows.Forms.TextBox();
            this.Kullanicilar_datagridview = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.bunifuCards1 = new Bunifu.Framework.UI.BunifuCards();
            this.bunifuVScrollBar1 = new Bunifu.UI.WinForms.BunifuVScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this.Kullanicilar_datagridview)).BeginInit();
            this.bunifuCards1.SuspendLayout();
            this.SuspendLayout();
            // 
            // baslik_label
            // 
            this.baslik_label.AutoSize = true;
            this.baslik_label.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            this.baslik_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.baslik_label.Location = new System.Drawing.Point(60, 176);
            this.baslik_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.baslik_label.Name = "baslik_label";
            this.baslik_label.Size = new System.Drawing.Size(111, 23);
            this.baslik_label.TabIndex = 48;
            this.baslik_label.Text = "Tüm Üyeler";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(2, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 16);
            this.label1.TabIndex = 49;
            this.label1.Text = "Üye";
            // 
            // onaylibakiye
            // 
            this.onaylibakiye.AutoSize = true;
            this.onaylibakiye.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.onaylibakiye.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.onaylibakiye.Location = new System.Drawing.Point(2, 63);
            this.onaylibakiye.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.onaylibakiye.Name = "onaylibakiye";
            this.onaylibakiye.Size = new System.Drawing.Size(99, 16);
            this.onaylibakiye.TabIndex = 50;
            this.onaylibakiye.Text = "Onaylı Bakiye";
            // 
            // pasifbakiye
            // 
            this.pasifbakiye.AutoSize = true;
            this.pasifbakiye.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.pasifbakiye.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.pasifbakiye.Location = new System.Drawing.Point(2, 109);
            this.pasifbakiye.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pasifbakiye.Name = "pasifbakiye";
            this.pasifbakiye.Size = new System.Drawing.Size(86, 16);
            this.pasifbakiye.TabIndex = 51;
            this.pasifbakiye.Text = "Pasif Bakiye";
            // 
            // parabirimibaslik
            // 
            this.parabirimibaslik.AutoSize = true;
            this.parabirimibaslik.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.parabirimibaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.parabirimibaslik.Location = new System.Drawing.Point(2, 154);
            this.parabirimibaslik.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.parabirimibaslik.Name = "parabirimibaslik";
            this.parabirimibaslik.Size = new System.Drawing.Size(78, 16);
            this.parabirimibaslik.TabIndex = 52;
            this.parabirimibaslik.Text = "Para Birimi";
            // 
            // doviz_txt
            // 
            this.doviz_txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.doviz_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.doviz_txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.doviz_txt.Location = new System.Drawing.Point(11, 172);
            this.doviz_txt.Margin = new System.Windows.Forms.Padding(2);
            this.doviz_txt.Name = "doviz_txt";
            this.doviz_txt.Size = new System.Drawing.Size(84, 20);
            this.doviz_txt.TabIndex = 53;
            // 
            // pasifbakiye_txt
            // 
            this.pasifbakiye_txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.pasifbakiye_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pasifbakiye_txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.pasifbakiye_txt.Location = new System.Drawing.Point(10, 127);
            this.pasifbakiye_txt.Margin = new System.Windows.Forms.Padding(2);
            this.pasifbakiye_txt.Name = "pasifbakiye_txt";
            this.pasifbakiye_txt.Size = new System.Drawing.Size(85, 20);
            this.pasifbakiye_txt.TabIndex = 54;
            // 
            // bakiye_txt
            // 
            this.bakiye_txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.bakiye_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bakiye_txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.bakiye_txt.Location = new System.Drawing.Point(10, 81);
            this.bakiye_txt.Margin = new System.Windows.Forms.Padding(2);
            this.bakiye_txt.Name = "bakiye_txt";
            this.bakiye_txt.Size = new System.Drawing.Size(85, 20);
            this.bakiye_txt.TabIndex = 55;
            // 
            // username_txt
            // 
            this.username_txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.username_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.username_txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.username_txt.Location = new System.Drawing.Point(11, 36);
            this.username_txt.Margin = new System.Windows.Forms.Padding(2);
            this.username_txt.Name = "username_txt";
            this.username_txt.Size = new System.Drawing.Size(84, 20);
            this.username_txt.TabIndex = 56;
            // 
            // Kullanicilar_datagridview
            // 
            this.Kullanicilar_datagridview.AllowCustomTheming = false;
            this.Kullanicilar_datagridview.AllowUserToAddRows = false;
            this.Kullanicilar_datagridview.AllowUserToDeleteRows = false;
            this.Kullanicilar_datagridview.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(191)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.Kullanicilar_datagridview.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Kullanicilar_datagridview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Kullanicilar_datagridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Kullanicilar_datagridview.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.Kullanicilar_datagridview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Kullanicilar_datagridview.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.Kullanicilar_datagridview.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Kullanicilar_datagridview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Kullanicilar_datagridview.ColumnHeadersHeight = 40;
            this.Kullanicilar_datagridview.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(191)))));
            this.Kullanicilar_datagridview.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.Kullanicilar_datagridview.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.Kullanicilar_datagridview.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.Kullanicilar_datagridview.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.Kullanicilar_datagridview.CurrentTheme.BackColor = System.Drawing.Color.Yellow;
            this.Kullanicilar_datagridview.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(153)))));
            this.Kullanicilar_datagridview.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.Yellow;
            this.Kullanicilar_datagridview.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.Kullanicilar_datagridview.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.Kullanicilar_datagridview.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.Kullanicilar_datagridview.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.Kullanicilar_datagridview.CurrentTheme.Name = null;
            this.Kullanicilar_datagridview.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(204)))));
            this.Kullanicilar_datagridview.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.Kullanicilar_datagridview.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.Kullanicilar_datagridview.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.Kullanicilar_datagridview.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.Kullanicilar_datagridview.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Kullanicilar_datagridview.DefaultCellStyle = dataGridViewCellStyle3;
            this.Kullanicilar_datagridview.EnableHeadersVisualStyles = false;
            this.Kullanicilar_datagridview.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(153)))));
            this.Kullanicilar_datagridview.HeaderBackColor = System.Drawing.Color.Yellow;
            this.Kullanicilar_datagridview.HeaderBgColor = System.Drawing.Color.Empty;
            this.Kullanicilar_datagridview.HeaderForeColor = System.Drawing.Color.Black;
            this.Kullanicilar_datagridview.Location = new System.Drawing.Point(176, 176);
            this.Kullanicilar_datagridview.Margin = new System.Windows.Forms.Padding(2);
            this.Kullanicilar_datagridview.Name = "Kullanicilar_datagridview";
            this.Kullanicilar_datagridview.ReadOnly = true;
            this.Kullanicilar_datagridview.RowHeadersVisible = false;
            this.Kullanicilar_datagridview.RowHeadersWidth = 51;
            this.Kullanicilar_datagridview.RowTemplate.Height = 40;
            this.Kullanicilar_datagridview.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.Kullanicilar_datagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Kullanicilar_datagridview.Size = new System.Drawing.Size(532, 223);
            this.Kullanicilar_datagridview.TabIndex = 58;
            this.Kullanicilar_datagridview.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Yellow;
            this.Kullanicilar_datagridview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Kullanicilar_datagridview_CellContentClick);
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCards1.BorderRadius = 5;
            this.bunifuCards1.BottomSahddow = false;
            this.bunifuCards1.color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.bunifuCards1.Controls.Add(this.username_txt);
            this.bunifuCards1.Controls.Add(this.bakiye_txt);
            this.bunifuCards1.Controls.Add(this.pasifbakiye_txt);
            this.bunifuCards1.Controls.Add(this.label1);
            this.bunifuCards1.Controls.Add(this.doviz_txt);
            this.bunifuCards1.Controls.Add(this.onaylibakiye);
            this.bunifuCards1.Controls.Add(this.parabirimibaslik);
            this.bunifuCards1.Controls.Add(this.pasifbakiye);
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(64, 202);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = false;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(107, 216);
            this.bunifuCards1.TabIndex = 59;
            // 
            // bunifuVScrollBar1
            // 
            this.bunifuVScrollBar1.AllowCursorChanges = true;
            this.bunifuVScrollBar1.AllowHomeEndKeysDetection = false;
            this.bunifuVScrollBar1.AllowIncrementalClickMoves = true;
            this.bunifuVScrollBar1.AllowMouseDownEffects = true;
            this.bunifuVScrollBar1.AllowMouseHoverEffects = true;
            this.bunifuVScrollBar1.AllowScrollingAnimations = true;
            this.bunifuVScrollBar1.AllowScrollKeysDetection = true;
            this.bunifuVScrollBar1.AllowScrollOptionsMenu = true;
            this.bunifuVScrollBar1.AllowShrinkingOnFocusLost = false;
            this.bunifuVScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuVScrollBar1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.bunifuVScrollBar1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuVScrollBar1.BackgroundImage")));
            this.bunifuVScrollBar1.BindingContainer = null;
            this.bunifuVScrollBar1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.bunifuVScrollBar1.BorderRadius = 14;
            this.bunifuVScrollBar1.BorderThickness = 1;
            this.bunifuVScrollBar1.DurationBeforeShrink = 2000;
            this.bunifuVScrollBar1.LargeChange = 10;
            this.bunifuVScrollBar1.Location = new System.Drawing.Point(713, 176);
            this.bunifuVScrollBar1.Maximum = 100;
            this.bunifuVScrollBar1.Minimum = 0;
            this.bunifuVScrollBar1.MinimumThumbLength = 18;
            this.bunifuVScrollBar1.Name = "bunifuVScrollBar1";
            this.bunifuVScrollBar1.OnDisable.ScrollBarBorderColor = System.Drawing.Color.Silver;
            this.bunifuVScrollBar1.OnDisable.ScrollBarColor = System.Drawing.Color.Transparent;
            this.bunifuVScrollBar1.OnDisable.ThumbColor = System.Drawing.Color.Silver;
            this.bunifuVScrollBar1.ScrollBarBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.bunifuVScrollBar1.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.bunifuVScrollBar1.ShrinkSizeLimit = 3;
            this.bunifuVScrollBar1.Size = new System.Drawing.Size(16, 223);
            this.bunifuVScrollBar1.SmallChange = 1;
            this.bunifuVScrollBar1.TabIndex = 57;
            this.bunifuVScrollBar1.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(0)))));
            this.bunifuVScrollBar1.ThumbLength = 21;
            this.bunifuVScrollBar1.ThumbMargin = 1;
            this.bunifuVScrollBar1.ThumbStyle = Bunifu.UI.WinForms.BunifuVScrollBar.ThumbStyles.Inset;
            this.bunifuVScrollBar1.Value = 0;
            // 
            // UyeleriListele
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(791, 546);
            this.ControlBox = false;
            this.Controls.Add(this.bunifuCards1);
            this.Controls.Add(this.Kullanicilar_datagridview);
            this.Controls.Add(this.bunifuVScrollBar1);
            this.Controls.Add(this.baslik_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UyeleriListele";
            this.Text = "UyeleriListele";
            this.Load += new System.EventHandler(this.UyeleriListele_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Kullanicilar_datagridview)).EndInit();
            this.bunifuCards1.ResumeLayout(false);
            this.bunifuCards1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label baslik_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label onaylibakiye;
        private System.Windows.Forms.Label pasifbakiye;
        private System.Windows.Forms.Label parabirimibaslik;
        private System.Windows.Forms.TextBox doviz_txt;
        private System.Windows.Forms.TextBox pasifbakiye_txt;
        private System.Windows.Forms.TextBox bakiye_txt;
        private System.Windows.Forms.TextBox username_txt;
        private Bunifu.UI.WinForms.BunifuDataGridView Kullanicilar_datagridview;
        private Bunifu.UI.WinForms.BunifuVScrollBar bunifuVScrollBar1;
        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
    }
}