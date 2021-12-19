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
    public partial class Admin_Ekle : Form
    {
        public Admin_Ekle()
        {
            InitializeComponent();
        }

        private void Admin_Ekle_Load(object sender, EventArgs e)
        {
            comboBox3.Items.Add("A");
            comboBox3.Items.Add("B");
            comboBox3.Items.Add("C");

        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "A")
            {
                comboBox1.Items.Clear();
                Kullanıcı_Girişi.baglanti.Close();
                Kullanıcı_Girişi.baglanti.Open();
                SqlCommand komut10 = new SqlCommand("Select * from siteA where Odurum=0", Kullanıcı_Girişi.baglanti);
                SqlDataReader okuyucu10 = komut10.ExecuteReader();
                while(okuyucu10.Read())
                {
                    comboBox1.Items.Add(okuyucu10["Odaire"].ToString());
                }
                Kullanıcı_Girişi.baglanti.Close();
            }
            else if (comboBox3.Text == "B")
            {
                comboBox1.Items.Clear();
                Kullanıcı_Girişi.baglanti.Close();
                Kullanıcı_Girişi.baglanti.Open();
                SqlCommand komut10 = new SqlCommand("Select * from siteB where Odurum=0", Kullanıcı_Girişi.baglanti);
                SqlDataReader okuyucu10 = komut10.ExecuteReader();
                while (okuyucu10.Read())
                {
                    comboBox1.Items.Add(okuyucu10["Odaire"].ToString());
                }
                Kullanıcı_Girişi.baglanti.Close();
            }
            else if (comboBox3.Text == "C")
            {
                comboBox1.Items.Clear();
                Kullanıcı_Girişi.baglanti.Close();
                Kullanıcı_Girişi.baglanti.Open();
                SqlCommand komut10 = new SqlCommand("Select * from siteC where Odurum=0", Kullanıcı_Girişi.baglanti);
                SqlDataReader okuyucu10 = komut10.ExecuteReader();
                while (okuyucu10.Read())
                {
                    comboBox1.Items.Add(okuyucu10["Odaire"].ToString());
                }
                Kullanıcı_Girişi.baglanti.Close();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string sorgu = textBox1.Text.Trim();
            string[] srg = sorgu.Split(' ');
            int a = 0;
            if (srg.Length.ToString() != "3")
            {
                MessageBox.Show("Lütfen plakayı örnekte gösterildiği gibi boşluklu giriniz.");
                textBox1.Focus();
                Admin_Ekle_Load(sender, e);

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
            if (a == 1)
            {


                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && comboBox1.Text != "" && comboBox3.Text != "")
                {
                    Kullanıcı_Girişi.baglanti.Close();
                    Kullanıcı_Girişi.baglanti.Open();
                    SqlCommand komut8 = new SqlCommand("INSERT INTO site (Oplaka,Omarka,Otel,Oad,Osoyad,Oblok,Odaire) Values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + comboBox3.Text.ToString() + "','" + comboBox1.Text.ToString() + "')", Kullanıcı_Girişi.baglanti);
                    komut8.ExecuteNonQuery();
                    Kullanıcı_Girişi.baglanti.Close();
                    Kullanıcı_Girişi.baglanti.Open();
                    SqlCommand komut6 = new SqlCommand("INSERT INTO sitelog (Okullanici, Oplaka, Oislem, Oysaat,Oaciklama) Values ('" + Kullanıcı_Girişi.kullanıcı + "','" + textBox1.Text.ToString() + "','Insert','" + Tarih.donusum(DateTime.Now.ToString()) + "','Site tablosuna araç eklendi')", Kullanıcı_Girişi.baglanti);
                    komut6.ExecuteNonQuery();
                    Kullanıcı_Girişi.baglanti.Close();
                    if (comboBox3.Text.ToString() == "A")
                    {
                        Kullanıcı_Girişi.baglanti.Open();
                        SqlCommand komut4 = new SqlCommand("update siteA set Odurum=1 where Odaire='" + comboBox1.Text.ToString() + "'", Kullanıcı_Girişi.baglanti);
                        komut4.ExecuteNonQuery();
                        Kullanıcı_Girişi.baglanti.Close();
                    }
                    else if (comboBox3.Text.ToString() == "B")
                    {
                        Kullanıcı_Girişi.baglanti.Open();
                        SqlCommand komut4 = new SqlCommand("update siteB set Odurum=1 where Odaire='" + comboBox1.Text.ToString() + "'", Kullanıcı_Girişi.baglanti);
                        komut4.ExecuteNonQuery();
                        Kullanıcı_Girişi.baglanti.Close();
                    }
                    else if (comboBox3.Text.ToString() == "C")
                    {
                        Kullanıcı_Girişi.baglanti.Open();
                        SqlCommand komut4 = new SqlCommand("update siteC set Odurum=1 where Odaire='" + comboBox1.Text.ToString() + "'", Kullanıcı_Girişi.baglanti);
                        komut4.ExecuteNonQuery();
                        Kullanıcı_Girişi.baglanti.Close();
                    }

                    MessageBox.Show("Plaka başarılı bir şekilde veritabanına eklenmiştir.", "Başarılı");

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    comboBox1.Items.Clear();
                    comboBox3.Items.Clear();
                    comboBox3.Text = "";
                    comboBox1.Text = "";

                }
                else
                {
                    MessageBox.Show("Lütfen tüm boşlukları doldurunuz", "UYARI");
                }
            }
            else
            {
                MessageBox.Show("Girdiğinizin plaka olduğundan emin olunuz");
                textBox1.Focus();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Items.Clear();
            comboBox3.Items.Clear();
            comboBox3.Text = "";
            comboBox1.Text = "";
            Admin_Ekle_Load(sender, e);
        }
    }
}
