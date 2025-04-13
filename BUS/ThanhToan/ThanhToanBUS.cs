using System;
using System.Data;
using DAL;

namespace BUS.ThanhToan
{
    public class ThanhToanBUS
    {
        Data data = new Data();

        // Hiển thị danh sách thanh toán
        public DataTable HienThi()
        {
            string sql = "SELECT * FROM ThanhToan";
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

        // Kiểm tra id_thanhtoan có tồn tại trong bảng ThanhToan không
        private bool KiemTraThanhToanTonTai(string id_thanhtoan)
        {
            string sql = $"SELECT COUNT(*) FROM ThanhToan WHERE id_thanhtoan = N'{id_thanhtoan}'";
            DataTable dt = data.GetTable(sql);
            return Convert.ToInt32(dt.Rows[0][0]) > 0;
        }

        // Thêm mới thanh toán (có kiểm tra khóa ngoại)
        public bool InsertThanhToan(string id_thanhtoan, string id_user, string id_goi, decimal sotien, string phuongthuc, DateTime ngaythanhtoan, string trangthai)
        {
            if (!KiemTraUserTonTai(id_user) || !KiemTraGoiTonTai(id_goi))
                return false;

            string sql_insert = $"INSERT INTO ThanhToan (id_thanhtoan, id_user, id_goi, sotien, phuongthuc, ngaythanhtoan, trangthai) " +
                                $"VALUES (N'{id_thanhtoan}', N'{id_user}', N'{id_goi}', {sotien}, N'{phuongthuc}', '{ngaythanhtoan:yyyy-MM-dd}', N'{trangthai}')";
            data.excuteNonquery(sql_insert);
            return true;
        }

        // Tìm kiếm thanh toán theo id_user hoặc id_thanhtoan
        public DataTable SearchThanhToan(string keyword)
        {
            string sql_search = $"SELECT * FROM ThanhToan WHERE id_user LIKE N'%{keyword}%' OR id_thanhtoan LIKE N'%{keyword}%'";
            return data.GetTable(sql_search);
        }

        // Xóa thanh toán (dựa vào id_thanhtoan)
        public void DeleteThanhToan(string id_thanhtoan)
        {
            string sql = $"DELETE FROM ThanhToan WHERE id_thanhtoan = N'{id_thanhtoan}'";
            data.excuteNonquery(sql);
        }

        // Sửa thông tin thanh toán
        public void UpdateThanhToan(string id_thanhtoan, string id_user, string id_goi, decimal sotien, string phuongthuc, DateTime ngaythanhtoan, string trangthai)
        {
            string sql = $"UPDATE ThanhToan " +
                         $"SET id_user = N'{id_user}', id_goi = N'{id_goi}', sotien = {sotien}, phuongthuc = N'{phuongthuc}', " +
                         $"ngaythanhtoan = '{ngaythanhtoan:yyyy-MM-dd}', trangthai = N'{trangthai}' " +
                         $"WHERE id_thanhtoan = N'{id_thanhtoan}'";
            data.excuteNonquery(sql);
        }
    }
}