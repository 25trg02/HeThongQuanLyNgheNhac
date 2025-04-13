using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BUS;

namespace HeThongQuanLyNgheNhac.DoanhThu
{
    public partial class QLNguoiDungDangKy : UserControl
    {
        public QLNguoiDungDangKy()
        {
            InitializeComponent();
        }

        BUS.ThanhToan.QLNguoiDungDangKyBUS DSNguoiDungDK = new BUS.ThanhToan.QLNguoiDungDangKyBUS();
        public void clearForm()
        {
            txt_id_user.Clear();
            txt_id_goi.Clear();
            txt_trangthai.Clear();

            date_start.Value = DateTime.Now;
            date_end.Value = DateTime.Now;
        }

        public void showDSNguoiDungDK()
        {
            DataTable dt = new DataTable();
            dt = DSNguoiDungDK.HienThi();
            DGV_DKNguoiDung.DataSource = dt;

        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (txt_id_user.Text == null)
            {
                MessageBox.Show("Chưa nhập tên người dùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DSNguoiDungDK.InsertDangKyNguoiDung(txt_id_user.Text, txt_id_goi.Text, date_start.Value, date_end.Value, txt_trangthai.Text);
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showDSNguoiDungDK();
            }
        }

        private void DGV_DKNguoiDung_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void QLNguoiDungDangKy_Load(object sender, EventArgs e)
        {
            showDSNguoiDungDK();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            clearForm();
            txt_search.Clear();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (txt_id_user.Text == null)
            {
                MessageBox.Show("Cần nhập id_user để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_id_user.Focus();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Có chắc chắn muốn sửa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    DSNguoiDungDK.UpdateDangKyNguoiDung(txt_id_user.Text, txt_id_goi.Text, date_start.Value, date_end.Value, txt_trangthai.Text);
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                showDSNguoiDungDK();
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (txt_id_user.Text == null)
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập tên id_user để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắc muốn xóa id_user này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    DSNguoiDungDK.DeleteDangKyNguoiDung(txt_id_user.Text, txt_id_goi.Text);
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showDSNguoiDungDK();
                    clearForm();
                    txt_search.Clear();

                }

            }
        }

        private void DGV_DKNguoiDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txt_id_user.Text = DGV_DKNguoiDung.Rows[e.RowIndex].Cells["id_user"].Value.ToString();
                txt_id_goi.Text = DGV_DKNguoiDung.Rows[e.RowIndex].Cells["id_goi"].Value.ToString();
                txt_trangthai.Text = DGV_DKNguoiDung.Rows[e.RowIndex].Cells["trangthai"].Value.ToString();
              

                date_start.Value = Convert.ToDateTime(DGV_DKNguoiDung.Rows[e.RowIndex].Cells["ngaybatdau"].Value);
                date_end.Value = Convert.ToDateTime(DGV_DKNguoiDung.Rows[e.RowIndex].Cells["ngayhethan"].Value);

            }
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (txt_search.Text == "")
            {
                MessageBox.Show("Chưa nhập id_user", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                showDSNguoiDungDK();
            }
            else
            {
                string tukhoa = txt_search.Text.Trim();
                DGV_DKNguoiDung.DataSource = DSNguoiDungDK.SearchDangKyNguoiDung(tukhoa);
            }
        }
    }
}
