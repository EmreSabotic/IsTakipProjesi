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
    public partial class FrmPersonelİstatistik : Form
    {
        public FrmPersonelİstatistik()
        {
            InitializeComponent();
        }
        DbİsTakipEntities db = new DbİsTakipEntities();
        private void FrmPersonelİstatistik_Load(object sender, EventArgs e)
        {
            lblToplamDepartman.Text = db.TblDepartmanlar.Count().ToString();
            lblToplamPersonel.Text = db.TblPersonel.Count().ToString();
            lblToplamFirma.Text = db.TblFirmalar.Count().ToString();
            lblAktifİş.Text = db.TblGorevler.Count(x=>x.Durum==true).ToString();
            lblPasifiş.Text = db.TblGorevler.Count(x=>x.Durum==false).ToString();
            lblSonGörev.Text=db.TblGorevler.OrderByDescending(x=>x.ID).Select(x=>x.Aciklama).FirstOrDefault();
            lblSonGörevTarihi.Text=db.TblGorevDetaylar.OrderByDescending(x=>x.ID).Select(x=>x.Saat).FirstOrDefault().ToString();
            lblŞehir.Text=db.TblFirmalar.Select(x=>x.il).Distinct().Count().ToString();
            lblSektör.Text=db.TblFirmalar.Select(x=>x.Sektor).Distinct().Count().ToString();
            DateTime bugün = DateTime.Today;
            lblBugünkiGörevler.Text=db.TblGorevler.Count(x=>x.Tarih==bugün).ToString();
            var d1=db.TblGorevler.GroupBy(x=>x.GorevAlan).OrderByDescending(z=>z.Count()).Select(y=>y.Key).FirstOrDefault();
            lblAyınPersoneli.Text=db.TblPersonel.Where(x=>x.ID==d1).Select(y=>y.Ad +" "+ y.Soyad).FirstOrDefault().ToString();
            lblAyınDepartmanı.Text=db.TblDepartmanlar.Where(x=>x.ID==db.TblPersonel.Where(t=>t.ID==d1).Select(z=>z.Departman).FirstOrDefault()).Select(y=>y.Ad).FirstOrDefault().ToString();
        }

       
    }
}
