using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using İş_Takip_Projesi.Entity;

namespace İş_Takip_Projesi.Formlar
{
    public partial class FrmGorev : Form
    {
        public FrmGorev()
        {
            InitializeComponent();
        }

      
        private void btnVazgeç_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DbİsTakipEntities db = new DbİsTakipEntities();

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TblGorevler t = new TblGorevler();
            t.GorevVeren = int.Parse(txtGorevVeren.Text);
            t.GorevAlan =int.Parse( lookUpEdit1.EditValue.ToString());
            t.Aciklama = txtAciklama.Text;
            t.Tarih=DateTime.Parse(txtTarih.Text);
            t.Durum = true;
            db.TblGorevler.Add(t);
            db.SaveChanges();
            XtraMessageBox.Show("Görev başarılı bir şekilde tanımlandı!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }

        private void FrmGorev_Load(object sender, EventArgs e)
        {
            var degerler = (from x in db.TblPersonel
                            select new
                            {
                                x.ID,
                                an = x.Ad + " " + x.Soyad
                            }).ToList();
            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DisplayMember = "an";
            lookUpEdit1.Properties.DataSource = degerler;
        }
    }
}
