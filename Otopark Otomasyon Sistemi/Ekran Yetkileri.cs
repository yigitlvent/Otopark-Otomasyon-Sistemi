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
    public partial class Ekran_Yetkileri : Form
    {
        public Ekran_Yetkileri()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Ekran_Yetkileri_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            checkBox9.Checked = false;
            checkBox10.Checked = false;
            checkBox11.Checked = false;
            checkBox12.Checked = false;
            listBox1.Items.Clear();
            Kullanıcı_Girişi.baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select Oyetki from ekran_yetkisi where Oyetki != 4 ", Kullanıcı_Girişi.baglanti);
            SqlDataReader okuyucu = komut1.ExecuteReader();
            if (textBox1.Text == "")
            {
                textBox1.Text = "5";
            }
            while (okuyucu.Read())
            {
                listBox1.Items.Add(okuyucu["Oyetki"]);
                
                if(Convert.ToInt32(textBox1.Text) <= Convert.ToInt32(okuyucu["Oyetki"]))
                {
                    textBox1.Text = (Convert.ToInt32(okuyucu["Oyetki"]) + 1).ToString();
                }
            }
            Kullanıcı_Girişi.baglanti.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                Kullanıcı_Girişi.baglanti.Open();
                SqlCommand komut1 = new SqlCommand("Select * from ekran_yetkisi where Oyetki='" + listBox1.SelectedItem + "'", Kullanıcı_Girişi.baglanti);
                SqlDataReader okuyucu = komut1.ExecuteReader();
                while (okuyucu.Read())
                {

                    if ("1" == okuyucu["Om"].ToString())
                    {
                        checkBox1.Checked = true;
                    }
                    else
                    {
                        checkBox1.Checked = false;
                    }

                    if ("1" == okuyucu["Om1"].ToString())
                    {
                        checkBox2.Checked = true;
                    }
                    else
                    {
                        checkBox2.Checked = false;
                    }

                    if ("1" == okuyucu["Om2"].ToString())
                    {
                        checkBox3.Checked = true;
                    }
                    else
                    {
                        checkBox3.Checked = false;
                    }

                    if ("1" == okuyucu["Om3"].ToString())
                    {
                        checkBox4.Checked = true;
                    }
                    else
                    {
                        checkBox4.Checked = false;
                    }

                    if ("1" == okuyucu["Om4"].ToString())
                    {
                        checkBox5.Checked = true;
                    }
                    else
                    {
                        checkBox5.Checked = false;
                    }

                    if ("1" == okuyucu["Om5"].ToString())
                    {
                        checkBox6.Checked = true;
                    }
                    else
                    {
                        checkBox6.Checked = false;
                    }

                    if ("1" == okuyucu["Om6"].ToString())
                    {
                        checkBox7.Checked = true;
                    }
                    else
                    {
                        checkBox7.Checked = false;
                    }

                    if ("1" == okuyucu["Om7"].ToString())
                    {
                        checkBox8.Checked = true;
                    }
                    else
                    {
                        checkBox8.Checked = false;
                    }

                    if ("1" == okuyucu["Om8"].ToString())
                    {
                        checkBox9.Checked = true;
                    }
                    else
                    {
                        checkBox9.Checked = false;
                    }

                    if ("1" == okuyucu["Om9"].ToString())
                    {
                        checkBox10.Checked = true;
                    }
                    else
                    {
                        checkBox10.Checked = false;
                    }

                    if ("1" == okuyucu["Om10"].ToString())
                    {
                        checkBox11.Checked = true;
                    }
                    else
                    {
                        checkBox11.Checked = false;
                    }

                    if ("1" == okuyucu["Om11"].ToString())
                    {
                        checkBox12.Checked = true;
                    }
                    else
                    {
                        checkBox12.Checked = false;
                    }
                    if (Kullanıcı_Girişi.kullanıcı != "yigit")
                    {
                        if (("1" == okuyucu["Oyetki"].ToString() || "2" == okuyucu["Oyetki"].ToString() || "3" == okuyucu["Oyetki"].ToString()) && "4" != okuyucu["Oyetki"].ToString())
                        {
                            checkBox1.Enabled = false;
                            checkBox2.Enabled = false;
                            checkBox3.Enabled = false;
                            checkBox4.Enabled = false;
                            checkBox5.Enabled = false;
                            checkBox6.Enabled = false;
                            checkBox7.Enabled = false;
                            checkBox8.Enabled = false;
                            checkBox9.Enabled = false;
                            checkBox10.Enabled = false;
                            checkBox11.Enabled = false;
                            checkBox12.Enabled = false;
                        }
                        else
                        {
                            checkBox1.Enabled = true;
                            checkBox2.Enabled = true;
                            checkBox3.Enabled = true;
                            checkBox4.Enabled = true;
                            checkBox5.Enabled = true;
                            checkBox6.Enabled = true;
                            checkBox7.Enabled = true;
                            checkBox8.Enabled = true;
                            checkBox9.Enabled = true;
                            checkBox10.Enabled = true;
                            checkBox11.Enabled = true;
                            checkBox12.Enabled = true;

                        }
                    }
                    else
                    {
                        checkBox1.Enabled = true;
                        checkBox2.Enabled = true;
                        checkBox3.Enabled = true;
                        checkBox4.Enabled = true;
                        checkBox5.Enabled = true;
                        checkBox6.Enabled = true;
                        checkBox7.Enabled = true;
                        checkBox8.Enabled = true;
                        checkBox9.Enabled = true;
                        checkBox10.Enabled = true;
                        checkBox11.Enabled = true;
                        checkBox12.Enabled = true;
                    }

                }
                Kullanıcı_Girişi.baglanti.Close();
        }
        private static string sorgu;
        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                sorgu = "update ekran_yetkisi set Om=" + (Convert.ToInt32(checkBox1.Checked)).ToString();
                sorgu = sorgu + ",Om1=" + (Convert.ToInt32(checkBox2.Checked)).ToString();
                sorgu = sorgu + ",Om2=" + (Convert.ToInt32(checkBox3.Checked)).ToString();
                sorgu = sorgu + ",Om3=" + (Convert.ToInt32(checkBox4.Checked)).ToString();
                sorgu = sorgu + ",Om4=" + (Convert.ToInt32(checkBox5.Checked)).ToString();
                sorgu = sorgu + ",Om5=" + (Convert.ToInt32(checkBox6.Checked)).ToString();
                sorgu = sorgu + ",Om6=" + (Convert.ToInt32(checkBox7.Checked)).ToString();
                sorgu = sorgu + ",Om7=" + (Convert.ToInt32(checkBox8.Checked)).ToString();
                sorgu = sorgu + ",Om8=" + (Convert.ToInt32(checkBox9.Checked)).ToString();
                sorgu = sorgu + ",Om9=" + (Convert.ToInt32(checkBox10.Checked)).ToString();
                sorgu = sorgu + ",Om10=" + (Convert.ToInt32(checkBox11.Checked)).ToString();
                sorgu = sorgu + ",Om11=" + (Convert.ToInt32(checkBox12.Checked)).ToString();
                sorgu = sorgu + " where Oyetki=" + listBox1.SelectedItem;
                Kullanıcı_Girişi.baglanti.Open();
                SqlCommand komut4 = new SqlCommand("" + sorgu + "", Kullanıcı_Girişi.baglanti);
                komut4.ExecuteNonQuery();
                Kullanıcı_Girişi.baglanti.Close();
                Kullanıcı_Girişi.baglanti.Open();
                SqlCommand komut1 = new SqlCommand("INSERT INTO ekranlog (Okullanici ,Oislem , Oysaat ,Oiskullanici) Values ('" + Kullanıcı_Girişi.kullanıcı + "','Update','" + Tarih.donusum(DateTime.Now.ToString()) + "','" + listBox1.SelectedItem + "')", Kullanıcı_Girişi.baglanti);
                komut1.ExecuteNonQuery();
                Kullanıcı_Girişi.baglanti.Close();
                MessageBox.Show("Yetki düzenlemesi yapıldı");
                Ekran_Yetkileri_Load(sender, e);
            }
            else
            {
                MessageBox.Show("lütfen yetkisini düzenlemek istediğiniz kullanıcıyı seçiniz");
            }
            
        }
        private static string es;
        private void button2_Click(object sender, EventArgs e)
        {
            //('4', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1')
            //es = "insert into ekran_yetkisi (Oyetki,Om,Om1,Om2,Om3,Om4,Om5,Om6,Om7,Om8,Om9,Om10,Om11) Values ('"+textBox1.Text+"'";
            //es = es + ",'" + (Convert.ToInt32(checkBox1.Checked)).ToString() + "'";
            //es = es + ",'" + (Convert.ToInt32(checkBox2.Checked)).ToString() + "'";
            //es = es + ",'" + (Convert.ToInt32(checkBox3.Checked)).ToString() + "'";
            //es = es + ",'" + (Convert.ToInt32(checkBox4.Checked)).ToString() + "'";
            //es = es + ",'" + (Convert.ToInt32(checkBox5.Checked)).ToString() + "'";
            //es = es + ",'" + (Convert.ToInt32(checkBox6.Checked)).ToString() + "'";
            //es = es + ",'" + (Convert.ToInt32(checkBox7.Checked)).ToString() + "'";
            //es = es + ",'" + (Convert.ToInt32(checkBox8.Checked)).ToString() + "'";
            //es = es + ",'" + (Convert.ToInt32(checkBox9.Checked)).ToString() + "'";
            //es = es + ",'" + (Convert.ToInt32(checkBox10.Checked)).ToString() + "'";
            //es = es + ",'" + (Convert.ToInt32(checkBox11.Checked)).ToString() + "'";
            //es = es + ",'" + (Convert.ToInt32(checkBox12.Checked)).ToString() + "'";
            //es = es + ")";
            //Kullanıcı_Girişi.baglanti.Open();
            //SqlCommand komut1 = new SqlCommand("" + es + "", Kullanıcı_Girişi.baglanti);
            //komut1.ExecuteNonQuery();
            //Kullanıcı_Girişi.baglanti.Close();
            Kullanıcı_Girişi.baglanti.Close();
            Kullanıcı_Girişi.baglanti.Open();
            SqlCommand komut1 = new SqlCommand("INSERT INTO ekran_yetkisi (Oyetki,Om,Om1,Om2,Om3,Om4,Om5,Om6,Om7,Om8,Om9,Om10,Om11) Values ('" + textBox1.Text + "','0','0','0','0','0','0','0','0','0','0','0','0')", Kullanıcı_Girişi.baglanti);
            komut1.ExecuteNonQuery();
            Kullanıcı_Girişi.baglanti.Close();
            Kullanıcı_Girişi.baglanti.Open();
            SqlCommand komut5 = new SqlCommand("INSERT INTO ekranlog (Okullanici ,Oislem , Oysaat ,Oiskullanici) Values ('" + Kullanıcı_Girişi.kullanıcı + "','insert','" + Tarih.donusum(DateTime.Now.ToString()) + "','" + listBox1.SelectedItem + "')", Kullanıcı_Girişi.baglanti);
            komut5.ExecuteNonQuery();
            Kullanıcı_Girişi.baglanti.Close();
            Ekran_Yetkileri_Load(sender, e);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            
            if (listBox1.SelectedIndex != -1)
            {
                if (listBox1.SelectedItem.ToString() == "1" || listBox1.SelectedItem.ToString() == "2" || listBox1.SelectedItem.ToString() == "3")
                {
                MessageBox.Show("Bu yetki grubunu silemezsiniz.");
                }
                else
                {
                    DialogResult sonuc = MessageBox.Show("Bu grup yetkiye sahip kullanıcılar olabilir silmek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo);
                    if (sonuc == DialogResult.Yes)
                    {
                        Kullanıcı_Girişi.baglanti.Open();
                        SqlCommand komut5 = new SqlCommand("DELETE FROM ekran_yetkisi where Oyetki='" + listBox1.SelectedItem.ToString() + "'", Kullanıcı_Girişi.baglanti);
                        komut5.ExecuteNonQuery();
                        Kullanıcı_Girişi.baglanti.Close();
                        Kullanıcı_Girişi.baglanti.Open();
                        SqlCommand komut1 = new SqlCommand("INSERT INTO ekranlog (Okullanici ,Oislem , Oysaat ,Oiskullanici) Values ('" + Kullanıcı_Girişi.kullanıcı + "','delete','" + Tarih.donusum(DateTime.Now.ToString()) + "','" + listBox1.SelectedItem + "')", Kullanıcı_Girişi.baglanti);
                        komut1.ExecuteNonQuery();
                        Kullanıcı_Girişi.baglanti.Close();

                        Kullanıcı_Girişi.baglanti.Open();
                        SqlCommand komut3 = new SqlCommand("update Yetki set Oyetki='1' where Oyetki='" + listBox1.SelectedItem + "'", Kullanıcı_Girişi.baglanti);
                        komut3.ExecuteNonQuery();
                        Kullanıcı_Girişi.baglanti.Close();
                        MessageBox.Show("Grup yetkisi silindi");
                        Ekran_Yetkileri_Load(sender, e);
                    }
                } 
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz yetkiyi seçiniz");
            }
        }
    }
}
