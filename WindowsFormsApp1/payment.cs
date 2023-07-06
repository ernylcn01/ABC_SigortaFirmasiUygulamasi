using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class payment : Form
    {
        private SqlConnection connection;
        private SqlCommand sqlCommand;
        private SqlCommand command;

        public payment(SqlConnection conn, SqlCommand cmd)
        {
            InitializeComponent();
            connection = conn;
            sqlCommand = cmd;
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

            sqlCommand.Connection = connection;
            dataGridView1.CellClick += dataGridViewPayments_CellClick;
            LoadPayments();
            ColorizeRows();
            LoadPayed();
        }
        private void ColorizeRows()
        {
            foreach (DataGridViewRow row in dataGridViewPayments.Rows)
            {
                string status = row.Cells["durum"].Value.ToString();
                if (status == "Ödenmedi")
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
                else if (status == "Ödendi")
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = dataGridViewPayments.DefaultCellStyle.BackColor;
                }
            }
        }

        private void dataGridViewPayments_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ColorizeRows();
        }

        public void LoadPayments()
        {
            try
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "GetPolicy";

                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridViewPayments.Columns.Clear();
                    dataGridViewPayments.DataSource = dataTable;
                }
                DataGridViewComboBoxColumn paymentTypeColumn = new DataGridViewComboBoxColumn();
                paymentTypeColumn.Name = "paymentType";
                paymentTypeColumn.HeaderText = "Ödeme Türü";
                paymentTypeColumn.Items.Add("Havale");
                paymentTypeColumn.Items.Add("Kredi Kartı");
                paymentTypeColumn.Items.Add("Nakit");
                paymentTypeColumn.DefaultCellStyle.NullValue = "Nakit"; 
                dataGridViewPayments.Columns.Add(paymentTypeColumn);
                DataGridViewButtonColumn paymentButtonColumn = new DataGridViewButtonColumn();
                paymentButtonColumn.Name = "paymentButton";
                paymentButtonColumn.HeaderText = "Öde";
                paymentButtonColumn.Text = "Öde";
                paymentButtonColumn.UseColumnTextForButtonValue = true;
                paymentButtonColumn.DataPropertyName = "police_id"; 
                dataGridViewPayments.Columns.Add(paymentButtonColumn);
                ColorizeRows(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ödemeler getirilirken bir hata oluştu: " + ex.Message);
            }
        }
        private void LoadPayed()
        {
            try
            {
                sqlCommand.Parameters.Clear();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "GetPayments";

                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
                DataGridViewButtonColumn pdfButtonColumn = new DataGridViewButtonColumn();
                pdfButtonColumn.Name = "pdfButton";
                pdfButtonColumn.HeaderText = "PDF";
                pdfButtonColumn.Text = "PDF Oluştur";
                pdfButtonColumn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(pdfButtonColumn);
                ColorizeRows(); 

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ödemeler getirilirken bir hata oluştu: " + ex.Message);
            }
        }
        private void dataGridViewPayments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewPayments.Columns["paymentButton"].Index && e.RowIndex >= 0)
            {
                string status = dataGridViewPayments.Rows[e.RowIndex].Cells["durum"].Value.ToString();

                if (status == "Ödendi")
                {
                    MessageBox.Show("Bu poliçe zaten ödenmiştir.");
                    return;
                }
                DataGridViewComboBoxCell paymentTypeCell = (DataGridViewComboBoxCell)dataGridViewPayments.Rows[e.RowIndex].Cells["paymentType"];
                string selectedPaymentType = paymentTypeCell.Value != null ? paymentTypeCell.Value.ToString() : "Nakit";

                if (selectedPaymentType == "")
                {
                    MessageBox.Show("Lütfen bir ödeme türü seçin.");
                    return;
                }

                string selectedPolicyId = dataGridViewPayments.Rows[e.RowIndex].Cells["police_id"].Value.ToString();
                decimal selectedPolicyAmount = Convert.ToDecimal(dataGridViewPayments.Rows[e.RowIndex].Cells["prim_tutari"].Value);

                try
                {
                    string customerId = dataGridViewPayments.Rows[e.RowIndex].Cells["musteri_id"].Value.ToString();
                    using (SqlCommand updateCommand = new SqlCommand("UpdatePolicyStatus", connection))
                    {
                        updateCommand.CommandType = CommandType.StoredProcedure;
                        updateCommand.Parameters.AddWithValue("@PoliceId", selectedPolicyId);
                        updateCommand.ExecuteNonQuery();
                    }
                    using (SqlCommand insertCommand = new SqlCommand("InsertPayment", connection))
                    {
                        insertCommand.CommandType = CommandType.StoredProcedure;
                        insertCommand.Parameters.AddWithValue("@MusteriId", customerId);
                        insertCommand.Parameters.AddWithValue("@Tarih", DateTime.Now);
                        insertCommand.Parameters.AddWithValue("@Tutar", selectedPolicyAmount);
                        insertCommand.Parameters.AddWithValue("@OdemeTuru", selectedPaymentType);
                        insertCommand.Parameters.AddWithValue("@Aciklama", "");
                        insertCommand.ExecuteNonQuery();
                    }

                    LoadPayments();
                    try
                    {
                        sqlCommand.Parameters.Clear();
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.CommandText = "GetPayments";

                        using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            dataGridView1.DataSource = dataTable;
                        }

                       
                        ColorizeRows();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ödemeler getirilirken bir hata oluştu: " + ex.Message);
                    }

                    MessageBox.Show("Ödeme işlemi başarıyla tamamlandı.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ödeme işlemi sırasında bir hata oluştu: " + ex.Message);
                }
            }
           
        }

        private string GeneratePDF(string odemeId, string musteriId, string tarih, decimal tutar, string odemeTuru)
        {
            try
            {
                iTextSharp.text.Document document = new iTextSharp.text.Document();
                string pdfPath = Path.Combine(Application.StartupPath, "dekont.pdf");
                iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, new FileStream(pdfPath, FileMode.Create));
                document.Open();
                iTextSharp.text.Font titleFont = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA_BOLD, 18, iTextSharp.text.Font.UNDERLINE);
                iTextSharp.text.Font headingFont = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA_BOLD, 12);
                iTextSharp.text.Font contentFont = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, 12);
                iTextSharp.text.Paragraph title = new iTextSharp.text.Paragraph("Dekont Bilgileri", titleFont);
                title.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                document.Add(title);
                document.Add(iTextSharp.text.Chunk.NEWLINE);
                string customerName = GetCustomerNameById(musteriId);
                document.Add(new iTextSharp.text.Paragraph($"Odeme ID: {odemeId}", headingFont));
                document.Add(new iTextSharp.text.Paragraph($"Müsteri ID: {musteriId}", headingFont));
                document.Add(new iTextSharp.text.Paragraph($"Müsteri Adı: {customerName}", headingFont));
                document.Add(new iTextSharp.text.Paragraph($"Tarih: {tarih}", headingFont));
                document.Add(new iTextSharp.text.Paragraph($"Tutar: {tutar}", headingFont));
                document.Add(new iTextSharp.text.Paragraph($"Odeme Türü: {odemeTuru}", headingFont));
                document.Close();

                return pdfPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show("PDF oluşturulurken bir hata oluştu: " + ex.Message);
                return null;
            }
        }

        private string GetCustomerNameById(string customerId)
        {
            string customerName = string.Empty;
            using (SqlCommand command = new SqlCommand("GetCustomerName", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CustomerId", customerId);

                SqlParameter outputParameter = new SqlParameter("@CustomerName", SqlDbType.VarChar, 128);
                outputParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(outputParameter);

                command.ExecuteNonQuery();

                customerName = command.Parameters["@CustomerName"].Value.ToString();
            }

            return customerName;
        }

        private void OpenPDF(string pdfPath)
        {
            try
            {
                if (File.Exists(pdfPath))
                {
                    System.Diagnostics.Process.Start(pdfPath);
                }
                else
                {
                    MessageBox.Show("PDF dosyası bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PDF dosyası açılırken bir hata oluştu: " + ex.Message);
            }
        }

        private void geri_tusu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
             if (e.ColumnIndex == dataGridView1.Columns["pdfButton"].Index && e.RowIndex >= 0)
            {
                string odemeId = dataGridView1.Rows[e.RowIndex].Cells["odeme_id"].Value.ToString();
                string musteriId = dataGridView1.Rows[e.RowIndex].Cells["musteri_id"].Value.ToString();
                string tarih = dataGridView1.Rows[e.RowIndex].Cells["tarih"].Value.ToString();
                decimal tutar = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["tutar"].Value);
                string odemeTuru = dataGridView1.Rows[e.RowIndex].Cells["odeme_turu"].Value.ToString();

                GeneratePDF(odemeId, musteriId, tarih, tutar, odemeTuru);
                string pdfPath = GeneratePDF(odemeId, musteriId, tarih, tutar, odemeTuru);
                OpenPDF(pdfPath);
            }
        }
    }
}
