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
using İş_Takip_Projesi.Entity;

namespace İş_Takip_Projesi.Formlar
{
    public partial class frmDepartmanlar : Form
    {
        //crud = create read update delete
        public frmDepartmanlar()
        {
            InitializeComponent();
        }
        DbİsTakipEntities db = new DbİsTakipEntities();

        void Listele()
        {
            var degerler = (from x in db.TblDepartmanlar
                            select new
                            {
                                x.ID,
                                x.Ad
                            }).ToList();
            gridControl1.DataSource = degerler;
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            TblDepartmanlar t = new TblDepartmanlar();
            t.Ad=txtAd.Text;
            db.TblDepartmanlar.Add(t);
            db.SaveChanges();
            XtraMessageBox.Show("Departman başarılı bir şekilde sisteme kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int x = int.Parse(txtID.Text);
            var deger = db.TblDepartmanlar.Find(x);
            db.TblDepartmanlar.Remove(deger);
            db.SaveChanges();
            XtraMessageBox.Show("Silme işlemi başarılı bir şekilde gerçekleştirildi!","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Stop);
            Listele();
                    
        
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtAd.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            int x = int.Parse(txtID.Text);
            var deger = db.TblDepartmanlar.Find(x);
            deger.Ad = txtAd.Text;



           
            db.SaveChanges();
            XtraMessageBox.Show("Güncelleme işlemi başarılı bir şekilde gerçekleştirildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }
    }
}
