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

namespace Otopark_Otomasyon_Sistemi
{
    public partial class Ana_Menü : Form
    {
        public Ana_Menü()
        {
            InitializeComponent();
        }
        public static int abc;
        private void Ana_Menü_Load(object sender, EventArgs e)
        {
            pictureBox14.Visible = false;
            pictureBox13.Visible = false;
            pictureBox12.Visible = false;
            pictureBox11.Visible = false;
            pictureBox10.Visible = false;
            pictureBox9.Visible = false;
            pictureBox8.Visible = false;
            pictureBox7.Visible = false;
            pictureBox6.Visible = false;
            pictureBox5.Visible = false;
            pictureBox4.Visible = false;
            pictureBox3.Visible = false;
            pictureBox2.Visible = false;
            Kullanıcı_Girişi.baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select * from ekran_yetkisi,Yetki where Yetki.Oyetki=ekran_yetkisi.Oyetki and Yetki.Okullanici='"+Kullanıcı_Girişi.kullanıcı+"'", Kullanıcı_Girişi.baglanti);
            SqlDataReader okuyucu = komut1.ExecuteReader();
            while (okuyucu.Read())
            {

                if ("1"==okuyucu["Om"].ToString())
                    pictureBox2.Visible = true;
                if ("1" == okuyucu["Om1"].ToString())
                    pictureBox3.Visible = true;
                if ("1" == okuyucu["Om2"].ToString())
                    pictureBox5.Visible = true;
                if ("1" == okuyucu["Om3"].ToString())
                    pictureBox4.Visible = true;
                if ("1" == okuyucu["Om4"].ToString())
                    pictureBox6.Visible = true;
                if ("1" == okuyucu["Om5"].ToString())
                    pictureBox7.Visible = true;
                if ("1" == okuyucu["Om6"].ToString())
                    pictureBox8.Visible = true;
                if ("1" == okuyucu["Om7"].ToString())
                    pictureBox9.Visible = true;
                if ("1" == okuyucu["Om8"].ToString())
                    pictureBox11.Visible = true;
                if ("1" == okuyucu["Om9"].ToString())
                    pictureBox12.Visible = true;
                if ("1" == okuyucu["Om10"].ToString())
                    pictureBox13.Visible = true;
                if ("1" == okuyucu["Om11"].ToString())
                    pictureBox14.Visible = true;

                if("4" == okuyucu["Oyetki"].ToString() || "3" == okuyucu["Oyetki"].ToString())
                {
                    pictureBox14.Visible = true;
                    pictureBox13.Visible = true;
                    pictureBox12.Visible = true;
                    pictureBox11.Visible = true;
                    pictureBox10.Visible = true;
                    pictureBox9.Visible = true;
                    pictureBox8.Visible = true;
                    pictureBox7.Visible = true;
                    pictureBox6.Visible = true;
                    pictureBox5.Visible = true;
                    pictureBox4.Visible = true;
                    pictureBox3.Visible = true;
                    pictureBox2.Visible = true;
                }
            }
            Kullanıcı_Girişi.baglanti.Close();
            
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Kullanıcı_Girişi kg = new Kullanıcı_Girişi();
            kg.Show();
            this.Close();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Ekle ekle = new Ekle();
            ekle.Show();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            Çıkış ac = new Çıkış();
            ac.Show();
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            Konum kn = new Konum();
            kn.Show();
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            Geçmiş gc = new Geçmiş();
            gc.Show();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Admin_Kullanıcı admin_Kullanıcı = new Admin_Kullanıcı();
            admin_Kullanıcı.Show();
            
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Admin_Çıkar admin_Çıkar = new Admin_Çıkar();
            admin_Çıkar.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Admin_Ekle admin_Ekle = new Admin_Ekle();
            admin_Ekle.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Site_Konum_A site_Konum_A = new Site_Konum_A();
            site_Konum_A.Show();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Db_Kontrol db_Kontrol = new Db_Kontrol();
            db_Kontrol.Show();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Yetki yetki = new Yetki();
            yetki.Show();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Sorgu sorgu = new Sorgu();
            sorgu.Show();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Sorgu_Çıktı sorgu_Çıktı = new Sorgu_Çıktı();
            sorgu_Çıktı.Show();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Ekran_Yetkileri ekran_Yetkileri = new Ekran_Yetkileri();
            ekran_Yetkileri.Show();
        }
    }
}
