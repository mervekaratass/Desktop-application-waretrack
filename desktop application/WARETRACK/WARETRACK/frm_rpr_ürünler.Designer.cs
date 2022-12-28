
namespace WARETRACK
{
    partial class frm_rpr_ürünler
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_rpr_ürünler));
            this.dtg_rpr_ürünler = new System.Windows.Forms.DataGridView();
            this.pRODUCTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wARETRACKDataSet4 = new WARETRACK.WARETRACKDataSet4();
            this.pRODUCTTableAdapter = new WARETRACK.WARETRACKDataSet4TableAdapters.PRODUCTTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_rpr_ürünler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRODUCTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wARETRACKDataSet4)).BeginInit();
            this.SuspendLayout();
            // 
            // dtg_rpr_ürünler
            // 
            this.dtg_rpr_ürünler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtg_rpr_ürünler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_rpr_ürünler.Location = new System.Drawing.Point(1, -2);
            this.dtg_rpr_ürünler.Margin = new System.Windows.Forms.Padding(2);
            this.dtg_rpr_ürünler.Name = "dtg_rpr_ürünler";
            this.dtg_rpr_ürünler.RowHeadersWidth = 51;
            this.dtg_rpr_ürünler.RowTemplate.Height = 24;
            this.dtg_rpr_ürünler.Size = new System.Drawing.Size(610, 611);
            this.dtg_rpr_ürünler.TabIndex = 0;
            // 
            // pRODUCTBindingSource
            // 
            this.pRODUCTBindingSource.DataMember = "PRODUCT";
            this.pRODUCTBindingSource.DataSource = this.wARETRACKDataSet4;
            // 
            // wARETRACKDataSet4
            // 
            this.wARETRACKDataSet4.DataSetName = "WARETRACKDataSet4";
            this.wARETRACKDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pRODUCTTableAdapter
            // 
            this.pRODUCTTableAdapter.ClearBeforeFill = true;
            // 
            // frm_rpr_ürünler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(610, 611);
            this.Controls.Add(this.dtg_rpr_ürünler);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frm_rpr_ürünler";
            this.Text = "frm_rpr_ürünler";
            this.Load += new System.EventHandler(this.frm_rpr_ürünler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_rpr_ürünler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRODUCTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wARETRACKDataSet4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtg_rpr_ürünler;
        private WARETRACKDataSet4 wARETRACKDataSet4;
        private System.Windows.Forms.BindingSource pRODUCTBindingSource;
        private WARETRACKDataSet4TableAdapters.PRODUCTTableAdapter pRODUCTTableAdapter;
    }
}