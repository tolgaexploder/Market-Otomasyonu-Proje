namespace WindowsFormsApp8.Formlar
{
    partial class UrunKontrol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UrunKontrol));
            this.urunkodu_txt = new System.Windows.Forms.TextBox();
            this.urunbaslik_label = new System.Windows.Forms.Label();
            this.urunlsl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.onaycontrol_label = new System.Windows.Forms.Label();
            this.urunonayla_btn = new System.Windows.Forms.Button();
            this.urunlerlistele_btn = new System.Windows.Forms.Button();
            this.urunler_combobox = new System.Windows.Forms.ComboBox();
            this.Urunler_datagridview = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.bunifuVScrollBar1 = new Bunifu.UI.WinForms.BunifuVScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this.Urunler_datagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // urunkodu_txt
            // 
            this.urunkodu_txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.urunkodu_txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.urunkodu_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.urunkodu_txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.urunkodu_txt.Location = new System.Drawing.Point(27, 222);
            this.urunkodu_txt.Name = "urunkodu_txt";
            this.urunkodu_txt.Size = new System.Drawing.Size(133, 22);
            this.urunkodu_txt.TabIndex = 28;
            // 
            // urunbaslik_label
            // 
            this.urunbaslik_label.AutoSize = true;
            this.urunbaslik_label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.urunbaslik_label.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            this.urunbaslik_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.urunbaslik_label.Location = new System.Drawing.Point(24, 114);
            this.urunbaslik_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.urunbaslik_label.Name = "urunbaslik_label";
            this.urunbaslik_label.Size = new System.Drawing.Size(116, 23);
            this.urunbaslik_label.TabIndex = 29;
            this.urunbaslik_label.Text = "Tüm Ürünler";
            // 
            // urunlsl
            // 
            this.urunlsl.AutoSize = true;
            this.urunlsl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.urunlsl.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.urunlsl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.urunlsl.Location = new System.Drawing.Point(24, 203);
            this.urunlsl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.urunlsl.Name = "urunlsl";
            this.urunlsl.Size = new System.Drawing.Size(89, 19);
            this.urunlsl.TabIndex = 30;
            this.urunlsl.Text = "Ürün Kodu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.label3.Location = new System.Drawing.Point(24, 268);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 19);
            this.label3.TabIndex = 31;
            this.label3.Text = "Durum";
            // 
            // onaycontrol_label
            // 
            this.onaycontrol_label.AutoSize = true;
            this.onaycontrol_label.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Underline);
            this.onaycontrol_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.onaycontrol_label.Location = new System.Drawing.Point(24, 303);
            this.onaycontrol_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.onaycontrol_label.Name = "onaycontrol_label";
            this.onaycontrol_label.Size = new System.Drawing.Size(0, 21);
            this.onaycontrol_label.TabIndex = 32;
            // 
            // urunonayla_btn
            // 
            this.urunonayla_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.urunonayla_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.urunonayla_btn.FlatAppearance.BorderSize = 0;
            this.urunonayla_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.urunonayla_btn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.urunonayla_btn.Location = new System.Drawing.Point(48, 349);
            this.urunonayla_btn.Margin = new System.Windows.Forms.Padding(2);
            this.urunonayla_btn.Name = "urunonayla_btn";
            this.urunonayla_btn.Size = new System.Drawing.Size(75, 23);
            this.urunonayla_btn.TabIndex = 33;
            this.urunonayla_btn.Text = "Onayla";
            this.urunonayla_btn.UseVisualStyleBackColor = false;
            this.urunonayla_btn.Click += new System.EventHandler(this.urunonayla_btn_Click);
            // 
            // urunlerlistele_btn
            // 
            this.urunlerlistele_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.urunlerlistele_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.urunlerlistele_btn.FlatAppearance.BorderSize = 0;
            this.urunlerlistele_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.urunlerlistele_btn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.urunlerlistele_btn.Location = new System.Drawing.Point(690, 104);
            this.urunlerlistele_btn.Margin = new System.Windows.Forms.Padding(2);
            this.urunlerlistele_btn.Name = "urunlerlistele_btn";
            this.urunlerlistele_btn.Size = new System.Drawing.Size(75, 33);
            this.urunlerlistele_btn.TabIndex = 34;
            this.urunlerlistele_btn.Text = "Getir";
            this.urunlerlistele_btn.UseVisualStyleBackColor = false;
            this.urunlerlistele_btn.Click += new System.EventHandler(this.urunlerlistele_btn_Click);
            // 
            // urunler_combobox
            // 
            this.urunler_combobox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.urunler_combobox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.urunler_combobox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.urunler_combobox.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.urunler_combobox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.urunler_combobox.FormattingEnabled = true;
            this.urunler_combobox.Location = new System.Drawing.Point(461, 107);
            this.urunler_combobox.Margin = new System.Windows.Forms.Padding(2);
            this.urunler_combobox.Name = "urunler_combobox";
            this.urunler_combobox.Size = new System.Drawing.Size(198, 27);
            this.urunler_combobox.TabIndex = 35;
            // 
            // Urunler_datagridview
            // 
            this.Urunler_datagridview.AllowCustomTheming = false;
            this.Urunler_datagridview.AllowUserToAddRows = false;
            this.Urunler_datagridview.AllowUserToDeleteRows = false;
            this.Urunler_datagridview.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.Urunler_datagridview.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Urunler_datagridview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Urunler_datagridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.Urunler_datagridview.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.Urunler_datagridview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Urunler_datagridview.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.Urunler_datagridview.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Urunler_datagridview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Urunler_datagridview.ColumnHeadersHeight = 40;
            this.Urunler_datagridview.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.Urunler_datagridview.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.Urunler_datagridview.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.White;
            this.Urunler_datagridview.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(117)))), ((int)(((byte)(119)))));
            this.Urunler_datagridview.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.Urunler_datagridview.CurrentTheme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            this.Urunler_datagridview.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.Urunler_datagridview.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            this.Urunler_datagridview.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.Urunler_datagridview.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.Urunler_datagridview.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Urunler_datagridview.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.Urunler_datagridview.CurrentTheme.Name = null;
            this.Urunler_datagridview.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.Urunler_datagridview.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.Urunler_datagridview.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.White;
            this.Urunler_datagridview.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(117)))), ((int)(((byte)(119)))));
            this.Urunler_datagridview.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.Urunler_datagridview.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(117)))), ((int)(((byte)(119)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Urunler_datagridview.DefaultCellStyle = dataGridViewCellStyle3;
            this.Urunler_datagridview.EnableHeadersVisualStyles = false;
            this.Urunler_datagridview.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.Urunler_datagridview.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            this.Urunler_datagridview.HeaderBgColor = System.Drawing.Color.Empty;
            this.Urunler_datagridview.HeaderForeColor = System.Drawing.Color.White;
            this.Urunler_datagridview.Location = new System.Drawing.Point(186, 153);
            this.Urunler_datagridview.Margin = new System.Windows.Forms.Padding(2);
            this.Urunler_datagridview.Name = "Urunler_datagridview";
            this.Urunler_datagridview.ReadOnly = true;
            this.Urunler_datagridview.RowHeadersVisible = false;
            this.Urunler_datagridview.RowHeadersWidth = 51;
            this.Urunler_datagridview.RowTemplate.Height = 40;
            this.Urunler_datagridview.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.Urunler_datagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Urunler_datagridview.Size = new System.Drawing.Size(579, 269);
            this.Urunler_datagridview.TabIndex = 36;
            this.Urunler_datagridview.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Dark;
            this.Urunler_datagridview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Urunler_datagridview_CellContentClick_1);
            this.Urunler_datagridview.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.Urunler_datagridview_RowsAdded);
            this.Urunler_datagridview.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.Urunler_datagridview_RowsRemoved);
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
            this.bunifuVScrollBar1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.bunifuVScrollBar1.BorderRadius = 14;
            this.bunifuVScrollBar1.BorderThickness = 1;
            this.bunifuVScrollBar1.DurationBeforeShrink = 2000;
            this.bunifuVScrollBar1.LargeChange = 10;
            this.bunifuVScrollBar1.Location = new System.Drawing.Point(769, 153);
            this.bunifuVScrollBar1.Maximum = 100;
            this.bunifuVScrollBar1.Minimum = 0;
            this.bunifuVScrollBar1.MinimumThumbLength = 18;
            this.bunifuVScrollBar1.Name = "bunifuVScrollBar1";
            this.bunifuVScrollBar1.OnDisable.ScrollBarBorderColor = System.Drawing.Color.Silver;
            this.bunifuVScrollBar1.OnDisable.ScrollBarColor = System.Drawing.Color.Transparent;
            this.bunifuVScrollBar1.OnDisable.ThumbColor = System.Drawing.Color.Silver;
            this.bunifuVScrollBar1.ScrollBarBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.bunifuVScrollBar1.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.bunifuVScrollBar1.ShrinkSizeLimit = 3;
            this.bunifuVScrollBar1.Size = new System.Drawing.Size(13, 269);
            this.bunifuVScrollBar1.SmallChange = 1;
            this.bunifuVScrollBar1.TabIndex = 37;
            this.bunifuVScrollBar1.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.bunifuVScrollBar1.ThumbLength = 26;
            this.bunifuVScrollBar1.ThumbMargin = 1;
            this.bunifuVScrollBar1.ThumbStyle = Bunifu.UI.WinForms.BunifuVScrollBar.ThumbStyles.Inset;
            this.bunifuVScrollBar1.Value = 0;
            this.bunifuVScrollBar1.Scroll += new System.EventHandler<Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs>(this.bunifuVScrollBar1_Scroll);
            // 
            // UrunKontrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(791, 546);
            this.Controls.Add(this.bunifuVScrollBar1);
            this.Controls.Add(this.Urunler_datagridview);
            this.Controls.Add(this.urunler_combobox);
            this.Controls.Add(this.urunlerlistele_btn);
            this.Controls.Add(this.urunonayla_btn);
            this.Controls.Add(this.onaycontrol_label);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.urunlsl);
            this.Controls.Add(this.urunbaslik_label);
            this.Controls.Add(this.urunkodu_txt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UrunKontrol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UrunKontrol";
            this.Load += new System.EventHandler(this.UrunKontrol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Urunler_datagridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox urunkodu_txt;
        private System.Windows.Forms.Label urunbaslik_label;
        private System.Windows.Forms.Label urunlsl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label onaycontrol_label;
        private System.Windows.Forms.Button urunonayla_btn;
        private System.Windows.Forms.Button urunlerlistele_btn;
        private System.Windows.Forms.ComboBox urunler_combobox;
        private Bunifu.UI.WinForms.BunifuDataGridView Urunler_datagridview;
        private Bunifu.UI.WinForms.BunifuVScrollBar bunifuVScrollBar1;
    }
}