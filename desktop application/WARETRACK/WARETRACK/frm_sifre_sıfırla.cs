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
using System.Net;
using System.Net.Mail;

namespace WARETRACK
{
    public partial class frm_sifre_sifirla : Form
    {
        public frm_sifre_sifirla()
        {
            InitializeComponent();
        }
        bool move;
        int mouse_x, mouse_y;
        private void frm_sifre_sifirla_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void frm_sifre_sifirla_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }
        string randomCode;           //mail gonderme 1
        public static string to;     //mail gonderme 2
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            string yol = Veri_tabanı.veritabani_class.baglanti;
            SqlConnection baglan = new SqlConnection(yol);

            if (bunifuMaterialTextbox3.Text == "E Posta")
            {
                MessageBox.Show("E Posta değeri boş girilemez");
            }
            else
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("select * from USERS where EMAIL=@p1", baglan);
                komut.Parameters.AddWithValue("@p1", bunifuMaterialTextbox3.Text.Trim());
                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    baglan.Close();

                    //mail gonderme 3
                    string from, pass, messageBody;
                    Random rand = new Random();
                    randomCode = (rand.Next(999999)).ToString();
                    MailMessage message = new MailMessage();
                    to = (bunifuMaterialTextbox3.Text).ToString();
                    from = "waretrack0@gmail.com";
                    pass = "beykent0";
                    messageBody = "Şifre değiştirme kodunuz " + randomCode;
                    message.To.Add(to);
                    message.From = new MailAddress(from);
                    message.Body = messageBody;
                    message.Subject = "Şifre Resetleme Kodu";
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    smtp.EnableSsl = true;
                    smtp.Port = 587;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(from, pass);
                    try
                    {
                        smtp.Send(message);
                        //MessageBox.Show("kod gonderildi");
                    }catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    //mail gonderme bitis

                    //dogrulama kodu sayfasının açılması 
                    frm_dogrulama_kodu frm = new frm_dogrulama_kodu();
                    frm.linkLabeleposta.Text = bunifuMaterialTextbox3.Text; //girilen e postayı dogrulama kodu formuna fırlatma
                    frm.linkLabeldogkodu.Text = randomCode;
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Girdiğiniz e posta bilgisine ait bir kullanıcı kaydı yoktur. Tekrar deneyiniz");
                }
            }
            
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuMaterialTextbox3_Enter(object sender, EventArgs e)
        {
            if(bunifuMaterialTextbox3.Text=="E Posta")
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

        private void frm_sifre_sifirla_MouseMove(object sender, MouseEventArgs e)
        {
            if(move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }
    }
}
