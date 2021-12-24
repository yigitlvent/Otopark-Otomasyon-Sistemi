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
    public partial class Yetki : Form
    {
        public Yetki()
        {
            InitializeComponent();
        }

        private void Yetki_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            textBox1.Text = "";
            listBox2.Items.Add("1");
            listBox2.Items.Add("2");
            listBox2.Items.Add("3");
            Kullanıcı_Girişi.baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select Okullanici from Yetki where Okullanici !='yigit'", Kullanıcı_Girişi.baglanti);
            SqlDataReader okuyucu = komut2.ExecuteReader();
            while (okuyucu.Read())
            {
                listBox1.Items.Add(okuyucu["Okullanici"].ToString());
            }

            Kullanıcı_Girişi.baglanti.Close();

            Kullanıcı_Girişi.baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select Oyetki from ekran_yetkisi where Oyetki !='4' and Oyetki !='3' and Oyetki !='2' and Oyetki !='1'", Kullanıcı_Girişi.baglanti);
            SqlDataReader okuyucu1 = komut1.ExecuteReader();
            while (okuyucu1.Read())
            {
                listBox2.Items.Add(okuyucu1["Oyetki"].ToString());
            }

            Kullanıcı_Girişi.baglanti.Close();
        }
        public static string eskiyetki;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Kullanıcı_Girişi.baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select * from Yetki where Okullanici ='"+ listBox1.SelectedItem+"'", Kullanıcı_Girişi.baglanti);
            SqlDataReader okuyucu = komut1.ExecuteReader();

            while (okuyucu.Read())
            {
                if (listBox1.SelectedItem.ToString() == okuyucu["Okullanici"].ToString())
                {
                    textBox1.Text = okuyucu["Oyetki"].ToString();
                }
            }
            
            Kullanıcı_Girişi.baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1 && listBox2.SelectedIndex != -1)
            {
                
                Kullanıcı_Girişi.baglanti.Open();
                SqlCommand komut3 = new SqlCommand("update Yetki set Oyetki='" + listBox2.SelectedItem + "' where Okullanici LIKE'" + listBox1.SelectedItem + "'", Kullanıcı_Girişi.baglanti);
                komut3.ExecuteNonQuery();
                Kullanıcı_Girişi.baglanti.Close();
                MessageBox.Show("Yetkilendirme yapıldı");
                Kullanıcı_Girişi.baglanti.Open();
                SqlCommand komut1 = new SqlCommand("INSERT INTO yetkilog (Okullanici, Oislem, Oysaat,Odkullanici, Oaciklama,Oyetkie,Oyetkiy) Values ('" + Kullanıcı_Girişi.kullanıcı + "','Update','" + Tarih.donusum(DateTime.Now.ToString()) + "','"+ listBox1.SelectedItem+"','Kullanıcı eklendi','" + textBox1.Text + "','" + listBox2.SelectedItem + "')", Kullanıcı_Girişi.baglanti);
                komut1.ExecuteNonQuery();
                Kullanıcı_Girişi.baglanti.Close();
                Yetki_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Lütfen bir kullanıcı ve yetki seçiniz", "Yetkilendirme Yapılamadı");
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
