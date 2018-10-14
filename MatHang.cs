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