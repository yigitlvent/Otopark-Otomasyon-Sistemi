using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Otopark_Otomasyon_Sistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 1;
                label1.Text = "%" + progressBar1.Value.ToString();
            }
            else
            {
                timer1.Enabled = false;
                Db_Kontrol db_Kontrol = new Db_Kontrol();
                db_Kontrol.Db_Kontrol_Load_1(sender, e);
                Kullanıcı_Girişi kg = new Kullanıcı_Girişi();
                kg.Show();
                this.Visible = false;

            }
        }
    }
}
