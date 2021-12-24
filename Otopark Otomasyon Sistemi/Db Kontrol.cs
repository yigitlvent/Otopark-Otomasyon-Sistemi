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
    public partial class Db_Kontrol : Form
    {
        public Db_Kontrol()
        {
            InitializeComponent();
        }

        public void Db_Kontrol_Load_1(object sender, EventArgs e)
        {
            try
            {
                Kullanıcı_Girişi.baglanti.Open();
                SqlCommand komut1 = new SqlCommand("Select * from Yetki where Yetki.Okullanici='" + Kullanıcı_Girişi.kullanıcı + "'", Kullanıcı_Girişi.baglanti);
                SqlDataReader okuyucu = komut1.ExecuteReader();
                while (okuyucu.Read())
                {
                    if ("4" == okuyucu["Oyetki"].ToString())
                    {
                        checkBox1.Visible = true;
                        checkBox2.Visible = true;
                        checkBox3.Visible = true;
                        checkBox4.Visible = true;
                        checkBox5.Visible = true;
                        checkBox6.Visible = true;
                        checkBox7.Visible = true;
                        checkBox8.Visible = true;
                        checkBox9.Visible = true;
                        checkBox10.Visible = true;
                        checkBox11.Visible = true;
                        checkBox12.Visible = true;
                        checkBox13.Visible = true;
                        checkBox14.Visible = true;
                        checkBox15.Visible = true;
                        checkBox16.Visible = true;
                        checkBox17.Visible = true;
                    }
                    else if ("3" == okuyucu["Oyetki"].ToString())
                    {
                        checkBox1.Visible = true;
                        checkBox2.Visible = true;
                        checkBox3.Visible = true;
                        checkBox4.Visible = true;
                        checkBox5.Visible = true;
                        checkBox6.Visible = true;
                        checkBox7.Visible = true;
                        checkBox8.Visible = true;
                        checkBox9.Visible = true;
                        checkBox10.Visible = true;
                        checkBox11.Visible = false;
                        checkBox12.Visible = false;
                        checkBox13.Visible = false;
                        checkBox14.Visible = false;
                        checkBox15.Visible = true;
                        checkBox16.Visible = false;
                        checkBox17.Visible = true;
                    }
                }
                Kullanıcı_Girişi.baglanti.Close();

            }
            catch (Exception)
            {
                Kullanıcı_Girişi.baglanti.Close();
            }
            //kullanici_girisi tablosu kontrolü
            try
            {
                Kullanıcı_Girişi.baglanti.Open();
                SqlCommand komut1 = new SqlCommand("SELECT * FROM kullanici_girisi", Kullanıcı_Girişi.baglanti);
                SqlDataReader okuyucu = komut1.ExecuteReader();
                if (okuyucu.Read() == true) {

                    checkBox1.Checked=true;
                }
                Kullanıcı_Girişi.baglanti.Close();
            }
            catch (Exception)
            {
                try
                {
                    Kullanıcı_Girişi.baglanti.Close();
                    Kullanıcı_Girişi.baglanti.Open();
                    SqlCommand komut2 = new SqlCommand("CREATE TABLE kullanici_girisi (Okullanici_adi varchar(100), Osifre varchar(200), Osorgu varchar(200),Odurum varchar(100),Oyenileme varchar(100),Ohata tinyint,PRIMARY KEY(Okullanici_adi))", Kullanıcı_Girişi.baglanti);
                    komut2.ExecuteNonQuery();
                    Kullanıcı_Girişi.baglanti.Close();
                    Kullanıcı_Girişi.baglanti.Open();
                    SqlCommand komut34 = new SqlCommand("INSERT INTO kullanici_girisi (Okullanici_adi, Osifre, Osorgu,Odurum,Oyenileme,Ohata)VALUES('yigit','5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5','d38a9c3ea00e94dc6ce4bd7d8476ca43fc624ae74abbc4d1f45a71ec7ab18e51','1','0',0)", Kullanıcı_Girişi.baglanti);
                    komut34.ExecuteNonQuery();
                    Kullanıcı_Girişi.baglanti.Close();
                }
                catch (Exception)
                {
                    checkBox1.Checked = false;
                }
            }

            //misafir tablosu kontrolü
            try
            {
                Kullanıcı_Girişi.baglanti.Open();
                SqlCommand komut3 = new SqlCommand("SELECT * FROM misafir", Kullanıcı_Girişi.baglanti);
                komut3.ExecuteNonQuery();
                Kullanıcı_Girişi.baglanti.Close();
                checkBox2.Checked = true;
            }
            catch (Exception)
            {
                try
                {
                    Kullanıcı_Girişi.baglanti.Close();
                    Kullanıcı_Girişi.baglanti.Open();
                    SqlCommand komut4 = new SqlCommand("CREATE TABLE misafir (Op varchar(100), Omarka varchar(100), Otel varchar(100),Oplaka varchar(100),Oadi varchar(100),Osoyadi varchar(100),Ogsaat datetime,Ocsaat datetime,Odurum tinyint)", Kullanıcı_Girişi.baglanti);
                    komut4.ExecuteNonQuery();
                    Kullanıcı_Girişi.baglanti.Close();

                }
                catch (Exception)
                {
                    checkBox2.Checked = false;
                }
            }

            //site tablosu kontrolü
            try
            {
                Kullanıcı_Girişi.baglanti.Open();
                SqlCommand komut5 = new SqlCommand("SELECT * FROM site", Kullanıcı_Girişi.baglanti);
                komut5.ExecuteNonQuery();
                Kullanıcı_Girişi.baglanti.Close();
                checkBox6.Checked = true;
            }
            catch (Exception)
            {
                try
                {
                    Kullanıcı_Girişi.baglanti.Close();
                    Kullanıcı_Girişi.baglanti.Open();
                    SqlCommand komut6 = new SqlCommand("CREATE TABLE site (Oplaka varchar(100), Omarka varchar(100), Otel varchar(100),Oad varchar(100),Osoyad varchar(100),Oblok varchar(100),Odaire varchar(100))", Kullanıcı_Girişi.baglanti);
                    komut6.ExecuteNonQuery();
                    Kullanıcı_Girişi.baglanti.Close();
                }
                catch (Exception)
                {
                    checkBox6.Checked = false;
                }
            }

            //parkyeriA tablosu kontrolü
            try
            {
                Kullanıcı_Girişi.baglanti.Open();
                SqlCommand komut7 = new SqlCommand("SELECT * FROM parkyeriA", Kullanıcı_Girişi.baglanti);
                komut7.ExecuteNonQuery();
                Kullanıcı_Girişi.baglanti.Close();
                checkBox3.Checked = true;
            }
            catch (Exception)
            {
                try
                {
                    Kullanıcı_Girişi.baglanti.Close();
                    Kullanıcı_Girişi.baglanti.Open();
                    SqlCommand komut8 = new SqlCommand("CREATE TABLE parkyeriA (Oparkyeri varchar(100), Odurum tinyint)", Kullanıcı_Girişi.baglanti);
                    komut8.ExecuteNonQuery();
                    Kullanıcı_Girişi.baglanti.Close();
                    for (int i = 1; i <= 10; i++)
                    {
                        string k = 'A' + i.ToString();
                        Kullanıcı_Girişi.baglanti.Open();
                        SqlCommand komut22 = new SqlCommand("INSERT INTO parkyeriA (Oparkyeri, Odurum) VALUES ('" + k + "',0)", Kullanıcı_Girişi.baglanti);
                        komut22.ExecuteNonQuery();
                        Kullanıcı_Girişi.baglanti.Close();
                    }

                }
                catch (Exception)
                {
                    checkBox3.Checked = false;
                }
            }

            //parkyeriB tablosu kontrolü
            try
            {
                Kullanıcı_Girişi.baglanti.Open();
                SqlCommand komut9 = new SqlCommand("SELECT * FROM parkyeriB", Kullanıcı_Girişi.baglanti);
                komut9.ExecuteNonQuery();
                Kullanıcı_Girişi.baglanti.Close();
                checkBox4.Checked = true;
            }
            catch (Exception)
            {
                try
                {
                    Kullanıcı_Girişi.baglanti.Close();
                    Kullanıcı_Girişi.baglanti.Open();
                    SqlCommand komut10 = new SqlCommand("CREATE TABLE parkyeriB (Oparkyeri varchar(100), Odurum tinyint)", Kullanıcı_Girişi.baglanti);
                    komut10.ExecuteNonQuery();
                    Kullanıcı_Girişi.baglanti.Close();
                    for (int i = 1; i <= 10; i++)
                    {
                        string k = 'B' + i.ToString();
                        Kullanıcı_Girişi.baglanti.Open();
                        SqlCommand komut24 = new SqlCommand("INSERT INTO parkyeriB (Oparkyeri, Odurum) VALUES ('" + k + "',0)", Kullanıcı_Girişi.baglanti);
                        komut24.ExecuteNonQuery();
                        Kullanıcı_Girişi.baglanti.Close();
                    }

                }
                catch (Exception)
                {
                    checkBox4.Checked = false;
                }
            }

            //parkyeriC tablosu kontrolü
            try
            {
                Kullanıcı_Girişi.baglanti.Open();
                SqlCommand komut11 = new SqlCommand("SELECT * FROM parkyeriC", Kullanıcı_Girişi.baglanti);
                komut11.ExecuteNonQuery();
                Kullanıcı_Girişi.baglanti.Close();
                checkBox5.Checked = true;
            }
            catch (Exception)
            {
                try
                {
                    Kullanıcı_Girişi.baglanti.Close();
                    Kullanıcı_Girişi.baglanti.Open();
                    SqlCommand komut12 = new SqlCommand("CREATE TABLE parkyeriC (Oparkyeri varchar(100), Odurum tinyint)", Kullanıcı_Girişi.baglanti);
                    komut12.ExecuteNonQuery();
                    Kullanıcı_Girişi.baglanti.Close();
                    for (int i = 1; i <= 10; i++)
                    {
                        string k = 'C' + i.ToString();
                        Kullanıcı_Girişi.baglanti.Open();
                        SqlCommand komut26 = new SqlCommand("INSERT INTO parkyeriC (Oparkyeri, Odurum) VALUES ('" + k + "',0)", Kullanıcı_Girişi.baglanti);
                        komut26.ExecuteNonQuery();
                        Kullanıcı_Girişi.baglanti.Close();
                    }

                }
                catch (Exception)
                {
                    checkBox5.Checked = false;
                }                
            }

            //siteA tablosu kontrolü
            try
            {
                Kullanıcı_Girişi.baglanti.Open();
                SqlCommand komut13 = new SqlCommand("SELECT * FROM siteA", Kullanıcı_Girişi.baglanti);
                komut13.ExecuteNonQuery();
                Kullanıcı_Girişi.baglanti.Close();
                checkBox7.Checked = true;
            }
            catch (Exception)
            {
                try
                {
                    Kullanıcı_Girişi.baglanti.Close();
                    Kullanıcı_Girişi.baglanti.Open();
                    SqlCommand komut14 = new SqlCommand("CREATE TABLE siteA (Oblok varchar(100),Odaire varchar(100), Odurum tinyint)", Kullanıcı_Girişi.baglanti);
                    komut14.ExecuteNonQuery();
                    Kullanıcı_Girişi.baglanti.Close();
                    for (int i = 1; i <= 6; i++)
                    {
                        Kullanıcı_Girişi.baglanti.Open();
                        SqlCommand komut28 = new SqlCommand("INSERT INTO siteA (Oblok,Odaire, Odurum) VALUES ('A','" + i.ToString() + "',0)", Kullanıcı_Girişi.baglanti);
                        komut28.ExecuteNonQuery();
                        Kullanıcı_Girişi.baglanti.Close();
                    }
                }
                catch (Exception)
                {
                    checkBox7.Checked = false;
                }
                
            }
            //siteB tablosu kontrolü
            try
            {
                Kullanıcı_Girişi.baglanti.Open();
                SqlCommand komut15 = new SqlCommand("SELECT * FROM siteB", Kullanıcı_Girişi.baglanti);
                komut15.ExecuteNonQuery();
                Kullanıcı_Girişi.baglanti.Close();
                checkBox8.Checked = true;
            }
            catch (Exception)
            {
                try
                {
                    Kullanıcı_Girişi.baglanti.Close();
                    Kullanıcı_Girişi.baglanti.Open();
                    SqlCommand komut16 = new SqlCommand("CREATE TABLE siteB (Oblok varchar(100),Odaire varchar(100), Odurum tinyint)", Kullanıcı_Girişi.baglanti);
                    komut16.ExecuteNonQuery();
                    Kullanıcı_Girişi.baglanti.Close();
                    for (int i = 1; i <= 6; i++)
                    {
                        Kullanıcı_Girişi.baglanti.Open();
                        SqlCommand komut30 = new SqlCommand("INSERT INTO siteB (Oblok,Odaire, Odurum) VALUES ('B','" + i.ToString() + "',0)", Kullanıcı_Girişi.baglanti);
                        komut30.ExecuteNonQuery();
                        Kullanıcı_Girişi.baglanti.Close();
                    }
                }
                catch (Exception)
                {
                    checkBox8.Checked = false;
                }                
            }

            //siteC tablosu kontrolü
            try
            {
                Kullanıcı_Girişi.baglanti.Open();
                SqlCommand komut17 = new SqlCommand("SELECT * FROM siteC", Kullanıcı_Girişi.baglanti);
                komut17.ExecuteNonQuery();
                Kullanıcı_Girişi.baglanti.Close();
                checkBox9.Checked = true;
            }
            catch (Exception)
            {
                try
                {
                    Kullanıcı_Girişi.baglanti.Close();
                    Kullanıcı_Girişi.baglanti.Open();
                    SqlCommand komut18 = new SqlCommand("CREATE TABLE siteC (Oblok varchar(100),Odaire varchar(100), Odurum tinyint)", Kullanıcı_Girişi.baglanti);
                    komut18.ExecuteNonQuery();
                    Kullanıcı_Girişi.baglanti.Close();
                    for (int i = 1; i <= 6; i++)
                    {
                        Kullanıcı_Girişi.baglanti.Open();
                        SqlCommand komut32 = new SqlCommand("INSERT INTO siteC (Oblok,Odaire, Odurum) VALUES ('C','" +i.ToString() + "',0)", Kullanıcı_Girişi.baglanti);
                        komut32.ExecuteNonQuery();
                        Kullanıcı_Girişi.baglanti.Close();
                    }
                }
                catch (Exception)
                {
                    checkBox9.Checked = false;
                }                
            }

            //yetki tablosu kontrolü
            try
            {
                Kullanıcı_Girişi.baglanti.Open();
                SqlCommand komut19 = new SqlCommand("SELECT * FROM Yetki", Kullanıcı_Girişi.baglanti);
                komut19.ExecuteNonQuery();
                Kullanıcı_Girişi.baglanti.Close();
                checkBox10.Checked = true;
            }
            catch (Exception)
            {
                try
                {
                    Kullanıcı_Girişi.baglanti.Close();
                    Kullanıcı_Girişi.baglanti.Open();
                    SqlCommand komut20 = new SqlCommand("CREATE TABLE Yetki (Okullanici varchar(100), Oyetki tinyint,PRIMARY KEY(Okullanici))", Kullanıcı_Girişi.baglanti);
                    komut20.ExecuteNonQuery();
                    Kullanıcı_Girişi.baglanti.Close();
                    Kullanıcı_Girişi.baglanti.Open();
                    SqlCommand komut33 = new SqlCommand("INSERT INTO Yetki (Okullanici, Oyetki)VALUES('yigit',4)", Kullanıcı_Girişi.baglanti);
                    komut33.ExecuteNonQuery();
                    Kullanıcı_Girişi.baglanti.Close();
                }
                catch (Exception)
                {
                    checkBox10.Checked = false;
                }                
            }

            //site log tablosu kontrolü
            try
            {
                Kullanıcı_Girişi.baglanti.Open();
                SqlCommand komut35 = new SqlCommand("SELECT * FROM sitelog", Kullanıcı_Girişi.baglanti);
                komut35.ExecuteNonQuery();
                Kullanıcı_Girişi.baglanti.Close();
                checkBox11.Checked = true;
            }
            catch (Exception)
            {
                try
                {
                    Kullanıcı_Girişi.baglanti.Close();
                    Kullanıcı_Girişi.baglanti.Open();
                    SqlCommand komut36 = new SqlCommand("CREATE TABLE sitelog (Okullanici varchar(100), Oplaka varchar(100), Oislem varchar(100), Oysaat datetime, Oaciklama varchar(500))", Kullanıcı_Girişi.baglanti);
                    komut36.ExecuteNonQuery();
                    Kullanıcı_Girişi.baglanti.Close();
                }
                catch (Exception)
                {
                    checkBox11.Checked = false;
                }
            }

            // misafir log tablosu kontrolü
            try
            {
                Kullanıcı_Girişi.baglanti.Open();
                SqlCommand komut37 = new SqlCommand("SELECT * FROM misafirlog", Kullanıcı_Girişi.baglanti);
                komut37.ExecuteNonQuery();
                Kullanıcı_Girişi.baglanti.Close();
                checkBox12.Checked = true;
            }
            catch (Exception)
            {
                try
                {
                    Kullanıcı_Girişi.baglanti.Close();
                    Kullanıcı_Girişi.baglanti.Open();
                    SqlCommand komut38 = new SqlCommand("CREATE TABLE misafirlog (Okullanici varchar(100), Oplaka varchar(100), Oislem varchar(100), Oysaat datetime, Oaciklama varchar(500))", Kullanıcı_Girişi.baglanti);
                    komut38.ExecuteNonQuery();
                    Kullanıcı_Girişi.baglanti.Close();
                }
                catch (Exception)
                {
                    checkBox12.Checked = false;
                }
            }

            //yetki log tablosu kontrolü
            try
            {
                Kullanıcı_Girişi.baglanti.Open();
                SqlCommand komut39 = new SqlCommand("SELECT * FROM yetkilog", Kullanıcı_Girişi.baglanti);
                komut39.ExecuteNonQuery();
                Kullanıcı_Girişi.baglanti.Close();
                checkBox13.Checked = true;
            }
            catch (Exception)
            {
                try
                {
                    Kullanıcı_Girişi.baglanti.Close();
                    Kullanıcı_Girişi.baglanti.Open();
                    SqlCommand komut40 = new SqlCommand("CREATE TABLE yetkilog (Okullanici varchar(100), Oislem varchar(100), Oysaat datetime,Odkullanici varchar(100), Oaciklama varchar(500), Oyetkie varchar(100), Oyetkiy varchar(100))", Kullanıcı_Girişi.baglanti);
                    komut40.ExecuteNonQuery();
                    Kullanıcı_Girişi.baglanti.Close();
                }
                catch (Exception)
                {
                    checkBox13.Checked = false;
                }
            }

            //kullanıcı log tablosu kontrolü
            try
            {
                Kullanıcı_Girişi.baglanti.Open();
                SqlCommand komut41 = new SqlCommand("SELECT * FROM kullanicilog", Kullanıcı_Girişi.baglanti);
                komut41.ExecuteNonQuery();
                Kullanıcı_Girişi.baglanti.Close();
                checkBox14.Checked = true;
            }
            catch (Exception)
            {
                try
                {
                    Kullanıcı_Girişi.baglanti.Close();
                    Kullanıcı_Girişi.baglanti.Open();
                    SqlCommand komut42 = new SqlCommand("CREATE TABLE kullanicilog (Okullanici varchar(100), Oislem varchar(100), Oysaat datetime,Oekullanici varchar(100), Oaciklama varchar(500))", Kullanıcı_Girişi.baglanti);
                    komut42.ExecuteNonQuery();
                    Kullanıcı_Girişi.baglanti.Close();
                }
                catch (Exception)
                {
                    checkBox14.Checked = false;
                }
            }

            //Sorgu çıktı tablosu kontrolü
            try
            {
                Kullanıcı_Girişi.baglanti.Open();
                SqlCommand komut43 = new SqlCommand("SELECT * FROM sorgu", Kullanıcı_Girişi.baglanti);
                komut43.ExecuteNonQuery();
                Kullanıcı_Girişi.baglanti.Close();
                checkBox15.Checked = true;
            }
            catch (Exception)
            {
                try
                {
                    Kullanıcı_Girişi.baglanti.Close();
                    Kullanıcı_Girişi.baglanti.Open();
                    SqlCommand komut44 = new SqlCommand("CREATE TABLE sorgu (Okullanici varchar(100),Oad varchar(300), Osql varchar(8000), Oysaat datetime,Oyetki varchar(100))", Kullanıcı_Girişi.baglanti);
                    komut44.ExecuteNonQuery();
                    Kullanıcı_Girişi.baglanti.Close();
                }
                catch (Exception)
                {
                    checkBox15.Checked = false;
                }
            }

            //Ekran Yetkisi tablosu kontrolü
            try
            {
                Kullanıcı_Girişi.baglanti.Open();
                SqlCommand komut45 = new SqlCommand("SELECT * FROM ekran_yetkisi", Kullanıcı_Girişi.baglanti);
                komut45.ExecuteNonQuery();
                Kullanıcı_Girişi.baglanti.Close();
                checkBox17.Checked = true;
            }
            catch (Exception)
            {
                try
                {
                    Kullanıcı_Girişi.baglanti.Close();
                    Kullanıcı_Girişi.baglanti.Open();
                    SqlCommand komut46 = new SqlCommand("CREATE TABLE ekran_yetkisi (Oyetki varchar(100),Om varchar(50),Om1 varchar(50),Om2 varchar(50),Om3 varchar(50),Om4 varchar(50),Om5 varchar(50),Om6 varchar(50),Om7 varchar(50),Om8 varchar(50),Om9 varchar(50),Om10 varchar(50),Om11 varchar(50))", Kullanıcı_Girişi.baglanti);
                    komut46.ExecuteNonQuery();
                    Kullanıcı_Girişi.baglanti.Close();
                    Kullanıcı_Girişi.baglanti.Open();
                    SqlCommand komut50 = new SqlCommand("INSERT INTO ekran_yetkisi (Oyetki,Om,Om1,Om2,Om3,Om4,Om5,Om6,Om7,Om8,Om9,Om10,Om11) Values ('4','1','1','1','1','1','1','1','1','1','1','1','1')", Kullanıcı_Girişi.baglanti);
                    komut50.ExecuteNonQuery();
                    Kullanıcı_Girişi.baglanti.Close();
                    Kullanıcı_Girişi.baglanti.Open();
                    SqlCommand komut51 = new SqlCommand("INSERT INTO ekran_yetkisi (Oyetki,Om,Om1,Om2,Om3,Om4,Om5,Om6,Om7,Om8,Om9,Om10,Om11) Values ('1','1','1','1','1','0','0','0','0','0','0','1','0')", Kullanıcı_Girişi.baglanti);
                    komut51.ExecuteNonQuery();
                    Kullanıcı_Girişi.baglanti.Close();
                    Kullanıcı_Girişi.baglanti.Open();
                    SqlCommand komut52 = new SqlCommand("INSERT INTO ekran_yetkisi (Oyetki,Om,Om1,Om2,Om3,Om4,Om5,Om6,Om7,Om8,Om9,Om10,Om11) Values ('2','1','1','1','1','1','1','1','0','0','0','1','0')", Kullanıcı_Girişi.baglanti);
                    komut52.ExecuteNonQuery();
                    Kullanıcı_Girişi.baglanti.Close();
                    Kullanıcı_Girişi.baglanti.Open();
                    SqlCommand komut53 = new SqlCommand("INSERT INTO ekran_yetkisi (Oyetki,Om,Om1,Om2,Om3,Om4,Om5,Om6,Om7,Om8,Om9,Om10,Om11) Values ('3','1','1','1','1','1','1','1','1','1','1','1','1')", Kullanıcı_Girişi.baglanti);
                    komut53.ExecuteNonQuery();
                    Kullanıcı_Girişi.baglanti.Close();
                }
                catch (Exception)
                {
                    checkBox17.Checked = false;
                }
            }

            //ekran log tablosu kontrolü
            try
            {
                Kullanıcı_Girişi.baglanti.Open();
                SqlCommand komut43 = new SqlCommand("SELECT * FROM ekranlog", Kullanıcı_Girişi.baglanti);
                komut43.ExecuteNonQuery();
                Kullanıcı_Girişi.baglanti.Close();
                checkBox16.Checked = true;
            }
            catch (Exception)
            {
                try
                {
                    Kullanıcı_Girişi.baglanti.Close();
                    Kullanıcı_Girişi.baglanti.Open();
                    SqlCommand komut44 = new SqlCommand("CREATE TABLE ekranlog (Okullanici varchar(100),Oislem varchar(300), Oysaat datetime,Oiskullanici varchar(100))", Kullanıcı_Girişi.baglanti);
                    komut44.ExecuteNonQuery();
                    Kullanıcı_Girişi.baglanti.Close();
                }
                catch (Exception)
                {
                    checkBox16.Checked = false;
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
