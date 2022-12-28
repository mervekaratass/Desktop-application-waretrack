using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WARETRACK
{
    public partial class frm_raporlar : Form
    {
        public frm_raporlar()
        {
            InitializeComponent();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnl_raporlar.Show();
            pnl_raporlar.Controls.Clear();
            frm_rpr_ürünler frm = new frm_rpr_ürünler();
            frm.Dock = DockStyle.Fill;
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            pnl_raporlar.Controls.Add(frm);
            frm.Show();
        }

        private void btn_ürün_fişleri_Click(object sender, EventArgs e)
        {
            pnl_raporlar.Show();
            pnl_raporlar.Controls.Clear();
            frm_rpr_ürün_fişleri frm = new frm_rpr_ürün_fişleri();
            frm.Dock = DockStyle.Fill;
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            pnl_raporlar.Controls.Add(frm);
            frm.Show();
        }

       

        private void btn_satın_alma_irsaliyeleri_Click(object sender, EventArgs e)
        {
            pnl_raporlar.Show();
            pnl_raporlar.Controls.Clear();
            frm_rpr_satın_alma_irsaliyeleri frm = new frm_rpr_satın_alma_irsaliyeleri();
            frm.Dock = DockStyle.Fill;
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            pnl_raporlar.Controls.Add(frm);
            frm.Show();
        }

        private void btn_satis_irsaliyeleri_Click(object sender, EventArgs e)
        {
            pnl_raporlar.Show();
            pnl_raporlar.Controls.Clear();
            frm_rpr_satış_irsaliyeleri frm = new frm_rpr_satış_irsaliyeleri();
            frm.Dock = DockStyle.Fill;
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            pnl_raporlar.Controls.Add(frm);
            frm.Show();
        }
    }
}
