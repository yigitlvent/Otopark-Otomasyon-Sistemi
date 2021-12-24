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
    public partial class Çıkış : Form
    {
        public Çıkış()
        {
            InitializeComponent();
        }

        private void Çıkış_Load(object sender, EventArgs e)
        {
            Kullanıcı_Girişi.baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from misafir where Odurum=0", Kullanıcı_Girişi.baglanti);
            SqlDataReader okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                comboBox1.Items.Add(okuyucu["Oplaka"].ToString().ToUpper());
            }
            Kullanıcı_Girişi.baglanti.Close();
        }
        string parkyeri = "";

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Kullanıcı_Girişi.baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select * from misafir where Odurum=0 and Oplaka LIKE'" + comboBox1.Text + "'", Kullanıcı_Girişi.baglanti);
            SqlDataReader okuyucu2 = komut2.ExecuteReader();
            while (okuyucu2.Read())
            {
                label3.Text = okuyucu2["Omarka"].ToString();
                label4.Text = okuyucu2["Otel"].ToString();
                label6.Text = okuyucu2["Oadi"].ToString();
                label8.Text = okuyucu2["Osoyadi"].ToString();
                parkyeri = okuyucu2["Op"].ToString();
                label10.Text = parkyeri.Substring(0, 1);
            }
            Kullanıcı_Girişi.baglanti.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                if (label10.Text=="A")
                {
                    Kullanıcı_Girişi.baglanti.Open();
                    SqlCommand komut4 = new SqlCommand("update parkyeriA set Odurum=0 where Oparkyeri='" + parkyeri + "'", Kullanıcı_Girişi.baglanti);
                    komut4.ExecuteNonQuery();
                    Kullanıcı_Girişi.baglanti.Close();
                }
                else if (label10.Text == "B")
                {
                    Kullanıcı_Girişi.baglanti.Open();
                    SqlCommand komut7 = new SqlCommand("update parkyeriB set Odurum=0 where Oparkyeri='" + parkyeri + "'", Kullanıcı_Girişi.baglanti);
                    komut7.ExecuteNonQuery();
                    Kullanıcı_Girişi.baglanti.Close();
                }
                else if (label10.Text == "C")
                {
                    Kullanıcı_Girişi.baglanti.Open();
                    SqlCommand komut8 = new SqlCommand("update parkyeriC set Odurum=0 where Oparkyeri='" + parkyeri + "'", Kullanıcı_Girişi.baglanti);
                    komut8.ExecuteNonQuery();
                    Kullanıcı_Girişi.baglanti.Close();
                }
                Kullanıcı_Girişi.baglanti.Open();
                SqlCommand komut6 = new SqlCommand("update misafir set Ocsaat='" + Tarih.donusum(DateTime.Now.ToString()) + "' where Odurum=0 and Oplaka='" + comboBox1.Text + "'", Kullanıcı_Girişi.baglanti);
                komut6.ExecuteNonQuery();
                Kullanıcı_Girişi.baglanti.Close();
                Kullanıcı_Girişi.baglanti.Open();
                SqlCommand komut5 = new SqlCommand("update misafir set Odurum=1 where Oplaka='" + comboBox1.Text + "'", Kullanıcı_Girişi.baglanti);
                komut5.ExecuteNonQuery();
                Kullanıcı_Girişi.baglanti.Close();
                MessageBox.Show("Araç çıkışı yapılmıştır.", "Başarıyla tamamlandı");
                Kullanıcı_Girişi.baglanti.Open();
                SqlCommand komut1 = new SqlCommand("INSERT INTO misafirlog (Okullanici, Oplaka, Oislem, Oysaat, Oaciklama) Values ('" + Kullanıcı_Girişi.kullanıcı + "','" + comboBox1.Text + "','Delete','" + Tarih.donusum(DateTime.Now.ToString()) + "','Misafir tablosundan araç çıkışı')", Kullanıcı_Girişi.baglanti);
                komut1.ExecuteNonQuery();
                Kullanıcı_Girişi.baglanti.Close();
                parkyeri = "";
                label3.Text = "";
                label4.Text = "";
                label6.Text = "";
                label8.Text = "";
                label10.Text = "";
                comboBox1.Text = "";
                comboBox1.Items.Clear();
                Çıkış_Load(sender, e);

            }
            else
            {
                MessageBox.Show("Lütfen bir plaka seçiniz!!", "UYARI");
                comboBox1.Items.Clear();
                Çıkış_Load(sender, e);
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
