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
    public partial class frm_kullanici_girisi : Form
    {
        public frm_kullanici_girisi()
        {
            InitializeComponent();
        }
        bool move;
        int mouse_x, mouse_y;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_hesap_olustur frm = new frm_hesap_olustur();
            frm.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_sifre_sifirla frm = new frm_sifre_sifirla();
            frm.Show();
            
        }

        private void bunifuMaterialTextbox1_Enter(object sender, EventArgs e)
        {
            if(txt_kullanici_adi.Text=="Kullanıcı Adı")
            {
                txt_kullanici_adi.Text = "";
            }
        }

        private void bunifuMaterialTextbox1_Leave(object sender, EventArgs e)
        {
            if (txt_kullanici_adi.Text == "")
            {
                txt_kullanici_adi.Text = "Kullanıcı Adı";
            }
        }

        private void bunifuMaterialTextbox2_Enter(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox2.Text == "Şifre")
            {
                bunifuMaterialTextbox2.Text = "";
                bunifuMaterialTextbox2.isPassword = true;
            }
        }

        private void bunifuMaterialTextbox2_Leave(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox2.Text == "")
            {
                bunifuMaterialTextbox2.Text = "Şifre";
                bunifuMaterialTextbox2.isPassword = false;
            }

        }

        private void frm_kullanici_girisi_Load(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

            string yol = Veri_tabanı.veritabani_class.baglanti;
            SqlConnection baglan = new SqlConnection(yol);

            if ( txt_kullanici_adi.Text == "Kullanıcı Adı" || bunifuMaterialTextbox2.Text == "Şifre")
            {
                MessageBox.Show("Kullanıcı adı veya şifreyi boş bırakmayınız.");
            }
            else
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("select * from USERS where USERNAME=@p1 AND PASS=@p2", baglan);
                komut.Parameters.AddWithValue("@p1", txt_kullanici_adi.Text.Trim());
                komut.Parameters.AddWithValue("@p2", bunifuMaterialTextbox2.Text.Trim());
                SqlDataReader dr = komut.ExecuteReader();
                if(dr.Read())
                {
                    baglan.Close();
                    //ana sayfaya geçme değerler doğru olduğunda çalışır.
                    frm_ana_sayfa frm = new frm_ana_sayfa();
                    frm.label2.Text = txt_kullanici_adi.Text;
                    frm.Show();
                }
                else
                {
                    MessageBox.Show("Girdiğiniz bilgilere ait bir kullanıcı kaydı yoktur. Yeniden deneyiniz");
                }
                
            }

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }
    }
}
