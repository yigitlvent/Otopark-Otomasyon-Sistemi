using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace Otopark_Otomasyon_Sistemi
{
    
    public partial class Şifremi_Unuttum : Form
    {
        public static string namekontrol="";
        
        public Şifremi_Unuttum()
        {
            InitializeComponent();
        }

        private void Şifremi_Unuttum_Load(object sender, EventArgs e)
        {

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
                MessageBox.Show("Lütfen güvenlik sorusu cevabını boş bırakmayın");
            }
            else
            {
                Kullanıcı_Girişi.baglanti.Open();
                SqlCommand komut = new SqlCommand("Select * From kullanici_girisi where Okullanici_adi='" + textBox1.Text.Trim().ToString() + "'", Kullanıcı_Girişi.baglanti);
                SqlDataReader okuyucu = komut.ExecuteReader();
                if (okuyucu.Read() == true)
                {

                    if (textBox1.Text.Trim().ToString() == okuyucu["Okullanici_adi"].ToString() && Şifreleme.Hashing(textBox2.Text.Trim().ToString()) == okuyucu["Osorgu"].ToString())
                    {
                        namekontrol = okuyucu["Okullanici_adi"].ToString();
                        Şifre_Yenileme şifre_Yenileme = new Şifre_Yenileme();
                        şifre_Yenileme.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya güvenlik sorusu cevabı yanlıştır. Lütfen kontrol ediniz");
                        textBox1.Clear();
                        textBox2.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya güvenlik sorusu cevabı yanlıştır. Lütfen kontrol ediniz");
                    textBox1.Clear();
                    textBox2.Clear();
                }
                Kullanıcı_Girişi.baglanti.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pictureBox2_Click(sender, e);
            }
        }
    }
}
