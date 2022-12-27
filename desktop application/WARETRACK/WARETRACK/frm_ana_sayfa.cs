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
    public partial class frm_ana_sayfa : Form
    {
        public frm_ana_sayfa()
        {
            InitializeComponent();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.Orange;
            button1.ForeColor = Color.White;
            
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
            button1.ForeColor = System.Drawing.Color.FromArgb(236, 130, 18);
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {

            button2.BackColor = Color.Orange;
            button2.ForeColor = Color.White;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.White;
            button2.ForeColor = System.Drawing.Color.FromArgb(236, 130, 18);
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.BackColor = Color.Orange;
            button3.ForeColor = Color.White;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.White;
            button3.ForeColor = System.Drawing.Color.FromArgb(236, 130, 18);
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.BackColor = Color.Orange;
            button4.ForeColor = Color.White;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.White;
            button4.ForeColor = System.Drawing.Color.FromArgb(236, 130, 18);
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            button5.BackColor = Color.Orange;
            button5.ForeColor = Color.White;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.White;
            button5.ForeColor = System.Drawing.Color.FromArgb(236, 130, 18);
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {    
            frm_cikis_sorgusu frm = new frm_cikis_sorgusu();
            frm.Show();
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

        private void button1_Click(object sender, EventArgs e)
        {
            frm_ürünler frm = new frm_ürünler();
            frm.Show();
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm_satın_alma_irsaliyeleri frm = new frm_satın_alma_irsaliyeleri();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_satış_irsaliyeleri frm = new frm_satış_irsaliyeleri();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frm_raporlar frm = new frm_raporlar();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frm_urun_fisleri frm = new frm_urun_fisleri();
            frm.Show();

        }
    }
}
