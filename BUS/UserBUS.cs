using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class UserBUS
    {
        Data data = new Data();

        public DataRow DangNhap(string username, string password)
        {
            string matKhauMaHoa = maHoaMatKhau(password); // Mã hóa mật khẩu
            string sql = "SELECT * FROM Users WHERE username = @username AND password = @password";
            SqlParameter[] parameters =
            {
                new SqlParameter("@username", username),
                new SqlParameter("@password", matKhauMaHoa)
            };
            DataTable dt = data.GetTable(sql, parameters);
            if (dt.Rows.Count > 0)
                return dt.Rows[0];
            return null;
        }

        public bool KiemTraTonTai(string username)
        {
            string sql = "SELECT COUNT(*) FROM Users WHERE username = @username";
            SqlParameter[] parameters =
            {
                new SqlParameter("@username", username)
            };
            int count = (int)data.ExecuteScalar(sql, parameters);
            return count > 0;
        }

        public string LayVaiTro(string username)
        {
            string sql = "SELECT vaitro FROM Users WHERE username = @username";
            SqlParameter[] parameters =
            {
                new SqlParameter("@username", username)
            };
            object ketqua = data.ExecuteScalar(sql, parameters);
            return ketqua != null ? ketqua.ToString() : null;
        }

        public bool KiemTraTonTaiEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false; // Không kiểm tra nếu email rỗng
            string sql = "SELECT COUNT(*) FROM Users WHERE email = @email";
            SqlParameter[] parameters =
            {
                new SqlParameter("@email", email)
            };
            int count = (int)data.ExecuteScalar(sql, parameters);
            return count > 0;
        }

        public bool DangKy(string username, string password, string email, string sodienthoai, string hoten, string vaitro)
        {
            // Tạo is_user dựa trên vai trò
            string id_user = taoIdUser(vaitro);
            string matKhauMaHoa = maHoaMatKhau(password); // Mã hóa mật khẩu
            string sql = @"INSERT INTO Users (id_user, username, password, email, sodienthoai, hoten, vaitro) VALUES
                          (@id_user, @username, @password, @email, @sodienthoai, @hoten, @vaitro)";
            SqlParameter[] parameters = {
                new SqlParameter("@id_user", id_user),
                new SqlParameter("@username", username),
                new SqlParameter("@password", matKhauMaHoa),
                new SqlParameter("@email", email),
                new SqlParameter("@sodienthoai", (object)sodienthoai ?? DBNull.Value),
                new SqlParameter("@hoten", (object)hoten ?? DBNull.Value),
                new SqlParameter("@vaitro", vaitro)
            };
            try
            {
                data.ExecuteNonQuery(sql, parameters);
                return true;
            }
            catch (SqlException ex)
            {
                // Xử lý lỗi nếu cần thiết
                Console.WriteLine("Lỗi khi thực hiện câu lệnh SQL: " + ex.Message);
                return false;
            }
        }
        public string taoIdUser(string vaitro)
        {
            string tiento = layTienToVaiTro(vaitro);  /// Lấy tiền tố dựa trên vai trò
            string sql = "SELECT MAX(CAST(SUBSTRING(id_user, 3, LEN(id_user) - 2) AS INT)) " +
                 "FROM Users WHERE id_user LIKE @tiento";
            SqlParameter[] parameters =
            {
                new SqlParameter("@tiento", tiento)
            };
            object ketqua = data.ExecuteScalar(sql, parameters);
            int maKeTiep = (ketqua != DBNull.Value) ? Convert.ToInt32(ketqua) + 1 : 1;  // +1 để lấy số tiếp theo sau mã có số lớn nhất
            return $"{tiento}{maKeTiep:D2}";  // Định dạng 2 chữ số (01, 02,..., 99)
        }

        // Hàm để lấy tiền tố dựa trên vai trò
        public string layTienToVaiTro(string vaitro)
        {
            switch (vaitro.ToLower())
            {
                case "admin":
                    return "AD";
                case "nghe_si":
                    return "NS";
                case "nguoi_dung":
                    return "ND";
                default:
                    return "ND"; // Tiền tố mặc định nếu không có vai trò nào khớp
            }
        }

        // Mã hóa mật khẩu bằng SHA256
        public string maHoaMatKhau(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] maHoaByte = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < maHoaByte.Length; i++)
                {
                    builder.Append(maHoaByte[i].ToString("x2"));  // Chuyển thành hex string
                }
                return builder.ToString();
            }
        }
    }
}
