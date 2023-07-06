    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Data.SqlClient;

    namespace WindowsFormsApp1
    {
        public partial class policy : Form
        {
            private SqlConnection connection;
            private SqlCommand sqlCommand;
        public policy(SqlConnection conn, SqlCommand cmd)
        {
            InitializeComponent();
            connection = conn;
            sqlCommand = cmd;
            sqlCommand.Connection = connection;

            if (connection.State == ConnectionState.Closed)
            {
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanına bağlanırken bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void geri_tusu_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void PolicyForm_Load(object sender, EventArgs e)
            {
                LoadCustomers();
                string police_id = Guid.NewGuid().ToString();
                policeid.Text = police_id;
                dateTimePickerBaslangic.Value = DateTime.Today;
                dateTimePickerBitis.Value = DateTime.Today;
                txtPrimTutari.Text = "0";
                LoadPolicyTypes();
                LoadPolicies();
                btnIptal_Click(sender, e);
            }

            private void LoadCustomers()
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("GetCustomersName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            comboBoxMusteri.DisplayMember = "musteri_ad_soyad";
                            comboBoxMusteri.ValueMember = "musteri_id";
                            comboBoxMusteri.DataSource = dataTable;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Müşteriler getirilirken bir hata oluştu: " + ex.Message);
                }
            }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                string police_id = Guid.NewGuid().ToString();
                policeid.Text = police_id;
                string musteri_id = comboBoxMusteri.SelectedValue != null ? comboBoxMusteri.SelectedValue.ToString() : string.Empty;
                string police_turu = txtPoliceTuru.Text;
                decimal prim_tutari = decimal.Parse(txtPrimTutari.Text);
                DateTime baslangic_tarihi = dateTimePickerBaslangic.Value.Date;
                DateTime bitis_tarihi = dateTimePickerBitis.Value.Date;
                string durum = "Ödenmedi";
                if (string.IsNullOrEmpty(police_turu) || string.IsNullOrEmpty(txtPrimTutari.Text))
                {
                    MessageBox.Show("Tüm alanları doldurunuz.");
                    return;
                }
                if (CustomerHasPolicyOfType(musteri_id, police_turu))
                {
                    var confirmationResult = MessageBox.Show("Bu müşterinin zaten aynı türde bir poliçesi bulunmaktadır. Yine de devam etmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirmationResult != DialogResult.Yes)
                    {
                        return; 
                    }
                }
                sqlCommand.Parameters.Clear();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "AddNewPolicy";
                sqlCommand.Parameters.AddWithValue("@PoliceID", police_id);
                sqlCommand.Parameters.AddWithValue("@MusteriID", musteri_id);
                sqlCommand.Parameters.AddWithValue("@PoliceTuru", police_turu);
                sqlCommand.Parameters.AddWithValue("@PrimTutari", prim_tutari);
                sqlCommand.Parameters.AddWithValue("@BaslangicTarihi", baslangic_tarihi);
                sqlCommand.Parameters.AddWithValue("@BitisTarihi", bitis_tarihi);
                sqlCommand.Parameters.AddWithValue("@Durum", durum);
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Yeni poliçe başarıyla eklendi.");
                LoadPolicies();
                btnIptal_Click(sender,e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Yeni poliçe eklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private bool CustomerHasPolicyOfType(string musteriId, string policeTuru)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("CheckCustomerPolicyOfType", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MusteriID", musteriId);
                    command.Parameters.AddWithValue("@PoliceTuru", policeTuru);

                    SqlParameter resultParameter = new SqlParameter("@Result", SqlDbType.Int);
                    resultParameter.Direction = ParameterDirection.Output;
                    command.Parameters.Add(resultParameter);

                    command.ExecuteNonQuery();

                    int count = Convert.ToInt32(command.Parameters["@Result"].Value);

                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteri poliçesi kontrol edilirken bir hata oluştu: " + ex.Message);
                return false;
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
            {

                comboBoxMusteri.SelectedIndex = -1;
                txtPoliceTuru.Text = "";
                txtPrimTutari.Text = "0";
                dateTimePickerBaslangic.Value = DateTime.Today;
                dateTimePickerBitis.Value = DateTime.Today;
                kaydetlabel.Enabled = true;
                kayit_islemleri.Enabled = true;
                button2.Enabled = false;
                label11.Enabled = false;
                delete.Enabled = false;
                label7.Enabled = false;
            }

            private void LoadPolicyTypes()
            {
                try
                {
                   
                    List<string> policyTypes = new List<string>
                    {
                        "Kasko Sigortası",
                        "Trafik Sigortası",
                        "Sağlık Sigortası",
                        "Konut Sigortası",
                        "Seyahat Sigortası",
                        "İşyeri Sigortası",
                        "Hayat Sigortası",
                        "Yangın Sigortası",
                        "Emeklilik Sigortası",
                        "Araç Sigortası"
                    };
                    txtPoliceTuru.DataSource = policyTypes;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Poliçe türleri getirilirken bir hata oluştu: " + ex.Message);
                }
            }

        private void LoadPolicies()
        {
            try
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.CommandText = "GetPoliciesData";
                sqlCommand.CommandType = CommandType.StoredProcedure;

                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView2.DataSource = dataTable;
                    dataGridView2.Columns["musteri_id"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Poliçeler getirilirken bir hata oluştu: " + ex.Message);
            }
        }

        private void txtPrimTutari_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                comboBoxMusteri.SelectedValue = row.Cells["musteri_id"].Value.ToString();
                txtPoliceTuru.Text = row.Cells["police_turu"].Value.ToString();
                txtPrimTutari.Text = row.Cells["prim_tutari"].Value.ToString();
                dateTimePickerBaslangic.Value = Convert.ToDateTime(row.Cells["baslangic_tarihi"].Value);
                dateTimePickerBitis.Value = Convert.ToDateTime(row.Cells["bitis_tarihi"].Value);
                kaydetlabel.Enabled = false;
                kayit_islemleri.Enabled = false;
                button2.Enabled = true;
                label11.Enabled = true;
                delete.Enabled = true;
                label7.Enabled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.SelectedRows.Count > 0)
                {
                    var confirmationResult = MessageBox.Show("Seçili poliçeyi silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirmationResult == DialogResult.Yes)
                    {
                        string policeId = dataGridView2.SelectedRows[0].Cells["police_id"].Value.ToString();
                        sqlCommand.Parameters.Clear();
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.CommandText = "DeletePolicy";
                        sqlCommand.Parameters.AddWithValue("@PoliceID", policeId);
                        sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Poliçe başarıyla silindi.");
                        LoadPolicies();
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen silmek istediğiniz poliçeyi seçin.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Poliçe silinirken bir hata oluştu: " + ex.Message);
            }
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.SelectedRows.Count > 0)
                {
                    string policeId = dataGridView2.SelectedRows[0].Cells["police_id"].Value.ToString();
                    string musteri_id = comboBoxMusteri.SelectedValue != null ? comboBoxMusteri.SelectedValue.ToString() : string.Empty;
                    string police_turu = txtPoliceTuru.Text;
                    decimal prim_tutari = decimal.Parse(txtPrimTutari.Text);
                    DateTime baslangic_tarihi = dateTimePickerBaslangic.Value.Date;
                    DateTime bitis_tarihi = dateTimePickerBitis.Value.Date;
                    if (string.IsNullOrEmpty(police_turu) || string.IsNullOrEmpty(txtPrimTutari.Text))
                    {
                        MessageBox.Show("Tüm alanları doldurunuz.");
                        return;
                    }
                    if (CustomerHasPolicyOfType(musteri_id, police_turu))
                    {
                        var confirmationResult = MessageBox.Show("Bu müşterinin zaten aynı türde bir poliçesi bulunmaktadır. Yine de devam etmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (confirmationResult != DialogResult.Yes)
                        {
                            return;
                        }
                    }
                    sqlCommand.Parameters.Clear();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = "UpdatePolicy";
                    sqlCommand.Parameters.AddWithValue("@PoliceID", policeId);
                    sqlCommand.Parameters.AddWithValue("@MusteriID", musteri_id);
                    sqlCommand.Parameters.AddWithValue("@PoliceTuru", police_turu);
                    sqlCommand.Parameters.AddWithValue("@PrimTutari", prim_tutari);
                    sqlCommand.Parameters.AddWithValue("@BaslangicTarihi", baslangic_tarihi);
                    sqlCommand.Parameters.AddWithValue("@BitisTarihi", bitis_tarihi);
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Poliçe başarıyla güncellendi.");
                    LoadPolicies();
                    btnIptal_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Lütfen güncellemek istediğiniz poliçeyi seçin.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Poliçe güncellenirken bir hata oluştu: " + ex.Message);
            }
        }

    }
}
