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
    public partial class MatHang : Form
    {
        private SqlConnection objConnect;
        public MatHang()
        {
            InitializeComponent();
        }

        private void matHangBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.matHangBindingSource.EndEdit();
            this.matHangTableAdapter.Update(this.DataSet1.MatHang);

        }

        private void MatHang_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.MatHang' table. You can move, or remove it, as needed.
            this.matHangTableAdapter.Fill(this.DataSet1.MatHang);
            txtMaMH.DataBindings.Clear();
            txtMaMH.DataBindings.Add("Text", matHangDataGridView.DataSource, "MaMH");
            txtTenMH.DataBindings.Clear();
            txtTenMH.DataBindings.Add("Text", matHangDataGridView.DataSource, "TenMH");
            txtMaNCC.DataBindings.Clear();
            txtMaNCC.DataBindings.Add("Text", matHangDataGridView.DataSource, "MaNCC");
            txtMaLH.DataBindings.Clear();
            txtMaLH.DataBindings.Add("Text", matHangDataGridView.DataSource, "MaLH");
            txtDVT.DataBindings.Clear();
            txtDVT.DataBindings.Add("Text", matHangDataGridView.DataSource, "DVT");
            txtDG.DataBindings.Clear();
            txtDG.DataBindings.Add("Text", matHangDataGridView.DataSource, "DonGia");
            txtSoTon.DataBindings.Clear();
            txtSoTon.DataBindings.Add("Text", matHangDataGridView.DataSource, "SoTon");

        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhanVien NV = new NhanVien();
            NV.Show();
            this.Close();
        }

        private void loạiHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoaiHang LH = new LoaiHang();
            LH.Show();
            this.Close();
        }      

        private void hướngdẫnSửDụngToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            HuongDan HuongDan = new HuongDan();
            HuongDan.Show();
        }

        private void thôngTinVềChươngTrìnhVàTácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TacGia TG = new TacGia();
            TG.Show();
        }

        private void liênHệToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            CamOn CamOn = new CamOn();
            CamOn.Show();
        }

        private void chiTiếtHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CTHD CT = new CTHD();
            CT.Show();
            this.Close();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            txtTimMH.SelectAll();
            txtTimMH.Text = "";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hóaĐơToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoaDon HD = new HoaDon();
            HD.Show();
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

        public void UpdateMH()
        {
            TaoKetNoi();
            //Tạo đối tượng command
            SqlCommand objCommand = new SqlCommand();
            objCommand.Connection = objConnect;
            objCommand.CommandType = CommandType.Text;
            objCommand.CommandText = " update mathang set tenMh= '"+txtTenMH.Text+"',MaNCC= '"+txtMaNCC.Text+"',MaLH="+txtMaLH.Text+",DVT='"+txtDVT.Text+"',Dongia="+txtDG.Text+",soton="+txtSoTon.Text+" where MaMH= "+int.Parse(txtMaMH.Text);
                
                
                
                
                //"Update mathang Set " +
                //                    "TenMH= '" + txtTenMH.Text +"',"+
                //                    "MaNCC = '" + txtMaNCC.Text + "'," +
                //                     "MaLH= " + txtMaLH.Text + "," +
                //                    "DVT= '" + txtDVT.Text + "'," +
                //                     "DonGia= "  + txtDG.Text + "," +
                //                    "SoTon= " + txtSoTon.Text + "," + 
                //                      "Where MaMH = " + int.Parse(txtMaMH.Text);
                                    
            objCommand.ExecuteNonQuery();
            //Hủy đối tượng
            objCommand.Dispose();
            objCommand = null;
            huyKetNoi();
        }
        private void bttncapnhat_Click(object sender, EventArgs e)
        {
            UpdateMH();

        }

        private void btnTimMH_Click(object sender, EventArgs e)
        {
            TaoKetNoi();
            SqlDataAdapter da = new SqlDataAdapter("TimMatHang " + txtTimMH.Text, objConnect);
            DataTable t1 = new DataTable();
            da.Fill(t1);
            this.matHangDataGridView.DataSource = t1;
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
                x = label8.Text.Substring(0, 1).ToString();
                //Ban dau thi cat 1 ki tu ban trai truoc
                y = label8.Text.Substring(1, label8.Text.Length - 1).ToString();
                //Lay ca cac ki tu con lai ben phai
                label8.Text = y + x;

            }
        }

    }
}