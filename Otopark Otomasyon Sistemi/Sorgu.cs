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
    public partial class Sorgu : Form
    {
        public Sorgu()
        {
            InitializeComponent();
        }
        private static string check;

        private void Sorgu_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            textBox2.Text = "";
            Kullanıcı_Girişi.baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select Oyetki from ekran_yetkisi where Oyetki!=4", Kullanıcı_Girişi.baglanti);
            SqlDataReader okuyucu2 = komut2.ExecuteReader();
            while (okuyucu2.Read())
            {
                listBox1.Items.Add(okuyucu2["Oyetki"].ToString());
            }
            Kullanıcı_Girişi.baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = textBox1.Text.ToLower().Trim();
            string[] srg = sorgu.Split(' ');
            int k = 0;
            foreach (string s in srg)
            {
                if (s == "select")
                {
                    k ++;
                }
                
            }
            if (Kullanıcı_Girişi.kullanıcı !="yigit")
            {
                string sorgu1 = textBox1.Text.ToLower().Trim();
                string[] srg1 = sorgu.Split(' ');
                foreach (string s in srg)
                {
                    string[] t = s.Split(',');
                    foreach (var l in t)
                    {
                        if (l == "ekranlog" || l == "kullanicilog" || l == "misafirlog" || l == "sitelog" || l == "yetkilog")
                        {
                            k++;
                        }
                    }
                }
            }
            

            if (k==1)
            {
                try
                {
                    Kullanıcı_Girişi.baglanti.Close();
                    Kullanıcı_Girişi.baglanti.Open();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("(" + textBox1.Text.ToString().Trim() + ")", Kullanıcı_Girişi.baglanti);
                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet, "SORGU");
                    dataGridView1.DataSource = dataSet.Tables["SORGU"];
                    Kullanıcı_Girişi.baglanti.Close();

                }
                catch (Exception)
                {
                    MessageBox.Show("Syntax Error. Tekrar kontrol edin.", "Uyarı");

                }
            }
            else
            {
                MessageBox.Show("Bu işlemi yapamazsınız", "Yetkisiz işlem");
            }
            
        }


        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
             
            if (textBox1.Text == "" || dataGridView1.Columns.Count == 0 || textBox2.Text=="")
            {
                MessageBox.Show("Lütfen öncelikle kaydetmek istediğiniz verilerin kodunu çalıştırınız ve dosya adını giriniz");
            }
            else if (listBox1.SelectedIndex ==-1)
            {
                MessageBox.Show("Lütfen hangi yetkidekilerin görmesini istediğinizi seçiniz ");
            }
            else
            {
                try
                {
                    Kullanıcı_Girişi.baglanti.Open();
                    SqlCommand komut1 = new SqlCommand("INSERT INTO sorgu (Okullanici, Oad,Osql, Oysaat, Oyetki) Values ('" + Kullanıcı_Girişi.kullanıcı + "','" + textBox2.Text + "',@textbox,'" + Tarih.donusum(DateTime.Now.ToString()) + "','" + listBox1.SelectedItem + "')", Kullanıcı_Girişi.baglanti);
                    komut1.Parameters.AddWithValue("@textbox", textBox1.Text);
                    komut1.ExecuteNonQuery();
                    Kullanıcı_Girişi.baglanti.Close();
                    MessageBox.Show("Sorgu veritabanına başarılı bir şekilde eklendi");
                    dataGridView1.DataSource = "";
                    textBox2.Text = "";
                }
                catch (Exception)
                {
                }



            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //listBox1.SelectionMode = SelectionMode.MultiSimple;
        }
    }
}
