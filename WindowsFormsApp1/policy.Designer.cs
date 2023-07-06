namespace WindowsFormsApp1
{
    partial class policy
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
            this.policeid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrimTutari = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dateTimePickerBaslangic = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerBitis = new System.Windows.Forms.DateTimePicker();
            this.txtPoliceTuru = new System.Windows.Forms.ComboBox();
            this.comboBoxMusteri = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.iptal = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.geri_tusu = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.iptal_et = new System.Windows.Forms.Button();
            this.kayit_islemleri = new System.Windows.Forms.Button();
            this.kaydetlabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // policeid
            // 
            this.policeid.BackColor = System.Drawing.SystemColors.Control;
            this.policeid.Enabled = false;
            this.policeid.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.policeid.Location = new System.Drawing.Point(122, 73);
            this.policeid.Margin = new System.Windows.Forms.Padding(4);
            this.policeid.Name = "policeid";
            this.policeid.Size = new System.Drawing.Size(186, 29);
            this.policeid.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(10, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 22);
            this.label2.TabIndex = 7;
            this.label2.Text = "Müşteri";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(17, 82);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 22);
            this.label1.TabIndex = 8;
            this.label1.Text = "Poliçe ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(332, 40);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 22);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tür";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(320, 73);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 22);
            this.label4.TabIndex = 10;
            this.label4.Text = "Tutar";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(562, 40);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 22);
            this.label5.TabIndex = 11;
            this.label5.Text = "Başlangıç Tarihi";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(613, 77);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 22);
            this.label6.TabIndex = 12;
            this.label6.Text = "Bitiş Tarihi";
            // 
            // txtPrimTutari
            // 
            this.txtPrimTutari.BackColor = System.Drawing.SystemColors.Control;
            this.txtPrimTutari.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPrimTutari.Location = new System.Drawing.Point(382, 74);
            this.txtPrimTutari.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrimTutari.Name = "txtPrimTutari";
            this.txtPrimTutari.Size = new System.Drawing.Size(173, 29);
            this.txtPrimTutari.TabIndex = 22;
            this.txtPrimTutari.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrimTutari_KeyPress);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(13, 161);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(1379, 373);
            this.dataGridView2.TabIndex = 29;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // dateTimePickerBaslangic
            // 
            this.dateTimePickerBaslangic.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateTimePickerBaslangic.Location = new System.Drawing.Point(729, 40);
            this.dateTimePickerBaslangic.Name = "dateTimePickerBaslangic";
            this.dateTimePickerBaslangic.Size = new System.Drawing.Size(208, 29);
            this.dateTimePickerBaslangic.TabIndex = 35;
            // 
            // dateTimePickerBitis
            // 
            this.dateTimePickerBitis.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateTimePickerBitis.Location = new System.Drawing.Point(729, 75);
            this.dateTimePickerBitis.Name = "dateTimePickerBitis";
            this.dateTimePickerBitis.Size = new System.Drawing.Size(208, 29);
            this.dateTimePickerBitis.TabIndex = 36;
            // 
            // txtPoliceTuru
            // 
            this.txtPoliceTuru.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPoliceTuru.FormattingEnabled = true;
            this.txtPoliceTuru.Location = new System.Drawing.Point(382, 38);
            this.txtPoliceTuru.Name = "txtPoliceTuru";
            this.txtPoliceTuru.Size = new System.Drawing.Size(173, 29);
            this.txtPoliceTuru.TabIndex = 37;
            // 
            // comboBoxMusteri
            // 
            this.comboBoxMusteri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMusteri.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBoxMusteri.FormattingEnabled = true;
            this.comboBoxMusteri.Location = new System.Drawing.Point(122, 37);
            this.comboBoxMusteri.Name = "comboBoxMusteri";
            this.comboBoxMusteri.Size = new System.Drawing.Size(186, 29);
            this.comboBoxMusteri.TabIndex = 38;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(1041, 118);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 23);
            this.label11.TabIndex = 42;
            this.label11.Text = "Güncelle";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1245, 118);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 23);
            this.label7.TabIndex = 41;
            this.label7.Text = "Sil";
            // 
            // iptal
            // 
            this.iptal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iptal.AutoSize = true;
            this.iptal.Font = new System.Drawing.Font("Arial", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iptal.Location = new System.Drawing.Point(1150, 118);
            this.iptal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.iptal.Name = "iptal";
            this.iptal.Size = new System.Drawing.Size(66, 23);
            this.iptal.TabIndex = 40;
            this.iptal.Text = "Sıfırla";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(1332, 118);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 23);
            this.label10.TabIndex = 43;
            this.label10.Text = "Geri";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label13.Location = new System.Drawing.Point(10, 122);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(910, 17);
            this.label13.TabIndex = 45;
            this.label13.Text = "Güncelleme yapmak için tablodan güncellemek istediğiniz kişiyi seçiniz! Yeni poli" +
    "çe ekleyecekseniz lütfen SIFIRLA tuşuna basınız!";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(547, 122);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 16);
            this.label12.TabIndex = 44;
            // 
            // geri_tusu
            // 
            this.geri_tusu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.geri_tusu.AutoSize = true;
            this.geri_tusu.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.icons8_return_96;
            this.geri_tusu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.geri_tusu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.geri_tusu.FlatAppearance.BorderSize = 0;
            this.geri_tusu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.geri_tusu.Location = new System.Drawing.Point(1312, 34);
            this.geri_tusu.Margin = new System.Windows.Forms.Padding(4);
            this.geri_tusu.MaximumSize = new System.Drawing.Size(100, 100);
            this.geri_tusu.Name = "geri_tusu";
            this.geri_tusu.Size = new System.Drawing.Size(80, 80);
            this.geri_tusu.TabIndex = 34;
            this.geri_tusu.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.geri_tusu.UseVisualStyleBackColor = true;
            this.geri_tusu.Click += new System.EventHandler(this.geri_tusu_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.AutoSize = true;
            this.button2.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.icons8_update_user_96;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(1045, 34);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.MaximumSize = new System.Drawing.Size(100, 100);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 80);
            this.button2.TabIndex = 32;
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // delete
            // 
            this.delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.delete.AutoSize = true;
            this.delete.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.icons8_delete_96;
            this.delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.delete.FlatAppearance.BorderSize = 0;
            this.delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delete.Location = new System.Drawing.Point(1224, 34);
            this.delete.Margin = new System.Windows.Forms.Padding(4);
            this.delete.MaximumSize = new System.Drawing.Size(100, 100);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(80, 80);
            this.delete.TabIndex = 30;
            this.delete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // iptal_et
            // 
            this.iptal_et.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iptal_et.AutoSize = true;
            this.iptal_et.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.icons8_close_96;
            this.iptal_et.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.iptal_et.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iptal_et.FlatAppearance.BorderSize = 0;
            this.iptal_et.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iptal_et.Location = new System.Drawing.Point(1136, 34);
            this.iptal_et.Margin = new System.Windows.Forms.Padding(4);
            this.iptal_et.MaximumSize = new System.Drawing.Size(100, 100);
            this.iptal_et.Name = "iptal_et";
            this.iptal_et.Size = new System.Drawing.Size(80, 80);
            this.iptal_et.TabIndex = 19;
            this.iptal_et.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iptal_et.UseVisualStyleBackColor = true;
            this.iptal_et.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // kayit_islemleri
            // 
            this.kayit_islemleri.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kayit_islemleri.AutoSize = true;
            this.kayit_islemleri.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.icons8_done_96__1_;
            this.kayit_islemleri.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.kayit_islemleri.Cursor = System.Windows.Forms.Cursors.Hand;
            this.kayit_islemleri.FlatAppearance.BorderSize = 0;
            this.kayit_islemleri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kayit_islemleri.Location = new System.Drawing.Point(957, 34);
            this.kayit_islemleri.Margin = new System.Windows.Forms.Padding(4);
            this.kayit_islemleri.Name = "kayit_islemleri";
            this.kayit_islemleri.Size = new System.Drawing.Size(80, 80);
            this.kayit_islemleri.TabIndex = 2;
            this.kayit_islemleri.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.kayit_islemleri.UseVisualStyleBackColor = true;
            this.kayit_islemleri.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // kaydetlabel
            // 
            this.kaydetlabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kaydetlabel.AutoSize = true;
            this.kaydetlabel.Font = new System.Drawing.Font("Arial", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kaydetlabel.Location = new System.Drawing.Point(953, 118);
            this.kaydetlabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kaydetlabel.Name = "kaydetlabel";
            this.kaydetlabel.Size = new System.Drawing.Size(75, 23);
            this.kaydetlabel.TabIndex = 39;
            this.kaydetlabel.Text = "Kaydet";
            // 
            // policy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1402, 612);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.iptal);
            this.Controls.Add(this.kaydetlabel);
            this.Controls.Add(this.comboBoxMusteri);
            this.Controls.Add(this.txtPoliceTuru);
            this.Controls.Add(this.dateTimePickerBitis);
            this.Controls.Add(this.dateTimePickerBaslangic);
            this.Controls.Add(this.geri_tusu);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.txtPrimTutari);
            this.Controls.Add(this.iptal_et);
            this.Controls.Add(this.kayit_islemleri);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.policeid);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "policy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Poliçe Ekranı";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PolicyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox policeid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button iptal_et;
        private System.Windows.Forms.TextBox txtPrimTutari;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button geri_tusu;
        private System.Windows.Forms.DateTimePicker dateTimePickerBaslangic;
        private System.Windows.Forms.DateTimePicker dateTimePickerBitis;
        private System.Windows.Forms.ComboBox txtPoliceTuru;
        private System.Windows.Forms.ComboBox comboBoxMusteri;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label iptal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button kayit_islemleri;
        private System.Windows.Forms.Label kaydetlabel;
    }
}