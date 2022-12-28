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
    public partial class frm_yeni_sifre : Form
    {
        public frm_yeni_sifre()
        {
            InitializeComponent();
        }

        private void frm_yeni_sifre_Load(object sender, EventArgs e)
        {

        }
        bool move;
        int mouse_x, mouse_y;
        private void frm_yeni_sifre_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void frm_yeni_sifre_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            string yol = Veri_tabanı.veritabani_class.baglanti;
            SqlConnection baglan = new SqlConnection(yol);
            if (bunifuMaterialTextbox3.Text =="Yeni Şifre" || bunifuMaterialTextbox1.Text =="Şifreyi Doğrula")
            {
                MessageBox.Show("Değerleri boş bırakmayınız");
            }
            else if(bunifuMaterialTextbox3.Text != bunifuMaterialTextbox1.Text)
            {
                MessageBox.Show("Değerleri doğru giriniz");
            }
            else
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("Update USERS Set PASS=@p1 where EMAIL=@p2",baglan);
                komut.Parameters.AddWithValue("p1", bunifuMaterialTextbox1.Text);
                komut.Parameters.AddWithValue("p2",linkLabel2.Text);
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Şifreniz başarıyla değiştirildi");

                this.Close(); //tamama basınca kapanmasını sağlıyor.
            }




                
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuMaterialTextbox3_Enter(object sender, EventArgs e)
        {
            if(bunifuMaterialTextbox3.Text=="Yeni Şifre")
            {
                bunifuMaterialTextbox3.Text = "";
            }
        }

        private void bunifuMaterialTextbox3_Leave(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox3.Text == "")
            {
                bunifuMaterialTextbox3.Text = "Yeni Şifre";
            }
        }

        private void bunifuMaterialTextbox1_Enter(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text == "Şifreyi Doğrula")
            {
                bunifuMaterialTextbox1.Text = "";
            }
        }

        private void bunifuMaterialTextbox1_Leave(object sender, EventArgs e)
        {

            if (bunifuMaterialTextbox1.Text == "")
            {
                bunifuMaterialTextbox1.Text = "Şifreyi Doğrula";
            }
        }

        private void frm_yeni_sifre_MouseMove(object sender, MouseEventArgs e)
        {
            if(move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }
    }
}
