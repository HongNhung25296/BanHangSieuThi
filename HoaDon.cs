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
    public partial class HoaDon : Form
    {
        private SqlConnection objConnect;
        public HoaDon()
        {
            InitializeComponent();
        }

        private void hoaDonBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.hoaDonBindingSource.EndEdit();
            this.hoaDonTableAdapter.Update(this.DataSet1.HoaDon);

        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.HoaDon' table. You can move, or remove it, as needed.
            this.hoaDonTableAdapter.Fill(this.DataSet1.HoaDon);
            txtSoHD.DataBindings.Clear();
            txtSoHD.DataBindings.Add("Text", hoaDonDataGridView.DataSource, "SoHD");
            txtMaNV.DataBindings.Clear();
            txtMaNV.DataBindings.Add("Text", hoaDonDataGridView.DataSource, "MaNV");
            txtNgayHD.DataBindings.Clear();
            txtNgayHD.DataBindings.Add("Text", hoaDonDataGridView.DataSource, "NgayHD");
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            txttim.SelectAll();
            txttim.Text = "";
        }

        private void hướngDẫnSửDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HuongDan HD = new HuongDan();
            HD.ShowDialog();
            
        }

        private void thôngTinVềChươngTrìnhVàTácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TacGia TG = new TacGia();
            TG.ShowDialog();
        }

        private void liênHệToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CamOn CamOn = new CamOn();
            CamOn.ShowDialog();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhanVien NV = new NhanVien();
            NV.Show();
            this.Close();
        }

        private void mặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MatHang MH = new MatHang();
            MH.Show();
            this.Close();
        }

        private void loạiHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoaiHang LH = new LoaiHang();
            LH.Show();
            this.Close();
        }

        private void chiTiếtHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CTHD CT = new CTHD();
            CT.Show();
            this.Close();
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

        public void UpdateHD()
        {
            TaoKetNoi();
            //Tạo đối tượng command
            SqlCommand objCommand = new SqlCommand();
            objCommand.Connection = objConnect;
            objCommand.CommandType = CommandType.Text;
            objCommand.CommandText = " Update HoaDon Set MaNV= " + txtMaNV.Text + ",NgayHD='" + txtNgayHD.Text + "' Where SoHD= " + int.Parse(txtSoHD.Text);
            objCommand.ExecuteNonQuery();
            //Hủy đối tượng
            objCommand.Dispose();
            objCommand = null;
            huyKetNoi();

        }
        private void btnupdate_Click(object sender, EventArgs e)
        {
            UpdateHD();            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
             TaoKetNoi();
             SqlDataAdapter da = new SqlDataAdapter("TimHoaDon " + txttim.Text, objConnect);
             DataTable t1 = new DataTable();
             da.Fill(t1);         
             this.hoaDonDataGridView.DataSource = t1;       
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