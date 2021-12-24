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
    public partial class Şifre_Yenileme : Form
    {
        
        
        public Şifre_Yenileme()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "")
            {
                if (textBox1.Text.Trim().ToString() == textBox2.Text.Trim().ToString())
                {
                    Kullanıcı_Girişi.baglanti.Open();
                    SqlCommand komut2 = new SqlCommand("update kullanici_girisi set Osifre='" + Şifreleme.Hashing(textBox1.Text.Trim().ToString()) + "' where Okullanici_adi='" + Şifremi_Unuttum.namekontrol.ToString() + "'", Kullanıcı_Girişi.baglanti);
                    komut2.ExecuteNonQuery();
                    Kullanıcı_Girişi.baglanti.Close();
                    Kullanıcı_Girişi.baglanti.Open();
                    SqlCommand komut3 = new SqlCommand("update kullanici_girisi set Oyenileme='0' where Okullanici_adi='" + Kullanıcı_Girişi.kullanıcı.ToString() + "'", Kullanıcı_Girişi.baglanti);
                    komut3.ExecuteNonQuery();
                    Kullanıcı_Girişi.baglanti.Close();
                    MessageBox.Show("Şifreniz başarılı bir şekilde değiştirildi.", "Başarılı İşlem");
                    Şifremi_Unuttum.namekontrol = "";
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lütfen yeni belirlediğiniz şifrelerin benzerliğini kontrol edip tekrar deneyiniz.", "UYARI");
                }

                
            }
            else
            {
                MessageBox.Show("Lütfen istenilenleri doldurduğunuzdan emin olunuz!", "UYARI");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            Şifremi_Unuttum.namekontrol = "";
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
