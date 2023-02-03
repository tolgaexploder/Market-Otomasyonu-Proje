namespace WindowsFormsApp8.Formlar
{
    partial class KullaniciKontrol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KullaniciKontrol));
            this.baslik_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.parabirimibaslik = new System.Windows.Forms.Label();
            this.doviz = new System.Windows.Forms.TextBox();
            this.pasifbakiye = new System.Windows.Forms.TextBox();
            this.bakiye = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.secenekler_combobox = new System.Windows.Forms.ComboBox();
            this.onayla_btn = new System.Windows.Forms.Button();
            this.donustur_btn = new System.Windows.Forms.Button();
            this.search_btn = new System.Windows.Forms.Button();
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
            this.baslik_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.baslik_label.Location = new System.Drawing.Point(1, 137);
            this.baslik_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.baslik_label.Name = "baslik_label";
            this.baslik_label.Size = new System.Drawing.Size(111, 23);
            this.baslik_label.TabIndex = 36;
            this.baslik_label.Text = "Tüm Üyeler";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.label1.Location = new System.Drawing.Point(4, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 23);
            this.label1.TabIndex = 37;
            this.label1.Text = "Üye";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.label2.Location = new System.Drawing.Point(4, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 23);
            this.label2.TabIndex = 38;
            this.label2.Text = "Onaylı Bakiye";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.label3.Location = new System.Drawing.Point(4, 135);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 23);
            this.label3.TabIndex = 39;
            this.label3.Text = "Pasif Bakiye";
            // 
            // parabirimibaslik
            // 
            this.parabirimibaslik.AutoSize = true;
            this.parabirimibaslik.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold);
            this.parabirimibaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.parabirimibaslik.Location = new System.Drawing.Point(4, 237);
            this.parabirimibaslik.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.parabirimibaslik.Name = "parabirimibaslik";
            this.parabirimibaslik.Size = new System.Drawing.Size(108, 23);
            this.parabirimibaslik.TabIndex = 40;
            this.parabirimibaslik.Text = "Para Birimi";
            // 
            // doviz
            // 
            this.doviz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.doviz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.doviz.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.doviz.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.doviz.Location = new System.Drawing.Point(26, 262);
            this.doviz.Margin = new System.Windows.Forms.Padding(2);
            this.doviz.Name = "doviz";
            this.doviz.Size = new System.Drawing.Size(112, 24);
            this.doviz.TabIndex = 41;
            // 
            // pasifbakiye
            // 
            this.pasifbakiye.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.pasifbakiye.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pasifbakiye.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.pasifbakiye.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.pasifbakiye.Location = new System.Drawing.Point(26, 160);
            this.pasifbakiye.Margin = new System.Windows.Forms.Padding(2);
            this.pasifbakiye.Name = "pasifbakiye";
            this.pasifbakiye.Size = new System.Drawing.Size(112, 24);
            this.pasifbakiye.TabIndex = 42;
            // 
            // bakiye
            // 
            this.bakiye.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.bakiye.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bakiye.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bakiye.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.bakiye.Location = new System.Drawing.Point(26, 107);
            this.bakiye.Margin = new System.Windows.Forms.Padding(2);
            this.bakiye.Name = "bakiye";
            this.bakiye.Size = new System.Drawing.Size(112, 24);
            this.bakiye.TabIndex = 43;
            // 
            // username
            // 
            this.username.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.username.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.username.Location = new System.Drawing.Point(26, 46);
            this.username.Margin = new System.Windows.Forms.Padding(2);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(112, 24);
            this.username.TabIndex = 44;
            // 
            // secenekler_combobox
            // 
            this.secenekler_combobox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.secenekler_combobox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.secenekler_combobox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.secenekler_combobox.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.secenekler_combobox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.secenekler_combobox.FormattingEnabled = true;
            this.secenekler_combobox.Location = new System.Drawing.Point(468, 133);
            this.secenekler_combobox.Margin = new System.Windows.Forms.Padding(2);
            this.secenekler_combobox.Name = "secenekler_combobox";
            this.secenekler_combobox.Size = new System.Drawing.Size(198, 27);
            this.secenekler_combobox.TabIndex = 45;
            // 
            // onayla_btn
            // 
            this.onayla_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.onayla_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.onayla_btn.FlatAppearance.BorderSize = 0;
            this.onayla_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.onayla_btn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.onayla_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.onayla_btn.Location = new System.Drawing.Point(42, 188);
            this.onayla_btn.Margin = new System.Windows.Forms.Padding(2);
            this.onayla_btn.Name = "onayla_btn";
            this.onayla_btn.Size = new System.Drawing.Size(75, 25);
            this.onayla_btn.TabIndex = 46;
            this.onayla_btn.Text = "Onayla";
            this.onayla_btn.UseVisualStyleBackColor = false;
            this.onayla_btn.Click += new System.EventHandler(this.onayla_btn_Click);
            // 
            // donustur_btn
            // 
            this.donustur_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.donustur_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.donustur_btn.FlatAppearance.BorderSize = 0;
            this.donustur_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.donustur_btn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.donustur_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.donustur_btn.Location = new System.Drawing.Point(42, 297);
            this.donustur_btn.Margin = new System.Windows.Forms.Padding(2);
            this.donustur_btn.Name = "donustur_btn";
            this.donustur_btn.Size = new System.Drawing.Size(75, 25);
            this.donustur_btn.TabIndex = 47;
            this.donustur_btn.Text = "Dönüştür";
            this.donustur_btn.UseVisualStyleBackColor = false;
            this.donustur_btn.Click += new System.EventHandler(this.donustur_btn_Click);
            // 
            // search_btn
            // 
            this.search_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.search_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.search_btn.FlatAppearance.BorderSize = 0;
            this.search_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.search_btn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.search_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.search_btn.Location = new System.Drawing.Point(681, 133);
            this.search_btn.Margin = new System.Windows.Forms.Padding(2);
            this.search_btn.Name = "search_btn";
            this.search_btn.Size = new System.Drawing.Size(75, 27);
            this.search_btn.TabIndex = 48;
            this.search_btn.Text = "Getir";
            this.search_btn.UseVisualStyleBackColor = false;
            this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
            // 
            // Kullanicilar_datagridview
            // 
            this.Kullanicilar_datagridview.AllowCustomTheming = false;
            this.Kullanicilar_datagridview.AllowUserToAddRows = false;
            this.Kullanicilar_datagridview.AllowUserToDeleteRows = false;
            this.Kullanicilar_datagridview.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
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
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Kullanicilar_datagridview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Kullanicilar_datagridview.ColumnHeadersHeight = 40;
            this.Kullanicilar_datagridview.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.Kullanicilar_datagridview.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.Kullanicilar_datagridview.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.White;
            this.Kullanicilar_datagridview.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(117)))), ((int)(((byte)(119)))));
            this.Kullanicilar_datagridview.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.Kullanicilar_datagridview.CurrentTheme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            this.Kullanicilar_datagridview.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.Kullanicilar_datagridview.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            this.Kullanicilar_datagridview.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.Kullanicilar_datagridview.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.Kullanicilar_datagridview.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.Kullanicilar_datagridview.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.Kullanicilar_datagridview.CurrentTheme.Name = null;
            this.Kullanicilar_datagridview.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.Kullanicilar_datagridview.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.Kullanicilar_datagridview.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.White;
            this.Kullanicilar_datagridview.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(117)))), ((int)(((byte)(119)))));
            this.Kullanicilar_datagridview.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            this.Kullanicilar_datagridview.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(117)))), ((int)(((byte)(119)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Kullanicilar_datagridview.DefaultCellStyle = dataGridViewCellStyle3;
            this.Kullanicilar_datagridview.EnableHeadersVisualStyles = false;
            this.Kullanicilar_datagridview.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(56)))), ((int)(((byte)(62)))));
            this.Kullanicilar_datagridview.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(18)))));
            this.Kullanicilar_datagridview.HeaderBgColor = System.Drawing.Color.Empty;
            this.Kullanicilar_datagridview.HeaderForeColor = System.Drawing.Color.White;
            this.Kullanicilar_datagridview.Location = new System.Drawing.Point(157, 163);
            this.Kullanicilar_datagridview.Margin = new System.Windows.Forms.Padding(2);
            this.Kullanicilar_datagridview.Name = "Kullanicilar_datagridview";
            this.Kullanicilar_datagridview.ReadOnly = true;
            this.Kullanicilar_datagridview.RowHeadersVisible = false;
            this.Kullanicilar_datagridview.RowHeadersWidth = 51;
            this.Kullanicilar_datagridview.RowTemplate.Height = 40;
            this.Kullanicilar_datagridview.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.Kullanicilar_datagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Kullanicilar_datagridview.Size = new System.Drawing.Size(599, 336);
            this.Kullanicilar_datagridview.TabIndex = 53;
            this.Kullanicilar_datagridview.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Dark;
            this.Kullanicilar_datagridview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Kullanicilar_datagridview_CellContentClick_1);
            this.Kullanicilar_datagridview.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.Kullanicilar_datagridview_RowsAdded);
            this.Kullanicilar_datagridview.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.Kullanicilar_datagridview_RowsRemoved);
            // 
            // bunifuCards1
            // 
            this.bunifuCards1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCards1.BorderRadius = 5;
            this.bunifuCards1.BottomSahddow = false;
            this.bunifuCards1.color = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.bunifuCards1.Controls.Add(this.donustur_btn);
            this.bunifuCards1.Controls.Add(this.username);
            this.bunifuCards1.Controls.Add(this.onayla_btn);
            this.bunifuCards1.Controls.Add(this.label1);
            this.bunifuCards1.Controls.Add(this.label2);
            this.bunifuCards1.Controls.Add(this.label3);
            this.bunifuCards1.Controls.Add(this.bakiye);
            this.bunifuCards1.Controls.Add(this.parabirimibaslik);
            this.bunifuCards1.Controls.Add(this.pasifbakiye);
            this.bunifuCards1.Controls.Add(this.doviz);
            this.bunifuCards1.LeftSahddow = false;
            this.bunifuCards1.Location = new System.Drawing.Point(5, 163);
            this.bunifuCards1.Name = "bunifuCards1";
            this.bunifuCards1.RightSahddow = false;
            this.bunifuCards1.ShadowDepth = 20;
            this.bunifuCards1.Size = new System.Drawing.Size(150, 336);
            this.bunifuCards1.TabIndex = 54;
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
            this.bunifuVScrollBar1.Location = new System.Drawing.Point(761, 163);
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
            this.bunifuVScrollBar1.Size = new System.Drawing.Size(16, 336);
            this.bunifuVScrollBar1.SmallChange = 1;
            this.bunifuVScrollBar1.TabIndex = 52;
            this.bunifuVScrollBar1.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(0)))), ((int)(((byte)(57)))));
            this.bunifuVScrollBar1.ThumbLength = 33;
            this.bunifuVScrollBar1.ThumbMargin = 1;
            this.bunifuVScrollBar1.ThumbStyle = Bunifu.UI.WinForms.BunifuVScrollBar.ThumbStyles.Inset;
            this.bunifuVScrollBar1.Value = 0;
            this.bunifuVScrollBar1.Scroll += new System.EventHandler<Bunifu.UI.WinForms.BunifuVScrollBar.ScrollEventArgs>(this.bunifuVScrollBar1_Scroll);
            // 
            // KullaniciKontrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(787, 542);
            this.Controls.Add(this.bunifuCards1);
            this.Controls.Add(this.Kullanicilar_datagridview);
            this.Controls.Add(this.bunifuVScrollBar1);
            this.Controls.Add(this.search_btn);
            this.Controls.Add(this.secenekler_combobox);
            this.Controls.Add(this.baslik_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "KullaniciKontrol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "KullaniciKontrol";
            this.Load += new System.EventHandler(this.KullaniciKontrol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Kullanicilar_datagridview)).EndInit();
            this.bunifuCards1.ResumeLayout(false);
            this.bunifuCards1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label baslik_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label parabirimibaslik;
        private System.Windows.Forms.TextBox doviz;
        private System.Windows.Forms.TextBox pasifbakiye;
        private System.Windows.Forms.TextBox bakiye;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.ComboBox secenekler_combobox;
        private System.Windows.Forms.Button onayla_btn;
        private System.Windows.Forms.Button donustur_btn;
        private System.Windows.Forms.Button search_btn;
        private Bunifu.UI.WinForms.BunifuVScrollBar bunifuVScrollBar1;
        private Bunifu.UI.WinForms.BunifuDataGridView Kullanicilar_datagridview;
        private Bunifu.Framework.UI.BunifuCards bunifuCards1;
    }
}