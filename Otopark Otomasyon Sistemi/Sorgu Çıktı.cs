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
    public partial class Sorgu_Çıktı : Form
    {
        public Sorgu_Çıktı()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private static int a;
        private string sorgu;
        private void Sorgu_Çıktı_Load(object sender, EventArgs e)
        {
            if (Kullanıcı_Girişi.kullanıcı=="yigit")
            {
                button3.Visible = true;
            }
            else
            {
                button3.Visible = false;
            }
            listBox1.Items.Clear();
            Kullanıcı_Girişi.baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select Oyetki from Yetki where Okullanici='" + Kullanıcı_Girişi.kullanıcı + "'", Kullanıcı_Girişi.baglanti);
            SqlDataReader okuyucu = komut1.ExecuteReader();
            while (okuyucu.Read())
            {
                  a = Convert.ToInt32(okuyucu["Oyetki"]);
            }
            if (a==3  || a==4)
            {
                textBox1.ReadOnly = false;
            }
            else
            {
                textBox1.ReadOnly = true;
            }
            Kullanıcı_Girişi.baglanti.Close();
            if (a==4||a==3)
            {
                sorgu = "Select Oad from sorgu where Oyetki=1 or Oyetki=2 or Oyetki=3";
            }
            else if (a==2)
            {
                sorgu = "Select Oad from sorgu where Oyetki=1 or Oyetki=2";
            }
            else if (a==1)
            {
                sorgu = "Select Oad from sorgu where Oyetki=1";
            }
            else
            {
                sorgu= "Select Oad from sorgu where Oyetki=1 and Oyetki='"+a+"'";
            }

            Kullanıcı_Girişi.baglanti.Open();
            SqlCommand komut2 = new SqlCommand("("+sorgu+")", Kullanıcı_Girişi.baglanti);
            SqlDataReader okuyucu2 = komut2.ExecuteReader();
            while (okuyucu2.Read())
            {
                listBox1.Items.Add(okuyucu2["Oad"].ToString());
            }
            Kullanıcı_Girişi.baglanti.Close();
        }


        private void button1_Click(object sender, EventArgs e)
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

                MessageBox.Show("Kod çalıştırılamadı.", "Syntax Error");
                Kullanıcı_Girişi.baglanti.Close();
            }
                
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="" && dataGridView1.Columns.Count == 0)
            {
                MessageBox.Show("Lütfen öncelikle Excel aktarmak istediğiniz verilerin kodunu çalıştırınız");
            }
            else
            {
                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                app.Visible = true;
                Microsoft.Office.Interop.Excel.Workbook workbook = app.Workbooks.Add(System.Reflection.Missing.Value);
                Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Kullanıcı_Girişi.baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select Osql from sorgu where Oad='"+listBox1.SelectedItem.ToString()+"'", Kullanıcı_Girişi.baglanti);
            SqlDataReader okuyucu3 = komut1.ExecuteReader();
            while (okuyucu3.Read())
            {
                textBox1.Text= okuyucu3["Osql"].ToString();
            }
            Kullanıcı_Girişi.baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex!=-1)
            {
                try
                {
                        Kullanıcı_Girişi.baglanti.Open();
                        SqlCommand komut5 = new SqlCommand("DELETE FROM sorgu where Oad='" + listBox1.SelectedItem.ToString() + "' and Osql=@textbox", Kullanıcı_Girişi.baglanti);
                        komut5.Parameters.AddWithValue("@textbox", textBox1.Text);
                        komut5.ExecuteNonQuery();
                        Kullanıcı_Girişi.baglanti.Close();
                        MessageBox.Show("Sorgu başarı ile silindi");
                        dataGridView1.DataSource = "";
                        textBox1.Text = "";
                        Sorgu_Çıktı_Load(sender, e);
                }
                catch (Exception)
                {

                    
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz sorguyu seçiniz");
            }
        }
    }
}
