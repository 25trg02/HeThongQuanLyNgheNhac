using System;
using System.Data;
using DAL;

namespace BUS.ThanhToan
{
    public class QLNguoiDungDangKyBUS
    {
        Data data = new Data();

        // Hiển thị danh sách người dùng đã đăng ký gói
        public DataTable HienThi()
        {
            string sql = "SELECT * FROM DangKyNguoiDung";
            return data.GetTable(sql);
        }

        // Kiểm tra id_user có tồn tại trong bảng User không
        private bool KiemTraUserTonTai(string id_user)
        {
            string sql = $"SELECT COUNT(*) FROM [User] WHERE id_user = N'{id_user}'";
            DataTable dt = data.GetTable(sql);
            return Convert.ToInt32(dt.Rows[0][0]) > 0;
        }

        // Kiểm tra id_goi có tồn tại trong bảng GoiDangKy không
        private bool KiemTraGoiTonTai(string id_goi)
        {
            string sql = $"SELECT COUNT(*) FROM GoiDangKy WHERE id_goi = N'{id_goi}'";
            DataTable dt = data.GetTable(sql);
            return Convert.ToInt32(dt.Rows[0][0]) > 0;
        }

        // Thêm mới đăng ký người dùng (có kiểm tra khóa ngoại)
        public bool InsertDangKyNguoiDung(string id_user, string id_goi, DateTime ngaybatdau, DateTime ngayhethan, string trangthai)
        {
            if (!KiemTraUserTonTai(id_user) || !KiemTraGoiTonTai(id_goi))
                return false;

            string sql_insert = $"INSERT INTO DangKyNguoiDung (id_user, id_goi, ngaybatdau, ngayhethan, trangthai) " +
                                $"VALUES (N'{id_user}', N'{id_goi}', '{ngaybatdau:yyyy-MM-dd}', '{ngayhethan:yyyy-MM-dd}', N'{trangthai}')";
            data.excuteNonquery(sql_insert);
            return true;
        }

        // Tìm kiếm đăng ký theo id_user
        public DataTable SearchDangKyNguoiDung(string keyword)
        {
            string sql_search = $"SELECT * FROM DangKyNguoiDung WHERE id_user LIKE '" + keyword + "' ";
            return data.GetTable(sql_search);
        }

        // Xóa đăng ký (dựa vào cả id_user và id_goi)
        public void DeleteDangKyNguoiDung(string id_user, string id_goi)
        {
            string sql = $"DELETE FROM DangKyNguoiDung WHERE id_user = N'{id_user}' AND id_goi = N'{id_goi}'";
            data.excuteNonquery(sql);
        }

        // Sửa thông tin đăng ký
        public void UpdateDangKyNguoiDung(string id_user, string id_goi, DateTime ngaybatdau, DateTime ngayhethan, string trangthai)
        {
            string sql = $"UPDATE DangKyNguoiDung " +
                         $"SET ngaybatdau = '{ngaybatdau:yyyy-MM-dd}', ngayhethan = '{ngayhethan:yyyy-MM-dd}', trangthai = N'{trangthai}' " +
                         $"WHERE id_user = N'{id_user}' AND id_goi = N'{id_goi}'";
            data.excuteNonquery(sql);
        }
    }
}