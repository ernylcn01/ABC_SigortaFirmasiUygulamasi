using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class YeniMusteriForm : Form
    {
        private SqlConnection connection;
        private SqlCommand sqlCommand;
        private bool isInitialLoad = true;
        public YeniMusteriForm(SqlConnection conn, SqlCommand cmd)
        {
            InitializeComponent();
            connection = conn;
            sqlCommand = cmd;
            sqlCommand.Connection = connection;
            btnIptal_Click();
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        private void btnIptal_Click()
        {
            txtID.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtTelefon.Text = "";
            txtEmail.Text = "";
            txtAdres.Text = "";
            string musteri_id = Guid.NewGuid().ToString();
            txtID.Text = musteri_id;
            button2.Enabled = false;
            label11.Enabled = false;
            button1.Enabled = false;
            label7.Enabled = false;
            kayit_islemleri.Enabled = true;
            label8.Enabled = true;
        }

        private void YeniMusteriForm_Load(object sender, EventArgs e)
        {
            string musteri_id = Guid.NewGuid().ToString();
            txtID.Text = musteri_id;
            isInitialLoad = false;
            VerileriGetir();
            btnIptal_Click();
        }

        private void VerileriGetir()
        {
            try
            {
                using (SqlCommand command = new SqlCommand("GetCustomers", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView2.DataSource = dataTable;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler getirilirken bir hata oluştu: " + ex.Message);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                string musteri_id = Guid.NewGuid().ToString();
                txtID.Text = musteri_id;
                string musteri_ad = txtAd.Text;
                string musteri_soyad = txtSoyad.Text;
                string musteri_tel = txtTelefon.Text;
                string musteri_mail = txtEmail.Text;
                string musteri_adres = txtAdres.Text;
                if (string.IsNullOrEmpty(musteri_ad) || string.IsNullOrEmpty(musteri_soyad) ||
                    string.IsNullOrEmpty(musteri_tel) || string.IsNullOrEmpty(musteri_mail) ||
                    string.IsNullOrEmpty(musteri_adres))
                {
                    MessageBox.Show("Tüm alanları doldurunuz.");
                    return;
                }
                sqlCommand.Parameters.Clear();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "AddNewCustomer";
                sqlCommand.Parameters.AddWithValue("@MusteriID", musteri_id);
                sqlCommand.Parameters.AddWithValue("@Ad", musteri_ad);
                sqlCommand.Parameters.AddWithValue("@Soyad", musteri_soyad);
                sqlCommand.Parameters.AddWithValue("@Telefon", musteri_tel);
                sqlCommand.Parameters.AddWithValue("@Email", musteri_mail);
                sqlCommand.Parameters.AddWithValue("@Adres", musteri_adres);
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Yeni müşteri başarıyla eklendi.");
                if (Owner is Form1 Form1)
                {
                    Form1.VerileriGetir();
                }

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Yeni müşteri eklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            txtTelefon.Text = "";
            txtEmail.Text = "";
            txtAdres.Text = "";
            string musteri_id = Guid.NewGuid().ToString();
            txtID.Text = musteri_id;
            button2.Enabled = false;
            label11.Enabled = false;
            button1.Enabled = false;
            label7.Enabled = false;
            kayit_islemleri.Enabled = true;
            label8.Enabled = true;
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (isInitialLoad)
            {
                return;
            }

            if (dataGridView2.SelectedRows.Count > 0)
            {
                kayit_islemleri.Enabled = false;
                label8.Enabled = false;
                button2.Enabled = true;
                label11.Enabled = true;
                button1.Enabled = true;
                label7.Enabled = true;

                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];
                txtID.Text = selectedRow.Cells["musteri_id"].Value.ToString();
                txtAd.Text = selectedRow.Cells["musteri_ad"].Value.ToString();
                txtSoyad.Text = selectedRow.Cells["musteri_soyad"].Value.ToString();
                txtTelefon.Text = selectedRow.Cells["musteri_tel"].Value.ToString();
                txtEmail.Text = selectedRow.Cells["musteri_mail"].Value.ToString();
                txtAdres.Text = selectedRow.Cells["musteri_adres"].Value.ToString();
            }
            else
            {
                txtID.Text = "";
                txtAd.Text = "";
                txtSoyad.Text = "";
                txtTelefon.Text = "";
                txtEmail.Text = "";
                txtAdres.Text = "";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string musteri_id = txtID.Text;
                string musteri_ad = txtAd.Text;
                string musteri_soyad = txtSoyad.Text;
                string musteri_tel = txtTelefon.Text;
                string musteri_mail = txtEmail.Text;
                string musteri_adres = txtAdres.Text;
                sqlCommand.Parameters.Clear();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "UpdateCustomer";
                sqlCommand.Parameters.AddWithValue("@MusteriID", musteri_id);
                sqlCommand.Parameters.AddWithValue("@Ad", musteri_ad);
                sqlCommand.Parameters.AddWithValue("@Soyad", musteri_soyad);
                sqlCommand.Parameters.AddWithValue("@Telefon", musteri_tel);
                sqlCommand.Parameters.AddWithValue("@Email", musteri_mail);
                sqlCommand.Parameters.AddWithValue("@Adres", musteri_adres);
                string eski_ad = dataGridView2.SelectedRows[0].Cells["musteri_ad"].Value.ToString();
                string eski_soyad = dataGridView2.SelectedRows[0].Cells["musteri_soyad"].Value.ToString();
                string eski_tel = dataGridView2.SelectedRows[0].Cells["musteri_tel"].Value.ToString();
                string eski_mail = dataGridView2.SelectedRows[0].Cells["musteri_mail"].Value.ToString();
                string eski_adres = dataGridView2.SelectedRows[0].Cells["musteri_adres"].Value.ToString();
                if (musteri_ad == eski_ad && musteri_soyad == eski_soyad && musteri_tel == eski_tel &&
                    musteri_mail == eski_mail && musteri_adres == eski_adres)
                {
                    MessageBox.Show("Değişiklik yapmadınız.");
                    return;
                }

                int affectedRows = sqlCommand.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    MessageBox.Show("Müşteri başarıyla güncellendi.");
                }
                else
                {
                    MessageBox.Show("Güncelleme işlemi başarısız oldu.");
                }
                VerileriGetir();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme işlemi sırasında bir hata oluştu: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.SelectedRows.Count > 0)
                {
                    string musteri_id = dataGridView2.SelectedRows[0].Cells["musteri_id"].Value.ToString();
                    DialogResult result = MessageBox.Show("Seçili müşteriyi silmek istediğinize emin misiniz?", "Müşteri Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        sqlCommand.Parameters.Clear();
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.CommandText = "DeleteCustomer";
                        sqlCommand.Parameters.AddWithValue("@MusteriID", musteri_id);
                        sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Müşteri başarıyla silindi.");
                        VerileriGetir();
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen silmek için bir müşteri seçin.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteri silinirken bir hata oluştu: " + ex.Message);
            }
        }

        private void geri_tusu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
