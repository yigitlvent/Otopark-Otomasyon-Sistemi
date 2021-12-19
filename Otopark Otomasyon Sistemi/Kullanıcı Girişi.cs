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
                SqlCommand komut = new SqlCommand("Select * From kullanici_girisi where Okullanici_adi='" + textBox1.Text.Trim().ToString() + "'", baglanti);
                SqlDataReader okuyucu = komut.ExecuteReader();
                if (okuyucu.Read() == true)
                {

                    if (textBox1.Text.Trim().ToString() == okuyucu["Okullanici_adi"].ToString() && Şifreleme.Hashing(textBox2.Text.Trim().ToString()) == okuyucu["Osifre"].ToString())
                    {
                        kullanıcı = okuyucu["Okullanici_adi"].ToString();
                        baglanti.Close();
                        Ana_Menü anamenu = new Ana_Menü();
                        anamenu.Show();
                        this.Hide();
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
            Şifremi_Unuttum şifremi_Unuttum = new Şifremi_Unuttum();
            şifremi_Unuttum.Show();
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
