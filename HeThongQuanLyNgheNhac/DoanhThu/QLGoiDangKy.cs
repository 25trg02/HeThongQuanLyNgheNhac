using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAL;
namespace HeThongQuanLyNgheNhac.DoanhThu
{
    public partial class QLGoiDangKy : UserControl
    {
        public QLGoiDangKy()
        {
            InitializeComponent();
        }

        public void clearForm()
        {
            txt_idGoi.Clear();
            txt_tenGoi.Clear();
            txt_gia.Clear();
            txt_moTa.Clear();
            dateTimePicker_thoigian.Value = DateTime.Now;

        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void QLGoiDangKy_Load(object sender, EventArgs e)
        {

            showGoiDangKy();
        }

        BUS.ThanhToan.QLGoiDangKyBUS QLGoiDK = new BUS.ThanhToan.QLGoiDangKyBUS();

        // show Goi dang ky
        public void showGoiDangKy()
        {

            DataTable dt = new DataTable();
            dt = QLGoiDK.HienThi();
            DGVGoiDK.DataSource = dt;
        }

        // Insert
        private void them_Click(object sender, EventArgs e)
        {

            if (txt_tenGoi.Text == "")
            {
                MessageBox.Show("Chua nhap ten goi", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                QLGoiDK.insertGoiDK(txt_idGoi.Text, txt_tenGoi.Text, Convert.ToDecimal(txt_gia.Text), dateTimePicker_thoigian.Value, txt_moTa.Text);
                MessageBox.Show("Them thanh cong", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showGoiDangKy();
            }
        }

        // Clear form
        private void clear_Click(object sender, EventArgs e)
        {
            clearForm();
            txt_search.Clear();
            showGoiDangKy();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (txt_search.Text == "")
            {
                MessageBox.Show("Chua nhap ten goi can tim", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                showGoiDangKy();
            }
            else
            {
                string tuKhoa = txt_search.Text.Trim();
                DGVGoiDK.DataSource = QLGoiDK.searchGoiDK(tuKhoa);
            }
        }

        private void sua_Click(object sender, EventArgs e)
        {
            if (txt_tenGoi.Text == "")
            {
                MessageBox.Show("Can nhap ten goi de sua", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_tenGoi.Focus();
            }

            else
            {
                DialogResult dialogResult = MessageBox.Show("Co chac chan muon sua khong? ", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    string key = txt_tenGoi.Text;
                    QLGoiDK.SuaGoiDk(txt_idGoi.Text, txt_tenGoi.Text, Convert.ToDecimal(txt_gia.Text), dateTimePicker_thoigian.Value, txt_moTa.Text);
                    MessageBox.Show("Sua thanh cong", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                showGoiDangKy();

            }
        }

        private void DGVGoiDK_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void DGVGoiDK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txt_idGoi.Text = DGVGoiDK.Rows[e.RowIndex].Cells["id_goi"].Value.ToString();
                txt_tenGoi.Text = DGVGoiDK.Rows[e.RowIndex].Cells["ten"].Value.ToString();
                txt_moTa.Text = DGVGoiDK.Rows[e.RowIndex].Cells["mota"].Value.ToString();
                txt_gia.Text = DGVGoiDK.Rows[e.RowIndex].Cells["gia"].Value.ToString();
                txt_idGoi.Text = DGVGoiDK.Rows[e.RowIndex].Cells["ten"].Value.ToString();
                dateTimePicker_thoigian.Value = Convert.ToDateTime(DGVGoiDK.Rows[e.RowIndex].Cells["thoigian"].Value);


            }
        }

        private void xoa_Click(object sender, EventArgs e)
        {
            if (txt_tenGoi.Text == null)
            {
                MessageBox.Show("Vui long chon goi can xoa", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Co chac chan muon xoa goi nay khong?", "Xac nhan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                QLGoiDK.DelGoiDK(txt_tenGoi.Text);
                MessageBox.Show("Xoa thanh cong","Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showGoiDangKy();
                clearForm();
                txt_search.Clear();
            }
        }
    }
}
