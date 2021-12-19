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
    public partial class Konum_B : Form
    {
        public Konum_B()
        {
            InitializeComponent();
        }

        private void Konum_B_Load(object sender, EventArgs e)
        {
            Kullanıcı_Girişi.baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from parkyeriB,misafir where parkyeriB.Oparkyeri=misafir.Op and misafir.Odurum=0", Kullanıcı_Girişi.baglanti);
            SqlDataReader okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                if (okuyucu["Op"].ToString() == "B1")
                {
                    pictureBox1.BackColor = Color.Red;
                    label2.Text = okuyucu["Oplaka"].ToString().ToUpper();
                    label2.BackColor = Color.Red;
                    label1.BackColor = Color.Red;

                }
                if (okuyucu["Op"].ToString() == "B2")
                {
                    pictureBox2.BackColor = Color.Red;
                    label3.Text = okuyucu["Oplaka"].ToString().ToUpper();
                    label3.BackColor = Color.Red;
                    label4.BackColor = Color.Red;
                }
                if (okuyucu["Op"].ToString() == "B3")
                {
                    pictureBox4.BackColor = Color.Red;
                    label7.Text = okuyucu["Oplaka"].ToString().ToUpper();
                    label7.BackColor = Color.Red;
                    label8.BackColor = Color.Red;
                }
                if (okuyucu["Op"].ToString() == "B4")
                {
                    pictureBox3.BackColor = Color.Red;
                    label5.Text = okuyucu["Oplaka"].ToString().ToUpper();
                    label5.BackColor = Color.Red;
                    label6.BackColor = Color.Red;
                }
                if (okuyucu["Op"].ToString() == "B5")
                {
                    pictureBox5.BackColor = Color.Red;
                    label9.Text = okuyucu["Oplaka"].ToString().ToUpper();
                    label9.BackColor = Color.Red;
                    label10.BackColor = Color.Red;
                }
                if (okuyucu["Op"].ToString() == "B10")
                {
                    pictureBox6.BackColor = Color.Red;
                    label11.Text = okuyucu["Oplaka"].ToString().ToUpper();
                    label11.BackColor = Color.Red;
                    label12.BackColor = Color.Red;
                }
                if (okuyucu["Op"].ToString() == "B9")
                {
                    pictureBox7.BackColor = Color.Red;
                    label13.Text = okuyucu["Oplaka"].ToString().ToUpper();
                    label13.BackColor = Color.Red;
                    label14.BackColor = Color.Red;
                }
                if (okuyucu["Op"].ToString() == "B8")
                {
                    pictureBox8.BackColor = Color.Red;
                    label15.Text = okuyucu["Oplaka"].ToString().ToUpper();
                    label15.BackColor = Color.Red;
                    label16.BackColor = Color.Red;
                }
                if (okuyucu["Op"].ToString() == "B7")
                {
                    pictureBox9.BackColor = Color.Red;
                    label17.Text = okuyucu["Oplaka"].ToString().ToUpper();
                    label17.BackColor = Color.Red;
                    label18.BackColor = Color.Red;
                }
                if (okuyucu["Op"].ToString() == "B6")
                {
                    pictureBox10.BackColor = Color.Red;
                    label19.Text = okuyucu["Oplaka"].ToString().ToUpper();
                    label19.BackColor = Color.Red;
                    label20.BackColor = Color.Red;
                }
            }
            Kullanıcı_Girişi.baglanti.Close();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Konum_C kn = new Konum_C();
            kn.Show();
            this.Hide();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Konum kn = new Konum();
            kn.Show();
            this.Hide();
        }
    }
}
