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
    public partial class frm_urun_fisleri : Form
    {
        public frm_urun_fisleri()
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

        private void btn_sil_Click(object sender, EventArgs e)
        {
            
            if (txt_irsaliye_no.Text == "" || txt_tarih.Text == "" || txt_belge_no.Text == "" || txt_urun_kodu.Text == "" || txt_adet.Text == "" || txt_fiyat.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Silme işleminin yapılacağı ürün fişini tablodan tıklayarak seçiniz.");
            }
            else
            {
                txt_urun_kodu.Enabled = true;
                string yol = Veri_tabanı.veritabani_class.baglanti;
                SqlConnection baglan = new SqlConnection(yol);
                baglan.Open();
                SqlCommand komut = new SqlCommand("Delete From PRFICHE Where FICHENO=@p1", baglan);
                komut.Parameters.AddWithValue("@p1", txt_irsaliye_no.Text.Trim());
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("İrsaliye silindi.");
                this.pRFICHETableAdapter2.Fill(this.wARETRACKDataSet13.PRFICHE);
                txt_urun_kodu.Text = "";
                txt_adet.Text = "";
                txt_irsaliye_no.Text = "";
                txt_tarih.Text = "";
                txt_belge_no.Text = "";
                txt_fiyat.Text = "";
                comboBox1.SelectedItem = null;
                txt_irsaliye_no.Enabled = true;
                txt_tarih.Enabled = true;
                txt_belge_no.Enabled = true;
                txt_adet.Enabled = true;
                txt_fiyat.Enabled = true;
                comboBox1.Enabled = true;
            }
        }

        private void btn_degistir_Click(object sender, EventArgs e)
        {

            if (txt_irsaliye_no.Text == "" || txt_tarih.Text == "" || txt_belge_no.Text == "" || txt_urun_kodu.Text == "" || txt_adet.Text == "" || txt_fiyat.Text == "")
            {
                MessageBox.Show("Değişikliğin yapılacağı irsaliyeyi tablodan tıklayarak seçiniz.");
            }
            else
            {
                btn_kaydet.Visible = true;
                btn_degistir.Visible = false;
                txt_urun_kodu.Enabled = false;
                

                //degistir butonu
                txt_irsaliye_no.Enabled = true;
                txt_tarih.Enabled = true;
                txt_belge_no.Enabled = true;
                txt_adet.Enabled = true;
                txt_fiyat.Enabled = true;
                comboBox1.Enabled = true;
                
            }
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {

            if (txt_irsaliye_no.Text == "" || txt_tarih.Text == "" || txt_belge_no.Text == "" || txt_urun_kodu.Text == "" || txt_adet.Text == "" || txt_fiyat.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Silme işleminin yapılacağı ürün fişini tablodan tıklayarak seçiniz.");
            }
            else
            {
                btn_kaydet.Visible = false;
                btn_degistir.Visible = true;
                txt_urun_kodu.Enabled = true;

                string yol = Veri_tabanı.veritabani_class.baglanti;
                SqlConnection baglan = new SqlConnection(yol);
                baglan.Open();
                SqlCommand komut = new SqlCommand("Update PRFICHE Set DATE_=@p2, DOCNO=@p3, COUNT_=@p4, PRICE=@p5, FICHETYPE=@p6, PRCODE=@p7 where FICHENO=@p1", baglan);
                komut.Parameters.AddWithValue("@p1",txt_irsaliye_no.Text.Trim());
                komut.Parameters.AddWithValue("@p2",Convert.ToDateTime(txt_tarih.Text.Trim()));
                komut.Parameters.AddWithValue("@p3",txt_belge_no.Text.Trim());
                int adet = Convert.ToInt32(txt_adet.Text.Trim());
                komut.Parameters.AddWithValue("@p4", adet);
                komut.Parameters.AddWithValue("@p5", txt_fiyat.Text.Trim());
                int fisturu;
                if(comboBox1.Text == "Üretimden Giriş Fişi (1)")
                {
                    fisturu = Convert.ToInt16(labelbir.Text.Trim());
                    komut.Parameters.AddWithValue("@p6",fisturu);
                }
                else if(comboBox1.Text == "Sayımdan Fazlası Fişi (2)")
                {
                    fisturu = Convert.ToInt16(labeliki.Text.Trim());
                    komut.Parameters.AddWithValue("@p6", fisturu);
                }
                else if(comboBox1.Text == "Sayım Eksiği Fişi (3)")
                {
                    fisturu = Convert.ToInt16(labeluc.Text.Trim());
                    komut.Parameters.AddWithValue("@p6", fisturu);
                }
                else if(comboBox1.Text == "Fire Fişi (4)")
                {
                    fisturu = Convert.ToInt16(labeldort.Text.Trim());
                    komut.Parameters.AddWithValue("@p6", fisturu);
                }
                komut.Parameters.AddWithValue("@p7",txt_urun_kodu.Text.Trim());
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Degişiklikler kaydedildi");
                this.pRFICHETableAdapter2.Fill(this.wARETRACKDataSet13.PRFICHE);
                txt_urun_kodu.Text = "";
                txt_adet.Text = "";
                txt_irsaliye_no.Text = "";
                txt_tarih.Text = "";
                txt_belge_no.Text = "";
                txt_fiyat.Text = "";
                comboBox1.SelectedItem = null;
            }
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            txt_urun_kodu.Enabled = true;
            //benim yazdıgım yerler

            if( txt_irsaliye_no.Text == "" || txt_tarih.Text =="" || txt_belge_no.Text == "" || txt_urun_kodu.Text == "" || txt_adet.Text =="" || txt_fiyat.Text == "" || comboBox1.Text =="")
            {
                MessageBox.Show("Lütfen değerleri boş bırakmayınız.");
            }
            else
            {
                string yol = Veri_tabanı.veritabani_class.baglanti;
                SqlConnection baglan = new SqlConnection(yol);
                baglan.Open();
                SqlCommand komut1 = new SqlCommand("select * from PRODUCT where CODE=@p1", baglan);
                komut1.Parameters.AddWithValue("@p1", txt_urun_kodu.Text.Trim());
                SqlDataReader dr = komut1.ExecuteReader();
                if(dr.Read())
                {
                    dr.Close();
                    SqlCommand komut2 = new SqlCommand("select * from PRFICHE where FICHENO=@p1", baglan);
                    komut2.Parameters.AddWithValue("@p1", txt_irsaliye_no.Text.Trim());
                    SqlDataReader dr1 = komut2.ExecuteReader();
                    if (dr1.Read())
                    {
                        MessageBox.Show("Aynı irsaliye numarasına sahip başka bir ürün fişi daha var. Lütfen farklı bir İrsaliye numarası giriniz");
                        dr1.Close();
                    }
                    else
                    {
                        dr1.Close();
                        dr.Close();
                        SqlCommand komut = new SqlCommand("insert into PRFICHE (FICHENO,DATE_,DOCNO,PRCODE,COUNT_,PRICE,FICHETYPE) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7) ", baglan);
                        komut.Parameters.AddWithValue("@p1", txt_irsaliye_no.Text.Trim());
                        komut.Parameters.AddWithValue("@p2", Convert.ToDateTime(txt_tarih.Text.Trim()));
                        komut.Parameters.AddWithValue("@p3", txt_belge_no.Text.Trim());
                        komut.Parameters.AddWithValue("@p4", txt_urun_kodu.Text.Trim());
                        //adet
                        int adet = Convert.ToInt32(txt_adet.Text.Trim());
                        komut.Parameters.AddWithValue("@p5", adet);
                        //fiyat
                        komut.Parameters.AddWithValue("@p6", txt_fiyat.Text.Trim());
                        //fiş türü
                        //komut.Parameters.AddWithValue("@p7", txt_irsaliye_no.Text.Trim());
                        if (comboBox1.Text == "Üretimden Giriş Fişi (1)")
                        {
                            int fisturu = Convert.ToInt16(labelbir.Text.Trim());
                            komut.Parameters.AddWithValue("@p7", fisturu);
                        }
                        else if (comboBox1.Text == "Sayımdan Fazlası Fişi (2)")
                        {
                            int fisturu = Convert.ToInt16(labeliki.Text.Trim());
                            komut.Parameters.AddWithValue("@p7", fisturu);
                        }
                        else if (comboBox1.Text == "Sayım Eksiği Fişi (3)")
                        {
                            int fisturu = Convert.ToInt16(labeluc.Text.Trim());
                            komut.Parameters.AddWithValue("@p7", fisturu);
                        }
                        else if (comboBox1.Text == "Fire Fişi (4)")
                        {
                            int fisturu = Convert.ToInt16(labeldort.Text.Trim());
                            komut.Parameters.AddWithValue("@p7", fisturu);
                        }
                        komut.ExecuteNonQuery();
                        baglan.Close();
                        MessageBox.Show("Malzeme fişi kaydedildi");
                        this.pRFICHETableAdapter2.Fill(this.wARETRACKDataSet13.PRFICHE);
                        txt_irsaliye_no.Text = "";
                        txt_tarih.Text = "";
                        txt_belge_no.Text = "";
                        txt_urun_kodu.Text = "";
                        txt_adet.Text = "";
                        txt_fiyat.Text = "";
                        comboBox1.SelectedItem = null;
                    }

                }
                else
                {
                    dr.Close();
                    MessageBox.Show("Lütfen sisteme kayıtlı olan bir ürünün malzeme fişini giriniz");
                    baglan.Close();
                }
            }
        }

        private void frm_urun_fisleri_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'wARETRACKDataSet13.PRFICHE' table. You can move, or remove it, as needed.
            this.pRFICHETableAdapter2.Fill(this.wARETRACKDataSet13.PRFICHE);
            

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dtg_ürün_fişleri_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_irsaliye_no.Enabled = false;
            txt_tarih.Enabled = false;
            txt_belge_no.Enabled = false;
            txt_urun_kodu.Enabled = false;
            txt_adet.Enabled = false;
            txt_fiyat.Enabled = false;
            comboBox1.Enabled = false;
            int secim = dtg_ürün_fişleri.SelectedCells[0].RowIndex;
            txt_irsaliye_no.Text = dtg_ürün_fişleri.Rows[secim].Cells[0].Value.ToString().Trim();
            txt_tarih.Text = Convert.ToDateTime(dtg_ürün_fişleri.Rows[secim].Cells[1].Value.ToString().Trim()).ToShortDateString();
            txt_belge_no.Text = dtg_ürün_fişleri.Rows[secim].Cells[2].Value.ToString().Trim();
            txt_urun_kodu.Text = dtg_ürün_fişleri.Rows[secim].Cells[3].Value.ToString().Trim();
            txt_adet.Text = dtg_ürün_fişleri.Rows[secim].Cells[4].Value.ToString().Trim();
            txt_fiyat.Text = dtg_ürün_fişleri.Rows[secim].Cells[5].Value.ToString().Trim();
            // comboBox1.SelectedValue = dtg_ürün_fişleri.Rows[secim].Cells[6].Value.ToString().Trim();
            string urun_fisi = dtg_ürün_fişleri.Rows[secim].Cells[6].Value.ToString().Trim();
            if(urun_fisi == "1")
            {
                comboBox1.SelectedIndex = 0;
            }
            else if(urun_fisi == "2")
            {
                comboBox1.SelectedIndex = 1;
            }
            else if (urun_fisi == "3")
            {
                comboBox1.SelectedIndex = 2;
            }
            else
            {
                comboBox1.SelectedIndex = 3;
            }
        }
    }
}
