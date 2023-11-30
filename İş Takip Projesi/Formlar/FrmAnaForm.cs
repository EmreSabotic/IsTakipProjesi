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
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }

       
        DbİsTakipEntities db=new DbİsTakipEntities();
        private void FrmAnaForm_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource=(from x in db.TblGorevler select new{
                x.Aciklama,
              xm = x.TblPersonel.Ad + " " + x.TblPersonel.Soyad
                
            }).ToList();
        }
    }
}
