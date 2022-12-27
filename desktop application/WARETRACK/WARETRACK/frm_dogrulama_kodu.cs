using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WARETRACK
{
    public partial class frm_dogrulama_kodu : Form
    {
        public frm_dogrulama_kodu()
        {
            InitializeComponent();
        }
        bool move;
        int mouse_x, mouse_y;
        private void frm_dogrulama_kodu_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void frm_dogrulama_kodu_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }
        
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

            if(bunifuMaterialTextbox3.Text == "Doğrulama Kodu")
            {
                MessageBox.Show("Lütfen doğrulama kodunu giriniz");
            }
            else
            {
                if(linkLabeldogkodu.Text == bunifuMaterialTextbox3.Text)
                {
                    frm_yeni_sifre frm = new frm_yeni_sifre();
                    frm.linkLabel2.Text = linkLabeleposta.Text;
                    frm.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Doğrulama kodunu yanlış girdiniz. Tekrar deneyin");
                }
            }

            
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuMaterialTextbox3_Enter(object sender, EventArgs e)
        {
            if(bunifuMaterialTextbox3.Text=="Doğrulama Kodu")
            { 
                bunifuMaterialTextbox3.Text = "";
            }
        }

        private void bunifuMaterialTextbox3_Leave(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox3.Text == "")
            {
                bunifuMaterialTextbox3.Text = "Doğrulama Kodu";
            }
        }

        private void frm_dogrulama_kodu_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }
    }
}
