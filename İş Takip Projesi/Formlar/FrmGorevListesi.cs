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
            chartControl1.Series["Series 1"].Points.AddPoint("İnsan Kaynakları", 26);
            chartControl1.Series["Series 1"].Points.AddPoint("Muhasebe", 55);
            chartControl1.Series["Series 1"].Points.AddPoint("Temizlik", 12);
            chartControl1.Series["Series 1"].Points.AddPoint("Danışma", 42);
            chartControl1.Series["Series 1"].Points.AddPoint("Güvenlik", 22);
            chartControl1.Series["Series 1"].Points.AddPoint("Ulaşım", 31);
            chartControl1.Series["Series 1"].Points.AddPoint("Müdür", 85);
            
            
        }
    }
}
