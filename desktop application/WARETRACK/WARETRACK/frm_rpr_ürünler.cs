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
    public partial class frm_rpr_ürünler : Form
    {
        public frm_rpr_ürünler()
        {
            InitializeComponent();
        }

        private void frm_rpr_ürünler_Load(object sender, EventArgs e)
        {
            
            string yol = Veri_tabanı.veritabani_class.baglanti;
            SqlConnection baglan = new SqlConnection(yol);
            baglan.Open();
            SqlCommand komut1 = new SqlCommand("select * from V_PRODUCT VP ORDER BY VP.[Ürün Adı] ASC", baglan);
            SqlDataAdapter da = new SqlDataAdapter(komut1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dtg_rpr_ürünler.DataSource = ds.Tables[0];
            baglan.Close();

        }
    }
}
