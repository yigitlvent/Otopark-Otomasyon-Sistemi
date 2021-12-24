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
using System.Diagnostics;
using System.Data.SqlClient;

namespace Otopark_Otomasyon_Sistemi
{

    public partial class Kullanıcı_Girişi : Form
    {
        public Kullanıcı_Girişi()
        {
            InitializeComponent();
        }
        public static SqlConnection baglanti = new SqlConnection(@"Data Source=JUNIOR-A\OTOMASYON;Initial Catalog=Otopark_Otomasyon;Integrated Security=true");
        public static string kullanıcı;
        private void Kullanıcı_Girişi_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
                Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text.Trim() == "" && textBox2.Text.Trim() == "")
            {
                MessageBox.Show("Lütfen giriş bilgilerini doldurunuz");
            }
            else if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("Lütfen kullanıcı adını boş bırakmayın");
            }
            else if (textBox2.Text.Trim() == "")
            {
                MessageBox.Show("Lütfen şifreyi boş bırakmayın");
            }
            else 
            {
                
                baglanti.Open();
                SqlCommand komut = new SqlCommand("Select * From kullanici_girisi where Odurum='1' and Okullanici_adi='" + textBox1.Text.Trim().ToString() + "'", baglanti);
                SqlDataReader okuyucu = komut.ExecuteReader();
                if (okuyucu.Read() == true)
                {

                    if (textBox1.Text.Trim().ToString() == okuyucu["Okullanici_adi"].ToString())
                    {
                        if (Şifreleme.Hashing(textBox2.Text.Trim().ToString()) == okuyucu["Osifre"].ToString())
                        {
                            kullanıcı = okuyucu["Okullanici_adi"].ToString();
                            baglanti.Close();
                            Form bb;
                            Form aa;
                            do
                            {
                                aa = Application.OpenForms["Şifre_Yenileme"];
                                while (aa != null)
                                {
                                    aa.Close();
                                }
                            } while (aa != null);
                            do
                            {
                                bb = Application.OpenForms["Şifremi_Unuttum"];
                                if (bb != null)
                                {
                                    bb.Close();
                                }
                            } while (bb != null);
                            baglanti.Open();
                            SqlCommand komut1 = new SqlCommand("Select Oyenileme From kullanici_girisi where Odurum='1' and Okullanici_adi='" + textBox1.Text.Trim().ToString() + "'", baglanti);
                            SqlDataReader okuyucu1 = komut1.ExecuteReader();
                            if (okuyucu1.Read() == true)
                            {
                                if (okuyucu1["Oyenileme"].ToString() == "1")
                                {
                                    baglanti.Close();
                                    textBox2.Text = "";
                                    Şifre_Yenileme şifre_Yenileme = new Şifre_Yenileme();
                                    şifre_Yenileme.Show();
                                }
                                else
                                {
                                    baglanti.Close();
                                    Ana_Menü anamenu = new Ana_Menü();
                                    anamenu.Show();
                                    this.Close();
                                }
                            }
                        }
                        // kullanıcı adı doğru şifre yanlış.
                        baglanti.Close();
                        baglanti.Open();
                        SqlCommand komut2 = new SqlCommand("Select * From kullanici_girisi where Okullanici_adi='" + textBox1.Text.Trim().ToString() + "'", baglanti);
                        SqlDataReader okuyucu2 = komut2.ExecuteReader();
                        if (okuyucu2.Read() == true)
                        {
                            if (okuyucu2["Okullanici_adi"].ToString()=="yigit")
                            {
                                baglanti.Close();
                                MessageBox.Show("Şifre yanlış. Tekrar dene", "Şifre Hatalı");
                            }
                            else
                            {
                                int x = Convert.ToInt32(okuyucu2["Ohata"]);
                                if (x == 2)
                                {
                                    baglanti.Close();
                                    baglanti.Open();
                                    SqlCommand komut3 = new SqlCommand("UPDATE kullanici_girisi set Odurum='0' where Okullanici_adi='" + textBox1.Text.Trim().ToString() + "'", baglanti);
                                    komut3.ExecuteNonQuery();
                                    baglanti.Close();
                                    baglanti.Open();
                                    SqlCommand komut4 = new SqlCommand("UPDATE kullanici_girisi set Ohata=0 where Okullanici_adi='" + textBox1.Text.Trim().ToString() + "'", baglanti);
                                    komut4.ExecuteNonQuery();
                                    baglanti.Close();
                                    MessageBox.Show("Şifrenizi 3 kere yanlış girdiğiniz için kullanıcınız pasif duruma çekilmiştir.", "Kullanıcı Pasif Edildi");
                                    textBox1.Text = "";
                                    textBox2.Text = "";
                                }
                                else
                                {
                                    x = x + 1;
                                    baglanti.Close();
                                    baglanti.Open();
                                    SqlCommand komut3 = new SqlCommand("UPDATE kullanici_girisi set Ohata='" + x + "' where Okullanici_adi='" + textBox1.Text.Trim().ToString() + "'", baglanti);
                                    komut3.ExecuteNonQuery();
                                    baglanti.Close();
                                    MessageBox.Show("Yanlış şifre girdiniz. Kontrol edip tekrar deneyiniz.", "Hatalı Şifre");
                                    textBox2.Text = "";
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya şifre yanlıştır. Lütfen kontrol ediniz");
                        textBox1.Clear();
                        textBox2.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre yanlıştır. Lütfen kontrol ediniz");
                    textBox1.Clear();
                    textBox2.Clear();
                }
                baglanti.Close();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form a = Application.OpenForms["Şifremi_Unuttum"];
            if (a != null)
            {
                a.Focus();
            }
            else
            {
                Şifremi_Unuttum şifremi_Unuttum = new Şifremi_Unuttum();
                şifremi_Unuttum.Show();
            }
            
        }

        private void textBox2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pictureBox2_Click(sender, e);

            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }


    }
}
