using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using İş_Takip_Projesi.Entity;

namespace İş_Takip_Projesi.Formlar
{
    public partial class FrmGorevListesi : Form
    {
        public FrmGorevListesi()
        {
            InitializeComponent();
        }
        DbİsTakipEntities db = new DbİsTakipEntities();
        private void FrmGorevListesi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblGorevler select new
            {
                
                x.Aciklama
            } ).ToList();

            lblAktifGörev.Text=db.TblGorevler.Where(x => x.Durum==true).Count().ToString();
            lblPasifGörev.Text=db.TblGorevler.Where(x => x.Durum==false).Count().ToString();
            lblToplamDepartman.Text=db.TblDepartmanlar.Count().ToString();


            chartControl1.Series["İstatistik"].Points.AddPoint("Aktif Görevler",int.Parse(lblAktifGörev.Text));
            chartControl1.Series["İstatistik"].Points.AddPoint("Pasif Görevler",int.Parse(lblPasifGörev.Text));
            chartControl1.Series["İstatistik"].Points.AddPoint("Departman Sayısı",int.Parse(lblToplamDepartman.Text));

            gridView1.OptionsView.ColumnAutoWidth = true;
            gridView1.BestFitColumns();


        }
    }
}
