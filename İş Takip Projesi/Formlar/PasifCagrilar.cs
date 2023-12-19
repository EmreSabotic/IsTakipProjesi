using İş_Takip_Projesi.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace İş_Takip_Projesi.Formlar
{
    public partial class PasifCagrilar : Form
    {
        public PasifCagrilar()
        {
            InitializeComponent();
        }

        private void PasifCagrilar_Load(object sender, EventArgs e)
        {
            DbİsTakipEntities db = new DbİsTakipEntities();
            var degerler = db.TblCagri.Where(x => x.Durum == false).ToList();
            gridControl1.DataSource = degerler;
            gridView1.Columns["Durum"].Visible = false;
            gridView1.Columns["TblFirmalar"].Visible = false;

            gridView1.OptionsView.ColumnAutoWidth = true;
            gridView1.BestFitColumns();

        }
    }
}
