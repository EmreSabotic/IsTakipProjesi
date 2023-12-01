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
    public partial class FrmPersoneller : Form
    {
        public FrmPersoneller()
        {
            InitializeComponent();
        }
        DbİsTakipEntities db = new DbİsTakipEntities();
        void personeller()
        {
            var degerler = from x in db.TblPersonel
                           select new
                           {
                               x.ID,
                               x.Ad,
                               x.Soyad,
                               x.Mail,
                               x.Telefon,
                               Departman=x.TblDepartmanlar.Ad,
                               x.Durum

                           };
            gridControl1.DataSource = degerler.Where(x=>x.Durum==true).ToList();
        }
        private void FrmPersoneller_Load(object sender, EventArgs e)
        {
            personeller();
            var departmanlar = (from x in db.TblDepartmanlar
                                select new
                                {
                                    x.ID,
                                    x.Ad
                                }).ToList();
            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DisplayMember = "Ad";
            lookUpEdit1.Properties.DataSource = departmanlar;
            gridView1.Columns["Durum"].Visible = false;

            gridView1.OptionsView.ColumnAutoWidth = true;
            gridView1.BestFitColumns();

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            personeller();
        }
       
        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {



                TblPersonel t = new TblPersonel();
                t.Ad = txtAd.Text;
                t.Soyad = txtSoyad.Text;
                t.Mail = txtMail.Text;
                t.Gorsel = txtGörsel.Text;
                t.Durum = true;
                t.Departman = int.Parse(lookUpEdit1.EditValue.ToString());
                db.TblPersonel.Add(t);
                
                
                db.SaveChanges();
                XtraMessageBox.Show("Personel başarı ile eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                personeller();
             
            }
            catch (Exception ex)
            {

                MessageBox.Show("hata"+ex);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {



                var x = int.Parse(txtID.Text);
                var deger = db.TblPersonel.Find(x);
                deger.Durum = false;
                db.SaveChanges();
                XtraMessageBox.Show("Personel başarı ile silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                personeller();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata Oluştu\n"+ex,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtAd.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
            txtSoyad.Text = gridView1.GetFocusedRowCellValue("Soyad").ToString();
            txtMail.Text = gridView1.GetFocusedRowCellValue("Mail").ToString();
            lookUpEdit1.Text = gridView1.GetFocusedRowCellValue("Departman").ToString();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            int x = int.Parse(txtID.Text);
            var deger =  db.TblPersonel.Find(x);
            deger.Ad=txtAd.Text;
            deger.Soyad=txtSoyad.Text;
            deger.Mail=txtMail.Text;
            deger.Gorsel=txtGörsel.Text;
            deger.Departman=int.Parse(lookUpEdit1.EditValue.ToString());
            db.SaveChanges();
            XtraMessageBox.Show("Personel başarı ile güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Question);
            personeller();
        }
    }
}
