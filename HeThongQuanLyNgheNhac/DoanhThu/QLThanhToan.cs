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

namespace HeThongQuanLyNgheNhac.DoanhThu
{
    public partial class QLThanhToan : UserControl
    {
        public QLThanhToan()
        {
            InitializeComponent();
        }

        public void clearForm()
        {
            txt_id_goi.Clear();
            txt_id_thanhtoan.Clear();
            txt_id_user.Clear();
            txt_phuongthuc.Clear();
            txt_sotien.Clear();
            txt_trangthai.Clear();
           
            date_start.Value = DateTime.Now;
            date_end.Value = DateTime.Now;
        }

        BUS.ThanhToan.ThanhToanBUS DSThanhToan = new BUS.ThanhToan.ThanhToanBUS();
        public void showDSThanhToan()
        {
            DataTable dt = new DataTable();
            dt = DSThanhToan.HienThi();
            DGV_ThanhToan = dt;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void QLThanhToan_Load(object sender, EventArgs e)
        {
            showDSThanhToan();
            clearForm();
        }
    }
}
