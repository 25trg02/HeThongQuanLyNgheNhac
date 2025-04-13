using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongQuanLyNgheNhac
{
    public partial class MainFormAdmin : Form
    {
        public MainFormAdmin()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void qLGóiĐăngKýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();

            //this.Controls.Add(menuStrip1);

            DoanhThu.QLGoiDangKy uc = new DoanhThu.QLGoiDangKy();
            uc.Dock = DockStyle.Fill;

            panelMain.Controls.Add(uc);
        }

        private void qLNgườiDùngĐăngKýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();

            //this.Controls.Add(menuStrip1);

            DoanhThu.QLNguoiDungDangKy uc = new DoanhThu.QLNguoiDungDangKy();
            uc.Dock = DockStyle.Fill;

            panelMain.Controls.Add(uc);
        }

        private void qLThanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelMain.Controls.Clear();

            //this.Controls.Add(menuStrip1);

            DoanhThu.QLThanhToan uc = new DoanhThu.QLThanhToan();
            uc.Dock = DockStyle.Fill;

            panelMain.Controls.Add(uc);
        }
    }
}
