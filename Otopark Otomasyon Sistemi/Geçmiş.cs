using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace Otopark_Otomasyon_Sistemi
{
    public partial class Geçmiş : Form
    {
        public Geçmiş()
        {
            InitializeComponent();
        }

        private void Geçmiş_Load(object sender, EventArgs e)
        {

        }
        int kontrol;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string sorgu = textBox1.Text.Trim();
            string[] srg = sorgu.Split(' ');
            int a = 0;
            if (srg.Length.ToString() != "3")
            {
                MessageBox.Show("Lütfen plakayı örnekte gösterildiği gibi boşluklu giriniz.");
            }
            else
            {
                for (int i = 1; i <= 81; i++)
                {
                    if (srg[0] == "0" + i.ToString() || srg[0] == i.ToString())
                    {
                        a = 1;
                    }
                }
            }
            if (textBox1.Text != "" && a==1)
                {
                kontrol = 0;
                Kullanıcı_Girişi.baglanti.Open();
                SqlCommand komut5 = new SqlCommand("Select * from site where Oplaka LIKE'" + textBox1.Text + "'", Kullanıcı_Girişi.baglanti);
                SqlDataReader okuyucu = komut5.ExecuteReader();

                while (okuyucu.Read())
                {
                    if (textBox1.Text.ToLower() == okuyucu["Oplaka"].ToString().ToLower())
                    {
                        label8.Text = okuyucu["Oplaka"].ToString();
                        label2.Text = okuyucu["Omarka"].ToString();
                        label3.Text = okuyucu["Otel"].ToString();
                        label4.Text = okuyucu["Oad"].ToString();
                        label5.Text = okuyucu["Osoyad"].ToString();
                        label6.Text = okuyucu["Oblok"].ToString();
                        label7.Text = okuyucu["Odaire"].ToString();
                        kontrol = 1;
                        label16.Text = "Site Sakini";
                    }
                }
                if (kontrol == 0)
                {
                    MessageBox.Show("Araç bilgisi bulunamadı.", "Araç Bilgisi");
                }
                Kullanıcı_Girişi.baglanti.Close();
            }
            else
            {
                MessageBox.Show("Plakayı doğru girdiğinizden emin olunuz");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
            label16.Text = "";
            textBox1.Focus();

        }

        private void label17_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
        }
    }
}
