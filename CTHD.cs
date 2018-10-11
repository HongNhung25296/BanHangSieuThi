using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace QuanLy
{
    public partial class CTHD : Form
    {
        private SqlConnection objConnect;
        public CTHD()
        {
            InitializeComponent();
        }

        private void cTHDBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.cTHDBindingSource.EndEdit();
            this.cTHDTableAdapter.Update(this.DataSet1.CTHD);

        }

        private void CTHD_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.CTHD' table. You can move, or remove it, as needed.
            this.cTHDTableAdapter.Fill(this.DataSet1.CTHD);
            txtSoHD.DataBindings.Clear();
            txtSoHD.DataBindings.Add("Text", cTHDDataGridView.DataSource, "SoHD");
            txtMaMH.DataBindings.Clear();
            txtMaMH.DataBindings.Add("Text", cTHDDataGridView.DataSource, "MaMH");
            txtDGBan.DataBindings.Clear();
            txtDGBan.DataBindings.Add("Text", cTHDDataGridView.DataSource, "DGBan");
            txtSL.DataBindings.Clear();
            txtSL.DataBindings.Add("Text", cTHDDataGridView.DataSource, "SL");

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            txtTim.SelectAll();
            txtTim.Text = "";
        }

        private void hướngdẫnSửDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void liênHệToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void mặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void hóaĐơnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void TaoKetNoi()
        {
            string chuoiKetNoi = "Data Source=DESKTOP-5VIA6DA;Initial Catalog=SieuThi;Integrated Security=True";
            objConnect = new SqlConnection(chuoiKetNoi);
            objConnect.Open();
        }

        public void huyKetNoi()
        {
            objConnect.Close(); //Đóng kết nối
            objConnect.Dispose();//Giải phóng tài nguyên
            objConnect = null; //Hủy đối tượng
        }

        private void UpdateCT()
        {
            TaoKetNoi();
            //Tạo đối tượng command
            SqlCommand objCommand = new SqlCommand();
            objCommand.Connection = objConnect;
            objCommand.CommandType = CommandType.Text;
            objCommand.CommandText = "Update CTHD Set " +
                                    "MaMH = " + "'" + txtMaMH.Text + "'" + "," +
                                    "DGBan = " +  int.Parse(txtDGBan.Text) +  "," +
                                    "SL = " + "'" + txtSL.Text + "'" + 
                                    " Where SoHD =  " + "'" +  txtSoHD.Text + "' " ;
            
            //'10248'"
            //Convert.ToInt32
            objCommand.ExecuteNonQuery();
            //Hủy đối tượng
            objCommand.Dispose();
            objCommand = null;
            huyKetNoi();
        }

        private void btncapnhat_Click(object sender, EventArgs e)
        {
            UpdateCT();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            TaoKetNoi();
            SqlDataAdapter da = new SqlDataAdapter(" TimCTHD "+txtTim.Text,objConnect);
            DataTable t = new DataTable();
            da.Fill(t);
            this.cTHDDataGridView.DataSource = t;
            huyKetNoi();
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Text = this.Text.Substring(this.Text.Length - 1, 1) + this.Text.Substring(0, this.Text.Length - 1);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            {
                string x;
                string y;
                x = label10.Text.Substring(0, 1).ToString();
                //Ban dau thi cat 1 ki tu ban trai truoc
                y = label10.Text.Substring(1, label10.Text.Length - 1).ToString();
                //Lay ca cac ki tu con lai ben phai
                label10.Text = y + x;

            }
        }
    }
}