using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otopark_Otomasyon_Sistemi
{
    class Tarih
    {
        public static string donusum(string s)
        {
            string k = "";
            //string[] tarih = s.Split(' ');
            //string[] tarih1 = tarih[0].Split('.');
            //for (int i = 2; i >= 0; i--)
            //{
            //    if (i == 2)
            //    {
            //        k = k + tarih1[i];
            //    }
            //    else
            //    {
            //        k = k + "." + tarih1[i];
            //    }
            //}
            //k = k + " "+ tarih[1]+".000";
            k = DateTime.Now.Year.ToString() + "." + DateTime.Now.Month.ToString() + "." + DateTime.Now.Day.ToString()+" "+ DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + ":" + DateTime.Now.Millisecond.ToString();
            return (k);
        }
    }
}
