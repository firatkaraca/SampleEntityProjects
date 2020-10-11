using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntitySonKisim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DbSinavOgrenciEntities db = new DbSinavOgrenciEntities();

        private void button1_Click(object sender, EventArgs e)
        {
            var degerler = db.TBLOGRENCI.OrderBy(x => x.SEHIR).GroupBy(y => y.SEHIR).Select(z => new
            {
                Şehir = z.Key,
                Toplam = z.Count()
            });
            dataGridView1.DataSource = degerler.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //label1.Text = db.TBLNOTLAR.Max(x => x.ORTALAMA).ToString();
            //label1.Text = db.TBLNOTLAR.Min(x => x.SINAV1).ToString();
            //label1.Text = db.TBLNOTLAR.Where(x => x.DURUM == false).Max(z => z.ORTALAMA).ToString();
            //  label1.Text = db.TBLURUN.Count().ToString();
            //label1.Text = db.TBLURUN.Sum(x => x.STOK).ToString();
            //label1.Text = db.TBLURUN.Count(x => x.AD == "Buzdolabı").ToString();
            //label1.Text = db.TBLURUN.Average(x => x.FIYAT).ToString();
            //label1.Text = db.TBLURUN.Where(x => x.AD == "Buzdolabı").Average(z => z.FIYAT).ToString()+" TL";
            label1.Text = (from x in db.TBLURUN
                           orderby x.STOK descending
                           select x.AD).First();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Kulupler();
        }
    }
}