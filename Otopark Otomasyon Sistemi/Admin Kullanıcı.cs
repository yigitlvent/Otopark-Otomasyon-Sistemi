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
    public partial class Admin_Kullanıcı : Form
    {
        public Admin_Kullanıcı()
        {
            InitializeComponent();
        }

        private void Admin_Kullanıcı_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Kullanıcı_Girişi.baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select Okullanici_adi from kullanici_girisi where Okullanici_adi !='yigit'", Kullanıcı_Girişi.baglanti);
            SqlDataReader okuyucu = komut2.ExecuteReader();
            while (okuyucu.Read())
            {
                listBox1.Items.Add(okuyucu["Okullanici_adi"].ToString());
            }

            Kullanıcı_Girişi.baglanti.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int a=0;
            if (textBox1.Text.Trim()=="" || textBox4.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox2.Text.Trim()=="")
            {
                MessageBox.Show("Lütfen boşlukları doldurunuz!", "UYARI");
            }
            else if (textBox4.Text.Trim() != textBox3.Text.Trim())
            {
                MessageBox.Show("Şifre tekrarını doğru girdiğinizden emin olunuz!", "Şifre Tekrarı Yanlış");
                textBox3.Text = "";
                textBox3.Focus();
            }
            else
            {
                
                Kullanıcı_Girişi.baglanti.Open();
                SqlCommand komut = new SqlCommand("Select kullanici_girisi.Okullanici_adi From kullanici_girisi where Okullanici_adi='" + textBox1.Text.ToString().Trim() + "'", Kullanıcı_Girişi.baglanti);
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    if (okuyucu["Okullanici_adi"].ToString() == textBox1.Text.ToString().Trim())
                    {
                        MessageBox.Show("Kullanıcı adı daha önce kaydedilmiş. Başka kullanıcı adıyla tekrar deneyiniz. ", "Kayıt Hatası");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        a = 1;
                        break;
                    }
                    else
                    {
                        a = 0;
                    }
                }
                if (a==0)
                {
                    Kullanıcı_Girişi.baglanti.Close();
                    Kullanıcı_Girişi.baglanti.Open();
                    SqlCommand komut2 = new SqlCommand("Insert Into kullanici_girisi (Okullanici_adi,Osifre,Osorgu) Values ('" + textBox1.Text.ToString().Trim() + "','" + Şifreleme.Hashing(textBox4.Text.ToString().Trim()) + "','" + Şifreleme.Hashing(textBox2.Text.ToString().Trim()) + "')", Kullanıcı_Girişi.baglanti);
                    komut2.ExecuteNonQuery();
                    Kullanıcı_Girişi.baglanti.Close();
                    Kullanıcı_Girişi.baglanti.Open();
                    SqlCommand komut3 = new SqlCommand("INSERT INTO Yetki (Okullanici, Oyetki)VALUES('" + textBox1.Text.ToString().Trim() + "',1)", Kullanıcı_Girişi.baglanti);
                    komut3.ExecuteNonQuery();
                    Kullanıcı_Girişi.baglanti.Close();
                    Kullanıcı_Girişi.baglanti.Open();
                    SqlCommand komut10 = new SqlCommand("INSERT INTO ekran_yetkisi (Oyetki,Om,Om1,Om2,Om3,Om4,Om5,Om6,Om7,Om8,Om9,Om10,Om11) Values ('4','1','1','1','1','0','0','0','0','0','0','0','0')", Kullanıcı_Girişi.baglanti);
                    komut10.ExecuteNonQuery();
                    Kullanıcı_Girişi.baglanti.Close();
                    Kullanıcı_Girişi.baglanti.Open();
                    SqlCommand komut1 = new SqlCommand("INSERT INTO kullanicilog (Okullanici, Oislem, Oysaat,Oekullanici, Oaciklama) Values ('" + Kullanıcı_Girişi.kullanıcı + "','Insert','" + Tarih.donusum(DateTime.Now.ToString()) + "','"+ textBox1.Text.ToString().Trim() + "','Kullanıcı eklendi')", Kullanıcı_Girişi.baglanti);
                    komut1.ExecuteNonQuery();
                    Kullanıcı_Girişi.baglanti.Close();
                    MessageBox.Show("Kişi sisteme kaydedilmiştir", "Başarılı İşlem");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    Admin_Kullanıcı_Load(sender, e);



                }
                Kullanıcı_Girişi.baglanti.Close();
            }
                           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                string tut = listBox1.SelectedItem.ToString();
                Kullanıcı_Girişi.baglanti.Open();
                SqlCommand komut5 = new SqlCommand("DELETE FROM kullanici_girisi where Okullanici_adi='" + listBox1.SelectedItem.ToString() + "'", Kullanıcı_Girişi.baglanti);
                komut5.ExecuteNonQuery();
                Kullanıcı_Girişi.baglanti.Close();
                Kullanıcı_Girişi.baglanti.Open();
                SqlCommand komut1 = new SqlCommand("INSERT INTO kullanicilog (Okullanici, Oislem, Oysaat,Oekullanici, Oaciklama) Values ('" + Kullanıcı_Girişi.kullanıcı + "','Delete','" + Tarih.donusum(DateTime.Now.ToString()) + "','" + tut + "','Kullanıcı silindi')", Kullanıcı_Girişi.baglanti);
                komut1.ExecuteNonQuery();
                Kullanıcı_Girişi.baglanti.Close();
                Kullanıcı_Girişi.baglanti.Open();
                SqlCommand komut6 = new SqlCommand("DELETE FROM Yetki where Okullanici='" + listBox1.SelectedItem.ToString() + "'", Kullanıcı_Girişi.baglanti);
                komut6.ExecuteNonQuery();
                Kullanıcı_Girişi.baglanti.Close();
                MessageBox.Show("Kişi sistemden silinmiştir.");
                Admin_Kullanıcı_Load(sender, e);

            }
            else
            {
                MessageBox.Show("lütfen silmek istediğiniz kullanıcıyı seçiniz");
            }
        }
    }
}
