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

namespace HeThongQuanLyNgheNhac
{
    public partial class RegisterForm : Form
    {
        private UserBUS userBUS = new UserBUS();
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Ẩn thông báo lỗi cũ
            lblErrorMessage.Visible = false;

            // Lấy dữ liệu từ các textbox
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string comfirmPassword = txtConfirmPassword.Text.Trim();
            string email = txtEmail.Text.Trim();
            string sodienthoai = txtSoDienThoai.Text.Trim();
            string hoten = txtHoTen.Text.Trim();

            // kiểm tra các trường bắt buộc
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(comfirmPassword))
            {
                lblErrorMessage.Text = "Vui lòng điền đầy đủ thông tin bắt buộc (*)!";
                lblErrorMessage.Visible = true;
                return;
            }

            // kiểm tra mật khẩu và xác nhận mật khẩu
            if (password != comfirmPassword)
            {
                lblErrorMessage.Text = "Mật khẩu và xác nhận mật khẩu không khớp!";
                lblErrorMessage.Visible = true;
                return;
            }

            // Kiểm tra số điện thoại (cơ bản, 10 số)
            if (!string.IsNullOrEmpty(sodienthoai) && (sodienthoai.Length != 10 || !sodienthoai.All(char.IsDigit)))
            {
                lblErrorMessage.Text = "Số điện thoại không hợp lệ!";
                lblErrorMessage.Visible = true;
                return;
            }
            // Kiểm tra email hợp lệ
            if(!string.IsNullOrEmpty(email) && !IsValidEmail(email))
            {
                lblErrorMessage.Text = "Email không hợp lệ!";
                lblErrorMessage.Visible = true;
                return;
            }

            // Kiểm tra điều khoản
            if(!chkAgreeTerms.Checked)
            {
                lblErrorMessage.Text = "Vui lòng đồng ý với điều khoản sử dụng!";
                lblErrorMessage.Visible = true;
                return;
            }

            // kiểm tra username đã tồn tại
            if (userBUS.KiemTraTonTai(username))
            {
                lblErrorMessage.Text = "Tên đăng nhập đã tồn tại!";
                lblErrorMessage.Visible = true;
                return;
            }

            // Kiểm tra email đã tồn tại
            if (!string.IsNullOrEmpty(email) && userBUS.KiemTraTonTaiEmail(email))
            {
                lblErrorMessage.Text = "Email đã được sử dụng!";
                lblErrorMessage.Visible = true;
                return;
            }

            // Đăng ký người dùng với vai trò mặc định là "nguoi_dung"
            bool ketqua = userBUS.DangKy(username, password, email, sodienthoai, hoten, "nguoi_dung");
            if (ketqua)
            {
                MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Đóng form đăng ký
                new LogInForm().Show(); // Mở form đăng nhập
            } else
            {
                MessageBox.Show("Đăng ký không thành công! Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);            
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
            new LogInForm().Show(); 
        }

        // Kiểm tra email hợp lệ 
        private bool IsValidEmail(string email)
        {
            if(string.IsNullOrEmpty(email))
                return true; // Cho phép rỗng vì email không bắt buộc điền
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            } catch
            {
                return false;
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

        // Bật tắt xem nhập lại mật khẩu
        private void txtConfirmedPassword_IconRightClick(object sender, EventArgs e)
        {
            txtConfirmPassword.UseSystemPasswordChar = !txtConfirmPassword.UseSystemPasswordChar;
            txtConfirmPassword.IconRight = txtConfirmPassword.UseSystemPasswordChar
                ? global::HeThongQuanLyNgheNhac.Properties.Resources.eye_closed
                : global::HeThongQuanLyNgheNhac.Properties.Resources.eye_open;
        }

    }
}
