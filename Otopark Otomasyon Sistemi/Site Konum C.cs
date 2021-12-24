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
    public partial class Site_Konum_C : Form
    {
        public Site_Konum_C()
        {
            InitializeComponent();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Site_Konum_B kn = new Site_Konum_B();
            kn.Show();
            this.Close();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Site_Konum_C_Load(object sender, EventArgs e)
        {
            Kullanıcı_Girişi.baglanti.Open();
            SqlCommand komut = new SqlCommand("Select site.Oplaka,siteC.Odaire from siteC,site where siteC.Oblok=site.Oblok and siteC.Odurum=1", Kullanıcı_Girişi.baglanti);
            SqlDataReader okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                if (okuyucu["Odaire"].ToString() == "1")
                {
                    pictureBox2.BackColor = Color.Red;
                    label3.Text = okuyucu["Oplaka"].ToString().ToUpper();
                    label3.BackColor = Color.Red;
                    label4.BackColor = Color.Red;
                }
                if (okuyucu["Odaire"].ToString() == "2")
                {
                    pictureBox4.BackColor = Color.Red;
                    label7.Text = okuyucu["plaka"].ToString().ToUpper();
                    label7.BackColor = Color.Red;
                    label8.BackColor = Color.Red;
                }
                if (okuyucu["Odaire"].ToString() == "3")
                {
                    pictureBox3.BackColor = Color.Red;
                    label5.Text = okuyucu["Oplaka"].ToString().ToUpper();
                    label5.BackColor = Color.Red;
                    label6.BackColor = Color.Red;
                }
                if (okuyucu["Odaire"].ToString() == "6")
                {
                    pictureBox7.BackColor = Color.Red;
                    label13.Text = okuyucu["Oplaka"].ToString().ToUpper();
                    label13.BackColor = Color.Red;
                    label14.BackColor = Color.Red;
                }
                if (okuyucu["Odaire"].ToString() == "5")
                {
                    pictureBox8.BackColor = Color.Red;
                    label15.Text = okuyucu["Oplaka"].ToString().ToUpper();
                    label15.BackColor = Color.Red;
                    label16.BackColor = Color.Red;
                }
                if (okuyucu["Odaire"].ToString() == "4")
                {
                    pictureBox9.BackColor = Color.Red;
                    label17.Text = okuyucu["Oplaka"].ToString().ToUpper();
                    label17.BackColor = Color.Red;
                    label18.BackColor = Color.Red;
                }
            }
            Kullanıcı_Girişi.baglanti.Close();
        }
    }
}
