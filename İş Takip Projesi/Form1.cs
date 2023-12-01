using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace İş_Takip_Projesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Formlar.frmDepartmanlar frm;
        private void btnDepartmanListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm == null || frm.IsDisposed) { 
            frm = new Formlar.frmDepartmanlar();
            frm.MdiParent = this;
            frm.Show();
        }
        }
        Formlar.FrmPersoneller frm2;
        private void btnPersonelListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm2 == null || frm2.IsDisposed)
            {
                frm2= new Formlar.FrmPersoneller();
                frm2.MdiParent = this;
                frm2.Show();
                
            }
            
        }
        Formlar.FrmPersonelİstatistik frm3;
        private void btnPersonelİstatistik_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm3 == null || frm3.IsDisposed)
            {
               frm3=  new Formlar.FrmPersonelİstatistik();
                frm3.MdiParent = this;
                frm3.Show();
            }
        }
        Formlar.FrmGorevListesi frm4;
        private void btnGorevListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm4 == null || frm4.IsDisposed)
            {

               frm4=  new Formlar.FrmGorevListesi();
                frm4.MdiParent = this;
                frm4.Show();
            }
        }
        Formlar.FrmGorev frm5;
        private void btnGorevTanimla_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm5 == null || frm5.IsDisposed)
            {
               frm5= new Formlar.FrmGorev();

                frm5.Show();
            }
        }
        Formlar.FrmGorevDetay frm6;
        private void btnGorevDetay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm6 == null || frm6.IsDisposed) {
                frm6=  new Formlar.FrmGorevDetay();

                frm6.Show();
            }
        }
        Formlar.FrmAnaForm frm7;
        private void btnAnaSayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if ( frm7 == null || frm7.IsDisposed)
            {
                frm7= new Formlar.FrmAnaForm();
                frm7.MdiParent= this;
                frm7.Show();
            }
        }
    }
}
