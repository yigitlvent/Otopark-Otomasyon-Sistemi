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
    public partial class Admin_Çıkar : Form
    {
        public Admin_Çıkar()
        {
            InitializeComponent();
            textBox12.Focus();
        }

        private void Admin_Çıkar_Load(object sender, EventArgs e)
        {
            textBox12.Focus();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            if (textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "" && textBox10.Text != "" && textBox6.Text != "" && textBox11.Text != "")
            {

                if (textBox11.Text == "A")
                {
                    Kullanıcı_Girişi.baglanti.Open();
                    SqlCommand komut1 = new SqlCommand("update siteA set Odurum=0 where Odaire='" + textBox6.Text + "'", Kullanıcı_Girişi.baglanti);
                    komut1.ExecuteNonQuery();
                    Kullanıcı_Girişi.baglanti.Close();
                }
                else if (textBox11.Text == "B")
                {
                    Kullanıcı_Girişi.baglanti.Open();
                    SqlCommand komut2 = new SqlCommand("update siteB set Odurum=0 where Odaire='" + textBox6.Text + "'", Kullanıcı_Girişi.baglanti);
                    komut2.ExecuteNonQuery();
                    Kullanıcı_Girişi.baglanti.Close();
                }
                else if (textBox11.Text == "C")
                {
                    Kullanıcı_Girişi.baglanti.Open();
                    SqlCommand komut3 = new SqlCommand("update siteC set Odurum=0 where Odaire='" + textBox6.Text + "'", Kullanıcı_Girişi.baglanti);
                    komut3.ExecuteNonQuery();
                    Kullanıcı_Girişi.baglanti.Close();
                }

                Kullanıcı_Girişi.baglanti.Open();
                SqlCommand komut5 = new SqlCommand("DELETE FROM site where Oplaka='" + textBox12.Text.ToString() + "'", Kullanıcı_Girişi.baglanti);
                komut5.ExecuteNonQuery();
                Kullanıcı_Girişi.baglanti.Close();
                MessageBox.Show("Araç başarı ile sistemden kaldırıldı", "Başarılı işlem");
                Kullanıcı_Girişi.baglanti.Open();
                SqlCommand komut6 = new SqlCommand("INSERT INTO sitelog (Okullanici, Oplaka, Oislem, Oysaat, Oaciklama) Values ('" + Kullanıcı_Girişi.kullanıcı + "','" + textBox12.Text.ToString() + "','Delete','" + Tarih.donusum(DateTime.Now.ToString()) + "','Site tablosundan araç çıkışı')", Kullanıcı_Girişi.baglanti);
                komut6.ExecuteNonQuery();
                Kullanıcı_Girişi.baglanti.Close();
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                textBox6.Text = "";
                textBox11.Text = "";
                textBox12.Text = "";
                

            }
            else
            {
                MessageBox.Show("Plaka sistemde bulunamadı. Kontrol edip tekrar deneyiniz.", "UYARI");
            }

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            textBox10.Text = "";
            textBox11.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox7.Text = "";
            textBox6.Text = "";
            Kullanıcı_Girişi.baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select * from site where Oplaka='" + textBox12.Text.Trim() + "'", Kullanıcı_Girişi.baglanti);
            SqlDataReader okuyucu2 = komut2.ExecuteReader();
            while (okuyucu2.Read())
            {
                textBox7.Text = okuyucu2["Omarka"].ToString();
                textBox8.Text = okuyucu2["Otel"].ToString();
                textBox10.Text = okuyucu2["Oad"].ToString();
                textBox9.Text = okuyucu2["Osoyad"].ToString();
                textBox11.Text = okuyucu2["Oblok"].ToString();
                textBox6.Text = okuyucu2["Odaire"].ToString();
            }
            Kullanıcı_Girişi.baglanti.Close();
            if (textBox7.Text == "" && textBox8.Text == "" && textBox9.Text == "" && textBox10.Text == "" && textBox6.Text == "" && textBox11.Text == "")
            {
                MessageBox.Show("Plaka sistemde bulunamadı. Plakayı boşluklu bir şekilde yazdığınızı kontrol edip tekrar deneyiniz", "UYARI");
            }

        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox7.Text = "";
            textBox6.Text = "";
        }
    }
}
