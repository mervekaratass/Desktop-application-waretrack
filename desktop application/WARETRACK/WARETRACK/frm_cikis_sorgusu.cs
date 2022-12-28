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
    public partial class frm_cikis_sorgusu : Form
    {
        public frm_cikis_sorgusu()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {    
            Application.Restart();
            frm_kullanici_girisi frm = new frm_kullanici_girisi();
            frm.Show();
        }
    }
}
