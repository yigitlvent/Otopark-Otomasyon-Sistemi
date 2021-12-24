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
            
            this.Close();
            Form a;
            Form b;
            Form c;
            Form d;
            Form f;
            Form h;
            Form g;
            Form aa;
            Form ab;
            Form ac;
            Form ad;
            Form al;
            Form ak;
            Form an;
            Form am;
            Form ae;
            Form af;
            Form ag;
            do
            {
                a = Application.OpenForms["Admin_Çıkar"];
                if (a != null)
                {
                    a.Close();
                }
            } while (a != null);
            do
            {
                b = Application.OpenForms["Admin_Ekle"];
                if (b != null)
                {
                    b.Close();
                }
            } while (b != null);
            do
            {
                c = Application.OpenForms["Admin_Kullanıcı"];
                if (c != null)
                {
                    c.Close();
                }
            } while (c != null);
            do
            {
                d = Application.OpenForms["Çıkış"];
                if (d != null)
                {
                    d.Close();
                }
            } while (d != null);
            do
            {
                f = Application.OpenForms["Db_Kontrol"];
                if (f != null)
                {
                    f.Close();
                }
            } while (f != null);
            do
            {
                g = Application.OpenForms["Ekle"];
                if (g != null)
                {
                    g.Close();
                }
            } while (g != null);
            do
            {
                h = Application.OpenForms["Ekran_Yetkileri"];
                if (h != null)
                {
                    h.Close();
                }
            } while (h != null);
            do
            {
                aa = Application.OpenForms["Ekle"];
                if (aa != null)
                {
                    aa.Close();
                }
            } while (aa != null);
            do
            {
                ab = Application.OpenForms["Geçmiş"];
                if (ab != null)
                {
                    ab.Close();
                }
            } while (ab != null);
            do
            {
                ac = Application.OpenForms["Konum"];
                if (ac != null)
                {
                    ac.Close();
                }
            } while (ac != null);
            do
            {
                ad = Application.OpenForms["Konum_B"];
                if (ad != null)
                {
                    ad.Close();
                }
            } while (ad != null);
            do
            {
                ae = Application.OpenForms["Konum_C"];
                if (ae != null)
                {
                    ae.Close();
                }
            } while (ae != null);
            do
            {
                af = Application.OpenForms["Site_Konum_A"];
                if (af != null)
                {
                    af.Close();
                }
            } while (af != null);
            do
            {
                ag = Application.OpenForms["Site_Konum_B"];
                if (ag != null)
                {
                    ag.Close();
                }
            } while (ag != null);
            do
            {
                al = Application.OpenForms["Site_Konum_C"];
                if (al != null)
                {
                    al.Close();
                }
            } while (al != null);
            do
            {
                ak = Application.OpenForms["Sorgu_Çıktı"];
                if (ak != null)
                {
                    ak.Close();
                }
            } while (ak != null);
            do
            {
                an = Application.OpenForms["Sorgu"];
                if (an != null)
                {
                    an.Close();
                }
            } while (an != null);
            do
            {
                am = Application.OpenForms["Yetki"];
                if (am != null)
                {
                    am.Close();
                }
            } while (am != null); 
             
            Kullanıcı_Girişi kg = new Kullanıcı_Girişi();
            kg.Show();

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Form a = Application.OpenForms["Ekle"];
            if (a != null)
            {
                a.Focus();
            }
            else
            {
                Ekle ekle = new Ekle();
                ekle.Show();
            }
            
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            Form a = Application.OpenForms["Çıkış"];
            if (a != null)
            {
                a.Focus();
            }
            else
            {
                Çıkış ac = new Çıkış();
                ac.Show();
            }
            
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {

            Form a = Application.OpenForms["Konum"];
            if (a != null)
            {
                a.Focus();
            }
            else
            {
                Form cb = Application.OpenForms["Konum_B"];
                if (cb != null)
                {
                    cb.Focus();
                }
                else
                {
                    Form cc = Application.OpenForms["Konum_C"];
                    if (cc != null)
                    {
                        cc.Focus();
                    }
                    else
                    {
                        Konum kn = new Konum();
                        kn.Show();
                    }
                }
                
            }
            
            

        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            Form a = Application.OpenForms["Geçmiş"];
            if (a != null)
            {
                a.Focus();
            }
            else
            {
                Geçmiş gc = new Geçmiş();
                gc.Show();
            }
            
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Form a = Application.OpenForms["Admin_Kullanıcı"];
            if (a != null)
            {
                a.Focus();
            }
            else
            {
                Admin_Kullanıcı admin_Kullanıcı = new Admin_Kullanıcı();
                admin_Kullanıcı.Show();
            }
            
            
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Form a = Application.OpenForms["Admin_Çıkar"];
            if (a!=null)
            {
                a.Focus();
            }
            else
            {
                Admin_Çıkar admin_Çıkar = new Admin_Çıkar();
                admin_Çıkar.Show();
            }
            
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form a = Application.OpenForms["Admin_Ekle"];
            if (a != null)
            {
                a.Focus();
            }
            else
            {
                Admin_Ekle admin_Ekle = new Admin_Ekle();
                admin_Ekle.Show();
            }
            
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form a = Application.OpenForms["Site_Konum_A"];
            if (a != null)
            {
                a.Focus();
            }
            else
            {
                Form bb = Application.OpenForms["Site_Konum_B"];
                if (bb != null)
                {
                    bb.Focus();
                }
                else
                {
                    Form bc = Application.OpenForms["Site_Konum_C"];
                    if (bc != null)
                    {
                        bc.Focus();
                    }
                    else
                    {
                        Site_Konum_A site_Konum_A = new Site_Konum_A();
                        site_Konum_A.Show();
                    }
                }
            } 
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Form a = Application.OpenForms["Db_Kontrol"];
            if (a != null)
            {
                a.Focus();
            }
            else
            {
                Db_Kontrol db_Kontrol = new Db_Kontrol();
                db_Kontrol.Show();
            }
            
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Form a = Application.OpenForms["Yetki"];
            if (a != null)
            {
                a.Focus();
            }
            else
            {
                Yetki yetki = new Yetki();
                yetki.Show();
            }
            
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Form a = Application.OpenForms["Sorgu"];
            if (a != null)
            {
                a.Focus();
            }
            else
            {
                Sorgu sorgu = new Sorgu();
                sorgu.Show();
            }
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Form a = Application.OpenForms["Sorgu_Çıktı"];
            if (a != null)
            {
                a.Focus();
            }
            else
            {
                Sorgu_Çıktı sorgu_Çıktı = new Sorgu_Çıktı();
                sorgu_Çıktı.Show();
            }
            
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Form a = Application.OpenForms["Ekran_Yetkileri"];
            if (a != null)
            {
                a.Focus();
            }
            else
            {
                Ekran_Yetkileri ekran_Yetkileri = new Ekran_Yetkileri();
                ekran_Yetkileri.Show();
            }
            
        }
    }
}
