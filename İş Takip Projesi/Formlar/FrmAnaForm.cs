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
using DevExpress.XtraGrid.Columns;


namespace İş_Takip_Projesi.Formlar
{
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }

       
        DbİsTakipEntities db=new DbİsTakipEntities();
        private void FrmAnaForm_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblGorevler
                                       select new
                                       {
                                           Açıklama = x.Aciklama,
                                           AdSoyad = x.TblPersonel.Ad + " " + x.TblPersonel.Soyad,
                                           x.Durum

                                       }).Where(y => y.Durum == true).ToList();
            gridView1.Columns["Durum"].Visible = false;

            DateTime bugun =DateTime.Parse( DateTime.Now.ToShortDateString());
            gridControl2.DataSource = (from x in db.TblGorevDetaylar
                                       select new
                                       {
                                           GörevAdı = x.TblGorevler.Aciklama,
                                            Açıklama = x.Aciklama,
                                            x.Tarih

                                           
                                       }).Where(x=>x.Tarih==bugun).ToList();
            
            gridView2.OptionsView.ColumnAutoWidth = true;
            gridView2.BestFitColumns();

            gridControl3.DataSource= (from x in db.TblCagri
                                      select new
                                      {
                                          x.TblFirmalar.Ad,
                                          x.Konu,
                                          x.Tarih,
                                          x.Durum
                                      }).Where(x=>x.Durum == true).ToList();
            gridView3.Columns["Durum"].Visible= false;
            gridView3.OptionsView.ColumnAutoWidth = true;
            gridView3.BestFitColumns();

        }
    }
}
