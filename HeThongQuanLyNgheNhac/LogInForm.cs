using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using DAL;
using BUS;
using System.IO;

namespace HeThongQuanLyNgheNhac
{
    public partial class LogInForm : Form
    {
        UserBUS userBUS = new UserBUS();
        // Lưu file chứa thông tin đăng nhập vào thư mục ApplicationData
        string fileThongTinDangNhap = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "remember.txt");
        public LogInForm()
        {
            InitializeComponent();
            LoadNhoThongTinDangNhap();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) {
                lblErrorMessage.Text = "Vui lòng nhập đầy đủ thông tin đăng nhập!";
                lblErrorMessage.Visible = true;
                return;
            }

            var user = userBUS.DangNhap(username, password); // Mật khẩu sẽ được mã hóa khi đăng nhập
            if (user != null)
            {
                string vaitro = user["vaitro"].ToString();
                if (chkRemember.Checked)
                {
                    nhoThongTinDangNhap(username, password);
                } else
                {
                    xoaNhoThongTindangNhap();
                }
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();

                if (vaitro == "admin")
                {
                    new Admin_Main_Form().ShowDialog();
                } else if (vaitro == "nghe_si")
                {
                    // Chuyển đến trang của nghệ sĩ
                } else
                {
                    // Chuyển đến trang người dùng
                }
                this.Show();
            } else
            {
                lblErrorMessage.Text = "Tên đăng nhập hoặc mật khẩu không đúng!";
                lblErrorMessage.ForeColor = Color.Red;
                lblErrorMessage.Visible = true;
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            new RegisterForm().ShowDialog();
            this.Show();
        }
        private void nhoThongTinDangNhap(string username, string password)
        {
            try
            {
                File.WriteAllText(fileThongTinDangNhap, $"{username}\n{password}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu thông tin đăng nhập: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LoadNhoThongTinDangNhap()
        {
            try
            {
                if (File.Exists(fileThongTinDangNhap))
                {
                    string[] lines = File.ReadAllLines(fileThongTinDangNhap);
                    if (lines.Length >= 2)
                    {
                        txtUsername.Text = lines[0];
                        txtPassword.Text = lines[1];
                        chkRemember.Checked = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin đăng nhập: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void xoaNhoThongTindangNhap()
        {
            try
            {
                if (File.Exists(fileThongTinDangNhap))
                    File.Delete(fileThongTinDangNhap);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa thông tin đăng nhập: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Thêm xử lý form đóng để đảm bảo thông tin đăng nhập được lưu khi đóng form
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (chkRemember.Checked)
            {
                nhoThongTinDangNhap(txtUsername.Text.Trim(), txtPassword.Text.Trim());
            }
            else
            {
                xoaNhoThongTindangNhap();
            }
        }

        // Bật tắt xem mật khẩu
        private void txtPassword_IconRightClick(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
            txtPassword.IconRight = txtPassword.UseSystemPasswordChar
                ? global::HeThongQuanLyNgheNhac.Properties.Resources.eye_closed
                : global::HeThongQuanLyNgheNhac.Properties.Resources.eye_open;
        }
    }
}
