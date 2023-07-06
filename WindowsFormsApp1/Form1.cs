// Form1.cs
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Timers;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=217.195.197.129;Initial Catalog=sigorta_uygulamasi;User ID=admin;Password=Mustafa1";
        private SqlConnection connection;
        private SqlCommand command;
        private System.Timers.Timer timer;
        private Action verileriGetirAction;

        public Form1()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            timer = new System.Timers.Timer();
            timer.Interval = 5000;
            timer.Elapsed += TimerElapsed;
            verileriGetirAction = new Action(VerileriGetir);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            command.Connection = connection;
            VerileriGetir();
            timer.Start();
        }
        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            Invoke(verileriGetirAction);
        }
        public void VerileriGetir()
        {
            try
            {
                command.Parameters.Clear();
                command.CommandText = "GetPolicies";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Clear(); 
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                label2.Text = "Toplam Poliçe Sayısı: " + dataTable.Rows.Count.ToString();
                command.CommandText = "GetCustomers";
                command.Parameters.Clear();
                dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView2.DataSource = dataTable;
                label8.Text = "Toplam Müşteriler: " + dataTable.Rows.Count.ToString();
                command.CommandText = "GetPayments";
                command.Parameters.Clear();
                dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView3.DataSource = dataTable;
                label9.Text = "Toplam Ödenmiş Poliçeler: " + dataTable.Rows.Count.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler getirilirken bir hata oluştu: " + ex.Message);
            }
        }

        private void duzenleme_resmi_Click(object sender, EventArgs e)
        {
            YeniMusteriEkle();
        }

        private void YeniMusteriEkle()
        {
            using (YeniMusteriForm yeniMusteriForm = new YeniMusteriForm(connection, command))
            {
                yeniMusteriForm.ShowDialog();
            }
        }

        private void yenile_Click(object sender, EventArgs e)
        {
            VerileriGetir();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Police_Ekle();
        }
        private void Police_Ekle()
        {
            using (policy policeform = new policy(connection, command))
            {
                policeform.ShowDialog();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            using (payment paymentform = new payment(connection, command))
            {
                paymentform.ShowDialog();
            }
        }
    }
}
