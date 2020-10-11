using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityOrnek2__
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DbSinavOgrenciEntities db = new DbSinavOgrenciEntities();

        private void BtnLinqEntity_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                var degerler = db.TBLNOTLARs.Where(x => x.SINAV1 < 50);
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton2.Checked == true)
            {
                var degerler = db.TBLOGRENCIs.Where(x => x.AD == "Ali");
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton3.Checked == true)
            {
                var degerler = db.TBLOGRENCIs.Where(x => x.AD == textBox1.Text || x.SOYAD == textBox1.Text);
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton4.Checked == true)
            {
                var degerler = db.TBLOGRENCIs.Select(x => new { SOYADI = x.SOYAD });
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton5.Checked == true)
            {
                var degerler = db.TBLOGRENCIs.Select(x =>
                new
                {
                    ADI = x.AD.ToUpper(),
                    SOYADI = x.SOYAD.ToLower()
                });
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton6.Checked == true)
            {
                var degerler = db.TBLOGRENCIs.Select(x =>
                new
                {
                    Adı = x.AD.ToUpper(),
                    Soyadı = x.SOYAD.ToLower()
                }).Where(x => x.Adı != "Ali");
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton7.Checked == true)
            {
                var degerler = db.TBLNOTLARs.Select(x =>
                new
                {
                    ÖğrenciAdSoyad = x.TBLOGRENCI.AD + " " + x.TBLOGRENCI.SOYAD,
                    Ortalaması = x.ORTALAMA,
                    Durum = x.DURUM == true ? "Geçti" : "Kaldı" //if else
                });
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton8.Checked == true)
            {
                var degerler = db.TBLNOTLARs.SelectMany(x => db.TBLOGRENCIs.Where(y => y.ID == x.OGR), (x, y) =>
                        new
                        {
                            ADI = y.AD,
                            x.ORTALAMA,
                            DURUMU = x.DURUM == true ? "Geçti" : "Kaldı"
                        }

                    );
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton9.Checked == true)
            {
                var degerler = db.TBLOGRENCIs.OrderBy(x => x.ID).Take(3);
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton10.Checked == true)
            {
                var degerler = db.TBLOGRENCIs.OrderByDescending(x => x.ID).Take(3);
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton11.Checked == true)
            {
                var degerler = db.TBLOGRENCIs.OrderBy(x => x.AD);
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton12.Checked == true)
            {
                var degerler = db.TBLOGRENCIs.OrderBy(x => x.ID).Skip(5);
                dataGridView1.DataSource = degerler.ToList();
            }
        }
    }
}