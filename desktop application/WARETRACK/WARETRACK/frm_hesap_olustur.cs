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
    public partial class frm_hesap_olustur : Form
    {
        public frm_hesap_olustur()
        {
            InitializeComponent();
        }
        bool move;
        int mouse_x, mouse_y;
        private void frm_hesap_olustur_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void frm_hesap_olustur_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_kullanici_girisi frm = new frm_kullanici_girisi();
            frm.Show();
            this.Close();
        }

        private void bunifuMaterialTextbox1_Enter(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text == "Kullanıcı Adı")
            {
                bunifuMaterialTextbox1.Text = "";
            }
        }

        private void bunifuMaterialTextbox1_Leave(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text == "")
            {
                bunifuMaterialTextbox1.Text = "Kullanıcı Adı";
            }
        }

        private void bunifuMaterialTextbox3_Enter(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox3.Text == "E Posta")
            {
                bunifuMaterialTextbox3.Text = "";
            }
        }

        private void bunifuMaterialTextbox3_Leave(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox3.Text == "")
            {
                bunifuMaterialTextbox3.Text = "E Posta";
            }
        }

        private void bunifuMaterialTextbox2_Enter(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox2.Text == "Şifre")
            {
                bunifuMaterialTextbox2.Text = "";
            }
        }

        private void bunifuMaterialTextbox2_Leave(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox2.Text == "")
            {
                bunifuMaterialTextbox2.Text = "Şifre";
            }
        }

        private void bunifuMaterialTextbox4_Enter(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox4.Text == "Şifre Tekrar")
            {
                bunifuMaterialTextbox4.Text = "";
            }
        }

        private void bunifuMaterialTextbox4_Leave(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox4.Text == "")
            {
                bunifuMaterialTextbox4.Text = "Şifre Tekrar";
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frm_hesap_olustur_Load(object sender, EventArgs e)
        {
            
            
        }

        
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            string yol = Veri_tabanı.veritabani_class.baglanti;
            SqlConnection baglan = new SqlConnection(yol);

            if (bunifuMaterialTextbox1.Text == "Kullanıcı Adı" || bunifuMaterialTextbox3.Text == "E Posta" || bunifuMaterialTextbox2.Text == "Şifre" || bunifuMaterialTextbox4.Text == "Şifre Tekrar")
            {
                MessageBox.Show("Değerler boş girilemez. Yeniden deneyiniz.");
            }
            else if(bunifuMaterialTextbox2.Text != bunifuMaterialTextbox4.Text)
            {
                MessageBox.Show("Girilen şifre değerleri birbiri ile aynı değil. Yeniden deneyiniz");
            }
            else
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("insert into USERS (USERNAME,PASS,EMAIL) values (@p2,@p3,@p4)",baglan);
                komut.Parameters.AddWithValue("@p2", bunifuMaterialTextbox1.Text.Trim());
                komut.Parameters.AddWithValue("@p3", bunifuMaterialTextbox2.Text.Trim());
                komut.Parameters.AddWithValue("@p4", bunifuMaterialTextbox3.Text.Trim());
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Kaydınız gerçekleşti");
                frm_kullanici_girisi frm = new frm_kullanici_girisi();
                frm.Show();
                this.Close();
            }
        }

        private void frm_hesap_olustur_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }
    }
}
