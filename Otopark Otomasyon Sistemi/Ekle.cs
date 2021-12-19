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
    public partial class Ekle : Form
    {
        public Ekle()
        {
            InitializeComponent();
        }
        private void Ekle_Load(object sender, EventArgs e)
        {
            comboBox3.Items.Add("A");
            comboBox3.Items.Add("B");
            comboBox3.Items.Add("C");

        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text=="A")
            {
                comboBox1.Items.Clear();
                Kullanıcı_Girişi.baglanti.Open();
                SqlCommand komut = new SqlCommand("Select * from parkyeriA where Odurum=0", Kullanıcı_Girişi.baglanti);
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    comboBox1.Items.Add(okuyucu["Oparkyeri"].ToString());
                }
                Kullanıcı_Girişi.baglanti.Close();

            }
            else if (comboBox3.Text=="B")
            {
                
                comboBox1.Items.Clear();
                Kullanıcı_Girişi.baglanti.Open();
                SqlCommand komut7 = new SqlCommand("Select * from parkyeriB where Odurum=0", Kullanıcı_Girişi.baglanti);
                SqlDataReader okuyucu7 = komut7.ExecuteReader();
                while (okuyucu7.Read())
                {
                    comboBox1.Items.Add(okuyucu7["Oparkyeri"].ToString());
                }
                Kullanıcı_Girişi.baglanti.Close();
            }
            else if (comboBox3.Text=="C")
            {
                comboBox1.Items.Clear();
                Kullanıcı_Girişi.baglanti.Open();
                SqlCommand komut8 = new SqlCommand("Select * from parkyeriC where Odurum=0", Kullanıcı_Girişi.baglanti);
                SqlDataReader okuyucu8 = komut8.ExecuteReader();
                while (okuyucu8.Read())
                {
                    comboBox1.Items.Add(okuyucu8["Oparkyeri"].ToString());
                }
                Kullanıcı_Girişi.baglanti.Close();
            }
        }

        int kontrol;

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            kontrol = 0;
            if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen bir plaka giriniz!!", "UYARI");
                comboBox1.Items.Clear();
                comboBox3.Items.Clear();
                comboBox3.Text = "";
                Ekle_Load(sender, e);
            }
            else if (comboBox3.Text == "" || comboBox1.Text == "")
            {
                DialogResult dialogResult = MessageBox.Show("Araç Siteye giriş yaptı mı?", "UYARI", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    MessageBox.Show("Lütfen blok ve parkyeri seçeneklerini doldurunuz.", "UYARI");
                    comboBox1.Items.Clear();
                    comboBox3.Items.Clear();
                    comboBox3.Text = "";
                    Ekle_Load(sender, e);

                }
                else
                {
                    kontrol = 1;
                }
            }
            string sorgu = textBox1.Text.Trim();
            string[] srg = sorgu.Split(' ');
            int a = 0;
            if (srg.Length.ToString() !="3")
            {
                MessageBox.Show("Lütfen plakayı örnekte gösterildiği gibi boşluklu giriniz.");
                Ekle_Load(sender, e);

            }
            else
            {
                for (int i = 1; i <=81; i++)
                {
                    if (srg[0]=="0"+i.ToString() || srg[0] == i.ToString())
                    {
                        a = 1;
                    }
                    
                }
            }
            if (a != 1 || srg.Length.ToString() != "3")
            {
                MessageBox.Show("Plaka girdiğinizden emin olunuz", "UYARI");
                textBox1.Focus();
            }
            else if ((kontrol == 1 && textBox1.Text != "") || (kontrol == 0 && comboBox3.Text != "" && comboBox1.Text != "" && textBox1.Text != ""))
            {
                
                Kullanıcı_Girişi.baglanti.Open();
                SqlCommand komut2 = new SqlCommand("Insert Into misafir (Op,Omarka,Otel,Oplaka,Oadi,Osoyadi,Ogsaat,Odurum) Values ('" + comboBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + Tarih.donusum(DateTime.Now.ToString()) + "','" + kontrol.ToString() +"')", Kullanıcı_Girişi.baglanti);

                komut2.ExecuteNonQuery();
                Kullanıcı_Girişi.baglanti.Close();
                if (comboBox3.Text == "A")
                {
                    Kullanıcı_Girişi.baglanti.Open();
                    SqlCommand komut3 = new SqlCommand("update parkyeriA set Odurum='1' where Oparkyeri LIKE'" + comboBox1.Text + "'", Kullanıcı_Girişi.baglanti);
                    komut3.ExecuteNonQuery();
                    Kullanıcı_Girişi.baglanti.Close();
                }
                if (comboBox3.Text == "B")
                {
                    Kullanıcı_Girişi.baglanti.Open();
                    SqlCommand komut3 = new SqlCommand("update parkyeriB set Odurum='1' where Oparkyeri LIKE'" + comboBox1.Text + "'", Kullanıcı_Girişi.baglanti);
                    komut3.ExecuteNonQuery();
                    Kullanıcı_Girişi.baglanti.Close();
                }

                if (comboBox3.Text == "C")
                {
                    Kullanıcı_Girişi.baglanti.Open();
                    SqlCommand komut3 = new SqlCommand("update parkyeriC set Odurum='1' where Oparkyeri LIKE'" + comboBox1.Text + "'", Kullanıcı_Girişi.baglanti);
                    komut3.ExecuteNonQuery();
                    Kullanıcı_Girişi.baglanti.Close();
                }
                MessageBox.Show("Kayıt tamamlanmıştır.", "Başarıyla tamamlandı");
                Kullanıcı_Girişi.baglanti.Open();
                SqlCommand komut1 = new SqlCommand("INSERT INTO misafirlog (Okullanici, Oplaka, Oislem, Oysaat, Oaciklama) Values ('" + Kullanıcı_Girişi.kullanıcı + "','" + comboBox1.Text + "','Insert','" + Tarih.donusum(DateTime.Now.ToString()) + "','Misafir tablosuna araç girişi')", Kullanıcı_Girişi.baglanti);
                komut1.ExecuteNonQuery();
                Kullanıcı_Girişi.baglanti.Close();
                comboBox1.Items.Clear();
                comboBox3.Items.Clear();
                comboBox1.Text = "";
                comboBox3.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                Ekle_Load(sender, e);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
        }
    }
}
